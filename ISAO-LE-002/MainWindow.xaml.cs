using System;
using System.Collections.Generic;
using System.Reflection;
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
using System.Windows.Threading;
using System.ComponentModel;
using Sharp7;

namespace ISAO_LE_002
{
    
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Windows
        Splash sp;
        Aide aideWin;

        //---
        DispatcherTimer dsp;
        Log info;

        string uriBtOn;
        string uriBtOFF;

        //
        




        static bool tmp=false;
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            this.Title = Assembly.GetExecutingAssembly().GetName().Name+"- Accueil";
            sp = new Splash();
            sp.Show();
            sp.pbar.Value = 0;
            // plusieurs tests
            info = new Log();

            //log.ItemsSource = info;
            log.Items.Add(new Log().messageInfo("Programme demaré"));
            log.Items.Add(new Log().messageInfo("API non connecté"));
            log.Items.Add(new Log().messageInfo("configuration absente"));

            // bar 50%
            aideWin = new Aide();
            aideWin.Closing += OnClosingHide;
            sp.pbar.Value = 50;

            

            

            // button img 
            uriBtOn = @"pack://application:,,,/buttons/buttonON.png";
            uriBtOFF = @"pack://application:,,,/buttons/buttonOFF.png";

            //timer
            dsp = new DispatcherTimer();
            dsp.Tick += new EventHandler(hTimer);
            dsp.Interval = new TimeSpan(0, 0, 5);
            dsp.Start();

            //une attente pour fermeture splash



            //
            // bar = 100%
            sp.pbar.Value = 100;

        }

        public void hTimer(object sender, EventArgs e)
        {
            
            if (!tmp)
            {
                tmp = true;
                sp.Close();
                this.Visibility = Visibility.Visible;
            }
        }

        private void BtOnMouse(object sender, MouseEventArgs e)
        {
          
            //btImgaide.ImageSource = new ImageSourceConverter().ConvertFromString(uriBtOn) as ImageSource;
        }

        private void BtOFMouse(object sender, MouseEventArgs e)
        {
            //btImgaide.ImageSource = new ImageSourceConverter().ConvertFromString(uriBtOn) as ImageSource;
        }

        private void Btaide_Click(object sender, RoutedEventArgs e)
        {
            
            aideWin.Show();
            
        }

        void OnClosingHide(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Window w = sender as Window;
            w.Hide();
        }

        private void mainClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    class Log
    {

        static int code =0;
        public int id { get; set; }
        public String time { get; set; }
        public String message { get; set; }
        public String type { get; set; }

        public Log()
        {
            code++;
            id = code;
        }
        public void Message(String message, String type)
        {
            // timestamp
            time = DateTime.Now.ToString("ddMMyyHHmmss");
            this.message = message;
            this.type = type;
            
            
           
        }

        public Log messageInfo(String message)
        {
            // timestamp
            time = DateTime.Now.ToString("ddMMyyHHmmss");
            this.message = message;
            this.type = LogType.INFO;

            return this;



        }

        public Log messageWarn(String message)
        {
            // timestamp
            time = DateTime.Now.ToString("ddMMyyHHmmss");
            this.message = message;
            this.type = LogType.WARN;

            return this;



        }

        public Log messageErr(String message)
        {
            // timestamp
            time = DateTime.Now.ToString("ddMMyyHHmmss");
            this.message = message;
            this.type = LogType.ERR;

            return this;



        }

        










    }

    static class LogType
    {

        public static readonly String WARN = "WARN";
        public static readonly String ERR = "ERR";
        public static readonly String INFO = "INFO";

        
    }

    
}
