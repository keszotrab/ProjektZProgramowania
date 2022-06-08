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

namespace ProjektZProgramowania
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           

        }

        private void Kat1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ///tutaj dodać linq
        }

        private void cartButton_Click(object sender, RoutedEventArgs e)
        {
            CartWindow Cart = new CartWindow();
            Cart.Show();

        }

        private void Kat2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // tu wyswietlanie konkretnej kategori
        }

        private void Kat3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // tu wyswietlanie konkretnej kategori
        }
    }



}
