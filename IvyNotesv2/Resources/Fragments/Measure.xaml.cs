using IvyNotesv2.Resources.Fragments.Charts;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IvyNotesv2.Resources.Fragments
{
    /// <summary>
    /// Logique d'interaction pour Measure.xaml
    /// </summary>
    public partial class Measure : UserControl
    {
        public Measure()
        {
            InitializeComponent();
            LoadMeasures();
        }

        public void LoadMeasures()
        {
            Cursor = Cursors.Wait;
            lvMeasures.ItemsSource = MainWindow.INSTANCE.ctxMeasures.Measures.OrderBy(m => m.MeasureDT).ToList();
            lvMeasures.Items.Refresh();
            Cursor = Cursors.Arrow;
        }

        private void OnStatisticsClick(object sender, RoutedEventArgs e)
        {
            MainWindow.INSTANCE.ChangeMainContent(new ChartsMeasure());
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            if (lvMeasures.SelectedItem != null)
            {
                Cursor = Cursors.Wait;
                MainWindow.INSTANCE.ctxMeasures.Measures.Remove((Database.Measure)lvMeasures.SelectedItem);
                MainWindow.INSTANCE.ctxMeasures.SaveChanges();
                LoadMeasures();
                Cursor = Cursors.Arrow;
            }
        }
        private void NewClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            MainWindow.INSTANCE.ChangeMainContent(new MeasureElement());
            Cursor = Cursors.Arrow;
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            MainWindow.INSTANCE.ChangeMainContent(new MeasureElement((Database.Measure)lvMeasures.SelectedItem));
            Cursor = Cursors.Arrow;
        }
    }
}
