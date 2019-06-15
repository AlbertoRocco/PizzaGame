using System;

namespace PizzaGame.Managers
{
    public class PizzaGameManager
    {
        #region Constructors

        /// <summary>
        /// Istanzia la classe con la configurazione di default
        /// </summary>
        public PizzaGameManager()
            : this(new PizzaGameConfiguration())
        {
        }

        /// <summary>
        /// Istanzia la classe con la configurazione specificata
        /// </summary>
        /// <param name="configuration"></param>
        public PizzaGameManager(PizzaGameConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            Configuration = configuration;
        }

        #endregion

        #region Public properties

        /// <summary>Configurazione del gioco</summary>
        public PizzaGameConfiguration Configuration { get; private set; }

        /// <summary>Numero identificativo del giocatore a cui tocca giocare</summary>
        public int ActivePlayer { get; private set; }

        /// <summary>Numero di pizze rimanenti da mangiare</summary>
        public int NrOfPizzasRemaining { get; private set; }

        /// <summary>Numero di pizze mangiate dall'ultimo giocatore che ha giocato</summary>
        public int NrOfPizzasEatenByLastPlayer { get; private set; }

        /// <summary>Indica se il gioco è in corso</summary>
        public bool IsGameRunning { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Avvia il gioco
        /// </summary>
        public void StartGame()
        {
            // Reset
            ResetGame();

            // Calcolo il numero random di pizze 
            NrOfPizzasRemaining = new Random().Next(Configuration.MinNrOfTotalPizzas, Configuration.MaxNrOfTotalPizzas + 1);

            // Attivo il turno del primo giocatore
            ActivePlayer = 1;

            // Indico che il gioco è in corso
            IsGameRunning = true;
        }

        /// <summary>
        /// Reset del gioco
        /// </summary>
        public void ResetGame()
        {
            NrOfPizzasRemaining = 0;
            NrOfPizzasEatenByLastPlayer = 0;
            ActivePlayer = 0;
            IsGameRunning = false;
        }

        /// <summary>
        /// Permette al giocatore attivo di mangiare il numero di pizze specificato,
        /// dopodichè attiva il turno del giocatore successivo
        /// </summary>
        /// <param name="nrOfPizzasToEat">Nr. di pizze da mangiare</param>
        /// <param name="hasNextPlayerValidChoices">OUT: Indica se è stato saltato il turno del giocatore successivo in quanto non aveva più scelte disponibili</param>
        /// <returns>False se il giocatore che ha mangiato le pizze ha perso</returns>
        public bool EatPizzas(int nrOfPizzasToEat, out bool hasNextPlayerValidChoices)
        {
            // Se viene chiamato questo metodo quando il gioco non è avviato significa che 
            // questa classe non viene utilizzata correttamente!
            if (!IsGameRunning)
            {
                throw new Exception("Game is not running");
            }

            // Mi assicuro che il numero di pizze da mangiare sia entro il range consentito
            if (nrOfPizzasToEat < Configuration.MinNrOfPizzasToEat || nrOfPizzasToEat > Configuration.MaxNrOfPizzasToEat)
            {
                throw new ArgumentException($"Number of pizzas to eat must be greater than {Configuration.MinNrOfPizzasToEat} and lower than {Configuration.MaxNrOfPizzasToEat}", nameof(nrOfPizzasToEat));
            }

            // Mi assicuro che il numero di pizze da mangiare non sia maggiore del numero di pizze rimaste
            if (nrOfPizzasToEat > NrOfPizzasRemaining)
            {
                throw new ArgumentException("Number of pizzas to eat must be lower or equal than the number of remaining pizzas");
            }

            // Il numero di pizze da mangiare non può essere uguale al numero di pizze
            // mangiato dall'ultimo giocatore che ha giocato: se il numero di pizze mangiate
            // dall'ultimo giocatore è 0 significa che si è al primo turno oppure il giocatore
            // precedente ha dovuto saltare il turno!
            if (NrOfPizzasEatenByLastPlayer > 0 && nrOfPizzasToEat == NrOfPizzasEatenByLastPlayer)
            {
                throw new ArgumentException("Number of pizzas to eat must be different from the number of pizzas eaten by last player", nameof(nrOfPizzasToEat));
            }

            // La prima pizza è quella avvelenata, per cui se il giocatore la mangia perde!
            if (NrOfPizzasRemaining - nrOfPizzasToEat == 0)
            {
                // Il giocatore ha perso
                hasNextPlayerValidChoices = true;
                ResetGame();
                return false;
            }

            // Detraggo il numero di pizze mangiate
            NrOfPizzasRemaining -= nrOfPizzasToEat;

            // Attivo il turno del giocatore successivo
            ActivePlayer = GetNextActivePlayer();

            // Salvo il riferimento al numero di pizze mangiato dal giocatore che ha appena giocato
            NrOfPizzasEatenByLastPlayer = nrOfPizzasToEat;

            // Verifico se il giocatore successivo non ha più mosse valide: in tal
            // caso è costretto a saltare il turno
            hasNextPlayerValidChoices = HasPlayerValidChoices();
            if (!hasNextPlayerValidChoices)
            {
                ActivePlayer = GetNextActivePlayer();
                NrOfPizzasEatenByLastPlayer = 0;
            }

            return true;
        }

        #endregion

        #region Private methods
        
        /// <summary>
        /// Restituisce il numero del prossimo giocatore a cui tocca giocare
        /// </summary>
        /// <returns></returns>
        private int GetNextActivePlayer()
        {
            // All'inizio del gioco è il turno del primo giocatore
            if (ActivePlayer <= 0)
                return 1;

            // Se ha appena giocato l'ultimo giocatore si riparte dal 1°
            if (ActivePlayer == Configuration.NumberOfPlayers)
                return 1;

            // è il turno del giocatore successivo
            return ActivePlayer + 1;
        }

        /// <summary>
        /// Indica se il giocatore attivo ha delle scelte possibili per poter mangiare le pizze
        /// </summary>
        /// <returns></returns>
        private bool HasPlayerValidChoices()
        {
            // Recupero il numero minimo di pizze che il può giocatore può mangiare
            int minNrOfPizzasToEat = NrOfPizzasEatenByLastPlayer != Configuration.MinNrOfPizzasToEat ? Configuration.MinNrOfPizzasToEat : Configuration.MinNrOfPizzasToEat + 1;

            // Se il numero minimo di pizze da poter mangiare è maggiore del numero 
            // di pizze rimanenti significa che il giocatore non ha più scelte disponibili
            bool hasChoices = !(minNrOfPizzasToEat > NrOfPizzasRemaining);
            return hasChoices;
        }

        #endregion
    }
}
