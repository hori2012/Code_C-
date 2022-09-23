using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CanBo
{
    internal class QLCB
    {
        private List<CanBo> list = new List<CanBo>();
        
        public QLCB()
        {

        }
        public QLCB(List<CanBo> list)
        {
            List = list;
        }   

        public List<CanBo> List { get => list; set => list = value; }

        //tim kiem can bo theo ten
        public void search(string name)
        {
            int count = -1;
            {
                Console.WriteLine("*********Thong tin can bo {0}*********", name);
                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Compare(list[i].Name, name, true) == 0)
                    {
                        list[i].Output();
                        count = 0;
                        if (String.Compare(list[i].check(), "CongNhan") == 0)
                        {
                            Console.WriteLine("-------->>> Cong Nhan");
                        }
                        else if (String.Compare(list[i].check(), "KySu") == 0)
                        {
                            Console.WriteLine("-------->>> Ky Su");
                        }
                        else if (String.Compare(list[i].check(), "NhanVien") == 0)
                        {
                            Console.WriteLine("-------->>> Nhan Vien");
                        }
                    }
                }
            }
            if(count == -1)
            {
                Console.WriteLine("---> Khong co can bo '{0}' trong danh sach !!!!", name);
            }
        }

        //dem so luong can bo moi loai
        public int[] countList()
        {
            int[] answer = new int[] {0, 0, 0};
            for(int i = 0; i < list.Count; i++)
            {
                if (String.Compare(list[i].check(), "CongNhan") == 0)
                {
                    answer[0]++;
                }
                else if (String.Compare(list[i].check(), "KySu") == 0)
                {
                    answer[1]++;
                }
                else if (String.Compare(list[i].check(), "NhanVien") == 0)
                {
                    answer[2]++;
                }
            }
            return answer;
        }

        //nhap danh sach can bo
        public void Enterlist(int[] ans)
        {
            if (ans[0] != 0)
            {
                Console.WriteLine("****Enter information Cong Nhan****");
                for(int i = 0; i < ans[0]; i++)
                {
                    CanBo value = new CongNhan();
                    value.Input();
                    list.Add(value);
                }
            }
            if (ans[1] != 0)
            {
                Console.WriteLine("****Enter information Ky Su****");
                for (int i = 0; i < ans[1]; i++)
                {
                    CanBo value = new KySu();
                    value.Input();
                    list.Add(value);
                }
            }
            if (ans[2] != 0)
            {
                Console.WriteLine("****Enter information Nhan Vien****");
                for (int i = 0; i < ans[2]; i++)
                {
                    CanBo value = new NhanVien();
                    value.Input();
                    list.Add(value);
                }
            }
        }

        // xuat danh sach thong tin can bo
        public void listCB()
        {
            int[] pri = countList();
            if (pri[0] != 0)
            {
                Console.WriteLine("***********List Cong Nhan**************");
                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Compare(list[i].check(), "CongNhan") == 0)
                    {
                        list[i].Output();
                        
                    }
                }
            }
            else
            {
                Console.WriteLine("No exist Cong Nhan in list !!");
            }
            if(pri[1] != 0)
            {
                Console.WriteLine("***********List Ky Su**************");
                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Compare(list[i].check(), "KySu") == 0)
                    {
                        list[i].Output();
                    }
                }
            }
            else
            {
                Console.WriteLine("No exist Ky Su in list !!");
            }
            if (pri[2] != 0)
            {
                Console.WriteLine("***********List Nhan Vien**************");
                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Compare(list[i].check(), "NhanVien") == 0)
                    {
                        list[i].Output();
                    }
                }
            }
            else
            {
                Console.WriteLine("No exists Nhan Vien in list !!");
            }
        }

        //thoat chuong trinh
        public int exit()
        {
            list.Clear();
            return 5; 
        }
    }
}
