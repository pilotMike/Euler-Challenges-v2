using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Files
{
    public class FileHelper
    {
        /// <summary>
        /// Reads a text file from the current project with a given file name,
        /// removes the quotes and separates by commas, then returns an array of
        /// the strings. Assumes that the Euler file is only on one line.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEnumerable<string> ParseFile(string filename)
        {
            try
            {
                using (var reader = new StreamReader(filename))
                {
                    var names = reader.ReadLine().Replace("\"", "").ToUpper().Split(',');
                    return names;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("couldn't load file " + filename, ex);
            }
        }
    }
}
