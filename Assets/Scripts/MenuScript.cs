using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	RectTransform trans;
	void Start () {
		trans = gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Q)) { trans.anchoredPosition = new Vector2(trans.anchoredPosition.x, trans.anchoredPosition.y + 1); }
		if (Input.GetKey(KeyCode.E)) { trans.anchoredPosition = new Vector2(trans.anchoredPosition.x, trans.anchoredPosition.y - 1); }
	}
}
