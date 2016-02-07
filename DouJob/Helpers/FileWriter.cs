using System.IO;

namespace DouJob
{
    public class FileWriter
    {
        public static void WriteStringToFile(string stats, string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(stats);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path, true);
                tw.WriteLine(stats);
                tw.Close();
            }
        }
    }
}
