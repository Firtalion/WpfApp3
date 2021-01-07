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
    public class MarquesMVVM : INotifyPropertyChanged
    {
        private ObservableCollection<Marques> _LMarques;
        private string _Filter;
        private Marques _SelectedMarques;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Marques> LMarques
        {
            get { return _LMarques; }
            set { this._LMarques = value; OnPropertyChanged(); }
        }

        public Marques SelectedMarques
        {
            get
            {
                return this._SelectedMarques;
            }

            set
            {
                this._SelectedMarques = value;
                OnPropertyChanged();
            }
        }

       

        private void UpdateList(string filter)
        {
            ExamensEntities MyEntity = new ExamensEntities();
            var data = (from mqt in MyEntity.Marques  select mqt).ToList();
            this.LMarques = new ObservableCollection<Marques>(data);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
