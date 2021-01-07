using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.MVVM;

namespace WpfApp3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MarquesMVVM Mq { get; set; }
        public VoituresMVVM Vt { get; set; }
        public MainWindow()
        {

            InitializeComponent();
            Vt = new VoituresMVVM();
            this.DataContext = Vt;
        }
        private void InitVoituresList()
        {
            Vt = new VoituresMVVM();
            ExamensEntities MyEntity = new ExamensEntities();
            var data = (from clt in MyEntity.Voitures select clt).ToList();
            Vt.LvVoitures = new ObservableCollection<Voitures>(data);
        }
        private void MarquesList()
        {
            Mq = new MarquesMVVM();
            ExamensEntities MyEntity = new ExamensEntities();
            var data = (from mqt in MyEntity.Marques select mqt).ToList();
            Mq.LMarques = new ObservableCollection<Marques>(data);
        }
        private void ListeMarques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lm = sender as ListView;
            Marques mqt = lm.SelectedItem as Marques;
            var mqid = mqt.MarqueId;
            ExamensEntities MyEntity = new ExamensEntities();
            Mq.SelectedMarques = (from clte in MyEntity.Marques where clte.MarqueId == mqt.MarqueId select clte).First();
        }

    }
}
