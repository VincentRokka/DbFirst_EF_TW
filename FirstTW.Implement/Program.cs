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
                ID = "id004",
                FULLNAME = "no",
                DOB = new DateTime(2000, 5, 12),
                SALARY = 50,
                NOTE = "great",
                DEPARTMENTID = null
            };

            //personService.Insert(person);

            personService.Update(person);

            var list = personService.GetAll().OrderBy(x=>x.ID).ToPagedList(1, 20);
            OutPut(list);

            Console.WriteLine("Data after Join Two Table");
            var listJoin = personService.GetAllPersonWithDepartmentID().OrderByDescending(x => x.ID).ToPagedList(1, 15);
            OutPut(listJoin);


            //Console.WriteLine("=============After Delete===================");
            //personService.Delete("id001");

            //var list2 = personService.GetAll().OrderBy(x=>x.FULLNAME);
            //OutPut(list2);

            //Console.WriteLine("=============Filtering===================");
            //var nowTime = DateTime.Now;
            //var listFiltering = personService.GetAllWithConditional(p => nowTime.Year - p.DOB.Value.Year >= 20)
            //                                 .OrderBy(x=>x.ID).ToPagedList(1,1);
            //OutPut(listFiltering);

            //Console.WriteLine("=============Filtering2===================");
            //var listFiltering2 = personService.GetAllWithConditional(p => p.FULLNAME.ToUpper().Contains("MINH"))
            //                                  .OrderBy(x => x.ID).ToPagedList(1, 1);
            //OutPut(listFiltering2);



            Console.ReadKey();

        }

        public static void OutPut(IPagedList<PERSON> list)
        {
            foreach (PERSON i in list)
            {
                var departmentName = i.DEPARTMENTID == null ? "Null" : i.DEPARTMENT.DEPARTMENTNAME;
                Console.WriteLine($"{i.ID}, {i.FULLNAME}, {i.DOB}, {i.SALARY}, {i.NOTE}, {departmentName}");
            }
        }

    }
}
