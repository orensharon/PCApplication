using System;
using System.Collections.Generic;
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
        public void FileUpload(RemoteFileInfo request) 
        {
            FileStream targetStream = null;
            Stream sourceStream = request.FileByteStream;

            string uploadFolder = @"C:\";

            string filePath = Path.Combine(uploadFolder, request.FileName);

            using (targetStream = new FileStream(filePath, FileMode.Create,
                                  FileAccess.Write, FileShare.None))
            {
                //read from the input stream in 65000 byte chunks

                const int bufferLen = 65000;
                byte[] buffer = new byte[bufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    // save to output stream
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }
        }
    }
}
