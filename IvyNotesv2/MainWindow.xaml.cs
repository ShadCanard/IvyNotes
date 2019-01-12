using IvyNotesv2.Database;
using IvyNotesv2.Resources.Fragments;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
        public IvyContext ctxDiapers = new IvyContext();
        public IvyContext ctxBottles = new IvyContext();
        public IvyContext ctxMeasures = new IvyContext();

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
            MenuCollection.Add(Parameters);
            OnHomeMenuClick(Home, new RoutedEventArgs());
        }

        private void OnBottleMenuClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
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
            Cursor = Cursors.Arrow;
        }

        private void OnDiapersMenuClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            OnMenuClick((Button)sender);
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
            Cursor = Cursors.Arrow;
        }

        private void OnMeasureMenuClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
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
            Cursor = Cursors.Arrow;
        }
        
        public void ChangeMainContent(UserControl control)
        {
            MainContent.Content = control;
        }

        private void OnParametersMenuClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            OnMenuClick((Button)sender);
            UserControl ctrlToLoad = new Settings();
            bool fragExists = false;
            foreach (UserControl ctrl in FragmentCollection)
            {
                if (ctrl is Settings)
                {
                    fragExists = true;
                    ctrlToLoad = ctrl;
                }
            }
            MainContent.Content = ctrlToLoad;
            if (!fragExists) FragmentCollection.Add(ctrlToLoad);
            Cursor = Cursors.Arrow;
        }
    }
}
