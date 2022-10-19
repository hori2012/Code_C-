using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanVien
{
    internal class Fix
    {
        static public bool KTString(char c)
        {
            int count = 0;
            char[] arr = {'á', 'ả', 'ã', 'ạ', 'à', 'â', 'ấ', 'ẫ', 'ẩ', 'ậ', 'ầ', 'ă', 'ắ', 'ẵ', 'ặ', 'ẳ', 'ằ', 'ê',
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
                    break;
                }
            }
            if (count == 0)
            {
                return false;
            }
            return true;
        }
        static public bool eventString(string str)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int count = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (KTString(str[i]))
                {
                    count = 1;
                }
                if ((str[i] >= 65 && str[i] <= 90) && str[i] != 32 && !((str[i] >= 97 && str[i] <= 122)))
                {
                    count = 1;
                }
            }
            if (count == 0)
            {
                return false;
            }
            return true;
        }
        static public bool KTSDT(string sdt)
        {
            for (int i = 0; i < sdt.Length; i++)
            {
                if (!(sdt[i] >= 48 && sdt[i] <= 57))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
