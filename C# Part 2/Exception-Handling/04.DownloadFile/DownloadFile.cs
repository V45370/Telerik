using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile("http://idg.bg/test/pcw/2011/9/20/18264-Telerik-Academy-logo.jpg", "../../logo.jpg");
            }

            catch (WebException)
            {
                Console.Error.WriteLine("The address is invalid.");
            }

            catch (NotSupportedException)
            {
                Console.Error.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}