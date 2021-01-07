using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.MVVM
{
    public class VoituresMVVM : INotifyPropertyChanged

    {

        private ObservableCollection<Voitures> _LvVoitures;
        string _Filter;
        private Voitures _SelectedVoiture;
        private List<Marques> _MarquesVt;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Voitures> LvVoitures
        {
            get
            {
                return _LvVoitures;
            }
            set
            {
                this._LvVoitures = value;
                OnPropertyChanged();
            }
        }
            public Voitures SelectedVoiture
        {
            get
            {
                return this._SelectedVoiture;
            }

            set
            {
                this._SelectedVoiture = value;
                OnPropertyChanged();
            }

        }
        public List<Marques> MarquesVt
        {
            get
            {
                return this._MarquesVt;

            }
            set
            {
                this._MarquesVt = value;
                OnPropertyChanged();
            }
        }
        public string Filter
        {
            get { return this._Filter; }
            set
            {
                this._Filter = value;
                UpdateList(value);
                OnPropertyChanged();
            }
        }
        private void UpdateList(string filter)
        {
            ExamensEntities MyEntity = new ExamensEntities();
            var data = (from clt in MyEntity.Voitures where clt.Modèle.StartsWith(filter) select clt).ToList();
            this.LvVoitures = new ObservableCollection<Voitures>(data);
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
