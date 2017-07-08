using System.IO;
using System.Text;

namespace Task_1
{
    public class SearcherOfSequence
    {
        public string InputData { get; private set; }

        public string OutputData { get; private set; }

        public int MaxLength { get; private set; }

        public int StartPosition { get; private set; }

        public void ReadFromFile(string filePath)
        {
            var bytes = File.ReadAllBytes(filePath);

            InputData = Encoding.UTF8.GetString(bytes);
        }

        public void WriteToFile(string filePath)
        {
            var bytes = Encoding.UTF8.GetBytes(MaxLength.ToString());

            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        public void FindMaxSequenceOfOnes()
        {
            var currlength = 0;

            for (var i = 0; i < InputData.Length; i++)
            {
                if (InputData[i] == '1')
                {
                    currlength++;

                    if (currlength > MaxLength)
                    {
                        MaxLength = currlength;
                        StartPosition = i + 1 - currlength;
                    }
                }
                else
                {
                    currlength = 0;
                }
            }

            OutputData = InputData.Substring(StartPosition, MaxLength);
        }
    }
}