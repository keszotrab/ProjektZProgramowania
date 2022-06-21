using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Testy
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Test 1");

            //Test ma za zadanie wypisac wszystkie nazwy kategorii z bazy danych

            Projekt_ProgObEntities context = new Projekt_ProgObEntities();
            List<Categorie> asd = new List<Categorie>();
            var testCat = context.Categorie;
            foreach (var item in testCat)
            {
                Console.WriteLine(item.Nazwa);

            }
            Console.WriteLine("");




            Console.WriteLine("Test 2");

            //Test ma za zadanie dodac rekord do bazy danych

            var showPiece = context.Dane_Osobowe
                   .OrderByDescending(p => p.Id)
                   .FirstOrDefault();

            Console.WriteLine("Najnowsze ID przed dodaniem");
            Console.WriteLine(showPiece.Id);
            Dane_Osobowe daneOs = new Dane_Osobowe()
                {
                    Imie = "test",
                    Nazwisko = "test",
                    Adres = "test",
                    Adres_dost = "test",
                    Email = "test"

                };
                context.Dane_Osobowe.Add(daneOs);
                context.SaveChanges();


            showPiece = context.Dane_Osobowe
                   .OrderByDescending(p => p.Id)
                   .FirstOrDefault();

            Console.WriteLine("Najnowsze ID po dodaniu");
            Console.WriteLine(showPiece.Id);


            //wypisuje ostatnie ID w bazie danych i ostatnie ID po dodaniu rekordu, jesli sa rózne oznacza to sukces

            Console.WriteLine("");



            Console.ReadKey();

        }
    }
}
