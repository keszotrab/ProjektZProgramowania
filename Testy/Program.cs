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






            Console.ReadKey();

        }
    }
}
