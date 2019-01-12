using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            if (lvDiapers.SelectedItem != null)
            {
                Cursor = Cursors.Wait;
                MainWindow.INSTANCE.ctxDiapers.Diapers.Remove((Database.Diaper)lvDiapers.SelectedItem);
                MainWindow.INSTANCE.ctxDiapers.SaveChanges();
                LoadDiapers();
                Cursor = Cursors.Arrow;
            }
        }
        private void NewClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            MainWindow.INSTANCE.ChangeMainContent(new DiaperElement());
            Cursor = Cursors.Arrow;
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            MainWindow.INSTANCE.ChangeMainContent(new DiaperElement((Database.Diaper)lvDiapers.SelectedItem));
            Cursor = Cursors.Arrow;
        }
    }
}
