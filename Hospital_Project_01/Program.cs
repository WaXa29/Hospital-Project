using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital_Project_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //string main_back;          // Check.....?         
            
            Login.userlogin();

            //------------
            Patient[] starray = new Patient[5];    //Delete later
            int nf = 0,enid=0;  /*id = 0,*/
            string opt;
            //string id = null; //Delete later
            Employee[] etarray = new Employee[5];
            int af = 0; /*id = 0,*/
            string opt1;           
            //----------
            Nursing[] ntarray = new Nursing[5];
            int ef = 0; /*id = 0,*/
            string opt2;
            //----------
            Doctor[] dtarray = new Doctor[5];
            int df = 0; /*id = 0,*/
            string opt3;
            //----
            string opt4;
            int bf = 0;
            //---


            if (Login.menu == 1)
            {
                 int userInput = 0;
                 //int choice = 0;
                 do
                 {
                     //rollback: userInput = Menu.Display();
                     Console.Clear();
                     Console.WriteLine("**************************************Welcome to the Hospital Management System**************************************");
                     Console.WriteLine("\n\n\n\n\t\t\tMain Menu");
                     Console.WriteLine();
                     Console.WriteLine("\n\n\t\t\t1. Patient");
                     Console.WriteLine("\n\n\t\t\t2. Staff(Employee)");
                     Console.WriteLine("\n\n\t\t\t3. Billing");
                     Console.WriteLine("\n\n\t\t\t4. About Program");
                     Console.WriteLine("\n\n\t\t\t0. Exit");
                     userInput = Convert.ToInt32(Console.ReadLine());
                     switch(userInput)
                     {
                         case 1:
                             //--------
                             do
                             {
                                 Console.Clear();
                                 Patient.LoadData(ref starray);
                                 Console.WriteLine("=============================================");
                                 Console.WriteLine("|\t\tMenu\t\t|");
                                 Console.WriteLine("=============================================");
                                 Console.WriteLine("1. Insert");
                                 Console.WriteLine("2. Delete");
                                 Console.WriteLine("3. Update");
                                 Console.WriteLine("4. Search");
                                 Console.WriteLine("5. ShowAll");
                                 Console.WriteLine("0. Exit");
                                 Console.WriteLine("----------------------------------------------");
                                 Console.WriteLine("Enter Your choice: ");
                                 opt = Console.ReadLine();
                                 Console.Clear();
                                 switch (opt)
                                 {
                                     case "1":                                        
                                         Patient.Insert(ref starray);
                                         Console.Clear();
                                         break;
                                     case "2":
                                         Patient.Delete(ref starray, ref enid);
                                         Patient.Writedata01(ref  starray);
                                         Console.Clear();
                                         break;
                                     case "3":
                                         Patient.Update(ref starray, ref enid);

                                         break;
                                     case "4":
                                         Patient.Search(ref starray, ref enid, ref  ef);
                                         Console.Clear();

                                         break;
                                     case "5":
                                         Patient.DisplayAllEntries(starray);

                                         break;
                                 }
                                /* if (opt != "0")
                                 {
                                     Console.WriteLine("Press any key to go back to Menu");
                                     Console.ReadKey();
                                     Console.Clear();
                                 }*/

                             } while (opt != "0");

                             //---------
                             break;
                         case 2:
                             //choice = 1;
                             do
                             {
                                 Console.Clear();
                                 Console.WriteLine("=============================================");
                                 Console.WriteLine("|\t\tMenu\t\t|");
                                 Console.WriteLine("=============================================");
                                 Console.WriteLine("\n\n\t\t1. Nursing");
                                 Console.WriteLine("\n\n\t\t2. Doctoring");
                                 Console.WriteLine("\n\n\t\t0. Exit");
                                 Console.WriteLine("----------------------------------------------");
                                 Console.WriteLine("Enter Your choice: ");
                                 opt1 = Console.ReadLine();
                                 Console.Clear();
                                 switch (opt1)
                                 {
                                     case "1":
                                         do
                                         {
                                             Console.Clear();
                                             Nursing.LoadData(ref ntarray);
                                             Console.WriteLine("=============================================");
                                             Console.WriteLine("|\t\tMenu\t\t|");
                                             Console.WriteLine("=============================================");
                                             Console.WriteLine("1. Insert");
                                             Console.WriteLine("2. Delete");
                                             Console.WriteLine("3. Update");
                                             Console.WriteLine("4. Search");
                                             Console.WriteLine("5. ShowAll");
                                             Console.WriteLine("0. Exit");
                                             Console.WriteLine("----------------------------------------------");
                                             Console.WriteLine("Enter Your choice: ");
                                             opt2 = Console.ReadLine();
                                             Console.Clear();
                                             switch (opt2)
                                             {
                                                 case "1":
                                                     Nursing.Insert(ref ntarray);
                                                     Console.Clear();
                                                     break;
                                                 case "2":
                                                     Nursing.Delete(ref ntarray, ref enid);
                                                     Nursing.Writedata01(ref  ntarray);
                                                     Console.Clear();
                                                     break;
                                                 case "3":
                                                     Nursing.Update(ref ntarray, ref enid);

                                                     break;
                                                 case "4":
                                                     Nursing.Search(ref ntarray, ref enid, ref  nf);
                                                     Console.Clear();

                                                     break;
                                                 case "5":
                                                     Nursing.DisplayAllEntries(ntarray);

                                                     break;
                                             }

                                         } while (opt2 != "0");

                                         break;


                                     case "2":
                                         do
                                         {
                                             Console.Clear();
                                             Doctor.LoadData(ref dtarray);
                                             Console.WriteLine("=============================================");
                                             Console.WriteLine("|\t\tMenu\t\t|");
                                             Console.WriteLine("=============================================");
                                             Console.WriteLine("1. Insert");
                                             Console.WriteLine("2. Delete");
                                             Console.WriteLine("3. Update");
                                             Console.WriteLine("4. Search");
                                             Console.WriteLine("5. ShowAll");
                                             Console.WriteLine("0. Exit");
                                             Console.WriteLine("----------------------------------------------");
                                             Console.WriteLine("Enter Your choice: ");
                                             opt3 = Console.ReadLine();
                                             Console.Clear();
                                             switch (opt3)
                                             {
                                                 case "1":
                                                     Doctor.Insert(ref dtarray);
                                                     Console.Clear();
                                                     break;
                                                 case "2":
                                                     Doctor.Delete(ref dtarray, ref enid);
                                                     Doctor.Writedata01(ref  dtarray);
                                                     Console.Clear();
                                                     break;
                                                 case "3":
                                                     Doctor.Update(ref dtarray, ref enid);

                                                     break;
                                                 case "4":
                                                     Doctor.Search(ref dtarray, ref enid, ref  nf);
                                                     Console.Clear();

                                                     break;
                                                 case "5":
                                                     Doctor.DisplayAllEntries(dtarray);

                                                     break;
                                             }

                                         } while (opt3 != "0");

                                         break;

                                 }
                                 if (opt1 != "0")
                                 {
                                     Console.WriteLine("\n\n\t\tPress any key to go back to Menu");
                                     Console.ReadKey();
                                     Console.Clear();
                                 }

                             } while (opt1 != "0");

                             break;


                         case 3:
                             //choice = 1
                               //LoadData()
                               //Billing b1 = new Billing();
                               Billing[] barray = new Billing[1];
                               //b1.check();
                                         do
                                         {
                                             Console.Clear();
                                             Billing.LoadData(ref barray);
                                             Console.WriteLine("=============================================");
                                             Console.WriteLine("|\t\tMenu\t\t|");
                                             Console.WriteLine("=============================================");
                                             Console.WriteLine("1. Insert");
                                             Console.WriteLine("2. ShowAll");
                                             Console.WriteLine("3. Delete");
                                             Console.WriteLine("0. Exit");
                                             Console.WriteLine("----------------------------------------------");
                                             Console.WriteLine("Enter Your choice: ");
                                             opt4 = Console.ReadLine();
                                             Console.Clear();
                                             switch (opt4)
                                             {
                                                 case "1":
                                                     Billing.check(ref barray, ref bf);
                                                     Console.Clear();
                                                     break;
                                                 case "2":
                                                     Billing.DisplayAllEntries(barray);

                                                     break;
                                                 case "3":
                                                     Billing.Delete(ref barray, ref enid);
                                                     Billing.Writedata01(ref  barray);
                                                     break;
                                             }

                                         } while (opt4 != "0");

                                       

                                         break;



                         case 4:
                             
                             Console.WriteLine("Please wait few seconds...");
                             System.Threading.Thread.Sleep(1000);
                             Console.Clear();

                             AboutProgram.Display();
                             //if (main_back != null)
                             //{
                             //   // goto rollback;
                             //}
                            break;
                         case 5:
                             Console.WriteLine("Program will now exit in 5 seconds...");
                             System.Threading.Thread.Sleep(3000);
                             System.Environment.Exit(1);
                             break;
                     }
                     if (userInput != 0 || userInput != 1)
                     {
                         Console.WriteLine("Press any key to go back to Menu");
                         Console.ReadKey();
                         Console.Clear();
                     }
                 } while (userInput != 0);
                
            }
        }
    }
}
