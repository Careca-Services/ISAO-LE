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
using System.Reflection;
using System.Collections.ObjectModel;

namespace ISAO_LE_002
{
    /// <summary>
    /// Interaction logic for Aide.xaml
    /// </summary>
    public partial class Aide : Window
    {
        public Aide()
        {
            InitializeComponent();
            this.Title = Assembly.GetExecutingAssembly().GetName().Name + "- Aide";

            MenuItem root = new MenuItem() { Title = "Aides" };

            root.child = new MenuItem() { Title = "Introduction" };
            root.child.Items.Add(new MenuItem() { Title = "Presentation produit" });
            root.child.Items.Add(new MenuItem() { Title = "Secteur" });
            //root.Items.Add(childItem1);
            // root.Items.Add(new MenuItem() { Title = "Child item #2" });
            root.Items.Add(root.child);
            trMenu.Items.Add(root);
        }

        public class MenuItem
        {
            public MenuItem()
            {
                this.Items = new ObservableCollection<MenuItem>();
                
            }

            public string Title { get; set; }
            public MenuItem child {
                get;
                set;
            }

            public ObservableCollection<MenuItem> Items { get; set; }
            
        }
        
    }
}
