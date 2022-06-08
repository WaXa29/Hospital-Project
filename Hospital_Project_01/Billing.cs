using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Hospital_Project_01
{
    class Billing
    {
        public int no;
        public string name;
        public string amount;

        public static string path = @"bill.txt";

        public int size; // Dynamic Size for array

        public static void LoadData(ref Billing[] pt1)
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }

            StreamReader sr = new StreamReader(path);

            int size = Convert.ToInt32(sr.ReadLine());
            pt1 = new Billing[size];

            for (int i = 0; i < pt1.Length; i++)
            {
                pt1[i] = new Billing();
                pt1[i].no = Convert.ToInt32(sr.ReadLine());
                pt1[i].name = sr.ReadLine();
                pt1[i].amount = sr.ReadLine();


            }
            sr.Close();
        }

        public void Display()
        {
            Console.WriteLine("Patient Reg ID: {0}", no);
            Console.WriteLine("Patient Name:   {0}", name);
            Console.WriteLine("Total Amount:   {0}", amount);
            Console.WriteLine("----------------------------------------------------\n");

        }

        public static void DisplayAllEntries(Billing[] pt1)
        {
            Console.Clear();
            for (int i = 0; i < pt1.Length; i++)
            {
                pt1[i].Display();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void Insert(ref Billing[] pt1, ref int p)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(pt1.Length + 1);

            Billing temp = new Billing();
            Console.Clear();
            //Console.Write("Enter the Rigisteration No of Patient : ");
            //int p = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Enter the Registration NO of the patient: ");
            //temp.no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the name of the patient: ");
            temp.name = Console.ReadLine();
            Console.Write("Enter the amount of the patient: ");
            temp.amount = Console.ReadLine();


            sw.WriteLine(p);
            sw.WriteLine(temp.name);
            sw.WriteLine(temp.amount);

            for (int i = 0; i < pt1.Length; i++)
            {
                if(pt1[i]!=null)
                {
                    sw.WriteLine(pt1[i].no);
                    sw.WriteLine(pt1[i].name);
                    sw.WriteLine(pt1[i].amount);
                }

            }
            sw.Close();
            LoadData(ref pt1);
        }
        //---------
        
        //----------

        public static void Writedata01(ref Billing[] starray)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                //Console.WriteLine("----------");          // for debuging use, will be commented..
                //Console.WriteLine(index);
                //Console.WriteLine("----------");
                sw.WriteLine(starray.Length - 1);
                for (int i = 0; i < starray.Length; i++)
                {
                    //starray[i] = new Student();
                    if (starray[i] != null)
                    {
                        sw.WriteLine(starray[i].no);
                        sw.WriteLine(starray[i].name);
                        sw.WriteLine(starray[i].amount);
                        //Console.WriteLine(starray[i].id);             // for debuging use, will be commented..
                        //Console.WriteLine(starray[i].name);
                        //Console.WriteLine(starray[i].disease);
                        //Console.WriteLine(starray[i].ref_doc);
                    }
                }
                sw.Close();
            }
            LoadData(ref starray);
        }

        public static void check(ref Billing[] barray, ref int bf)
        {
            //try
            //{
            Patient[] starray = new Patient[1];
            Console.WriteLine(starray.Length + 1);
            Console.Clear();
            Console.Write("Enter the Rigisteration No of Patient : ");
            int p = Convert.ToInt32(Console.ReadLine());

            using (StreamReader sr = new StreamReader(File.Open(@"H:\oop\patientrecord.txt", FileMode.Open)))
            {
                int size = Convert.ToInt32(sr.ReadLine());
                starray = new Patient[size];
                bf = 0;
                for (int i = 0; i < starray.Length; i++)
                {
                    starray[i] = new Patient();
                    starray[i].r_num = Convert.ToInt32(sr.ReadLine());
                    starray[i].name = sr.ReadLine();
                    starray[i].age = Convert.ToInt32(sr.ReadLine());
                    starray[i].disease = sr.ReadLine();
                    starray[i].ref_doc = sr.ReadLine();

                    if (starray[i].r_num == p)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\t\tSuccessfull");
                        Thread.Sleep(1000);
                        Insert(ref barray, ref p);
                        Console.Clear();
                        Console.WriteLine("\n\n\n\t\tBilling Successfull........");

                        bf = 1;
                    }
                }

                sr.Close();

            }
            if (bf == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\t\t\t******* Patient Not Found .....! *****");
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            //}
            //catch (IndexOutOfRangeException ex)
            //{
            //    Console.WriteLine("Invalid Patient.");
            //}
            //finally
            //{
            //    Console.WriteLine("HELLO WORLD");
            //}
        }

        public static void Delete(ref Billing[] btarray, ref int enid)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Delete Patient Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Delete ");
            enid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < btarray.Length; i++)
            {

                if (btarray[i].no == enid)
                {
                    btarray[i] = null;
                }


            }
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tPatient Has Deleted Successfully.....");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }


        
    }
}
