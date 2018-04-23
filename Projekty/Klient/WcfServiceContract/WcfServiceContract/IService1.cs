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
    /// Główny interface usługi słownika
    /// </summary>
    [ServiceContract]
    public interface ICalculator
    {
     
        /// <summary>
        /// Metoda dodania do słownika
        /// </summary>
        /// <returns><c>true</c>jeśli dodano poprawnie do słownika<c>false</c>jeśli wystąpił błąd</returns>
        /// <param name="value">Słowo po polski</param>
        /// <param name="translation">Słowo przetłumaczona na język angielski</param>
        [OperationContract]
        bool DodajDoSlownika(String value, String translation);

        /// <summary>
        /// Wyszukaj tłumaczenie
        /// </summary>
        /// <returns>String z wyszukanym tłumaczeniem / tłumaczeniami</returns>
        /// <param name="value">Polskie słowo</param>
        [OperationContract]
        String Wyszukaj(String value);

        /// <summary>
        /// Usuwa ze słownika określone tłumaczenie
        /// </summary>
        /// <returns>Czy wartość została usunięta.</returns>
        /// <param name="value">Słowo kucz ze słownika</param>
        [OperationContract]
        bool Usun(String value);

        /// <summary>
        /// Modyfikuje tłumaczenie
        /// </summary>
        /// <returns>Czy poprawnie zmodyfikowano</returns>
        /// <param name="value">Polskie słowo</param>
        /// <param name="translation">Nowa wersja tłumaczenie po angielsku</param>
        [OperationContract]
        bool Modyfikuj(String value, String translation);

    }
}