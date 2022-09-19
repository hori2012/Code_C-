using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CanBo
{
    internal class CongNhan : CanBo
    {
        private double level;

        public CongNhan()
        {
        }
        public CongNhan(string name, int yearBirt, string gender, string add, double leverl) :base (name, yearBirt, gender, add)
        {
            this.Level = leverl;
        }

        public double Level { get => level; set => level = value; }

        public override string check()
        {
            return "CongNhan";
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
            Console.Write("Enter level: ");
            double level = Convert.ToDouble(Console.ReadLine());
            this.level = level;
        }

        public override void Output()
        {
            Console.WriteLine("Name : {0}", Name);
            Console.WriteLine("BirthDay : {0}", YearBirt);
            Console.WriteLine("Gender : {0}", Gender);
            Console.WriteLine("Address : {0}", Add);
            Console.WriteLine("Level : {0}", this.level);
            Console.WriteLine("");
        }

        public override string toString()
        {
            return Name + " " + YearBirt + " " + Gender + " " + Add + " " + Level;
         }
    }
}
