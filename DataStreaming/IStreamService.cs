using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataStreaming
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStreamService" in both code and config file together.
    [ServiceContract]
    public interface IStreamService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                   UriTemplate = "/UploadFile?fileName={fileName}")]
        void FileUpload(RemoteFileInfo request);
    }

    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
