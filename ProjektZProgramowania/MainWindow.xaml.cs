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
        
        List<Button> dynamicButtList = new List<Button>();
        List<int> itemsInCategory = new List<int>();
        public List<int> buyList = new List<int>();






        public void CatList(int catID)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var productsTable = from Products in context.Products select Products;
            productImg.Children.Clear();
            productName.Children.Clear();
            productPrice.Children.Clear();
            productDesc.Children.Clear();
            productAmount.Children.Clear();
            productBuyButtons.Children.Clear();
            itemsInCategory.Clear();
            int listId = 0;
            dynamicButtList.Clear();


            foreach (var item in productsTable)
            {
                if (item.Categoria_Id == catID)
                {

                    itemsInCategory.Add(item.Id);




                    TextBlock tBoxProductName = new TextBlock();
                    tBoxProductName.Text = item.Name;
                    tBoxProductName.Height = 40;
                    tBoxProductName.TextAlignment = TextAlignment.Center;
                    tBoxProductName.VerticalAlignment = VerticalAlignment.Center;
                    productName.Children.Add(tBoxProductName);

                    TextBlock tBoxProductPrice = new TextBlock();
                    tBoxProductPrice.Text = item.Price.ToString();
                    tBoxProductPrice.Height = 40;
                    tBoxProductPrice.TextAlignment = TextAlignment.Center;
                    productPrice.Children.Add(tBoxProductPrice);

                    TextBlock tBoxProductDesc = new TextBlock();
                    tBoxProductDesc.Text = item.Desc;
                    tBoxProductDesc.Height = 40;
                    tBoxProductPrice.TextAlignment = TextAlignment.Center;
                    productDesc.Children.Add(tBoxProductDesc);

                    TextBlock tBoxProductAmmount = new TextBlock();
                    tBoxProductAmmount.Text = item.Amount;
                    tBoxProductAmmount.Height = 40;
                    productAmount.Children.Add(tBoxProductAmmount);




                    
                    Button testBtn = new Button();
                    testBtn.Content = "Dodaj do koszyka";
                    testBtn.FontSize = 10;
                    testBtn.Height = 40;
                    testBtn.Click += buyButton_Click;
                    productBuyButtons.Children.Add(testBtn);
                    //testBtn.Foreground = new SolidColorBrush(Colors.White);
                    //testBtn.FontWeight = FontWeights.Bold;
                    //testBtn.Background = new SolidColorBrush(Colors.Transparent);
                    dynamicButtList.Add(testBtn);

















                }
            }
        }

        

        
        



        public MainWindow()
        {
            InitializeComponent();
           
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
            decimal totalCostNumber = 0;

            DataClasses1DataContext context = new DataClasses1DataContext();
            var productsTable = from Products in context.Products select Products;

            foreach (var item in buyList)
            {
                foreach (var item2 in productsTable)
                {
                    if (item == item2.Id)
                    {


                        TextBlock cartTBProductName = new TextBlock();
                        cartTBProductName.Text = item2.Name;
                        cartTBProductName.Height = 40;
                        Cart.cartNameSP.Children.Add(cartTBProductName);


                        TextBlock cartTBProductPrice = new TextBlock();
                        cartTBProductPrice.Text = item2.Price.ToString();
                        cartTBProductPrice.Height = 40;
                        Cart.cartPriceSP.Children.Add(cartTBProductPrice);
                        totalCostNumber += item2.Price;
                        //totalCost

                    }
                }
            }





            Cart.totalCost.Text = totalCostNumber.ToString();
        }

        private void Kat2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CatList(2);

        }

        private void Kat3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CatList(3);

        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            int j = 0;
            foreach (var item in dynamicButtList)
            {
                if (sender == dynamicButtList[j])
                {
                    buyList.Add(itemsInCategory[j]);
                    break;
                    
                }
                j++;
            }


        }



    }



}
