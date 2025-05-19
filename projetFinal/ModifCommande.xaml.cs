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
    /// Logique d'interaction pour ModifCommande.xaml
    /// </summary>
    public partial class ModifCommande : Window
    {
        public int NewQte {  get; set; }
        public int NewTable { get; set; }
        public ModifCommande()
        {
            InitializeComponent();
        }

        private void OkComande_Click(object sender, RoutedEventArgs e)
        {   
            if((txtQuantite is not null) && (txtTable is not null))
            {
                NewQte = int.Parse(txtQuantite.Text.Trim());
                NewTable = int.Parse(txtTable.Text.Trim());
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tout les champs !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
