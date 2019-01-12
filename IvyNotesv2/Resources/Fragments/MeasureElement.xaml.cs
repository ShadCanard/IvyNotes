using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IvyNotesv2.Resources.Fragments
{
    /// <summary>
    /// Logique d'interaction pour MeasureElement.xaml
    /// </summary>
    public partial class MeasureElement : UserControl
    {
        public Database.Measure measure;
        public bool IsEditing;
        public MeasureElement()
        {
            InitializeComponent();
            IsEditing = false;
            DatePick.SelectedDate = DateTime.Now;
            HourPick.Time = new RoyT.TimePicker.DigitalTime(DateTime.Now.Hour, DateTime.Now.Minute);
            HourPick.MinTime = new RoyT.TimePicker.DigitalTime(00, 00);
            HourPick.MaxTime = new RoyT.TimePicker.DigitalTime(23, 45);

        }

        public MeasureElement(Database.Measure measureIn)
        {
            InitializeComponent();
            IsEditing = true;
            measure = measureIn;
            txtHeight.Text = measure.MeasureValueHeight.ToString();
            txtWeight.Text = measure.MeasureValueWeight.ToString();
            Comments.Text = measure.MeasureComments;
            DatePick.SelectedDate = new DateTime(measure.MeasureDT.Year, measure.MeasureDT.Month, measure.MeasureDT.Day);
            HourPick.Time = new RoyT.TimePicker.DigitalTime(measure.MeasureDT.Hour, measure.MeasureDT.Minute);
            HourPick.MinTime = new RoyT.TimePicker.DigitalTime(00, 00);
            HourPick.MaxTime = new RoyT.TimePicker.DigitalTime(23, 45);

        }

        private bool isInputOk(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void OnTextInput(object sender, KeyEventArgs e)
        {
            if (!isInputOk(txtWeight.Text))
            {
                txtWeight.Text = txtWeight.Text.Substring(0, txtWeight.Text.Length - 1);
                txtWeight.CaretIndex = txtWeight.Text.Length;
            }
            if (!isInputOk(txtHeight.Text))
            {
                txtHeight.Text = txtHeight.Text.Substring(0, txtHeight.Text.Length - 1);
                txtHeight.CaretIndex = txtHeight.Text.Length;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditing)
            {
                Database.Measure measureOut = MainWindow.INSTANCE.ctxMeasures.Measures.Where(m => m.MeasureID == measure.MeasureID).First();
                measure.MeasureDT = new DateTime(DatePick.SelectedDate.Value.Year, DatePick.SelectedDate.Value.Month, DatePick.SelectedDate.Value.Day, HourPick.Time.Hour, HourPick.Time.Minute, 0);
                measure.MeasureComments = Comments.Text;
                measure.MeasureValueHeight = Convert.ToInt32(txtHeight.Text);
                measure.MeasureValueWeight = Convert.ToInt32(txtWeight.Text);
                measureOut = measure;
                MainWindow.INSTANCE.ctxMeasures.SaveChanges();
            }
            else
            {
                measure = new Database.Measure()
                {
                    MeasureDT = new DateTime(DatePick.SelectedDate.Value.Year, DatePick.SelectedDate.Value.Month, DatePick.SelectedDate.Value.Day, HourPick.Time.Hour, HourPick.Time.Minute, 0),
                    MeasureComments = Comments.Text,
                    MeasureValueHeight = Convert.ToInt32(txtHeight.Text),
                    MeasureValueWeight = Convert.ToInt32(txtWeight.Text)
                };
                MainWindow.INSTANCE.ctxMeasures.Measures.Add(measure);
                MainWindow.INSTANCE.ctxMeasures.SaveChanges();
            }
            foreach (UserControl ctrl in MainWindow.INSTANCE.FragmentCollection)
            {
                if (ctrl is Measure)
                {
                    Cursor = Cursors.Wait;
                    ((Measure)ctrl).LoadMeasures();
                    MainWindow.INSTANCE.ChangeMainContent(ctrl);
                    Cursor = Cursors.Arrow;
                }
            }
        }
    }
}
