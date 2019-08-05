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
using System.Windows.Shapes;

namespace ISAO_LE_001
{
    
    /// <summary>
    /// Interaction logic for Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {

        MainWindow mainWin;
        bool bt_valPushed;

        public Connexion()
        {
            InitializeComponent();
            mainWin = new MainWindow();
        }

        private void Bt_valider_con_Click(object sender, RoutedEventArgs e)
        {
            bt_valPushed = true;
            ListBoxItem s_item = listCpu.SelectedItem as ListBoxItem;

            //Gestion des erreurs
            if (s_item == null) {
                MessageBox.Show("Slectionez le type de CPU", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if(ip_box.Text =="0.0.0.0")
            {
                MessageBox.Show("Adresse IP invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (short.Parse(rack_box.Text) < 0)
            {
                MessageBox.Show("La valeur de Rack invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            if (short.Parse(slot_box.Text) < 1)
            {
                MessageBox.Show("La valeur de Slot invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            //---------------

            //DataGridRow 
            //MessageBox.Show(s_item.Content.ToString());
            S7.Net.CpuType cpu_type_code = cpuTypeCode(s_item.Content.ToString());

            bool status = App.Connexion(cpu_type_code,ip_box.Text,short.Parse(rack_box.Text),short.Parse(slot_box.Text));
            if (status)
            {
                mainWin.Show();
                conWin.Close();
            }
            
            
        }

        private S7.Net.CpuType cpuTypeCode(string s)
        {
            switch (s)
            {
                case "S7-200":
                    return S7.Net.CpuType.S7200;
                case "S7-300":
                    return S7.Net.CpuType.S7300;
                case "S7-400":
                    return S7.Net.CpuType.S7400;
                case "S7-1200":
                    return S7.Net.CpuType.S71200;
                case "S7-1500":
                    return S7.Net.CpuType.S71500;
                 
                case "Logo-0BA8":
                    return S7.Net.CpuType.Logo0BA8;
                   
                default:
                    return S7.Net.CpuType.S7300;

            }
        }

        private void ListCpu_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void conWinOnClosed(object sender, EventArgs e)
        {
            if (!bt_valPushed)
            {
                Application.Current.Shutdown();

            }
        }


    }
}
