using System.ComponentModel;

namespace projetFinal
{
    public class Commandes : INotifyPropertyChanged
    {
        private int idCommande;
        private Plats platChoisi;
        private int quantite;
        private int table; 
        private float prixTotal;

        public Commandes() { }
        public Commandes(int idCommande, Plats platChoisi, int quantite, int table)
        {
            IdCommande = idCommande;
            PlatChoisi = platChoisi;
            Quantite = quantite;
            Table = table;
            PrixTotal = PlatChoisi.Prix * Quantite;
        }

        public int IdCommande
        {
            get => idCommande;
            set
            {
                if (idCommande != value)
                {
                    idCommande = value;
                    OnPropertyChanged(nameof(IdCommande));
                }
            }
        }

        public Plats PlatChoisi
        {
            get => platChoisi;
            set
            {
                if (platChoisi != value)
                {
                    platChoisi = value;
                    OnPropertyChanged(nameof(PlatChoisi));
                    OnPropertyChanged(nameof(PrixTotal));
                }
            }
        }

        public int Quantite
        {
            get => quantite;
            set
            {
                if (quantite != value)
                {
                    quantite = value;
                    OnPropertyChanged(nameof(Quantite));
                    OnPropertyChanged(nameof(PrixTotal));
                }
            }
        }

        public int Table
        {
            get => table;
            set
            {
                if (table != value)
                {
                    table = value;
                    OnPropertyChanged(nameof(Table));
                }
            }
        }

        public float PrixTotal
        {
            get => prixTotal;
            set
            {
                if (prixTotal != value)
                {
                    prixTotal = value;
                    OnPropertyChanged(nameof(PrixTotal));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
