using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;

namespace MCLauncher.WebServer
{
    class Server
    {
        static HttpListener listener = new HttpListener();

        public static void Start()
        {
            if (!HttpListener.IsSupported)
            {
                return;
            }

            listener.Prefixes.Add("http://localhost:8000/");
            listener.Prefixes.Add("http://127.0.0.1:8000/");

            listener.Start();
            
            listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            listener.IgnoreWriteExceptions = true;

            while (true)
            {
                IAsyncResult result = listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
                // Applications can do some work here while waiting for the 
                // request. If no work can be done until you have processed a request,
                // use a wait handle to prevent this thread from terminating
                // while the asynchronous operation completes.
                //Console.WriteLine("Waiting for request to be processed asyncronously.");
                result.AsyncWaitHandle.WaitOne();
                //Console.WriteLine("Request processed asyncronously.");
            }
        }

        public static void Stop()
        {
            listener.Stop();
        }

        public static void ListenerCallback(IAsyncResult result)
        {
            HttpListener listener = (HttpListener)result.AsyncState;
            // Call EndGetContext to complete the asynchronous operation.
            HttpListenerContext context = listener.EndGetContext(result);
            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }

    }
}
