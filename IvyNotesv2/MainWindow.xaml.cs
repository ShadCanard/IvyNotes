using IvyNotesv2.Database;
using IvyNotesv2.Resources.Fragments;
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

namespace IvyNotesv2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow INSTANCE;
        public List<Button> MenuCollection = new List<Button>();
        public List<UserControl> FragmentCollection = new List<UserControl>();
        public DiaperContext ctxDiapers = new DiaperContext();
        public FeedingBottleContext ctxBottles = new FeedingBottleContext();
        public MeasureContext ctxMeasures = new MeasureContext();

        public MainWindow()
        {
            InitializeComponent();
            INSTANCE = this;
            Main main = new Main();
            FragmentCollection.Add(main);
            MenuCollection.Add(FeedingBottle);
            MenuCollection.Add(Diapers);
            MenuCollection.Add(Measures);
            MenuCollection.Add(Home);
            OnHomeMenuClick(Home, new RoutedEventArgs());
        }

        private void OnBottleMenuClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            OnLoading(true);
            OnMenuClick((Button)sender);
            UserControl ctrlToLoad = new Resources.Fragments.FeedingBottle();
            bool fragExists = false;
            foreach (UserControl ctrl in FragmentCollection)
            {
                if(ctrl is Resources.Fragments.FeedingBottle)
                {
                    fragExists = true;
                    ctrlToLoad = ctrl;
                }
            }
            MainContent.Content = ctrlToLoad;
            if (!fragExists) FragmentCollection.Add(ctrlToLoad);
            OnLoading(false);
            Cursor = Cursors.Arrow;
        }

        private void OnDiapersMenuClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            OnMenuClick((Button)sender);
            OnLoading(true);
            UserControl ctrlToLoad = new Resources.Fragments.Diaper();
            bool fragExists = false;
            foreach (UserControl ctrl in FragmentCollection)
            {
                if (ctrl is Resources.Fragments.Diaper)
                {
                    fragExists = true;
                    ctrlToLoad = ctrl;
                }
            }
            MainContent.Content = ctrlToLoad;
            if (!fragExists) FragmentCollection.Add(ctrlToLoad);
            OnLoading(false);
            Cursor = Cursors.Arrow;
        }

        private void OnMeasureMenuClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            OnLoading(true);
            OnMenuClick((Button)sender);
            UserControl ctrlToLoad = new Resources.Fragments.Measure();
            bool fragExists = false;
            foreach (UserControl ctrl in FragmentCollection)
            {
                if (ctrl is Resources.Fragments.Measure)
                {
                    fragExists = true;
                    ctrlToLoad = ctrl;
                }
            }
            MainContent.Content = ctrlToLoad;
            if (!fragExists) FragmentCollection.Add(ctrlToLoad);
            OnLoading(false);
            Cursor = Cursors.Arrow;
        }

        private void OnMenuClick(Button sender)
        {
            foreach (Button button in MenuCollection)
            {
                button.Background = new SolidColorBrush(Colors.Transparent);
                button.BorderBrush = new SolidColorBrush(Colors.Transparent);
                button.BorderThickness = new Thickness(0);
            }
            sender.Background = new SolidColorBrush(Colors.LightBlue);
            sender.BorderBrush = new SolidColorBrush(Colors.LightGray);
            sender.BorderThickness = new Thickness(1);
        }

        private void OnHomeMenuClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            OnLoading(true);
            OnMenuClick((Button)sender);
            UserControl ctrlToLoad = new Resources.Fragments.Main();
            bool fragExists = false;
            foreach (UserControl ctrl in FragmentCollection)
            {
                if (ctrl is Resources.Fragments.Main)
                {
                    fragExists = true;
                    ctrlToLoad = ctrl;
                }
            }
            MainContent.Content = ctrlToLoad;
            if (!fragExists) FragmentCollection.Add(ctrlToLoad);
            OnLoading(false);
            Cursor = Cursors.Arrow;
        }

        public void OnLoading(bool isLoading)
        {
            LoadingCanvas.Visibility = (isLoading ? Visibility.Visible : Visibility.Hidden);
        }

        public void ChangeMainContent(UserControl control)
        {
            MainContent.Content = control;
        }

    }
}
