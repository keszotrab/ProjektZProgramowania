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

    public static class WhatIsThat
    {
        /// 
        /// Klasa statyczna przechowywująca metode konwertująca dane obrazka z bazy w postaci byte[] na image
        /// Aktualnie nieużywana
        /// 
    
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
         List<Categorie> catList = new List<Categorie>();
         List<TextBlock> catTBList = new List<TextBlock>();
        List<Button> dynamicButtList = new List<Button>();
        List<int> itemsInCategory = new List<int>();
        public List<int> buyList = new List<int>();
        public decimal totalCostNumber = 0;


        //CatList to funkcja która wczytuje wszystkie produkty o id categori
        //równym catID

        public void CatList(int catID)
        {
            
            
            Projekt_ProgObEntities context = new Projekt_ProgObEntities();
            var productsTable = context.Produkty;
           

            productImg.Children.Clear();
            productName.Children.Clear();
            productPrice.Children.Clear();
            productDesc.Children.Clear();
            productBuyButtons.Children.Clear();
            itemsInCategory.Clear();
            dynamicButtList.Clear();

            Label columnTitleImg = new Label();
            columnTitleImg.Content = "Obrazek";
            columnTitleImg.Height = 32;
            columnTitleImg.FontSize = 16;
            columnTitleImg.HorizontalAlignment = HorizontalAlignment.Center;
            columnTitleImg.VerticalAlignment = VerticalAlignment.Top;
            productImg.Children.Add(columnTitleImg);

            Label columnTitleName = new Label();
            columnTitleName.Content = "Nazwa";
            columnTitleName.Height = 32;
            columnTitleName.FontSize = 16;
            columnTitleName.HorizontalAlignment = HorizontalAlignment.Center;
            columnTitleName.VerticalAlignment = VerticalAlignment.Top;
            productName.Children.Add(columnTitleName);

            Label columnTitleDesc = new Label();
            columnTitleDesc.Content = "Opis";
            columnTitleDesc.Height = 32;
            columnTitleDesc.FontSize = 16;
            columnTitleDesc.HorizontalAlignment = HorizontalAlignment.Center;
            columnTitleDesc.VerticalAlignment = VerticalAlignment.Top;
            productDesc.Children.Add(columnTitleDesc);

            Label columnTitleCost = new Label();
            columnTitleCost.Content = "Cena";
            columnTitleCost.Height = 32;
            columnTitleCost.FontSize = 16;
            columnTitleCost.HorizontalAlignment = HorizontalAlignment.Center;
            columnTitleCost.VerticalAlignment = VerticalAlignment.Top;
            productPrice.Children.Add(columnTitleCost);

            Label columnTitleButt = new Label();
            columnTitleButt.Content = "Przycisk";
            columnTitleButt.Height = 32;
            columnTitleButt.FontSize = 16;
            columnTitleButt.HorizontalAlignment = HorizontalAlignment.Center;
            columnTitleButt.VerticalAlignment = VerticalAlignment.Top;
            productBuyButtons.Children.Add(columnTitleButt);



            foreach (var item in productsTable)
            {
                if (item.Categoria_Id == catID)
                {

                    itemsInCategory.Add(item.Id);

                    Label tBoxProductName = new Label();
                    tBoxProductName.Content = item.Nazwa;
                    tBoxProductName.Height = 90;
                    tBoxProductName.HorizontalAlignment = HorizontalAlignment.Center;
                    tBoxProductName.VerticalAlignment = VerticalAlignment.Center;
                    tBoxProductName.VerticalContentAlignment = VerticalAlignment.Center;
                    productName.Children.Add(tBoxProductName);

                    Label tBoxProductPrice = new Label();
                    tBoxProductPrice.Content = item.Cena.ToString() + " zł";
                    tBoxProductPrice.Height = 90;
                    tBoxProductPrice.HorizontalAlignment = HorizontalAlignment.Center;
                    tBoxProductPrice.VerticalAlignment = VerticalAlignment.Center;
                    tBoxProductPrice.VerticalContentAlignment = VerticalAlignment.Center;
                    productPrice.Children.Add(tBoxProductPrice);

                    Label tBoxProductDesc = new Label();
                    tBoxProductDesc.Content = item.Opis;
                    tBoxProductDesc.Height = 90;
                    tBoxProductDesc.HorizontalAlignment = HorizontalAlignment.Center;
                    tBoxProductDesc.VerticalAlignment = VerticalAlignment.Center;
                    tBoxProductDesc.VerticalContentAlignment = VerticalAlignment.Center;
                    productDesc.Children.Add(tBoxProductDesc);

                    Image asrd = new Image();


                    byte[] byteimg = item.Img;
                    BitmapImage i = new BitmapImage();
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


                    /////////////////////////////////////////////////////
                    productImg.Width = 90;
                    productImg.Children.Add(asrd);


                    Button testBtn = new Button();
                    testBtn.Content = "Dodaj do koszyka";
                    testBtn.FontSize = 12;
                    testBtn.Height = 90;
                    testBtn.Click += buyButton_Click;
                    productBuyButtons.Children.Add(testBtn);
                    dynamicButtList.Add(testBtn);


                }
            }
            
        }


        public MainWindow()
        {
            InitializeComponent();
            Projekt_ProgObEntities context = new Projekt_ProgObEntities();
            var tabCat = context.Categorie;

            foreach (var item in tabCat)
            {
                catList.Add(item);
                TextBlock nazwaKategorii = new TextBlock();
                nazwaKategorii.MouseLeftButtonUp += nazwaKategorii_MouseLeftButtonUp;
                nazwaKategorii.TextWrapping = System.Windows.TextWrapping.Wrap;
                nazwaKategorii.Text = item.Nazwa;
                nazwaKategorii.FontSize = 26;
                catTBList.Add(nazwaKategorii);

                Console.WriteLine(item.Nazwa);
                Kategorie.Children.Add(nazwaKategorii);
            }



        }


        private void cartButton_Click(object sender, RoutedEventArgs e)
        {
            CartWindow instance = Application.Current.Windows.OfType<CartWindow>().SingleOrDefault();
            if (instance == null)
            {


                CartWindow Cart = new CartWindow();
                Cart.Show();
                totalCostNumber = 0;


                Projekt_ProgObEntities context = new Projekt_ProgObEntities();
                var productsTable = context.Produkty;




                foreach (var item in buyList)
                {
                    foreach (var item2 in productsTable)
                    {
                        if (item == item2.Id)
                        {

                            Label cartTBProductName = new Label();
                            cartTBProductName.Content = item2.Nazwa;
                            cartTBProductName.Height = 40;
                            Cart.cartNameSP.Children.Add(cartTBProductName);


                            Label cartTBProductPrice = new Label();
                            cartTBProductPrice.Content = item2.Cena.ToString();
                            cartTBProductPrice.Height = 40;
                            Cart.cartPriceSP.Children.Add(cartTBProductPrice);
                            totalCostNumber += item2.Cena;

                        }
                    }
                }

                Cart.totalCost.Text = totalCostNumber.ToString();
            }
        }



        private void nazwaKategorii_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Projekt_ProgObEntities context = new Projekt_ProgObEntities();
            var tabCat = context.Categorie;

            int j = 0;
            foreach (var item in catTBList)
            {
                if (item == sender)
                {
                    break;
                }
                j++;
            }

            int d = catList[j].Id;

            CatList(d);


        }


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // calculates incorrect when window is maximized
            string tmp = MainWindow.ActualHeightProperty.ToString();
            Scroll.Height = this.ActualHeight -200;
        }


        //Event przycisku kup generowanego dla każdego produktu
        //dodaje do listy rzeczy w koszyku przedmiot któremu odpowiada

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            CartWindow instance = Application.Current.Windows.OfType<CartWindow>().SingleOrDefault();

            if (instance == null)
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
            else 
            {
                string messageBoxText = "Przed dodaniem produktów do koszyka zamknij okno koszyka!";
                string caption = "Friendly reminder";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }



    }



}
