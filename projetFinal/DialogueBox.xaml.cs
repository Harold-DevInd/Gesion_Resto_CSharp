using System.Windows;

namespace projetFinal
{
    public partial class DialogueBox : Window
    {
        public string CouleurChoisie { get; private set; }

        public DialogueBox(string prompt = "")
        {
            InitializeComponent();
            CouleurSaisie.Text = prompt;
        }

        private void OkDB_Click(object sender, RoutedEventArgs e)
        {
            CouleurChoisie = CouleurSaisie.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
