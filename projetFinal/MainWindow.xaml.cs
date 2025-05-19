using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlzEx.Standard;

namespace projetFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int idPlatCourant = 1;
        private int idEmployeCourant = 1;
        private int idCommandeCourant = 1;

        public ObservableCollection<Plats> ListePlats { get; set; } = new ObservableCollection<Plats>();
        public ObservableCollection<Employes> ListeEmployes { get; set; } = new ObservableCollection<Employes>();
        public ObservableCollection<Commandes> ListeCommandes { get; set; } = new ObservableCollection<Commandes>();

        private MyAppParamManager ParamManager = new MyAppParamManager();

        private string cheminFichier;

        public MainWindow()
        {
            InitializeComponent();
            dgEmployes.ItemsSource = ListeEmployes;
            dgPlats.ItemsSource = ListePlats;
            dgCommandes.ItemsSource = ListeCommandes;
        }

        // Gestion du menu
        #region Gestion du menu
        private void Utilisateur_Click(object sender, RoutedEventArgs e) { /* ... */ }
        private void ImporterEmployes_Click(object sender, RoutedEventArgs e) { /* ... */ }
        private void ExporterEmployes_Click(object sender, RoutedEventArgs e) { /* ... */ }
        private void ImporterPlats_Click(object sender, RoutedEventArgs e) { /* ... */ }
        private void ExporterPlats_Click(object sender, RoutedEventArgs e) { /* ... */ }
        private void ImporterCommandes_Click(object sender, RoutedEventArgs e) { /* ... */ }
        private void ExporterCommandes_Click(object sender, RoutedEventArgs e) { /* ... */ }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        // Gestion des bouttons
        #region Gestion des Plats
        private void AjouterP_Click(object sender, RoutedEventArgs e)
        {
            var NewPlat = new AjoutPlat { Owner = this };
            if (NewPlat.ShowDialog() == true)
            {
                ListePlats.Add(new Plats(idPlatCourant, NewPlat.NomPlat, NewPlat.OriginePlat, NewPlat.PrixPlat, NewPlat.Allergene));
            }
            idPlatCourant++;
            MessageBox.Show("Plat ajouté avec succès.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ModifierP_Click(object sender, RoutedEventArgs e)
        {
            if(ListePlats.Count == 0)
            {
                MessageBox.Show("Liste de plat vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else 
            {
                if (dgPlats.SelectedItem is null)
                {
                    MessageBox.Show("Veuillez sélectionner un plat à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (dgPlats.SelectedItem is Plats c)
                {
                    var NewPlat = new AjoutPlat { Owner = this };
                    NewPlat.txtNom.Text = c.Nom;
                    NewPlat.txtOrigine.Text = c.Origine;
                    NewPlat.txtPrix.Text = c.Prix.ToString();
                    NewPlat.txtAllergene.Text = c.Allergene;

                    if (NewPlat.ShowDialog() == true)
                    {
                        c.Nom = NewPlat.txtNom.Text;
                        c.Origine = NewPlat.txtOrigine.Text;
                        c.Prix = float.Parse(NewPlat.txtPrix.Text);
                        c.Allergene = NewPlat.txtAllergene.Text;
                    }

                    MessageBox.Show("Plat modifié avec succès.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void SupprimerP_Click(object sender, RoutedEventArgs e)
        {
            if(ListePlats.Count == 0)
            {
                MessageBox.Show("Liste de plat vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (dgPlats.SelectedItem is null)
            {
                MessageBox.Show("Veuillez sélectionner un plat à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (dgEmployes.SelectedItem is Plats c) ListePlats.Remove(c);
        }
        #endregion

        #region Gestion des employés
        private void AjouterE_Click(object sender, RoutedEventArgs e)
        {
            var NewEmploye = new AjoutEmploye { Owner = this };
            if (NewEmploye.ShowDialog() == true)
            {
                ListeEmployes.Add(new Employes (idEmployeCourant, NewEmploye.NomEmploye,NewEmploye.PrenomEmploye, NewEmploye.GSM, NewEmploye.DateEmbauche));
            }
            idEmployeCourant++;
            MessageBox.Show("Employé ajouté avec succès.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ModifierE_Click(Object sender, RoutedEventArgs e)
        {
            if(ListeEmployes.Count == 0)
            {
                MessageBox.Show("Liste d'employé vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (dgEmployes.SelectedItem is null)
                {
                    MessageBox.Show("Veuillez sélectionner un employé à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else {
                    var NewEmploye = new AjoutEmploye { Owner = this };
                    if (dgEmployes.SelectedItem is Employes emp)
                    {
                        NewEmploye.txtNom.Text = emp.Nom;
                        NewEmploye.txtPrenom.Text = emp.Prenom;
                        NewEmploye.txtGSM.Text = emp.GSM;
                        NewEmploye.dpDateEmbauche.SelectedDate = emp.DateEmbauche;
                        if (NewEmploye.ShowDialog() == true)
                        {
                            emp.Nom = NewEmploye.txtNom.Text;
                            emp.Prenom = NewEmploye.txtPrenom.Text;
                            emp.GSM = NewEmploye.txtGSM.Text;
                            emp.DateEmbauche = NewEmploye.dpDateEmbauche.SelectedDate ?? DateTime.Now;
                        }
                        MessageBox.Show("Employé modifié avec succès.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void SupprimerE_Click(object sender, RoutedEventArgs e)
        {
            if (ListeEmployes.Count == 0)
            {
                MessageBox.Show("Liste d'employé vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (dgEmployes.SelectedItem is null)
            {
                MessageBox.Show("Veuillez sélectionner un employé à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (dgEmployes.SelectedItem is Employes emp)
            {
                ListeEmployes.Remove(emp);
                MessageBox.Show("Employé supprimé avec succès.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region Gestion des commandes
        private void AjouterC_Click(object sender, RoutedEventArgs e)
        {
            if (txtChoixPlat.Text.Trim() is null)
            {
                MessageBox.Show("Veuillez entrer un plat valide (Pas de vide).", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else {
                int ChoixPlat = int.Parse(txtChoixPlat.Text.Trim());
                int Quantite = int.Parse(txtQuantite.Text.Trim());
                int Table = int.Parse(txtTable.Text.Trim());

                if (ListePlats.Count == 0)
                {
                    MessageBox.Show("Liste de plat vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    // retourne le premier élément correspondant ou null s’il n’existe pas.
                    Plats PlatCommande = ListePlats.FirstOrDefault(p => p.IdPlat == ChoixPlat);

                    if (PlatCommande == null)
                    {
                        MessageBox.Show("Plat non trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        var NewCommande = new Commandes(idCommandeCourant, PlatCommande, Quantite, Table);
                        ListeCommandes.Add(NewCommande);
                    }
                }                
                idCommandeCourant++;
                MessageBox.Show("Commande ajoutée avec succès.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ModifierC_Click(object sender, RoutedEventArgs e)
        {
            if (ListeCommandes != null)
            {
                if (dgCommandes.SelectedItem is not null)
                {
                    var NewCommande = new ModifCommande{ Owner = this};
                    if (dgCommandes.SelectedItem is Commandes cmd)
                    {
                        NewCommande.txtQuantite.Text = cmd.Quantite.ToString();
                        NewCommande.txtTable.Text = cmd.Table.ToString();

                        if(NewCommande.ShowDialog() == true)
                        {
                            cmd.Quantite = int.Parse(NewCommande.txtQuantite.Text);
                            cmd.Table = int.Parse(NewCommande.txtTable.Text);
                            MessageBox.Show("Commande modifiée avec succès.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner une commande.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Liste de Commande vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SupprimerC_Click(object sender, RoutedEventArgs e)
        {
            if (dgCommandes.SelectedItem is Commandes cmd)
                ListeCommandes.Remove(cmd);
        }
        #endregion

        #region Gestion des parametres de l'application
        private void Parametres_Click(object sender, RoutedEventArgs e)
        {
            var modifierApp = new ModifierApp { Owner = this };
            if (modifierApp.ShowDialog() == true)
            {
                ChargerCheminFichiers();
                ChargerCouleurFond();
                ChargerCouleurBoutons();
            }
        }

        public void ChargerCheminFichiers()
        {
            cheminFichier = ParamManager.LoadRegistryParameter("CheminFichiers", "C:\\");
            if (cheminFichier == null)
            {
                MessageBox.Show("Erreur lors de l'enregistrement du chemin.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ChangerCheminFichiers(string chemin)
        {
            if(string.IsNullOrEmpty(chemin))
            {
                MessageBox.Show("Veuillez entrer un chemin valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
                cheminFichier = chemin;
        }
        public void ChargerCouleurFond()
        {
            string couleur = ParamManager.LoadRegistryParameter("CouleurFond", "#FFFFFFFF");
            if (couleur != null)
            {
                try
                {
                    var color = (Color)ColorConverter.ConvertFromString(couleur);
                    MainGrid.Background = new SolidColorBrush(color);
                }
                catch
                {
                    MessageBox.Show("Couleur invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void ChargerCouleurBoutons()
        {
            string couleur = ParamManager.LoadRegistryParameter("CouleurBoutons", "#FFD3D3D3");
            if (couleur != null)
            {
                try
                {
                    var color = (Color)ColorConverter.ConvertFromString(couleur);
                    ChangerCouleurBoutons(color);
                }
                catch
                {
                    MessageBox.Show("Couleur invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void ChangerCouleurFond(Color couleur)
        {
            MainGrid.Background = new SolidColorBrush(couleur);
        }

        public void ChangerCouleurBoutons(Color couleur)
        {
            var brush = new SolidColorBrush(couleur);

            foreach (var element in MainGrid.Children)
            {
                if (element is Button bouton)
                {
                    bouton.Background = brush;
                }
            }
        }
        #endregion
    }
}