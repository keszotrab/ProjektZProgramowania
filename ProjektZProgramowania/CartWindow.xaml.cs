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

    [Table(Name = "Transkacje")]
    public class UserEntity
    {
        [Column(IsPrimaryKey = true, Name = "Id", IsDbGenerated = true)]
        public long Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Role")]
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT

        [Column(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column(Name = "RemovedAt")]
        public DateTime? RemovedAt { get; set; }
    }

    [Table(Name = "Dane_Osobowe")]
    public class DaneOsobowe
    {
        [Column(IsPrimaryKey = true, Name = "Id", IsDbGenerated = true)]
        public long Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Role")]
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT

        [Column(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column(Name = "RemovedAt")]
        public DateTime? RemovedAt { get; set; }
    }



    /// <summary>
    /// Logika interakcji dla klasy CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        string prod = "";

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
            DataClasses1DataContext context = new DataClasses1DataContext();
            

            Transakcje tr = new Transakcje();
            tr.Status = "asd";
            tr.Kwota = mw.totalCostNumber;
            prod = "";
            foreach (var item in mw.buyList)
            {
                prod += item + " ";
            }
            tr.Produkty = prod;

            Dane_Osobowe da = new Dane_Osobowe();
            da.Imie = customerName.Text;
            da.Nazwisko = customerSurename.Text;
            da.Email = customerEmail.Text;
            da.Adres = customerHomeAddress.Text;
            da.Adres_dost = customerDeliveryAddress.Text;


            var tableDO = from Dane_Osobowe in context.Dane_Osobowe select Dane_Osobowe;



            /*

            string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True";




            using (DataClasses1DataContext dataContext = new DataClasses1DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();

                users.InsertOnSubmit(new UserEntity  // adding a new user to the future saving
                {
                    Name = "Piotr",
                    Role = "MODERATOR",
                    CreatedAt = DateTime.Now
                });

                dataContext.SubmitChanges();         // saves changes in the database (saves added user)
            }

            */




            ///////////////////////////Nie wiem nie działa

















            //string personID = "SELECT MAX(Id) FROM Dane_Osobowe.[dbo].[Projekt_ProgOb] ";
            //personID += " ";
            //GROUP BY id
        }
    }
}
