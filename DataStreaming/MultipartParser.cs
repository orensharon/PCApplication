using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// MultipartParser http://multipartparser.codeplex.com
/// Reads a multipart form data stream and returns the filename, content type and contents as a stream.
/// 2009 Anthony Super http://antscode.blogspot.com
/// </summary>
namespace DataStreaming
{
    public class MultipartParser
    {
        public MultipartParser(Stream stream)
        {
            this.Parse(stream, Encoding.UTF8);
        }

        public MultipartParser(Stream stream, Encoding encoding)
        {
            this.Parse(stream, encoding);
        }

        private void Parse(Stream stream, Encoding encoding)
        {
            this.Success = false;

            // Read the stream into a byte array
            byte[] data = ToByteArray(stream);
            byte[] fileData = null;

            // Copy to a string for header parsing
            string content = encoding.GetString(data);
            byte[] StringBytes = Encoding.UTF8.GetBytes("\r\n");
            string extractedData = null, prefix = null;

            // Running throw the binary file
            for (int i = 0; i <= (data.Length - StringBytes.Length); i++)
            {
                if (data[i] == StringBytes[0])
                {
                    int j;
                    for (j = 1; j < StringBytes.Length && data[i + j] == StringBytes[j]; j++) ;
                    
                    // Found a delimeter \r\n
                    if (j == StringBytes.Length)
                    {

                        Debug.WriteLine("String was found at offset {0}", i);

                        // This is the first line - the suffix
                        // Some string with ------- and some letters
                        if (prefix == null)
                        {

                            // Save the prefix as string to get the EndIndex
                            int prefixEndIndex = i;
                            fileData = new byte[prefixEndIndex];
                            Buffer.BlockCopy(data, 0, fileData, 0, prefixEndIndex);
                            prefix = encoding.GetString(fileData);
                            continue;
                        }

                        // Found another \r\n
                        int delimiterEndIndex = i;
                            
                        // If we already got the file name, give space for the last \r\n to come
                        if (this.Filename != null)
                        {
                             delimiterEndIndex += 4;
                        }

                        // Retriving the data from the byte array into string to extract the properties
                        fileData = new byte[delimiterEndIndex];
                        Buffer.BlockCopy(data, 0, fileData, 0, delimiterEndIndex);
                        extractedData = encoding.GetString(fileData);
                        
                        
                        Debug.WriteLine(extractedData);

                        // Start looking for matches
                        Regex re = null;
                        Match filenameMatch = null, contentTypeMatch = null;

                        // Look for filename
                        if (this.Filename == null)
                        {
                            re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
                            filenameMatch = re.Match(extractedData);
                            if (filenameMatch.Success)
                            {
                                this.Filename = filenameMatch.Value.Trim();
                                continue;
                            }
                        }

                        // Look for Content-Type
                        re = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n\r\n)");
                        contentTypeMatch = re.Match(extractedData);
                        if (contentTypeMatch.Success)
                        {
                            this.ContentType = contentTypeMatch.Value.Trim();
                        }
                       

                        // Did we find the required values?
                        if (this.ContentType != null && this.Filename != null)
                        {

                            Debug.WriteLine(this.ContentType + "\n" + this.Filename);

                            int startIndex = contentTypeMatch.Index + contentTypeMatch.Length + "\r\n\r\n".Length;

                            byte[] delimiterBytes = encoding.GetBytes("\r\n" + prefix);
                            int endIndex = IndexOf(data, delimiterBytes, startIndex);

                            int contentLength = endIndex - startIndex;

                            // Extract the file contents from the byte array
                            byte[] readlData = new byte[contentLength];

                            Buffer.BlockCopy(data, startIndex, readlData, 0, contentLength);

                            this.FileContents = readlData;
                            this.Success = true;
                            break;
                        }
                    }
                }
            }

            /*delimiterEndIndex = content.IndexOf("\r\n");
            
            if (delimiterEndIndex > -1)
            {
                delimiter = content.Substring(0, content.IndexOf("\r\n"));

                // Look for Content-Type
                Regex re = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n\r\n)");
                Match contentTypeMatch = re.Match(content);

                // Look for filename
                re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
                Match filenameMatch = re.Match(content);

                // Did we find the required values?
                if (contentTypeMatch.Success && filenameMatch.Success)
                {
                    // Set properties
                    this.ContentType = contentTypeMatch.Value.Trim();
                    this.Filename = filenameMatch.Value.Trim();

                    // Get the start & end indexes of the file contents
                    int startIndex = contentTypeMatch.Index + contentTypeMatch.Length + "\r\n\r\n".Length;

                    byte[] delimiterBytes = encoding.GetBytes("\r\n" + delimiter);
                    int endIndex = IndexOf(data, delimiterBytes, startIndex);

                    int contentLength = endIndex - startIndex;

                    // Extract the file contents from the byte array
                    byte[] fileData = new byte[contentLength];

                    Buffer.BlockCopy(data, startIndex, fileData, 0, contentLength);

                    this.FileContents = fileData;
                    this.Success = true;
                }
            }*/
        }

        private int IndexOf(byte[] searchWithin, byte[] serachFor, int startIndex)
        {
            int index = 0;
            int startPos = Array.IndexOf(searchWithin, serachFor[0], startIndex);

            if (startPos != -1)
            {
                while ((startPos + index) < searchWithin.Length)
                {
                    if (searchWithin[startPos + index] == serachFor[index])
                    {
                        index++;
                        if (index == serachFor.Length)
                        {
                            return startPos;
                        }
                    }
                    else
                    {
                        startPos = Array.IndexOf<byte>(searchWithin, serachFor[0], startPos + index);
                        if (startPos == -1)
                        {
                            return -1;
                        }
                        index = 0;
                    }
                }
            }

            return -1;
        }

        private byte[] ToByteArray(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public bool Success
        {
            get;
            private set;
        }

        public string ContentType
        {
            get;
            private set;
        }

        public string Filename
        {
            get;
            private set;
        }

        public byte[] FileContents
        {
            get;
            private set;
        }
    }
}
