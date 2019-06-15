using System;

namespace PizzaGame.Managers
{
    public class PizzaGameConfiguration
    {
        #region Constructors

        public PizzaGameConfiguration()
        {
            // Inizializzo le proprietà con i valori di default
            NumberOfPlayers = 2;
            MinNrOfTotalPizzas = 10;
            MaxNrOfTotalPizzas = 30;
            MinNrOfPizzasToEat = 1;
            MaxNrOfPizzasToEat = 3;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Numero di giocatori 
        /// </summary>
        public int NumberOfPlayers { get; set; }

        /// <summary>
        /// Numero minimo di pizze utilizzato per il calcolo del valore random all'inizio del gioco
        /// </summary>
        public int MinNrOfTotalPizzas { get; set; }

        /// <summary>
        /// Numero massimo di pizze utilizzato per il calcolo del valore random all'inizio del gioco
        /// </summary>
        public int MaxNrOfTotalPizzas { get; set; }

        /// <summary>
        /// Numero minimo di pizze che i giocatori possono decidere di mangiare
        /// </summary>
        public int MinNrOfPizzasToEat { get; set; }

        /// <summary>
        /// Numero massimo di pizze che i giocatori possono decidere di mangiare
        /// </summary>
        public int MaxNrOfPizzasToEat { get; set; }

        #endregion
    }
}
