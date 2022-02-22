using FirstTW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTW.Service.Service
{
    public class PersonService : DBIO<PERSON>
    {
        ORCDbContext context = new ORCDbContext();

        public IQueryable<PERSON> GetAllPersonWithDepartmentID()
        {
            var listJoin = from s in context.People join r in context.DEPARTMENTs 
                           on s.DEPARTMENTID equals r.ID
                           where s.DEPARTMENTID == r.ID
                           select s;
            return listJoin.AsQueryable();
        }

    }
}
