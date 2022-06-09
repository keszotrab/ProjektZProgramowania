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
using System.Xml.Linq;

namespace ProjektZProgramowania
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    //[Table(Name = "Users")]
    public class Produkt
    { 
    
    }

    public partial class MainWindow : Window
    {
        public void CatList( int catID)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var productsTable = from Products in context.Products select Products;
            productImg.Children.Clear();
            productName.Children.Clear();
            productPrice.Children.Clear();
            productDesc.Children.Clear();
            productAmount.Children.Clear();
            foreach (var item in productsTable)
            {
                if (item.Categoria_Id == catID)
                {
                    


                    TextBox tBoxProductName = new TextBox();
                    tBoxProductName.Text = item.Name;
                    productName.Children.Add(tBoxProductName);

                    TextBox tBoxProductPrice = new TextBox();
                    tBoxProductPrice.Text = item.Price.ToString();
                    productPrice.Children.Add(tBoxProductPrice);

                    TextBox tBoxProductDesc = new TextBox();
                    tBoxProductDesc.Text = item.Desc;
                    productDesc.Children.Add(tBoxProductDesc);

                    TextBox tBoxProductAmmount = new TextBox();
                    tBoxProductAmmount.Text = item.Amount;
                    productAmount.Children.Add(tBoxProductAmmount);

                    //Image imageProductImg = new Image();
                }
                

            }


        }


        //Button button = new Button();
        //button.Click += (s,e) => { your code; };
        //button.Click += new EventHandler(button_Click);   
        //container.Controls.Add(button);



        public MainWindow()
        {
            InitializeComponent();
            List<int> itemsInCat1 = new List<int>();
            List<int> itemsInCat2 = new List<int>();
            List<int> itemsInCat3 = new List<int>();
            // int  jest placeholderem zmienic go na poprawny typ


        }

        private void Kat1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CatList(1);

        }

        private void cartButton_Click(object sender, RoutedEventArgs e)
        {
            CartWindow Cart = new CartWindow();
            Cart.Show();
        }

        private void Kat2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CatList(2);

        }

        private void Kat3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CatList(3);

        }
    }



}
