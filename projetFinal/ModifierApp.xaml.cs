using System.Windows;
using System.Windows.Media;
using projetFinal;

namespace projetFinal
{
    public partial class ModifierApp : Window
    {
        private string chemin = String.Empty;

        private MyAppParamManager ParamManager = new MyAppParamManager();
        public ModifierApp()
        {
            InitializeComponent();
        }

        private void ChoisirDossier_Click(object sender, RoutedEventArgs e)
        {
            if(txtChemin.Text is null)
            {
                MessageBox.Show("Veuillez choisir un dossier valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            chemin = txtChemin.Text;
            ParamManager.SaveRegistryParameter("CheminFichiers", chemin);
            MessageBox.Show("Le chemin a été enregistré avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ChoisirCouleurBG_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null) {
                MessageBox.Show("La fenêtre principale n'est pas disponible.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var ChoixCouleur = new DialogueBox();
            if (ChoixCouleur.ShowDialog() == true)
            {
                try
                {
                    string colorText = ChoixCouleur.CouleurChoisie;
                    var color = (Color)ColorConverter.ConvertFromString(colorText);
                    ParamManager.SaveRegistryParameter("CouleurFond", colorText);
                    mainWindow.ChangerCouleurFond(color);
                }
                catch
                {
                    MessageBox.Show("Couleur invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ChoisirCouleurB_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null)
            {
                MessageBox.Show("La fenêtre principale n'est pas disponible.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var ChoixCouleur = new DialogueBox();
            if (ChoixCouleur.ShowDialog() == true)
            {
                try
                {
                    string colorText = ChoixCouleur.CouleurChoisie;
                    var color = (Color)ColorConverter.ConvertFromString(colorText);
                    ParamManager.SaveRegistryParameter("CouleurBoutons", colorText);
                    mainWindow.ChangerCouleurBoutons(mainWindow.MainGrid, color);
                }
                catch
                {
                    MessageBox.Show("Couleur invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
