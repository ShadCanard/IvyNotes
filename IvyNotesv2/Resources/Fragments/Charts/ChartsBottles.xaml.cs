using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IvyNotesv2.Resources.Fragments.Charts
{
    /// <summary>
    /// Logique d'interaction pour ChartsBottles.xaml
    /// </summary>
    public partial class ChartsBottles : UserControl
    {
        /*        "Lait Maternel"
         *        "Lait Artificiel"
         *        "Mélange"
         *        "Allaitement maternel"
         */

        public ChartsBottles()
        {
            InitializeComponent();
            List<Database.FeedingBottle> bottles = MainWindow.INSTANCE.ctxBottles.FeedingBottles.ToList();
            int AM = bottles.Where(b => b.FeedingBottleType == "Allaitement maternel").Count();
            int LM = bottles.Where(b => b.FeedingBottleType == "Lait Maternel").Count();
            int Mix = bottles.Where(b => b.FeedingBottleType == "Mélange").Count();
            int LA = bottles.Where(b => b.FeedingBottleType == "Lait Artificiel").Count();
            ((PieSeries)ChartType.Series[0]).ItemsSource = new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string, int>("Allaitement Maternel",AM),
                new KeyValuePair<string, int>("Lait Maternel",LM),
                new KeyValuePair<string, int>("Mélange",Mix),
                new KeyValuePair<string, int>("Lait Artificiel",LA),

            };

            ((LineSeries)ChartQty.Series[0]).ItemsSource = bottles.Where(b => b.FeedingBottleType != "Allaitement Maternel");
        }
    }
}
