using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetFinal
{
    public class Employes : INotifyPropertyChanged
    {
        private int idEmploye;
        private string nom;
        private string prenom;
        private string gsm;
        private DateTime dateEmbauche;

        public Employes(int idEmploye, string nom, string prenom, string gsm, DateTime dateEmbauche)
        {
            IdEmploye = idEmploye;
            Nom = nom;
            Prenom = prenom;
            GSM = gsm;
            DateEmbauche = dateEmbauche;
        }

        public int IdEmploye
        {
            get => idEmploye;
            set
            {
                if (idEmploye != value)
                {
                    idEmploye = value;
                    OnPropertyChanged(nameof(IdEmploye));
                }
            }
        }

        public string Nom
        {
            get => nom;
            set
            {
                if (nom != value)
                {
                    nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }

        public string Prenom
        {
            get => prenom;
            set
            {
                if (prenom != value)
                {
                    prenom = value;
                    OnPropertyChanged(nameof(Prenom));
                }
            }
        }

        public string GSM
        {
            get => gsm;
            set
            {
                if (gsm != value)
                {
                    gsm = value;
                    OnPropertyChanged(nameof(GSM));
                }
            }
        }

        public DateTime DateEmbauche
        {
            get => dateEmbauche;
            set
            {
                if (dateEmbauche != value)
                {
                    dateEmbauche = value;
                    OnPropertyChanged(nameof(DateEmbauche));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
