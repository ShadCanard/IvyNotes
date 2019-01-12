using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IvyNotesv2.Resources.Fragments
{
    /// <summary>
    /// Logique d'interaction pour DiaperElement.xaml
    /// </summary>
    public partial class DiaperElement : UserControl
    {
        public Database.Diaper diaper;
        public bool isEditing;
        public DiaperElement()
        {
            InitializeComponent();
            DatePick.SelectedDate = DateTime.Now;
            HourPick.Time = new RoyT.TimePicker.DigitalTime(DateTime.Now.Hour, DateTime.Now.Minute);
            isEditing = false;
            HourPick.MinTime = new RoyT.TimePicker.DigitalTime(00, 00);
            HourPick.MaxTime = new RoyT.TimePicker.DigitalTime(23, 45);
        }

        public DiaperElement(Database.Diaper diaperIn)
        {
            InitializeComponent();
            HourPick.MinTime = new RoyT.TimePicker.DigitalTime(00, 00);
            HourPick.MaxTime = new RoyT.TimePicker.DigitalTime(23, 45);

            isEditing = true;
            diaper = diaperIn;
            DatePick.SelectedDate = new DateTime(diaper.DiaperDT.Year, diaper.DiaperDT.Month, diaper.DiaperDT.Day);
            HourPick.Time = new RoyT.TimePicker.DigitalTime(diaper.DiaperDT.Hour, diaper.DiaperDT.Minute);
            HasPoop.IsChecked = diaper.DiaperHasPoop;
            HasPee.IsChecked = diaper.DiaperHasPee;
            Comments.Text = diaper.DiaperComments;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                Database.Diaper diaperOut = MainWindow.INSTANCE.ctxDiapers.Diapers.Where(d => d.DiaperID == diaper.DiaperID).First();
                diaper.DiaperComments = Comments.Text;
                diaper.DiaperDT = new DateTime(DatePick.SelectedDate.Value.Year, DatePick.SelectedDate.Value.Month, DatePick.SelectedDate.Value.Day, HourPick.Time.Hour, HourPick.Time.Minute, 0);
                diaper.DiaperHasPee = HasPee.IsChecked.Value;
                diaper.DiaperHasPoop = HasPoop.IsChecked.Value;
                diaperOut = diaper;
                MainWindow.INSTANCE.ctxDiapers.SaveChanges();
            }
            else
            {
                diaper = new Database.Diaper()
                {
                    DiaperComments = Comments.Text,
                    DiaperDT = new DateTime(DatePick.SelectedDate.Value.Year, DatePick.SelectedDate.Value.Month, DatePick.SelectedDate.Value.Day, HourPick.Time.Hour, HourPick.Time.Minute, 0),
                    DiaperHasPee = HasPee.IsChecked.Value,
                    DiaperHasPoop = HasPoop.IsChecked.Value
                };
                MainWindow.INSTANCE.ctxDiapers.Diapers.Add(diaper);
                MainWindow.INSTANCE.ctxDiapers.SaveChanges();
            }
            foreach (UserControl ctrl in MainWindow.INSTANCE.FragmentCollection)
            {
                if(ctrl is Diaper)
                {
                    Cursor = Cursors.Wait;
                    ((Diaper)ctrl).LoadDiapers();
                    MainWindow.INSTANCE.ChangeMainContent(ctrl);
                    Cursor = Cursors.Arrow;
                }
            }
        }
    }
}
