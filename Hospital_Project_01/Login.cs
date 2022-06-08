using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Hospital_Project_01
{
    class Login
    {
        public static string loginid;
        public static string password;
        public static string enloginid;
        public static string enpassword;
        public static int menu = 0;
        public static string path1 = @"UseridCredential.txt";
           
        public static void userlogin()
        {
            if (!File.Exists(path1))
            {
                
                Console.WriteLine("\n\n\n\n\n\t\t\t\t\tFirst We Create a New User...");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("\n\n\nEnter your Login ID: ");
            
                loginid = Console.ReadLine();

                Console.WriteLine("Enter your password: ");
                password = Console.ReadLine();
                using (StreamWriter sw = new StreamWriter(path1))
                {
                    sw.WriteLine(loginid);
                    sw.WriteLine(password);
                    sw.Close();
                }
                    Console.WriteLine("\n\n\n\t\t\tNew User succesfully created...");
                    Thread.Sleep(1000);
                    Console.Clear();
            }

                Console.WriteLine("************Login Screen*********\n");
                Console.WriteLine("\n\n\nEnter your Login ID: ");
                enloginid = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                enpassword = Console.ReadLine();
                using (StreamReader sr = new StreamReader(File.Open(path1, FileMode.Open)))
                {
                    loginid = sr.ReadLine();
                    password = sr.ReadLine();
                    sr.Close();
                }
                if(enloginid==loginid && enpassword == password)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\t\t\tLogin Sucessfull");
                    Thread.Sleep(1000);
                    Console.Clear();
                    menu = 1;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\t\t\tLogin Failed..!");
                }
        }

       
    }
}
