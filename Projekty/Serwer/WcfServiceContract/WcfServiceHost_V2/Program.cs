using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract;

namespace WcfServiceHost_V2
{
    /// <summary>
    /// Martyna Kumaszka
    /// Klasa hosta z którą łączy się klient
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Metoda główna programu, to tutaj włącza się serwer
        /// </summary>
        /// <param name="args">Argumenty uruchomienia - tutaj nie używane</param>
        public static void Main(string[] args)
        {
            ServiceHost mojHost = new ServiceHost(typeof(MyCalculator));
            try
            {

                ServiceEndpoint endpoint1 = mojHost.Description.Endpoints.Find(typeof(ICalculator));
             
                //wyswietl endpointy
                Console.WriteLine("\n---> Endpointy:");

                ShowEndpoint(endpoint1);
                
                mojHost.Open();
                Console.WriteLine("\n--> Serwis 1 jest uruchomiony.");

                ContractDescription cd =
                ContractDescription.GetContract(typeof(ICalculator));
                Console.WriteLine("Informacje o kontrakcie:");
                Type contractType = cd.ContractType;
                Console.WriteLine("\tContract type: {0}", contractType.ToString());
                string name = cd.Name;
                Console.WriteLine("\tName: {0}", name);
                OperationDescriptionCollection odc = cd.Operations;
                Console.WriteLine("\tOperacje:");
                foreach (OperationDescription od in odc) {
                    Console.WriteLine("\t\t" + od.Name);
                } 

                Console.WriteLine("\n--> Nacisnij <ENTER> aby zakonczyc.");
                Console.WriteLine();
                Console.ReadLine();
                Console.ReadLine();

                mojHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", ce.Message);
                mojHost.Abort();
            }
        }

        /// <summary>
        /// Sunkcja wyświetlająca szczegółu endpointu
        /// </summary>
        /// <param name="endpoint">Endpoint który chcemy wyświetlić</param>
        public static void ShowEndpoint(ServiceEndpoint endpoint)
        {
            Console.WriteLine("\nService endpoint {0}:", endpoint.Name);
            Console.WriteLine("Binding: {0}", endpoint.Binding.ToString());
            Console.WriteLine("ListenUri: {0}", endpoint.ListenUri.ToString());
        }
    }
}
