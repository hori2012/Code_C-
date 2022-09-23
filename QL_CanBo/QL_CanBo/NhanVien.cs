using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CanBo
{
    internal class NhanVien : CanBo
    {
        private string job;
        public NhanVien()
        {

        }
        public NhanVien(string name, DateTime yearBirt, string gender, string add, string job):base(name, yearBirt, gender, add)
        {
            this.Job = job;
        }

        public string Job { get => job; set => job = value; }

        public override string check()
        {
            return "NhanVien";
        }

        public override void Input()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int k = 0;
            do
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                if (eventString(name) == true)
                {
                    Name = name;
                    k = 1;
                }
            } while (k == 0);
            Console.Write("\nEnter Birtday: ");
            YearBirt = eventTime();
            do
            {
                Console.Write("\nEnter gender: ");
                string gender = Console.ReadLine();
                Gender = gender;
            } while ((Gender != "Nam" && Gender != "nam") && (Gender != "Nu" && Gender != "nu" && Gender != "Nữ" && Gender != "nữ"));
            int f = 0;
            do
            {
                Console.Write("Enter Address: ");
                string add = Console.ReadLine();
                if (eventString(add) == true)
                {
                    Add = add;
                    f = 1;
                }
            } while (f == 0);
            Console.Write("Enter job: ");
            string job = Console.ReadLine();
            this.job = job;
            int s = 0;
            do
            {
                Console.Write("Enter sector: ");
                string jobs = Console.ReadLine();
                if (eventString(jobs) == true)
                {
                    this.job = jobs;
                    s = 1;
                }
            } while (s == 0);
        }

        public override void Output()
        {
            Console.WriteLine("Name : {0}", Name);
            Console.WriteLine("BirthDay : {0}", YearBirt.ToString("D"));
            Console.WriteLine("Gender : {0}", Gender);
            Console.WriteLine("Address : {0}", Add);
            Console.WriteLine("Job : {0}", this.Job);
            Console.WriteLine("");
        }

        public override string toString()
        {
            return Name + " " + YearBirt + " " + Gender + " " + Add + " " + Job;
        }
    }
}
