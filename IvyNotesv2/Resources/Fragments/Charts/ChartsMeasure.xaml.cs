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
using IvyNotesv2.Database;
using System.Windows.Controls.DataVisualization.Charting;

namespace IvyNotesv2.Resources.Fragments.Charts
{
    /// <summary>
    /// Logique d'interaction pour ChartsMeasure.xaml
    /// </summary>
    public partial class ChartsMeasure : UserControl
    {
        public ChartsMeasure()
        {
            InitializeComponent();
            List<Database.Measure> measureList = MainWindow.INSTANCE.ctxMeasures.Measures.OrderBy(m => m.MeasureDT).ToList();
            ((LineSeries)PoidsChart.Series[0]).ItemsSource = measureList;
            ((LineSeries)TailleChart.Series[0]).ItemsSource = measureList;
        }
    }
}
