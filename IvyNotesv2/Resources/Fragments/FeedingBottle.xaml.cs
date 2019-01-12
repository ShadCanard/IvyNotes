using IvyNotesv2.Resources.Fragments.Charts;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IvyNotesv2.Resources.Fragments
{
    /// <summary>
    /// Logique d'interaction pour FeedingBottle.xaml
    /// </summary>
    public partial class FeedingBottle : UserControl
    {
        public FeedingBottle()
        {
            InitializeComponent();
            LoadBottles();
        }
        public void LoadBottles()
        {
            Cursor = Cursors.Wait;
            lvBottles.ItemsSource = MainWindow.INSTANCE.ctxBottles.FeedingBottles.OrderBy(fb => fb.FeedingBottleDT).ToList();
            lvBottles.Items.Refresh();
            Cursor = Cursors.Arrow;
        }
        private void OnStatisticsClick(object sender, RoutedEventArgs e)
        {
            MainWindow.INSTANCE.ChangeMainContent(new ChartsBottles());
        }
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            if (lvBottles.SelectedItem != null)
            {
                Cursor = Cursors.Wait;
                MainWindow.INSTANCE.ctxBottles.FeedingBottles.Remove((Database.FeedingBottle)lvBottles.SelectedItem);
                MainWindow.INSTANCE.ctxBottles.SaveChanges();
                LoadBottles();
                Cursor = Cursors.Arrow;
            }
        }
        private void NewClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            MainWindow.INSTANCE.ChangeMainContent(new FeedingBottleElement());
            Cursor = Cursors.Arrow;
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            if (lvBottles.SelectedItem != null) MainWindow.INSTANCE.ChangeMainContent(new FeedingBottleElement((Database.FeedingBottle)lvBottles.SelectedItem));
            Cursor = Cursors.Arrow;
        }
    }
}
