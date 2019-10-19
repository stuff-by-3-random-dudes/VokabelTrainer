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

namespace EnglischAbfrage
{
    
    public partial class TypeWindow : Window
    {
        private static int KapitelID { get; set; } = 0;
        public TypeWindow() 
        {
            InitializeComponent();
        }
        public TypeWindow(int kapitel)
        {
            InitializeComponent();
            KapitelID = kapitel;
        }
        private void Vokabel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(KapitelID);
            this.Visibility = Visibility.Hidden;
            mw.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void Synonym_Click(object sender, RoutedEventArgs e)
        {
            SYNWindow sw = new SYNWindow(KapitelID);
            this.Visibility = Visibility.Hidden;
            sw.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void Gegenteil_Click(object sender, RoutedEventArgs e)
        {
            OPPWindow ow = new OPPWindow(KapitelID);
            this.Visibility = Visibility.Hidden;
            ow.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void Kapitel_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            EnglischAbfrage.Windows.KapitelWindow kapitelWindow = new Windows.KapitelWindow();
            kapitelWindow.Show();
        }
    }
}
