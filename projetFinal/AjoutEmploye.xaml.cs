using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projetFinal
{
    /// <summary>
    /// Logique d'interaction pour AjoutEmploye.xaml
    /// </summary>
    public partial class AjoutEmploye : Window
    {
        public string NomEmploye { get; set; }
        public string PrenomEmploye { get; set; }
        public string GSM { get; set; }

        public DateTime DateEmbauche { get; set; }

        public AjoutEmploye()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (txtNom.Text.Trim() is null)
            {
                MessageBox.Show("Veuillez entrer un Nom valide (Pas de vide).", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NomEmploye = txtNom.Text.Trim();
            PrenomEmploye = txtPrenom.Text.Trim();
            GSM = txtGSM.Text.Trim();
            DateEmbauche = dpDateEmbauche.SelectedDate ?? DateTime.Now;
            DialogResult = true;
            Close();
        }


    }
}
