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
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.IO;
using System.Drawing;
namespace ProjektZProgramowania
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    //[Table(Name = "Users")]
    public static class WhatIsThat
    {
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit(); image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad; image.UriSource = null; image.StreamSource = mem; image.EndInit();
            }
            image.Freeze(); return image;
        }
    }





    public partial class MainWindow : Window
    {



        
        List<Button> dynamicButtList = new List<Button>();
        List<int> itemsInCategory = new List<int>();
        public List<int> buyList = new List<int>();
        public decimal totalCostNumber = 0;


        


        public void CatList(int catID)
        {
            //DataClasses1DataContext context = new DataClasses1DataContext();
            //var productsTable = from Products in context.Products select Products;

            //Produkty context = new Produkty();
            //string productsTable = context.ToString();
            //ProjektZProgramowania.Produkty.ToList();
            
            Projekt_ProgObEntities context = new Projekt_ProgObEntities();
            var productsTable = context.Produkty;
           

            productImg.Children.Clear();
            productName.Children.Clear();
            productPrice.Children.Clear();
            productDesc.Children.Clear();
            productBuyButtons.Children.Clear();
            itemsInCategory.Clear();
            int listId = 0;
            dynamicButtList.Clear();


            productName.Children.Add(tBoxProductName);
            productDesc.Children.Add(tBoxProductDesc);
            productPrice.Children.Add(tBoxProductPrice);
            productImg.Children.Add(asrd);

            foreach (var item in productsTable)
            {
                if (item.Categoria_Id == catID)
                {

                    itemsInCategory.Add(item.Id);




                    TextBlock tBoxProductName = new TextBlock();
                    tBoxProductName.Text = item.Nazwa;
                    tBoxProductName.Height = 90;
                    tBoxProductName.TextAlignment = TextAlignment.Center;
                    tBoxProductName.VerticalAlignment = VerticalAlignment.Center;
                    productName.Children.Add(tBoxProductName);

                    TextBlock tBoxProductPrice = new TextBlock();
                    tBoxProductPrice.Text = item.Cena.ToString() + " zł";
                    tBoxProductPrice.Height = 90;
                    tBoxProductPrice.TextAlignment = TextAlignment.Center;
                    tBoxProductPrice.VerticalAlignment = VerticalAlignment.Center;

                    productPrice.Children.Add(tBoxProductPrice);

                    TextBlock tBoxProductDesc = new TextBlock();
                    tBoxProductDesc.Text = item.Opis;
                    tBoxProductDesc.Height = 90;
                    tBoxProductDesc.TextWrapping = TextWrapping.WrapWithOverflow;
                    tBoxProductDesc.TextAlignment = TextAlignment.Center;
                    tBoxProductDesc.VerticalAlignment = VerticalAlignment.Center;

                    productDesc.Children.Add(tBoxProductDesc);

                    Image asrd = new Image();
                    //asrd.Source = item.Img.


                    byte[] byteimg = item.Img;
                    BitmapImage i = new BitmapImage();
                    //i.BeginInit();
                    i = WhatIsThat.LoadImage(item.Img);
                    if (i != null)
                    {
                        asrd.Source = i;
                    }
                    else
                    {
                        var uriSource = new Uri("NoImage.jpg", UriKind.Relative);

                        asrd.Source = new BitmapImage(uriSource);
                    } 




                    productImg.Children.Add(asrd);

                    //i.DecodePixelWidth = 90;
                    //i.EndInit();

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
            totalCostNumber = 0;

            //DataClasses1DataContext context = new DataClasses1DataContext();
            //var productsTable = from Products in context.Products select Products;

            Projekt_ProgObEntities context = new Projekt_ProgObEntities();
            var productsTable = context.Produkty;




            foreach (var item in buyList)
            {
                foreach (var item2 in productsTable)
                {
                    if (item == item2.Id)
                    {


                        TextBlock cartTBProductName = new TextBlock();
                        cartTBProductName.Text = item2.Nazwa;
                        cartTBProductName.Height = 40;
                        Cart.cartNameSP.Children.Add(cartTBProductName);


                        TextBlock cartTBProductPrice = new TextBlock();
                        cartTBProductPrice.Text = item2.Cena.ToString();
                        cartTBProductPrice.Height = 40;
                        Cart.cartPriceSP.Children.Add(cartTBProductPrice);
                        totalCostNumber += item2.Cena;

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
