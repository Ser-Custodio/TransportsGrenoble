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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransportInterfaceGraphique
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StationViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Instance de la vue 'StudentViewModel' (dans le constructeur de la ViewModel nous avons ajouté la création d'une ObservableCollection)
            ViewModel.StationViewModel stationViewModelObject = new ViewModel.StationViewModel();
            //Définir le DataContext en utilisant le nom StudentViewControl donné dans la balise <views x:Name="StudentViewControl">
            StationViewControl.DataContext = stationViewModelObject;
        }
    }
}
