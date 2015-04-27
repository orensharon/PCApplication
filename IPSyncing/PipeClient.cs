using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSyncing
{
    class PipeClient
    {
        public void Send(string SendStr, string PipeName, int TimeOut = 1000)
        {

            byte[] _buffer;
            NamedPipeClientStream pipeStream;


                pipeStream = new NamedPipeClientStream
                   (".", PipeName, PipeDirection.Out, PipeOptions.Asynchronous);

                // The connect function will indefinitely wait for the pipe to become available
                // If that is not acceptable specify a maximum waiting time (in ms)
                try
                {
                    pipeStream.Connect(TimeOut);
                }
                catch (TimeoutException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw ex;
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw ex;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw ex;
                } 
                catch (IOException ex) 
                {
                    Debug.WriteLine(ex.Message);
                    throw ex;
                }

                try
                {
                    _buffer = Encoding.UTF8.GetBytes(SendStr);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw ex;
                }

                try
                {
                    pipeStream.BeginWrite(_buffer, 0, _buffer.Length,
                        new AsyncCallback(AsyncSend), pipeStream);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw ex;
                }
                

        }

        private void AsyncSend(IAsyncResult iar)
        {
            try
            {
                // Get the pipe
                NamedPipeClientStream pipeStream = (NamedPipeClientStream)iar.AsyncState;

                // End the write
                pipeStream.EndWrite(iar);
                pipeStream.Flush();
                pipeStream.Close();
                pipeStream.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
