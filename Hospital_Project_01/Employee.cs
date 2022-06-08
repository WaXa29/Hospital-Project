using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital_Project_01
{
    abstract class Employee
    {
        public int r_num;
        public string name;
        public int age;
        public string disease;
        public string ref_doc;
        public static string ans;

   

        public virtual void Display()
        {
            Console.WriteLine("Reg ID: {0}", r_num);
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("disease: {0}", disease);
            Console.WriteLine("Refered to Doctor: {0}", ref_doc);
            Console.WriteLine("----------------------------------------------------\n");

        }

    

    }
}
