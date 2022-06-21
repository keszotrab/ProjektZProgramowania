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


            if (customerName.Text != "" && customerSurename.Text != "" && customerHomeAddress.Text != "" && customerEmail.Text != "" && prod !="")
            {


                using (Projekt_ProgObEntities context = new Projekt_ProgObEntities())
                {
                    Dane_Osobowe daneOs = new Dane_Osobowe()
                    {
                        Imie = customerName.Text,
                        Nazwisko = customerSurename.Text,
                        Adres = customerHomeAddress.Text,
                        Adres_dost = customerDeliveryAddress.Text,
                        Email = customerEmail.Text

                    };
                    context.Dane_Osobowe.Add(daneOs);
                    
                    if (daneOs.Adres_dost == null)
                    {
                        daneOs.Adres_dost =daneOs.Adres;
                    }

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

                //czyszczenie listy i zamkniecie okna w celu unikniecia kupienia produktow wielekrotnie
                mw.buyList.Clear();
                Close();
                string messageBoxText = "Przedmioty zostały zakupione";
                string caption = "Friendly reminder";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                if (prod == "")
                {
                    string messageBoxText = "Nie wybrano żadnych produktów";
                    string caption = "Friendly reminder";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                }

                if (customerName.Text == "" || customerSurename.Text == "" || customerHomeAddress.Text == "" || customerEmail.Text == "")
                {
                    string messageBoxText = "Uzupełniej dane osobowe! (Jeślli adres dostawy jest taki sam jak zamieszkania możesz zostawić pole puste)";
                    string caption = "Friendly reminder";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }


            }
        }
    }
}
