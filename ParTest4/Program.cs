using ParTest4.TaminServices;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ParTest4
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
                Console.WriteLine("Service Error Message : " + result.ErrorMessage);
                // Close the client
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

    }
}