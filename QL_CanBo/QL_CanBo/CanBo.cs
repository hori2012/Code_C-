using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CanBo
{
    internal abstract class  CanBo
    {
        private string name;
        private int yearBirt;
        private string gender;
        private string add;
        public CanBo()
        {

        }
        public CanBo(string name, int yearBirt, string gender, string add)
        {
            this.Name = name;
            this.YearBirt = yearBirt;
            this.Gender = gender;
            this.Add = add;
        }

        public string Name { get => name; set => name = value; }
        public int YearBirt { get => yearBirt; set => yearBirt = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Add { get => add; set => add = value; }

        abstract public string toString();
        //nhap thong tin can bo
        abstract public void Input();
        //xuat thong tin can bo
        abstract public void Output();
        //kiem tra thuoc can bo nao(cong nhan, ky su hay nhan vien)
        abstract public string check();

    }
}
