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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace ProjektZProgramowania
{

    public partial class CartWindow : Window
    {

        public CartWindow()
        {
            InitializeComponent();
        }

        private void clearCartButton_Click(object sender, RoutedEventArgs e)
        {
            var mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mw.buyList.Clear();
            Close();
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            var mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            string prod = "";
            foreach (var item in mw.buyList)
            {
                prod += item;
                prod += " ";
            }



            using (Projekt_ProgObEntities context = new Projekt_ProgObEntities())
            {
                Dane_Osobowe daneOs = new Dane_Osobowe()
                {
                    Imie = customerName.Text,
                    Nazwisko = customerSurename.Text,
                    Adres = customerHomeAddress.Text,
                    Adres_dost= customerDeliveryAddress.Text,
                    Email = customerEmail.Text

                };
                context.Dane_Osobowe.Add(daneOs);

                Transakcje transakcje = new Transakcje()
                {
                    Id_dane = daneOs.Id,
                    Status = "w trakcie",
                    Kwota = mw.totalCostNumber,
                    Produkty = prod
                };
                context.Transakcje.Add(transakcje);
                context.SaveChanges();

            }











        }
    }
}
