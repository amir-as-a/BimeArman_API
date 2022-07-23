namespace FRMJX.Core.Infrastructure;

public static class Utility
{
	public static string GetNextFilename(string filePath)
	{
		int i = 1;
		string dir = Path.GetDirectoryName(filePath);
		string file = Path.GetFileNameWithoutExtension(filePath) + "{0}";
		string extension = Path.GetExtension(filePath);

		while (File.Exists(filePath))
		{
			filePath = Path.Combine(dir, string.Format(file, "(" + i++ + ")") + extension);
		}

		return filePath;
	}
}
