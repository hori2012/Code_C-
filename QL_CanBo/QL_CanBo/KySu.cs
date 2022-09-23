using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CanBo
{
    internal class KySu : CanBo
    {
        private string sector;
        public KySu()
        {

        }
        public KySu(string name, DateTime yearBirt, string gender, string add, string sector) : base(name, yearBirt, gender, add)
        {
            this.Sector = sector;
        }

        public string Sector { get => sector; set => sector = value; }

        public override string check()
        {
            return "KySu";
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
            int s = 0;
            do
            {
                Console.Write("Enter sector: ");
                string sector = Console.ReadLine();
                if (eventString(sector) == true)
                {
                    this.sector = sector;
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
            Console.WriteLine("Sector : {0}", this.sector);
            Console.WriteLine("");
        }

        public override string toString()
        {
            return  Name + " " + YearBirt + " " + Gender + " " + Add + " " + Sector ;
        }
    }
}
