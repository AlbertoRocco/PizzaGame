using System;
using PizzaGame.Properties;

namespace PizzaGame.Helpers
{
    static class ExceptionHelper
    {
        public static void ManageException(Exception ex, bool showMessage = true)
        {
            if (showMessage)
            {
                MessageBoxHelper.ShowErrorMessageBox(Resources.ExceptionMessage);
            }
        }
    }
}
