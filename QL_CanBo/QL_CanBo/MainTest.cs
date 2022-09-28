using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QL_CanBo
{
    internal class MainTest
    {
        static public void Menu()
        {
            int choice;
            int[] answer = new int[3];
            QLCB list = new QLCB();
            do
            {
                Console.WriteLine("\t\t\t*****************MENU*****************");
                Console.WriteLine("\t\t\t*      1. Nhap thong tin can bo      *");
                Console.WriteLine("\t\t\t*      2. Danh sach can bo           *");
                Console.WriteLine("\t\t\t*      3. Tim kiem can bo            *");
                Console.WriteLine("\t\t\t*      4. Thoat chuc nang            *");
                Console.WriteLine("\t\t\t**************************************");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap so luong Cong Nhan: ");
                        answer[0] = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nNhap so luong Ky Su: ");
                        answer[1] = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nNhap so luong Nhan Vien: ");
                        answer[2] = Convert.ToInt32(Console.ReadLine());
                        list.Enterlist(answer);
                        break;
                    case 2:
                        int[] key = list.countList();
                        if (key[0] != 0 && key[1] != 0 && key[2] != 0) {
                            list.listCB();
                        }
                        else if (key[0] != 0 && key[1] != 0 && key[2] == 0) {
                            list.listCB();
                        }
                        else if (key[0] != 0 && key[1] == 0 && key[2] != 0)
                        {
                            list.listCB();
                        }
                        else if (key[0] != 0 && key[1] == 0 && key[2] == 0)
                        {
                            list.listCB();
                        }
                        else if (key[0] == 0 && key[1] == 0 && key[2] != 0)
                        {
                            list.listCB();
                        }
                        else if (key[0] == 0 && key[1] != 0 && key[2] == 0)
                        {
                            list.listCB();
                        }
                        else if (key[0] == 0 && key[1] != 0 && key[2] != 0)
                        {
                            list.listCB();
                        }
                        else
                        {
                            Console.WriteLine("Khong co can bo de thuc hien chuc nang nay!!!!");
                        }
                        break;
                    case 3:
                        int[] key1 = list.countList();
                        if (key1[0] != 0 && key1[1] != 0 && key1[2] != 0)
                        {
                            Console.Write("Nhap ten can bo can tim: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("");
                            list.search(name);
                        }
                        else if (key1[0] != 0 && key1[1] != 0 && key1[2] == 0)
                        {
                            Console.Write("Nhap ten can bo can tim: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("");
                            list.search(name);
                        }
                        else if (key1[0] != 0 && key1[1] == 0 && key1[2] != 0)
                        {
                            Console.Write("Nhap ten can bo can tim: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("");
                            list.search(name);
                        }
                        else if (key1[0] != 0 && key1[1] == 0 && key1[2] == 0)
                        {
                            Console.Write("Nhap ten can bo can tim: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("");
                            list.search(name);
                        }
                        else if (key1[0] == 0 && key1[1] == 0 && key1[2] != 0)
                        {
                            Console.Write("Nhap ten can bo can tim: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("");
                            list.search(name);
                        }
                        else if (key1[0] == 0 && key1[1] != 0 && key1[2] == 0)
                        {
                            Console.Write("Nhap ten can bo can tim: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("");
                            list.search(name);
                        }
                        else if (key1[0] == 0 && key1[1] != 0 && key1[2] != 0)
                        {
                            Console.Write("Nhap ten can bo can tim: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("");
                            list.search(name);
                        }
                        else
                        {
                            Console.WriteLine("Khong co can bo de thuc hien chuc nang nay!!!!");
                        }
                        break;
                    default:
                        choice = list.exit();
                        break;
                }
            } while (choice != 5);
            Console.WriteLine("Nhan Enter de thoat chuong trinh !!!!");
        }
        static public void Main(string[] args)
        {
            //nhap();
            //CanBo a = new CongNhan("nam", 2002, "nam", "123", 1.2);
            //CanBo b = new KySu("duc", 2002, "nam", "123", "Cnnt");
            //CanBo c = new KySu("hao", 2002, "nam", "123", "Le Tan");
            //CanBo d = new CongNhan();
            //CanBo e = new KySu();
           // d.Input();
            //e.Input();
           // d.Output();
            //e.Output();
            //QLCB list = new QLCB();
            //list.List.Add(a);
            //list.List.Add(b);
            //list.List.Add(c);
            //Console.WriteLine("*****************************");
            //list.search("hao");
            //Console.WriteLine("*****************************");
            //list.search("nam");
            //Console.WriteLine("*****************************");
            //Console.WriteLine(a.toString());
            //Console.WriteLine(b.toString());
            //Console.WriteLine(c.toString());
            //Console.WriteLine("*****************************");
            //list.listCB();
             Menu();
            Console.ReadKey();
        }
    }
}
