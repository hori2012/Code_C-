using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QL_CanBo
{
    internal abstract class CanBo
    {
        private string name;
        private DateTime yearBirt;
        private string gender;
        private string add;
        public CanBo()
        {

        }
        public CanBo(string name, DateTime yearBirt, string gender, string add)
        {
            this.Name = name;
            this.YearBirt = yearBirt;
            this.Gender = gender;
            this.Add = add;
        }

        public string Name { get => name; set => name = value; }

        public string Gender { get => gender; set => gender = value; }
        public string Add { get => add; set => add = value; }
        public DateTime YearBirt { get => yearBirt; set => yearBirt = value; }

        abstract public string toString();
        //nhap thong tin can bo
        abstract public void Input();
        //xuat thong tin can bo
        abstract public void Output();
        //kiem tra thuoc can bo nao(cong nhan, ky su hay nhan vien)
        abstract public string check();

        static public bool KTString(char c)
        {
            int count = 0;
            char[] arr = {'á', 'ả', 'ã', 'ạ', 'à', 'â', 'ấ', 'ẫ', 'ẩ', 'ậ', 'ầ', 'ă', 'ắ', 'ẵ', 'ặ', 'ằ', 'ê',
                'ế', 'ề', 'ễ', 'ệ', 'ể', 'đ', 'i','í', 'ì', 'ị', 'ĩ', 'ỉ', 'ó', 'ò', 'ỏ', 'õ' , 'ọ', 'ú', 'ù' ,'ũ',
                'ủ', 'ụ', 'ý', 'ỳ', 'ỷ', 'ỹ', 'ỵ','ơ','ớ','ở', 'ợ', 'ỡ', 'ờ','ô','ố', 'ồ', 'ộ', 'ỗ', 'ổ','ứ', 'ừ', 'ử',
                'ữ','ự','é', 'è', 'ẽ', 'ẻ', 'ẹ','Á', 'Ả', 'Ã', 'Ạ', 'À', 'Â', 'Ấ', 'Ẫ', 'Ẩ', 'Ậ', 'Ầ', 'Ă', 'Ắ', 'Ẵ', 'Ặ', 'Ằ', 'Ê',
                'Ế', 'Ề', 'Ễ', 'Ệ', 'Ể', 'Đ', 'I','Í', 'Ì', 'Ị', 'Ĩ', 'Ỉ', 'Ó', 'Ò', 'Ỏ', 'Õ' , 'Ọ', 'Ú', 'Ù',
                'Ũ', 'Ủ', 'Ụ', 'Ý', 'Ỳ', 'Ỷ', 'Ỹ','Ỵ', 'Ớ','Ở', 'Ợ', 'Ỡ', 'Ờ','Ố', 'Ồ', 'Ộ', 'Ỗ', 'Ổ','Ứ', 'Ừ',
                'Ử', 'Ữ','Ự','É', 'È', 'Ẽ', 'Ẻ', 'Ẹ'};
            for (int i = 0; i < arr.Length; i++)
            {
                if (c == arr[i])
                {
                    count = 1;
                    //break;
                }
            }
            if (count != 1)
            {
                return false;
            }
            return true;
        }
        static public bool eventString(string str)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (KTString(str[i]) == true)
                    {
                        count++;
                    }
                    else if ((str[i] >= 65 && str[i] <= 90) || str[i] == 32 || ((str[i] >= 97 && str[i] <= 122)))
                    {
                        count++;
                    }
                    else
                    {
                        return false;
                    }
                }
            return true;
        }
        static public DateTime eventTime()
        {
            int day, month, year;
            do
            {
                Console.Write("\n\tEnter day:");
                day = Convert.ToInt32(Console.ReadLine());
            } while (day > 31 || day < 1);
            do
            {
                Console.Write("\n\tEnter month:");
                month = Convert.ToInt32(Console.ReadLine());
            } while (month > 12 || month <= 0);
            do
            {
                Console.Write("\n\tEnter year:");
                year = Convert.ToInt32(Console.ReadLine());
            } while (year < 1980 || ((DateTime.Now).Year - year) < 18);
            DateTime time = new DateTime(year, month, day);
            return time;
        } 
        static public void errorType(ref double c)
        {
            bool flag = true;
            Console.Write("Enter level: ");
            try
            {
                c = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e1)
            {
                Console.WriteLine("Only enter number Level !!!!");
                flag = false;
            }
            finally{
                if(flag == false)
                {
                    errorType(ref c);
                }
            }
        }
    }
}
