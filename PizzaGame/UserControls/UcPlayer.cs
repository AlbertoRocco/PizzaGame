using System;
using System.Drawing;
using System.Windows.Forms;
using PizzaGame.Helpers;
using PizzaGame.Managers;
using PizzaGame.Properties;

namespace PizzaGame.UserControls
{
    public partial class UcPlayer : UserControl
    {
        #region Constants

        private static readonly Color _activePlayerHeaderColor = Color.FromArgb(0, 192, 0);
        private static readonly Color _activePlayerBackColor = Color.FromArgb(192, 255, 192);
        private static readonly Color _notActivePlayerHeaderColor = Color.Gray;
        private static readonly Color _notActivePlayerBackColor = Color.Silver;

        #endregion

        #region Private fields

        /// <summary>Classe di gestione del gioco</summary>
        private PizzaGameManager _manager = null;

        #endregion

        #region Constructors

        public UcPlayer()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Evento generato al click del pulsante per mangiare le pizze
        /// </summary>
        public event EventHandler<PizzasEatenEventArgs> PizzasEaten;

        #endregion

        #region Properties

        /// <summary>
        /// Numero identificativo del giocatore
        /// </summary>
        public int PlayerNumber { get; set; }

        /// <summary>
        /// Nome del giocatore
        /// </summary>
        public string PlayerName
        {
            get { return lblPlayerName.Text; }
            set { lblPlayerName.Text = value; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Effettua le operazioni di inizializzazione dello user control
        /// </summary>
        /// <param name="manager"></param>
        public void Init(PizzaGameManager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            _manager = manager;

            lblPlayerName.BackColor = _notActivePlayerHeaderColor;
            BackColor = _notActivePlayerBackColor;

            // Permetto l'inserimento solo del numero di pizze previsto (1, 2 o 3)
            nudNrOfPizzasToEat.Minimum = _manager.Configuration.MinNrOfPizzasToEat;
            nudNrOfPizzasToEat.Maximum = _manager.Configuration.MaxNrOfPizzasToEat;
        }

        /// <summary>
        /// Attiva o disattiva il turno del giocatore
        /// </summary>
        /// <param name="isActive"></param>
        public void SetActivePlayer(bool isActive)
        {
            try
            {
                errorProvider.Clear();

                if (isActive)
                {
                    lblPlayerName.BackColor = _activePlayerHeaderColor;
                    BackColor = _activePlayerBackColor;
                    
                    btnEatPizzas.Enabled = true;
                    nudNrOfPizzasToEat.Enabled = true;
                    nudNrOfPizzasToEat.Focus();

                    nudNrOfPizzasToEat.Value = 1;
                }
                else
                {
                    lblPlayerName.BackColor = _notActivePlayerHeaderColor;
                    BackColor = _notActivePlayerBackColor;

                    btnEatPizzas.Enabled = false;
                    nudNrOfPizzasToEat.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManageException(ex);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Metodo chiamato quando viene premuto il pulsante per mangiare le pizze,
        /// o viene premuto invio nel controllo per l'inserimento del numero di pizze da mangiare
        /// </summary>
        private void EatPizzas()
        {
            try
            {
                errorProvider.Clear();

                // Recupero il numero di pizze da mangiare inserito dall'utente
                int nrOfPizzasToEat = (int)nudNrOfPizzasToEat.Value;

                // Mi assicuro che il numero di pizze scelto non sia superiore al numero di pizze rimasto
                if (nrOfPizzasToEat > _manager.NrOfPizzasRemaining)
                {
                    errorProvider.SetError(nudNrOfPizzasToEat, Resources.NrOfPizzasToEatIsGreaterThanNrOfRemainingPizzas);
                    return;
                }

                // Mi assicuro che il numero di pizze scelto non sia uguale a quello scelto dall'ultimo giocatore
                if (nrOfPizzasToEat == _manager.NrOfPizzasEatenByLastPlayer)
                {
                    errorProvider.SetError(nudNrOfPizzasToEat, Resources.NrOfPizzasToEatMustBeDifferentFromLast);
                    return;
                }

                // Genero l'evento di pizza mangiata
                OnBtnEatPizzasClicked(nrOfPizzasToEat);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManageException(ex);
            }
        }

        /// <summary>
        /// Se assegnato, genera l'evento di pizze mangiate
        /// </summary>
        /// <param name="nrOfPizzasToEat"></param>
        private void OnBtnEatPizzasClicked(int nrOfPizzasToEat)
        {
            PizzasEaten?.Invoke(this, new PizzasEatenEventArgs(nrOfPizzasToEat));
        }

        #endregion

        #region Event handlers methods

        /// <summary>
        /// Metodo di gestione dell'evento generato al resize dello user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcPlayer_Resize(object sender, EventArgs e)
        {
            try
            {
                // Al resize dello user control, tengo al centro il pannello con i vari controlli
                int x = (panMain.Width / 2) - (panComponents.Width / 2);
                int y = (panMain.Height / 2) - (panComponents.Height / 2);
                panComponents.Location = new Point(x, y);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ManageException(ex, false);
            }
        }

        /// <summary>
        /// Metodo di gestione dell'evento click del pulsante per mangiare le pizze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEatPizzas_Click(object sender, EventArgs e)
        {
            EatPizzas();
        }

        /// <summary>
        /// Metodo di gestione dell'evento generato dal componente per l'inserimento del
        /// numero di pizze da mangiare al cambio di valore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudNrOfPizzasToEat_ValueChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        /// <summary>
        /// Metodo di gestione dell'evento generato dal componente per l'inserimento del
        /// numero di pizze da mangiare alla pressione di un tasto della tastiera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudNrOfPizzasToEat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                EatPizzas();
            }
        }

        #endregion

        #region Classes

        public class PizzasEatenEventArgs : EventArgs
        {
            public PizzasEatenEventArgs(int nrOfPizzasToEat) => NrOfPizzasToEat = nrOfPizzasToEat;
            public int NrOfPizzasToEat { get; }
        }

        #endregion
    }
}
