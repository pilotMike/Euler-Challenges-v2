using System.Collections.Generic;
using System.IO;

namespace CodeEvalChallenges.Helpers
{
    public class FileHelper
    {
        public static IEnumerable<string> OpenFile(string source)
        {
            using (StreamReader reader = File.OpenText(source))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                        yield return line;
                }
            }
        }
    }
}