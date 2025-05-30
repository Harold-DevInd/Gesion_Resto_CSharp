using System.ComponentModel;

namespace projetFinal
{
    public class Plats : INotifyPropertyChanged
    {
        // Initialisation pour eviter les avertissement
        private int idPlat;
        private string nomPlat = string.Empty; 
        private string origine = string.Empty; 
        private float prix;
        private string photo = string.Empty;

        public Plats() { }

        public Plats(int idPlat, string nomPlat, string origine, float prix, string photo)
        {
            IdPlat = idPlat;
            Nom = nomPlat;
            Origine = origine;
            Prix = prix;
            Photo = photo;
        }

        public int IdPlat
        {
            get => idPlat;
            set
            {
                if (idPlat != value)
                {
                    idPlat = value;
                    OnPropertyChanged(nameof(IdPlat));
                }
            }
        }

        public string Nom
        {
            get => nomPlat;
            set
            {
                if (nomPlat != value)
                {
                    nomPlat = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }

        public string Origine
        {
            get => origine;
            set
            {
                if (origine != value)
                {
                    origine = value;
                    OnPropertyChanged(nameof(Origine));
                }
            }
        }

        public float Prix
        {
            get => prix;
            set
            {
                if (prix != value)
                {
                    prix = value;
                    OnPropertyChanged(nameof(Prix));
                }
            }
        }

        public string Photo
        {
            get => photo;
            set
            {
                if (photo != value)
                {
                    photo = value;
                    OnPropertyChanged(nameof(Photo));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
