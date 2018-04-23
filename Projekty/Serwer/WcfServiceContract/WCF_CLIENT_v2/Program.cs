using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_CLIENT_v2.ServiceReference1;

namespace WCF_CLIENT_v2
{
    /// <summary>
    /// Martyna Kumaszka, Tomasz Mosur
    /// Klasa interfajsu klienta
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Klient do połączenia
        /// </summary>
        public static CalculatorClient client = new CalculatorClient("WSHttpBinding_ICalculator");

        /// <summary>
        /// Główna funkcja programu
        /// </summary>
        /// <param name="args">Argumenty startowe - nie używane</param>
        public static void Main(string[] args)
        {

            bool runProgram = true;

            Console.WriteLine("Witaj w słowniku");
            Console.WriteLine("");
            ShowHelp();

            while (runProgram)
            {
                Console.Write("$ ");
                string line = Console.ReadLine();
                string[] words = line.Split(' ');
                switch (words[0])
                {
                    case "ADD":
                        Add(words);
                        break;
                    case "TRANSLATE":
                        Translate(words);
                        break;
                    case "MODIFY":
                        Modify(words);
                        break;
                    case "REMOVE":
                        Remove(words);
                        break;
                    case "SHOW":
                        Show();
                        break;
                    case "HELP":
                        ShowHelp();
                        break;
                    case "CLOSE":
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawna komenda");
                        break;
                }
            }
        }

        /// <summary>
        /// Metoda wyswietlająca słownik
        /// </summary>
        private static void Show()
        {
            Dictionary<String, String> slownik = client.Wyswietl();

            List<String> values = new List<String>();

            foreach (KeyValuePair<String, String> pair in slownik)
            {
                
                   values.Add(pair.Key + " - " + pair.Value);
                
            }
            Console.WriteLine(string.Join("\n", values.ToArray()));

        }

        /// <summary>
        /// Metoda dodająca tłumaczenie do słownika
        /// </summary>
        /// <param name="words">Polecenie podzielone na słowa</param>
        public static void Add(string[] words)
        {
            if (words.Length == 3)
            {
                if (client.DodajDoSlownika(words[1], words[2]))
                {
                    Console.WriteLine("Dodano");
                }
                else
                {
                    Console.WriteLine("Element juz istnieje");
                }
            }
            else
                Console.WriteLine("Niepoprawna komenda");
        }

        /// <summary>
        /// Metoda modyfikująca tłumaczenie
        /// </summary>
        /// <param name="words">Polecenie podzielone na słowa</param>
        public static void Modify(string[] words)
        {
            if (words.Length == 3)
            {
                if (client.Modyfikuj(words[1], words[2]))
                {
                    Console.WriteLine("Zmieniono");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono");
                }
            }
            else
                Console.WriteLine("Niepoprawna komenda");
        }

        /// <summary>
        /// Metoda usuwająca tłumaczenie ze słownika
        /// </summary>
        /// <param name="words">Polecenie podzielone na słowa</param>
        public static void Remove(string[] words)
        {
            if (words.Length == 2)
            {
                if (client.Usun(words[1]))
                {
                    Console.WriteLine("Usunieto");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono");
                }
            }
            else
                Console.WriteLine("Niepoprawna komenda");
        }

        /// <summary>
        /// Metoda pobierająca tłumaczenie
        /// </summary>
        /// <param name="words">Polecenie podzielone na słowa</param>
        public static void Translate(string[] words)
        {
            if (words.Length == 2)
            {
                Console.WriteLine(client.Wyszukaj(words[1]));
            }
            else
                Console.WriteLine("Niepoprawna komenda");
        }

        /// <summary>
        /// Metoda wyświetlajaca komendy możliwe do wykonania w programie
        /// </summary>
        public static void ShowHelp()
        {
            Console.WriteLine("Oto operacje które możesz wykonać:");
            Console.WriteLine("   ADD [słowo polskie] [słowo angielskie]");
            Console.WriteLine("   TRANSLATE [słowo polskie]");
            Console.WriteLine("   MODIFY [słowo polskie]");
            Console.WriteLine("   REMOVE [słowo polskie]");
            Console.WriteLine("   SHOW");
            Console.WriteLine("");
        }


    }
}
