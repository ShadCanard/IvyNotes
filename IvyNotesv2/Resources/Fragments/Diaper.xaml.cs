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

namespace IvyNotesv2.Resources.Fragments
{
    /// <summary>
    /// Logique d'interaction pour Diaper.xaml
    /// </summary>
    public partial class Diaper : UserControl
    {
        public Diaper()
        {
            InitializeComponent();
            LoadDiapers();
        }

        public void LoadDiapers()
        {
            Cursor = Cursors.Wait;
            lvDiapers.ItemsSource = MainWindow.INSTANCE.ctxDiapers.Diapers.OrderBy(d => d.DiaperDT).ToList();
            lvDiapers.Items.Refresh();
            Cursor = Cursors.Arrow;
        }

        private void OnStatisticsClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bientôt !");
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            if(lvDiapers.SelectedItem != null)
            {
            MainWindow.INSTANCE.ctxDiapers.Diapers.Remove((Database.Diaper)lvDiapers.SelectedItem);
            MainWindow.INSTANCE.ctxDiapers.SaveChanges();
            LoadDiapers();
            }
        }
        private void NewClick(object sender, RoutedEventArgs e)
        {
            MainWindow.INSTANCE.ChangeMainContent(new DiaperElement());
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            MainWindow.INSTANCE.ChangeMainContent(new DiaperElement((Database.Diaper)lvDiapers.SelectedItem));
        }
    }
}
