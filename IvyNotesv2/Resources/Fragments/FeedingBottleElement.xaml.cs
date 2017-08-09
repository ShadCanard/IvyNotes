using IvyNotesv2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour FeedingBottleElement.xaml
    /// </summary>
    public partial class FeedingBottleElement : UserControl
    {
        public Database.FeedingBottle bottle;
        public bool isEditing;

        public FeedingBottleElement()
        {
            InitializeComponent();
            PopulateComboBox();
            isEditing = false;
            DatePick.SelectedDate = DateTime.Now;
            HourPick.Time = new RoyT.TimePicker.DigitalTime(DateTime.Now.Hour, DateTime.Now.Minute);
            HourPick.MinTime = new RoyT.TimePicker.DigitalTime(00, 00);
            HourPick.MaxTime = new RoyT.TimePicker.DigitalTime(23, 45);

        }

        private void PopulateComboBox()
        {
            cbxType.Items.Add("Lait Maternel");
            cbxType.Items.Add("Lait Artificiel");
            cbxType.Items.Add("Mélange");
            cbxType.Items.Add("Allaitement maternel");
        }

        public FeedingBottleElement(Database.FeedingBottle bottleIn)
        {
            InitializeComponent();
            PopulateComboBox();
            HourPick.MinTime = new RoyT.TimePicker.DigitalTime(00, 00);
            HourPick.MaxTime = new RoyT.TimePicker.DigitalTime(23, 45);
            isEditing = true;
            bottle = bottleIn;
            DatePick.SelectedDate = new DateTime(bottle.FeedingBottleDT.Year, bottle.FeedingBottleDT.Month, bottle.FeedingBottleDT.Day);
            HourPick.Time = new RoyT.TimePicker.DigitalTime(bottle.FeedingBottleDT.Hour, bottle.FeedingBottleDT.Minute);
            txtQty.Text = bottle.FeedingBottleQuantity.ToString();
            Comments.Text = bottle.FeedingBottleComments;
            cbxType.SelectedItem = bottle.FeedingBottleType;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbxType.SelectedItem == null || cbxType.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Merci de vouloir sélectionner un type de repas", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (isEditing)
                {
                    Database.FeedingBottle bottleOut = MainWindow.INSTANCE.ctxBottles.FeedingBottles.Where(fb => fb.FeedingBottleID == bottle.FeedingBottleID).First();
                    bottle.FeedingBottleDT = new DateTime(DatePick.SelectedDate.Value.Year, DatePick.SelectedDate.Value.Month, DatePick.SelectedDate.Value.Day, HourPick.Time.Hour, HourPick.Time.Minute, 0);
                    bottle.FeedingBottleComments = Comments.Text;
                    bottle.FeedingBottleType = cbxType.SelectedItem.ToString();
                    bottle.FeedingBottleQuantity = (cbxType.SelectedItem.ToString() == "Allaitement maternel" ? 0 : Convert.ToInt32(txtQty.Text));
                    bottleOut = bottle;
                    MainWindow.INSTANCE.ctxBottles.SaveChanges();
                }
                else
                {
                    bottle = new Database.FeedingBottle()
                    {
                        FeedingBottleDT = new DateTime(DatePick.SelectedDate.Value.Year, DatePick.SelectedDate.Value.Month, DatePick.SelectedDate.Value.Day, HourPick.Time.Hour, HourPick.Time.Minute, 0),
                        FeedingBottleComments = Comments.Text,
                        FeedingBottleType = cbxType.SelectedItem.ToString(),
                        FeedingBottleQuantity = (cbxType.SelectedItem.ToString() == "Allaitement maternel" ? 0 : Convert.ToInt32(txtQty.Text))
                    };
                    MainWindow.INSTANCE.ctxBottles.FeedingBottles.Add(bottle);
                    MainWindow.INSTANCE.ctxBottles.SaveChanges();
                }
                foreach (UserControl ctrl in MainWindow.INSTANCE.FragmentCollection)
                {
                    if (ctrl is FeedingBottle)
                    {
                        Cursor = Cursors.Wait;
                        MainWindow.INSTANCE.OnLoading(true);
                        ((FeedingBottle)ctrl).LoadBottles();
                        MainWindow.INSTANCE.ChangeMainContent(ctrl);
                        MainWindow.INSTANCE.OnLoading(false);
                        Cursor = Cursors.Arrow;
                    }
                }
            }
        }

        private bool isInputOk(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void OnTextInput(object sender, KeyEventArgs e)
        {
            if (!isInputOk(txtQty.Text))
            {
                txtQty.Text = txtQty.Text.Substring(0, txtQty.Text.Length - 1);
                txtQty.CaretIndex = txtQty.Text.Length;
            }
        }
    }
}