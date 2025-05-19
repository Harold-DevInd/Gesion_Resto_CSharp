using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinal
{
    public class Plats : INotifyPropertyChanged
    {

        private int idPlat;
        private string nomPlat;
        private string origine;
        private float prix;
        private string allergene;

        public Plats(int idPlat, string nomPlat, string origine, float prix,string allergene)
        {
            IdPlat = idPlat;
            Nom = nomPlat;
            Origine = origine;
            Prix = prix;
            Allergene = allergene;
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

        public string Allergene
        {
            get => allergene;
            set
            {
                if (allergene != value)
                {
                    allergene = value;
                    OnPropertyChanged(nameof(Allergene));
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
