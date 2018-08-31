using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportInterfaceGraphique.Model;
using TransportLibrary;

namespace TransportInterfaceGraphique.ViewModel
{
    public class StationViewModel : Mere
    {
        private String latitude;
        private String longitude;
        private Int32 distance;
        private ObservableCollection<DataStation> stations;

        public ObservableCollection<DataStation> Stations
        {
            get
            {
                return stations;
            }

            set
            {
                if (stations != value)
                {
                    stations = value;
                    RaisePropertyChanged("Stations");
                }
            }
        }

        public String Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                if (latitude != value)
                {
                    latitude = value;
                   // DoRequest();
                }
            }
        }

        public String Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                if (longitude != value)
                {
                    longitude = value;
                   // DoRequest();
                }
            }
        }

        public Int32 Distance
        {
            get
            {
                return distance;
            }

            set
            {
                if (distance != value)
                {
                    distance = value;
                   // DoRequest();
                }
            }
        }

        public StationViewModel()
        {
            latitude = "45.185476";
            longitude = "5.727772";
            distance = 1000;
            DoRequest();
            FindLignes = new RelayCommand(DoRequest);
        }

        private void DoRequest()
        {
            DataLignesProximite dataLignesProximite = new DataLignesProximite(new ConnectApi());
            Dictionary<String, List<Ligne>> dicoLignesProximite = dataLignesProximite.GetDataDetailsLigneProximite(longitude, latitude, distance);
            Stations = ConvertInObsCollection(dicoLignesProximite);
        }

        private ObservableCollection<DataStation> ConvertInObsCollection(Dictionary<String, List<Ligne>> dicoLignes)
        {
            ObservableCollection<DataStation> listLignesProx = new ObservableCollection<DataStation>();
            foreach (KeyValuePair<String, List<Ligne>> kvp in dicoLignes)
            {
                DataStation data = new DataStation(kvp.Key, kvp.Value);
                listLignesProx.Add(data);
            }
            return listLignesProx;
        }

        public RelayCommand FindLignes { get; set; }

        //private static void RechercherLignes()
        //{
        //    DoRequest();
        //}
    }
}