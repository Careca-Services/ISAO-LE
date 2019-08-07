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
using System.Windows.Threading;




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
        AboutBox1 aideWin;
        ConfigDiag conf_diagWin;
        InfoDiag infoDiagWin;
        Connexion conWin;

        TextBox[] dynTbox1;
        TextBox[] dynTbox2;
        TextBox[] dynTbox3;

        public MainWindow()
        {
            InitializeComponent();
            //--------------- windows-------
            conWin = new Connexion();
            conWin.Closing += Hidde;

            aideWin = new AboutBox1();
            aideWin.FormClosing += aboutHidde;

            infoDiagWin = new InfoDiag();
            infoDiagWin.Closing += Hidde;

            conf_diagWin = new ConfigDiag();
            conf_diagWin.Closing += Hidde;

            //---------------Init-------------------

            //diagconfig
            int max = 10;
            dynTbox1 = new TextBox[max];
            dynTbox2 = new TextBox[max];
            dynTbox3 = new TextBox[max];

            conf_diagWin.stack1.Children.Clear();
            conf_diagWin.stack2.Children.Clear();
            conf_diagWin.stack3.Children.Clear();

            for (int i = 0; i < max; i++) {
                dynTbox1[i] = new TextBox();
                dynTbox1[i].Name = "st1tb"+i;
                dynTbox1[i].Height = 23;
                dynTbox1[i].Text = "";
                conf_diagWin.stack1.Children.Add(dynTbox1[i]);
                    }
            for (int i = 0; i < max; i++)
            {
                dynTbox1[i] = new TextBox();
                dynTbox1[i].Name = "st2tb" + i;
                dynTbox1[i].Height = 23;
                dynTbox1[i].Text = "";
                conf_diagWin.stack2.Children.Add(dynTbox1[i]);
            }
            for (int i = 0; i < max; i++)
            {
                dynTbox1[i] = new TextBox();
                dynTbox1[i].Name = "st3tb" + i;
                dynTbox1[i].Height = 23;
                dynTbox1[i].Text = "";
                conf_diagWin.stack3.Children.Add(dynTbox1[i]);
            }

            // gestionaire d'evennement temporisé
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += routine;
            timer.Start();

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

        private void BtAideOnClick(object sender, RoutedEventArgs e)
        {

            
            aideWin.Show();
        }

        private void mainWinOnClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtConfDiagOnClick(object sender, RoutedEventArgs e)
        {
            conf_diagWin.Show();
        }

        private void Bt_diag_Click(object sender, RoutedEventArgs e)
        {

            infoDiagWin.Show();
           
        }

        public void BtConnexion(object sender, EventArgs e)
        {

        }


        //--------------------------- fondtion utile -----------------

            /// <summary>
            /// Cette methode sera appellé toutes les seconde
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        public void routine(object sender, EventArgs e)
        {
            
            if (App.PlcOnline())
            {
                bt_connexion.IsEnabled = false;
                alarm_box.Text = "API connecté";
                bt_valider.IsEnabled = true;
                //#FF C1 EE EA
                bt_valider.Background = new SolidColorBrush(Color.FromArgb(0xFF,0xC1,0xEE,0xEA));
                bt_deconnexion.IsEnabled = true;
                bt_deconnexion.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xC1, 0xEE, 0xEA));
            }
            else
            {
                bt_connexion.IsEnabled = true;
                alarm_box.Text = "API no connecté";
                bt_valider.IsEnabled = false;
                //"#FF EF F0 F0"
                bt_valider.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEF, 0xF0,0xF0));
                bt_deconnexion.IsEnabled = false;
                bt_deconnexion.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEF, 0xF0, 0xF0));

            }
        }

        private void mainActivated(object sender, EventArgs e)
        {
            


        }

        private void BtConnexion(object sender, RoutedEventArgs e)
        {
            conWin.Show();
        }

        public void Hidde(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Window w = (Window)sender;
           w.Visibility = Visibility.Hidden;
        }
        private void aboutHidde(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            AboutBox1 a = (AboutBox1)sender;
            a.Hide();

        }

        private void BtDeConnexion(object sender, RoutedEventArgs e)
        {
            App.PlcClose();
        }
    }
}
