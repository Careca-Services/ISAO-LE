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

using System.Threading;

namespace ISAO_LE_002
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        
        public Splash()
        {
            
            InitializeComponent();
            //this.Title = Assembly.GetExecutingAssembly().GetName().Name;
            lversion.Content = "version : "+ Assembly.GetExecutingAssembly().GetName().Version;
            pbar.Value = 0;
            

        }

        


       
    }
}
