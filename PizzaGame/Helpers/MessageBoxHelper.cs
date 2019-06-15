using System;
using System.Windows.Forms;

namespace PizzaGame.Helpers
{
    static class MessageBoxHelper
    {
        public static void ShowInformationMessageBox(string text)
        {
            MessageBox.Show(text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarningMessageBox(string text)
        {
            MessageBox.Show(text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowErrorMessageBox(string text)
        {
            MessageBox.Show(text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuestionMessageBox(string text)
        {
            return MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
