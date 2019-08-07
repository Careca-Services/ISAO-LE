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

using System.Threading;

namespace ISAO_LE_001
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        //Connexion conWin;
        MainWindow mainWin;
        bool Btcon_pushed;
        public Splash()
        {
            InitializeComponent();
            pbar.Value = 0;
            bt_connect.Visibility = Visibility.Hidden;
            pbar.Value = 10;
            bt_close.Visibility = Visibility.Hidden;

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pbar.Value == 100)
            {
                bt_connect.Visibility = Visibility.Visible;
                bt_close.Visibility = Visibility.Visible;
            }
        }

        private void SplashActivated(object sender, EventArgs e)
        {
            
        }

        private void SplashRendered(object sender,EventArgs e)
        {
            
            pbar.Value = 50;
            mainWin = new MainWindow();
            pbar.Value = 100;


        }

        private void Bt_ConnectOnClick(object sender, RoutedEventArgs e)
        {
            Btcon_pushed = true;
            mainWin.Show();
            Splash1.Close();
        }

        private void SplashClosed(object sender, EventArgs e)
        {
            if (!Btcon_pushed)
            {
                Application.Current.Shutdown();

            }
           

            
        }

        private void Bt_CloseOnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
