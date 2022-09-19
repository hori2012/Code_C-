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
        public NhanVien(string name, int yearBirt, string gender, string add, string job):base(name, yearBirt, gender, add)
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
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Name = name;
            Console.Write("\nEnter year Birtday: ");
            int year = Convert.ToInt32(Console.ReadLine());
            YearBirt = year;
            do
            {
                Console.Write("\nEnter gender: ");
                string gender = Console.ReadLine();
                Gender = gender;
            } while (Gender != "Nam" && Gender != "Nu");
            Console.Write("\nEnter address: ");
            string add = Console.ReadLine();
            Add = add;
            Console.Write("Enter job: ");
            string job = Console.ReadLine();
            this.job = job;
        }

        public override void Output()
        {
            Console.WriteLine("Name : {0}", Name);
            Console.WriteLine("BirthDay : {0}", YearBirt);
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
