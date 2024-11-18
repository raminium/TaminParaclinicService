using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using TaminServices;

namespace ParTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Create BasicHttpBinding with HTTPS
                var binding = new BasicHttpBinding
                {
                    Security = new BasicHttpSecurity
                    {
                        Mode = BasicHttpSecurityMode.Transport // Use HTTPS
                    }
                };

                // Set the endpoint address
                var endpoint = new EndpointAddress("https://darmanws.tamin.ir/ParaclinicWebService.asmx");

                // Initialize the client with the binding and endpoint
                var client = new ParaclinicWebServiceSoapClient(binding, endpoint);

                // Create request objects
                ParaUserInfo usrInfo = new ParaUserInfo();
                Diagnose diag = new Diagnose();

                // Call the service method
                var result = await client.Save_Diagnose_parAsync(usrInfo, 123, diag);
                Console.WriteLine(result);

                // Close the client
                await client.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
    }
}
