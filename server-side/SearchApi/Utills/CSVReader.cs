namespace SearchApi.Utills
{
    public class CSVReader
    {
        public static Dictionary<int, string> Read(string filePath)
        {
            var values = new Dictionary<int, string>();

            StreamReader reader = new StreamReader(filePath);
            var x = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                values.Add(x++, line);
            }
            return values;
        }
    }
}
