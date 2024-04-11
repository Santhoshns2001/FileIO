using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Demo.Practice1();

            // Demo.RaeadingAllLines();

            // Demo.ReadingText();

            //Demo.Clone();

            //Demo.Delete();


            // using stream reader and writer

            //Demo.Read();

            // Demo.Write();



            /*Reading the text from csv file and writing the text to csv file  */

            //string directoryPath = @"C:\Users\Admin\source\repos\FileIO\FileIO";
            //string fileName = "data.csv";
            //string filePath = Path.Combine(directoryPath, fileName);
            // WriteToCsv(filePath);
            // ReadFromCsv(filePath);



            /* Serailization and deseraliazation by converting json object to c# and vise versa*/


            // serialization -> converting c# program to json object 

          // convertCsToJson();

            //deseralization -> converting back from json to cs object

            convertJsonToCs();








        }


        
        private static void convertJsonToCs()
        {
            string fileName = @"C:\Users\Admin\source\repos\FileIO\FileIO\CustomerDetails.json";

            if(System.IO.File.Exists(fileName))
            {
                string stringText = File.ReadAllText(fileName);

                Customer c = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(stringText);

                Console.WriteLine("deserialization is succussfull");



                Console.Write(c.customer_Id+" ");
                Console.WriteLine(c.Cusomer_Name);
                
                foreach(var e in c.employees)
                {
                    Console.WriteLine(e.first_name+","+e.last_name+","+e.phone);
                }

            }
            
            
            
        }

        private static void convertCsToJson()
        {

            Customer customer1 = createCustomer();

            //converts csharp to json
            var jsonFormattedtype = Newtonsoft.Json.JsonConvert.SerializeObject(customer1);

            string fileName = @"C:\Users\Admin\source\repos\FileIO\FileIO\CustomerDetails.json";

            File.WriteAllText(fileName, jsonFormattedtype);

            //if(File.Exists(fileName))
            //{
            //    File.WriteAllText(fileName, jsonFormattedtype);
            //}
            //else
            //{
            //    File.Delete(fileName);
            //    File.WriteAllText(fileName, jsonFormattedtype);
            //}

            Console.WriteLine("serialization is succussfull ");



        }

        private static Customer createCustomer()
        {
            //Customer c1 = new Customer();
            //c1.Cusomer_Name = "manju";
            //    c1.customer_Id = 01;
            //c1.employees = new List<Employee>();

            //var e1 = new Employee();
            //e1.first_name = "manjunath";
            //e1.last_name = "reddy";
            //e1.phone = "7894561325";

            //c1.employees.Add(e1);

            //var e2 = new Employee();
            //e2.first_name = "sharanabasava";
            //e2.last_name = "reddy";
            //e2.phone = "9632587415";
            //c1.employees.Add(e2);

            //return c1;

            //or 

            var c = new Customer();
            c.customer_Id = 01;
            c.Cusomer_Name = "prashanth";
            c.employees = new List<Employee>
            {
                new Employee{first_name="manju",last_name="reddy",phone="9632587412"},
                new Employee{first_name="prashanth",last_name="reddy",phone="7418529635"},
                new Employee{first_name="purushotham",last_name="c",phone="7895463150"}
            };

            return c;
        }



        private static void ReadFromCsv(string filePath)
        {
            try
            {

                if (File.Exists(filePath))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false
                    };

                    using (StreamReader sr = new StreamReader(filePath))
                    using (CsvReader reader = new CsvReader(sr, config))
                    {
                        //Read records from csv file 
                        IEnumerable<Person> records = reader.GetRecords<Person>();

                        foreach (Person record in records)
                        {
                            Console.WriteLine($"Name :{record.Name}, ID :{record.ID},Country :{record.Country}");

                        }
                        Console.ReadKey();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace); ;
            }

        }

        static void WriteToCsv(string filepath)
        {
            try
            {

                if (!File.Exists(filepath))
                {
                    using (File.Create(filepath)) { }
                }

                List<Person> people = new List<Person>()
                {
                    new Person{Name="santhosh",ID=1,Country="India"},
                    new Person{Name="Purushotham",ID=2,Country="India"},
                    new Person {Name="Sharana",ID=3,Country="India"}
                };

                var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                };

                using (StreamWriter streamWriter = new StreamWriter(filepath, true))
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, configPersons))
                {
                    csvWriter.WriteRecords(people);
                }
                Console.WriteLine("data written in csv succussfully");


            }
            catch (Exception ex)
            {
                throw;
            }

        }



    }
}
