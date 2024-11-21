using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkeletonRzut
{
    public partial class MainWindow : Window
    {
        private int liczbaKostek = 1;
        private int liczbaScian = 4;
        private int wynikOgolnyWartosc = 0;
        private static Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            liczbaKostekValue.Text = liczbaKostek.ToString();
            liczbaScianValue.Text = liczbaScian.ToString();
        }

        private void LiczbaKostekSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (liczbaKostekValue != null)
            {
                liczbaKostek = (int)e.NewValue;
                liczbaKostekValue.Text = liczbaKostek.ToString();
            }
        }

        private void LiczbaScianSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (liczbaScianValue != null)
            {
                liczbaScian = (int)e.NewValue;
                liczbaScianValue.Text = liczbaScian.ToString();
            }
        }

        private void RzucKostkami_Click(object sender, RoutedEventArgs e)
        {
            wynikiPanel.Children.Clear();
            int wynikAktualnyRzut = 0;

            for (int i = 0; i < liczbaKostek; i++)
            {
                int rzut = rand.Next(1, liczbaScian + 1);
                wynikAktualnyRzut += rzut;
                TextBlock wynikTextBlock = new TextBlock
                {
                    Text = rzut.ToString(),
                    Margin = new Thickness(5)
                };
                wynikiPanel.Children.Add(wynikTextBlock);
            }

            wynikOgolnyWartosc += wynikAktualnyRzut;
            wynikAktualny.Text = $"Wynik aktualnego rzutu: {wynikAktualnyRzut}";
            wynikOgolny.Text = $"Wynik ogólny: {wynikOgolnyWartosc}";
        }

        private void ResetujWynik_Click(object sender, RoutedEventArgs e)
        {
            wynikOgolnyWartosc = 0;
            wynikOgolny.Text = "Wynik ogólny: 0";
        }
    }
}
