using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataStreaming
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StreamService" in both code and config file together.
    public class StreamService : IStreamService
    {
        public string Upload(Stream stream)
        {
            MultipartParser parser = new MultipartParser(stream);
            if (parser.Success)
            {
                // Save the file
                File.WriteAllBytes(@"C:\" + parser.Filename, parser.FileContents); // Requires System.IO
            }

            stream.Close();
            return parser.FileContents.Length.ToString();
        }
    }
}
