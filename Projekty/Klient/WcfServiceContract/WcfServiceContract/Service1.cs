using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract
{
    /// <summary>
    /// Martyna Kumaszka, Tomasz Mosur
    /// Klasa z implementacją interfacu słownika
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyCalculator : ICalculator
    {
        /// <summary>
        /// Obiekt w którym zapisywany jest słownik
        /// </summary>
        public Dictionary<String, String> slownik;

        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        public MyCalculator()
        {
            this.slownik = new Dictionary<string, string>();
        }

        /// <summary>
        /// Metoda dodania do słownika
        /// </summary>
        /// <returns><c>true</c>jeśli dodano poprawnie do słownika<c>false</c>jeśli wystąpił błąd</returns>
        /// <param name="value">Słowo po polski</param>
        /// <param name="translation">Słowo przetłumaczona na język angielski</param>
        public bool DodajDoSlownika(String value, String translation)
        {
            if (this.slownik.ContainsKey(value))
            {
                return false;
            }
            this.slownik.Add(value, translation);
            return true;
        }

        /// <summary>
        /// Wyszukaj tłumaczenie
        /// </summary>
        /// <returns>String z wyszukanym tłumaczeniem / tłumaczeniami</returns>
        /// <param name="value">Polskie słowo</param>
        public String Wyszukaj(String value)
        {

            List<String> values = new List<String>();

            foreach (KeyValuePair<String,String> pair in this.slownik)
            {
                if (pair.Key.StartsWith(value))
                {
                    values.Add(pair.Key + " - " + pair.Value);
                }
            }
            return string.Join("\n", values.ToArray());
        }

        /// <summary>
        /// Usuwa ze słownika określone tłumaczenie
        /// </summary>
        /// <returns>Czy wartość została usunięta.</returns>
        /// <param name="value">Słowo kucz ze słownika</param>
        public bool Usun(String value)
        {
            if (!this.slownik.ContainsKey(value))
            {
                return false;
            }
            this.slownik.Remove(value);
            return true;
        }

        /// <summary>
        /// Modyfikuje tłumaczenie
        /// </summary>
        /// <returns>Czy poprawnie zmodyfikowano</returns>
        /// <param name="value">Polskie słowo</param>
        /// <param name="translation">Nowa wersja tłumaczenie po angielsku</param>
        public bool Modyfikuj(String value, String translation)
        {
            if (!this.slownik.ContainsKey(value))
            {
                return false;
            }
            this.slownik[value] = translation;
            return true;
        }



    }
}
