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
        public KySu(string name, int yearBirt, string gender, string add, string sector) : base(name, yearBirt, gender, add)
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
            Console.Write("Enter sector: ");
            string sector = Console.ReadLine();
            this.sector = sector;
        }

        public override void Output()
        {
            Console.WriteLine("Name : {0}", Name);
            Console.WriteLine("BirthDay : {0}", YearBirt);
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
