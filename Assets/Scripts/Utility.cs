public static class Utility
{
	public static string FileToName(string path)
	{
		int slashIndex = path.LastIndexOf('/');
		int dotIndex = path.LastIndexOf('.');
		if (dotIndex == -1 || slashIndex == -1 || slashIndex > dotIndex) { return path; }

		return path.Substring(slashIndex + 1, dotIndex - (slashIndex + 1));
	}
}
