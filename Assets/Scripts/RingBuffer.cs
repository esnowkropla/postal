using UnityEngine;

public class RingBuffer<T>
{
	T[] block;
	int start = 0;
	int end = 0; /* One past the last element (so the element to insert at)*/

	public int Count = 0;

	public RingBuffer() { block = new T[10]; }
	public RingBuffer(uint size) { block = new T[size]; }

	public T this[int i]
	{
		get
		{
			if (i >= Count) { throw new System.IndexOutOfRangeException(i + " is not within bounds for buffer with size " + Count); }
			return block[(start + i) % block.Length];
		}
		set
		{
			if (i >= Count) { throw new System.IndexOutOfRangeException(i + " is not within bounds for buffer with size " + Count); }
			block[(start + i) % block.Length] = value;
		}
	}

	public T PopFront()
	{
		if (Count == 0) { throw new System.IndexOutOfRangeException("Attempted to pop empty buffer"); }
		T val = block[start];
		start += 1;
		start = start % block.Length;
		CalcCount();
		return val;
	}

	public void Add(T elem)
	{
		if (Full()) { Grow(); }

		if (end < block.Length)
		{
			block[end++] = elem;
			end = end % block.Length;
			CalcCount();
		}
	}

	public T Pop()
	{
		if (Empty()) { return default(T); }

		int i = end - 1;

		i += block.Length;
		i = i % block.Length;
		
		T val = block[i];
		end -= 1;

		end += block.Length;
		end = end % block.Length;
		CalcCount();
		return val;
	}

	bool Full() { return start == (end + 1) % block.Length; }

	bool Empty() { return start == end; }

	void CalcCount()
	{
		if (Full()) { Count = block.Length - 1; }
		else if (Empty()) { Count = 0; }
		else if (start < end) { Count = end - start; }
		else if (end < start) { Count = block.Length - start + end; }
		else { throw new System.Exception("What the fuck happened here " + ToString()); }
	}

	void Grow()
	{
		int oldSize = block.Length;
		int size = 2 * oldSize;
		if (size <= oldSize) { size = oldSize + 1; }

		T[] newBlock = new T[size];

		for (int i = 0; i < block.Length; i++)
		{
			newBlock[i] = block[(start + i) % block.Length];
		}

		block = newBlock;
		start = 0;
		end = oldSize - 1;
	}

	public override string ToString()
	{
		string s = "start: " + start + " end: " + end + " count: " + Count + " block size: " + block.Length + " [";
		for (int i = 0; i < block.Length; i++)
		{
			if (i == 0) { s += block[i]; }
			else if (i == block.Length - 1) { s += ", " + block[i] + "]"; }
			else { s += ", " + block[i]; }
		}
		return s;
	}
}
