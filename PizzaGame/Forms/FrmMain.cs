using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PizzaGame.Properties;
using PizzaGame.UserControls;
using PizzaGame.Managers;
using PizzaGame.Helpers;

namespace PizzaGame.Forms
{
    public partial class FrmMain : Form
    {
        #region Private fields

        /// <summary>Classe di gestione del gioco</summary>
        private PizzaGameManager _manager = null;

        #endregion

        #region Constructors

        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Effettua le operazioni di inizializzazione da effettuare all'avvio dell'applicazione
        /// </summary>
        private void Init()
        {
            // Istanzio la classe di gestione del gioco, con la relativa configurazione
            PizzaGameConfiguration configuration = new PizzaGameConfiguration
            {
                MinNrOfTotalPizzas = Settings.Default.MinNrOfTotalPizzas,
                MaxNrOfTotalPizzas = Settings.Default.MaxNrOfTotalPizzas,
                MinNrOfPizzasToEat = Settings.Default.MinNrOfPizzasToEat,
                MaxNrOfPizzasToEat = Settings.Default.MaxNrOfPizzasToEat
            };
            _manager = new PizzaGameManager(configuration);

            // Inizializzo gli user control dei giocatori
            foreach (UcPlayer ucPlayer in GetAllPlayersUserControls())
            {
                ucPlayer.Init(_manager);
            }

            // Reset del gioco
            ResetGame();
        }

        /// <summary>
        /// Effettua il reset del gioco
        /// </summary>
        private void ResetGame()
        {
            // Reset del gioco
            _manager.ResetGame();

            // Rimuovo il numero di pizze rimanenti
            lblPizzasNr.Text = string.Empty;

            // Disattivo tutti gli user control dei giocatori
            foreach (UcPlayer ucPlayer in GetAllPlayersUserControls())
            {
                ucPlayer.SetActivePlayer(false);
            }

            // Metto il focus al pulsante per l'inizio del gioco
            btnStartGame.Focus();
        }

        /// <summary>
        /// Avvia il gioco
        /// </summary>
        private void StartGame()
        {
            // Se il gioco è già in corso chiedo all'utente se vuole ricominciarlo
            if (_manager.IsGameRunning)
            {
                if (MessageBoxHelper.ShowQuestionMessageBox(Resources.QuestionRestartGame) != DialogResult.Yes)
                {
                    return;
                }
            }

            // Reset
            ResetGame();

            // Avvio il gioco
            _manager.StartGame();

            // Visualizzo il numero di pizze rimanenti
            ShowNumberOfPizzas();
            
            // Attivo il turno del giocatore a cui tocca giocare (il 1°)
            GetPlayerUserControl(_manager.ActivePlayer).SetActivePlayer(true);
        }

        /// <summary>
        /// Metodo chiamato quando il giocatore sceglie il numero di pizze da mangiare
        /// </summary>
        /// <param name="ucPlayer"></param>
        /// <param name="nrOfPizzasToEat"></param>
        private void EatPizzas(UcPlayer ucPlayer, int nrOfPizzasToEat)
        {
            bool hasNextPlayerValidChoices;

            // Mangio le pizze e procedo con il turno del prossimo giocatore
            bool hasLost = !_manager.EatPizzas(nrOfPizzasToEat, out hasNextPlayerValidChoices);
            
            // Se il giocatore ha perso il gioco è finito
            if (hasLost)
            {
                MessageBoxHelper.ShowWarningMessageBox(string.Format(Resources.PlayerHasLost, ucPlayer.PlayerName));
                ResetGame();
                return;
            }

            // Visualizzo il numero di pizze rimanenti
            ShowNumberOfPizzas();

            // Disattivo lo user control del giocatore che ha appena giocato
            ucPlayer.SetActivePlayer(false);

            // Attivo lo user control del prossimo giocatore a cui tocca mangiare la pizza
            GetPlayerUserControl(_manager.ActivePlayer).SetActivePlayer(true);

            // Se il giocatore attuale non ha mosse valide è costretto a passare il turno:
            // mostro un messaggio all'utente
            if (!hasNextPlayerValidChoices)
            {
                MessageBoxHelper.ShowInformationMessageBox(Resources.PlayerHasNoChoices);
            }
        }
        
        /// <summary>
        /// Restituisce lo user control relativo al giocatore specificato
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        private UcPlayer GetPlayerUserControl(int playerNumber)
        {
            return GetAllPlayersUserControls().Where(uc => uc.PlayerNumber == playerNumber).FirstOrDefault();
        }
        
        /// <summary>
        /// Restituisce tutti gli user control di tipo UcPlayer presenti nel form
        /// </summary>
        /// <returns></returns>
        private IEnumerable<UcPlayer> GetAllPlayersUserControls()
        {
            return tableLayoutPanel.Controls.OfType<UcPlayer>();
        }

        /// <summary>
        /// Visualizza il numero di pizze rimanenti
        /// </summary>
        private void ShowNumberOfPizzas()
        {
            lblPizzasNr.Text = string.Format(Resources.NumberOfPizzas, _manager.NrOfPizzasRemaining);
        }

        #endregion

        #region Event handlers methods

        /// <summary>
        /// Metodo di gestione dell'evento generato al caricamento della form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Init();
        }
        
        /// <summary>
        /// Metodo di gestione dell'evento click del pulsante per l'inizio del gioco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// Metodo di gestione dell'evento generato dagli user control dei giocatori
        /// quando viene premuto il pulsante per mangiare le pizze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPlayer_PizzasEaten(object sender, UcPlayer.PizzasEatenEventArgs e)
        {
            EatPizzas((UcPlayer)sender, e.NrOfPizzasToEat);
        }

        #endregion
    }
}
