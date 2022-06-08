using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital_Project_01
{
    class Patient
    {
        public int r_num;
        public string name;
        public int age;
        public string disease;
        public string ref_doc;
        public static string ans;

        public static string path = @"patientrecord.txt";

        public int size; // Dynamic Size for array

        public Patient()
        {
            r_num = 420;
            name = "Kevin";
            age = 48;
            disease = "fever";
            ref_doc = "DrCharles";
        }
        public static void LoadData(ref Patient[] pt1)
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }

            StreamReader sr = new StreamReader(path);

            int size = Convert.ToInt32(sr.ReadLine());
            pt1 = new Patient[size];

            for (int i = 0; i < pt1.Length; i++)
            {
                pt1[i] = new Patient();
                pt1[i].r_num = Convert.ToInt32(sr.ReadLine());
                pt1[i].name = sr.ReadLine();
                pt1[i].age = Convert.ToInt32(sr.ReadLine());
                pt1[i].disease = sr.ReadLine();
                pt1[i].ref_doc = sr.ReadLine();

            }
            sr.Close();
        }

        public void Display()
        {
            Console.WriteLine("Patient Reg ID:     {0}", r_num);
            Console.WriteLine("Patient Name:       {0}", name);
            Console.WriteLine("Patient Age:        {0}", age);
            Console.WriteLine("Patient Disease:    {0}", disease);
            Console.WriteLine("Refered to Doctor:  {0}", ref_doc);
            Console.WriteLine("----------------------------------------------------\n");

        }

        public static void DisplayAllEntries(Patient[] pt1)
        {
            Console.Clear();
            for (int i = 0; i < pt1.Length; i++)
            {
                pt1[i].Display();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void Insert(ref Patient[] pt1)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(pt1.Length + 1);

            Patient temp = new Patient();

            Console.Write("Enter the Registration NO of the patient: ");
            temp.r_num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the name of the patient: ");
            temp.name = Console.ReadLine();
            Console.Write("Enter the age of the patient: ");
            temp.age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Disease or problem for which he/she wants the treatment: ");
            temp.disease = Console.ReadLine();
            Console.Write("Enter the name of the Doctor to which he/she being reffered: ");
            temp.ref_doc = Console.ReadLine();

            sw.WriteLine(temp.r_num);
            sw.WriteLine(temp.name);
            sw.WriteLine(temp.age);
            sw.WriteLine(temp.disease);
            sw.WriteLine(temp.ref_doc);

            for (int i = 0; i < pt1.Length; i++)
            {
                sw.WriteLine(pt1[i].r_num);
                sw.WriteLine(pt1[i].name);
                sw.WriteLine(pt1[i].age);
                sw.WriteLine(pt1[i].disease);
                sw.WriteLine(pt1[i].ref_doc);
            }
            sw.Close();
            LoadData(ref pt1);
        }
        //---------
        public static void UpdateWritedata(ref Patient[] starray)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                //Console.WriteLine("----------");          // for debuging use, will be commented..
                //Console.WriteLine(index);
                //Console.WriteLine("----------");
                sw.WriteLine(starray.Length);
                for (int i = 0; i < starray.Length; i++)
                {
                    //starray[i] = new Student();
                    if (starray[i] != null)
                    {
                        sw.WriteLine(starray[i].r_num);
                        sw.WriteLine(starray[i].name);
                        sw.WriteLine(starray[i].age);
                        sw.WriteLine(starray[i].disease);
                        sw.WriteLine(starray[i].ref_doc);
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

        public static void Update(ref Patient[] starray, ref int enid)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Update Patient Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Update ");
            enid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < starray.Length; i++)
            {
                if (starray[i].r_num == enid)
                {
                    Patient temp = new Patient();
                    Console.WriteLine("\nNow you can update its value\n\n");
                    Console.Write("Enter the Registration NO of the patient: ");
                    starray[i].r_num = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the name of the patient: ");
                    starray[i].name = Console.ReadLine();
                    Console.Write("Enter the age of the patient: ");
                    starray[i].age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the Disease or problem for which he/she wants the treatment: ");
                    starray[i].disease = Console.ReadLine();
                    Console.Write("Enter the name of the Doctor to which he/she being reffered: ");
                    starray[i].ref_doc = Console.ReadLine();
                }
            }
            UpdateWritedata(ref starray);
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tPatient Has Updated Successfully.....");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
        public static void Delete(ref Patient[] starray, ref int enid)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Delete Patient Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Delete ");
            enid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < starray.Length; i++)
            {

                if (starray[i].r_num == enid)
                {
                    starray[i] = null;
                }
                   
             
           }
            Console.Clear();
            Console.WriteLine("\n\n\n\t\tPatient Has Deleted Successfully.....");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        //----------


        public static void Search(ref Patient[] starray, ref int enid, ref int nf)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Search Patient Information");
            Console.WriteLine("------ ---------------------");
            Console.WriteLine("Please Enter Id to Search ");
            enid = Convert.ToInt32(Console.ReadLine());
            nf = 0;
            Console.Clear();
            for (int i = 0; i < starray.Length; i++)
            {
                //if (starray[i] != null)
                //{
                if (starray[i].r_num == enid)
                {
                    starray[i].Display();
                    nf = 1;
                }
                //}
            }
            if (nf == 0)
            {
                Console.WriteLine("\n\t\t***********     Not found....!        *************\n\n\n");
            }            

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void Writedata01(ref Patient[] starray)
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
                        sw.WriteLine(starray[i].r_num);
                        sw.WriteLine(starray[i].name);
                        sw.WriteLine(starray[i].age);
                        sw.WriteLine(starray[i].disease);
                        sw.WriteLine(starray[i].ref_doc);
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

        
    }
}
