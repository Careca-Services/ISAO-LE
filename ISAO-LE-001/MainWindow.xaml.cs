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



namespace ISAO_LE_001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListBoxItem data_type_item;
        int adress;
        int start_p;
        int nb_data;
        public MainWindow()
        {
            InitializeComponent();
            if(App.diag_status)
            {
                diag_ok.Visibility = Visibility.Visible;
                diag_nok.Visibility = Visibility.Hidden;
            }
            else
            {
                diag_nok.Visibility = Visibility.Visible;
                diag_ok.Visibility = Visibility.Hidden;

            }
        }

        private void ListCpu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtValiderOnClick(object sender, RoutedEventArgs e)
        {
            adress = int.Parse(addr_box.Text);
            start_p = int.Parse(start_point_box.Text);
            nb_data = int.Parse(nb_box.Text);

            data_type_item = list_data_type.SelectedItem as ListBoxItem;
            if(data_type_item == null)
            {
                MessageBox.Show("Aucun type de données selectionées", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (start_p < 0)
            {
                MessageBox.Show("Point de depart d'adresse incorecte ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (nb_data < 0)
            {
                MessageBox.Show("Nombre des donées  incorrecte ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string dtype = data_type_item.Content.ToString();
            byte[] data =(byte[]) App.LectureDataBytes(dtypeCode(dtype),adress,start_p,nb_data);

            AffichageDonnees(data);

        }

        private void AffichageDonnees(byte [] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                list_data.Items.Add(new ListBoxItem() { Content = "Type :"+data_type_item.Content.ToString()+" "+adress+"."+start_p+" byte[" + i + "] = " + data[i] });
            }
        }

        private S7.Net.DataType dtypeCode(string s)
        {
            switch (s)
            {
                case "Entrées":
                    return S7.Net.DataType.Input;
                case "Sorties":
                    return S7.Net.DataType.Output;
                case "Memoire":
                    return S7.Net.DataType.Memory;
                case "Block de donéees":
                    return S7.Net.DataType.DataBlock;
                case "Timer":
                    return S7.Net.DataType.Timer;
                case "Compteur":
                    return S7.Net.DataType.Counter;
                default:
                    return S7.Net.DataType.DataBlock;
            }
        }
    }
}
