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
    /// Logique d'interaction pour AjoutPlat.xaml
    /// </summary>
    public partial class AjoutPlat : Window
    {
        public int IdPlat { get; private set; }
        public string NomPlat { get; private set; }
        public string OriginePlat { get; private set; }
        public float PrixPlat { get; private set; }
        public string Allergene { get; private set; }

        public AjoutPlat()
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

            IdPlat = 0;
            NomPlat = txtNom.Text.Trim();
            OriginePlat = txtOrigine.Text.Trim();
            if (!float.TryParse(txtPrix.Text.Trim(), out float prix))
            {
                MessageBox.Show("Veuillez entrer un prix valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                PrixPlat = prix;
            }
            Allergene = txtAllergene.Text.Trim();

            DialogResult = true;
            Close();
        }
    }
}
