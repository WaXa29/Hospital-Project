using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital_Project_01
{
    class Doctor : Employee
    {
        // public int r_num;
        //public string name;
        //public int age;
        //public static string ans;

        public static string path = @"doctoringrecord.txt";

        public int size; // Dynamic Size for array
      
        public static void LoadData(ref Doctor[] nt1)
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }

            StreamReader sr1 = new StreamReader(path);

            int size = Convert.ToInt32(sr1.ReadLine());
            nt1 = new Doctor[size];

            for (int i = 0; i < nt1.Length; i++)
            {
                nt1[i] = new Doctor();
                nt1[i].r_num = Convert.ToInt32(sr1.ReadLine());
                nt1[i].name = sr1.ReadLine();
                nt1[i].age = Convert.ToInt32(sr1.ReadLine());

            }
            sr1.Close();
        }

        public override void Display()
        {
            Console.WriteLine("Doctor Reg ID:     {0}", r_num);
            Console.WriteLine("Doctor Name:       {0}", name);
            Console.WriteLine("Doctor Age:        {0}", age);
            Console.WriteLine("----------------------------------------------------\n");

        }

        public static void DisplayAllEntries(Doctor[] dt1)
        {
            Console.Clear();
            for (int i = 0; i < dt1.Length; i++)
            {
                dt1[i].Display();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void Insert(ref Doctor[] dt1)
        {
            StreamWriter sw1 = new StreamWriter(path);
            sw1.WriteLine(dt1.Length + 1);

            Doctor temp = new Doctor();

            Console.Write("Enter the Registration NO of the Doctor: ");
            temp.r_num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the name of the Doctor: ");
            temp.name = Console.ReadLine();
            Console.Write("Enter the age of the Doctor: ");
            temp.age = Convert.ToInt32(Console.ReadLine());

            sw1.WriteLine(temp.r_num);
            sw1.WriteLine(temp.name);
            sw1.WriteLine(temp.age);


            for (int i = 0; i < dt1.Length; i++)
            {
                sw1.WriteLine(dt1[i].r_num);
                sw1.WriteLine(dt1[i].name);
                sw1.WriteLine(dt1[i].age);

            }
            sw1.Close();
            LoadData(ref dt1);
        }
        //---------
        public static void UpdateWritedata(ref Doctor[] dtarray)
        {
            using (StreamWriter sw1 = new StreamWriter(path))
            {
                //Console.WriteLine("----------");          // for debuging use, will be commented..
                //Console.WriteLine(index);
                //Console.WriteLine("----------");
                sw1.WriteLine(dtarray.Length);
                for (int i = 0; i < dtarray.Length; i++)
                {
                    //starray[i] = new Student();
                    if (dtarray[i] != null)
                    {
                        sw1.WriteLine(dtarray[i].r_num);
                        sw1.WriteLine(dtarray[i].name);
                        sw1.WriteLine(dtarray[i].age);

                        //Console.WriteLine(starray[i].id);             // for debuging use, will be commented..
                        //Console.WriteLine(starray[i].name);
                        //Console.WriteLine(starray[i].disease);
                        //Console.WriteLine(starray[i].ref_doc);
                    }
                }
                sw1.Close();
            }
            LoadData(ref dtarray);
        }

        public static void Update(ref Doctor[] dtarray, ref int enid)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Update Patient Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Update ");
            enid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < dtarray.Length; i++)
            {
                if (dtarray[i].r_num == enid)
                {
                    Doctor temp = new Doctor();
                    Console.WriteLine("\nNow you can update its value\n\n");
                    Console.Write("Enter the Registration NO of the Doctor: ");
                    dtarray[i].r_num = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the name of the Doctor: ");
                    dtarray[i].name = Console.ReadLine();
                    Console.Write("Enter the age of the Doctor: ");
                    dtarray[i].age = Convert.ToInt32(Console.ReadLine());
                }
            }
            UpdateWritedata(ref dtarray);
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tDoctor's Record Has Updated Successfully.....");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
        public static void Delete(ref Doctor[] dtarray, ref int enid)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Delete Doctor's Record Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Delete ");
            enid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < dtarray.Length; i++)
            {

                if (dtarray[i].r_num == enid)
                {
                    dtarray[i] = null;
                }
                   
             
           }
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tDoctor's Record Has Deleted Successfully.....");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        //----------


        public static void Search(ref Doctor[] dtarray, ref int enid, ref int df)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Search Doctor's Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Search ");
            enid = Convert.ToInt32(Console.ReadLine());
            df = 0;
            Console.Clear();
            for (int i = 0; i < dtarray.Length; i++)
            {
                //if (starray[i] != null)
                //{
                if (dtarray[i].r_num == enid)
                {
                    dtarray[i].Display();
                    df = 1;
                }
                //}
            }
            if (df == 0)
            {
                Console.WriteLine("\n\t\t***********     Not found....!        *************\n\n\n");
            }            

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void Writedata01(ref Doctor[] dtarray)
        {
            using (StreamWriter sw1 = new StreamWriter(path))
            {
                //Console.WriteLine("----------");          // for debuging use, will be commented..
                //Console.WriteLine(index);
                //Console.WriteLine("----------");
                sw1.WriteLine(dtarray.Length - 1);
                for (int i = 0; i < dtarray.Length; i++)
                {
                    //starray[i] = new Student();
                    if (dtarray[i] != null)
                    {
                        sw1.WriteLine(dtarray[i].r_num);
                        sw1.WriteLine(dtarray[i].name);
                        sw1.WriteLine(dtarray[i].age);
                        //Console.WriteLine(starray[i].id);             // for debuging use, will be commented..
                        //Console.WriteLine(starray[i].name);
                        //Console.WriteLine(starray[i].disease);
                        //Console.WriteLine(starray[i].ref_doc);
                    }
                }
                sw1.Close();
            }
            LoadData(ref dtarray);
        }
    }
}
