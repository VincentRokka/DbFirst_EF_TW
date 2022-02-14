using FirstTW.Model;
using FirstTW.Service.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTW.Implement
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonService personService = new PersonService();
            PERSON person = new PERSON() {
                ID = "id001",
                FULLNAME = "nameUpdated",
                DOB = new DateTime(2000, 5, 12),
                DEPARTMENT = "QA updated",
                SALARY = 10000,
                NOTE = "great"
            };

            //personService.Insert(person);

            //personService.Update(person);

            var list = personService.GetAll().OrderBy(x=>x.ID).ToPagedList(1, 5);
            OutPut(list);
            Console.WriteLine("=============After Delete===================");

            personService.Delete("id001");

            //var list2 = personService.GetAll().OrderBy(x=>x.FULLNAME);
            //OutPut(list2);

            Console.WriteLine("=============Filtering===================");
            var nowTime = DateTime.Now;
            var listFiltering = personService.GetAllWithConditional(p => nowTime.Year - p.DOB.Value.Year >= 20)
                                             .OrderBy(x=>x.ID).ToPagedList(1,6);
            OutPut(listFiltering);

            Console.WriteLine("=============Filtering2===================");
            var listFiltering2 = personService.GetAllWithConditional(p => p.FULLNAME.ToUpper().Contains("MINH"))
                                              .OrderBy(x => x.ID).ToPagedList(1, 6);
            OutPut(listFiltering2);
            
            Console.ReadKey();

        }

        public static void OutPut(IPagedList<PERSON> list)
        {
            foreach (PERSON i in list)
            {
                Console.WriteLine($"{i.ID}\t{i.FULLNAME}\t{i.DOB}\t{i.DEPARTMENT}\t{i.SALARY}\t{i.NOTE}");
            }
        }
    }
}
