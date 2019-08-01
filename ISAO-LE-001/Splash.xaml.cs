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
        MainWindow m;
        bool Btcon_pushed;
        public Splash()
        {
            InitializeComponent();
            m = new MainWindow();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SplashActivated(object sender, EventArgs e)
        {
            
        }

        private void SplashRendered(object sender,EventArgs e)
        {
            for (int i = 0; i < 101; i++)
            {
                pbar.Value = i;
                Thread.Sleep(10);

            }
            bt_connect.Visibility = Visibility.Visible;
          
            
        }

        private void Bt_ConnectOnClick(object sender, RoutedEventArgs e)
        {
            Btcon_pushed = true;
            m.Show();
            Splash1.Close();
        }

        private void SplashClosed(object sender, EventArgs e)
        {
            if (!Btcon_pushed) m.Close();
           

            
        }
    }
}
