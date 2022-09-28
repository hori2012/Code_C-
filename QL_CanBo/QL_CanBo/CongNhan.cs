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
        public CongNhan(string name, DateTime yearBirt, string gender, string add, double leverl) :base (name, yearBirt, gender, add)
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
            int k = 0;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            do
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
               if(eventString(name) == true)
                {
                    Name = name;
                    k = 1;
                }
            } while (k == 0);
            Console.Write("\nEnter Birtday ");
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
            //Console.Write("Enter level: ");
            errorType(ref this.level);
        }

        public override void Output()
        {
            Console.WriteLine("Name : {0}", Name);
            Console.WriteLine("BirthDay : {0}", YearBirt.ToString("D"));
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
