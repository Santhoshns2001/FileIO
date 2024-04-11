using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{

    public class Customer 
    {
        public int customer_Id { get; set; }
        public string Cusomer_Name { get; set; }
        public List<Employee> employees { get; set; }
    }


    public class Employee
    {
            public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
    }
    
}
