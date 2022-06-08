using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital_Project_01
{
    class Nursing : Employee
    {
        //public int r_num;
        //public string name;
        //public int age;
        //public static string ans;

        public static string path = @"Nursingrecord.txt";

        public int size; // Dynamic Size for array

        public static void LoadData(ref Nursing[] nt1)
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }

            StreamReader sr1 = new StreamReader(path);

            int size = Convert.ToInt32(sr1.ReadLine());
            nt1 = new Nursing[size];

            for (int i = 0; i < nt1.Length; i++)
            {
                nt1[i] = new Nursing();
                nt1[i].r_num = Convert.ToInt32(sr1.ReadLine());
                nt1[i].name = sr1.ReadLine();
                nt1[i].age = Convert.ToInt32(sr1.ReadLine());

            }
            sr1.Close();
        }

        public override void Display()
        {
            Console.WriteLine("Nurse Reg ID:     {0}", r_num);
            Console.WriteLine("Nurse Name:       {0}", name);
            Console.WriteLine("Nurse Age:        {0}", age);
            Console.WriteLine("----------------------------------------------------\n");

        }

        public static void DisplayAllEntries(Nursing[] nt1)
        {
            Console.Clear();
            for (int i = 0; i < nt1.Length; i++)
            {
                nt1[i].Display();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void Insert(ref Nursing[] nt1)
        {
            StreamWriter sw1 = new StreamWriter(path);
            sw1.WriteLine(nt1.Length + 1);

            Nursing temp = new Nursing();

            Console.Write("Enter the Registration NO of the Nurse: ");
            temp.r_num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the name of the Nurse: ");
            temp.name = Console.ReadLine();
            Console.Write("Enter the age of the Nurse: ");
            temp.age = Convert.ToInt32(Console.ReadLine());

            sw1.WriteLine(temp.r_num);
            sw1.WriteLine(temp.name);
            sw1.WriteLine(temp.age);


            for (int i = 0; i < nt1.Length; i++)
            {
                sw1.WriteLine(nt1[i].r_num);
                sw1.WriteLine(nt1[i].name);
                sw1.WriteLine(nt1[i].age);

            }
            sw1.Close();
            LoadData(ref nt1);
        }
        //---------
        public static void UpdateWritedata(ref Nursing[] ntarray)
        {
            using (StreamWriter sw1 = new StreamWriter(path))
            {
                //Console.WriteLine("----------");          // for debuging use, will be commented..
                //Console.WriteLine(index);
                //Console.WriteLine("----------");
                sw1.WriteLine(ntarray.Length);
                for (int i = 0; i < ntarray.Length; i++)
                {
                    //starray[i] = new Student();
                    if (ntarray[i] != null)
                    {
                        sw1.WriteLine(ntarray[i].r_num);
                        sw1.WriteLine(ntarray[i].name);
                        sw1.WriteLine(ntarray[i].age);

                        //Console.WriteLine(starray[i].id);             // for debuging use, will be commented..
                        //Console.WriteLine(starray[i].name);
                        //Console.WriteLine(starray[i].disease);
                        //Console.WriteLine(starray[i].ref_doc);
                    }
                }
                sw1.Close();
            }
            LoadData(ref ntarray);
        }

        public static void Update(ref Nursing[] ntarray, ref int enid)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Update Nurse Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Update ");
            enid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < ntarray.Length; i++)
            {
                if (ntarray[i].r_num == enid)
                {
                    Nursing temp = new Nursing();
                    Console.WriteLine("\nNow you can update its value\n\n");
                    Console.Write("Enter the Registration NO of the Nurse: ");
                    ntarray[i].r_num = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the name of the Nurse: ");
                    ntarray[i].name = Console.ReadLine();
                    Console.Write("Enter the age of the Nurse: ");
                    ntarray[i].age = Convert.ToInt32(Console.ReadLine());
                }
            }
            UpdateWritedata(ref ntarray);
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tNurse Record Has Updated Successfully.....");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
        public static void Delete(ref Nursing[] ntarray, ref int enid)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Delete Nurse Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Delete ");
            enid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < ntarray.Length; i++)
            {

                if (ntarray[i].r_num == enid)
                {
                    ntarray[i] = null;
                }
                   
             
           }
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tNurse Record Has Deleted Successfully.....");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        //----------


        public static void Search(ref Nursing[] ntarray, ref int enid, ref int ef)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Search Nurse Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Search ");
            enid = Convert.ToInt32(Console.ReadLine());
            ef = 0;
            Console.Clear();
            for (int i = 0; i < ntarray.Length; i++)
            {
                //if (starray[i] != null)
                //{
                if (ntarray[i].r_num == enid)
                {
                    ntarray[i].Display();
                    ef = 1;
                }
                //}
            }
            if (ef == 0)
            {
                Console.WriteLine("\n\t\t***********     Not found....!        *************\n\n\n");
            }            

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void Writedata01(ref Nursing[] ntarray)
        {
            using (StreamWriter sw1 = new StreamWriter(path))
            {
                //Console.WriteLine("----------");          // for debuging use, will be commented..
                //Console.WriteLine(index);
                //Console.WriteLine("----------");
                sw1.WriteLine(ntarray.Length - 1);
                for (int i = 0; i < ntarray.Length; i++)
                {
                    //starray[i] = new Student();
                    if (ntarray[i] != null)
                    {
                        sw1.WriteLine(ntarray[i].r_num);
                        sw1.WriteLine(ntarray[i].name);
                        sw1.WriteLine(ntarray[i].age);
                        //Console.WriteLine(starray[i].id);             // for debuging use, will be commented..
                        //Console.WriteLine(starray[i].name);
                        //Console.WriteLine(starray[i].disease);
                        //Console.WriteLine(starray[i].ref_doc);
                    }
                }
                sw1.Close();
            }
            LoadData(ref ntarray);
        }
    }
}
