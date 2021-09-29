using System;
using System.Collections.Generic;
using System.Text;

namespace Real_estate_management
{
    public abstract class CongTyDiaOc
    {
        private string DiaDiem;
        private float GiaTien;
        private float DienTich;

        public float GiaTien1 { get => GiaTien; set => GiaTien = value; }
        public string DiaDiem1 { get => DiaDiem; set => DiaDiem = value; }
        public float DienTich1 { get => DienTich; set => DienTich = value; }

        public CongTyDiaOc(string diaDiem, float giaTien, float dienTich)
        {
            this.DiaDiem = diaDiem;
            this.GiaTien = giaTien;
            this.DienTich = dienTich;
        }

        public CongTyDiaOc()
        {
        }
        public void input()
        {
            Console.Write("Nhập địa điểm: ");
            DiaDiem = Console.ReadLine();
            Console.Write("Nhập giá tiền: ");
            GiaTien = float.Parse(Console.ReadLine());
            Console.Write("Nhập diện tích: ");
            DienTich = float.Parse(Console.ReadLine());
        }
        public void show()
        {
            Console.WriteLine("địa điểm:{0}\n giá tiền: {1}\n diện tích: {2}\n", this.DiaDiem, this.GiaTien, this.DienTich);
        }
    }
    public class KhuDat : CongTyDiaOc
    {

    }
    public class NhaPho : CongTyDiaOc
    {

        private int NamXayDung;
        private int SoTang;

        public NhaPho()
        {
        }

        public NhaPho(string diaDiem, float giaTien, float dienTich, int namXD, int soTang) : base(diaDiem, giaTien, dienTich)
        {
            this.NamXayDung = namXD;
            this.SoTang = soTang;
        }

        public int NamXayDung1 { get => NamXayDung; set => NamXayDung = value; }

        public void inputNhaPho()
        {
            Console.Write("Nhập năm xây dựng: ");
            NamXayDung = int.Parse(Console.ReadLine());
            Console.Write("Nhập số tầng: ");
            SoTang = int.Parse(Console.ReadLine());

        }
        public void showNhaPho()
        {
            Console.WriteLine(" năm xây dựng:{0}\n số tầng:{1} ", this.NamXayDung, this.SoTang);
        }



    }
    class ChungCu : CongTyDiaOc
    {
        private int Tang;

        public ChungCu()
        {
        }

        public ChungCu(string diaDiem, float giaTien, float dienTich, int tang) : base(diaDiem, giaTien, dienTich)
        {
            this.Tang = tang;
        }
        public void inputChungCu()
        {
            Console.Write("Nhập tầng: ");
            Tang = int.Parse(Console.ReadLine());
        }
        public void showChungCu()
        {
            Console.WriteLine("tang:{0} ", this.Tang);
        }

    }

    class Program
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int choice;
            List<KhuDat> danhSachKhuDat = new List<KhuDat>();
            List<NhaPho> danhSachNhaPho = new List<NhaPho>();
            List<ChungCu> danhSachChungCu = new List<ChungCu>();
            while (true)
            {
                Console.WriteLine("----- MENU -----");
                Console.WriteLine("1.Thêm mới");
                Console.WriteLine("2.Xem danh sách");
                Console.WriteLine("3.Xuất tổng giá bán");
                Console.WriteLine("4.Xuất danh sách theo diện tích");
                Console.WriteLine("5.Tìm kiếm");
                Console.Write("Your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1.Khu đất");
                        Console.WriteLine("2.Nhà phố");
                        Console.WriteLine("3.Chung cư");
                        Console.Write("Your choice: ");
                        int add = int.Parse(Console.ReadLine());
                        switch (add)
                        {
                            case 1:
                                KhuDat kd1 = new KhuDat();
                                kd1.input();
                                danhSachKhuDat.Add(kd1);
                                break;
                            case 2:
                                NhaPho np1 = new NhaPho();
                                np1.input();
                                np1.inputNhaPho();
                                danhSachNhaPho.Add(np1);
                                break;
                            case 3:
                                ChungCu cc1 = new ChungCu();
                                cc1.input();
                                cc1.inputChungCu();
                                danhSachChungCu.Add(cc1);
                                break;

                        }
                        break;
                    case 2:
                        Console.WriteLine("1.Danh sách khu đất");
                        Console.WriteLine("2.Danh sách nhà phố");
                        Console.WriteLine("3.Danh sách chung cư");
                        Console.Write("Your choice: ");
                        int view = int.Parse(Console.ReadLine());
                        switch (view)
                        {
                            case 1:
                                foreach (var item in danhSachKhuDat)
                                {
                                    item.show();
                                }
                                break;
                            case 2:
                                foreach (var item in danhSachNhaPho)
                                {
                                    item.show();
                                    item.showNhaPho();
                                }
                                break;
                            case 3:
                                foreach (var item in danhSachChungCu)
                                {
                                    item.show();
                                    item.showChungCu();
                                }
                                break;


                        }
                        break;
                    case 3:
                        Console.Write("Tổng giá tiền khu đất: ");
                        float total = 0;
                        for (int i = 0; i < danhSachKhuDat.Count; i++)
                        {
                            total += danhSachKhuDat[i].GiaTien1;

                        }
                        Console.WriteLine("{0}", total);
                        Console.Write("Tổng giá tiền nhà phố: ");
                        float total1 = 0;
                        for (int i = 0; i < danhSachNhaPho.Count; i++)
                        {
                            total1 += danhSachNhaPho[i].GiaTien1;
                        }
                        Console.WriteLine("{0}", total1);
                        Console.Write("Tổng giá tiền chung cư: ");
                        float total2 = 0;
                        for (int i = 0; i < danhSachChungCu.Count; i++)
                        {
                            total2 += danhSachChungCu[i].GiaTien1;
                        }
                        Console.WriteLine("{0}", total2);

                        break;
                    case 4:
                        foreach (var item in danhSachKhuDat)
                        {
                            if (item.DienTich1 > 100)
                            {
                                item.show();
                            }
                            else
                            {
                                foreach (var item1 in danhSachNhaPho)
                                {
                                    if (item1.DienTich1 > 60 && item1.NamXayDung1 >= 2020)
                                    {
                                        item1.show();
                                        item1.showNhaPho();
                                    }
                                }
                            }
                        }
                        break;
                    case 5:
                        Console.Write("Nhập địa điểm: ");
                        string search1 = Console.ReadLine();
                        Console.Write("Nhập giá tiền: ");
                        float search2 = float.Parse(Console.ReadLine());
                        Console.Write("Nhập diện tích: ");
                        float search3 = float.Parse(Console.ReadLine());

                        foreach (var item2 in danhSachNhaPho)
                        {
                            if (item2.DiaDiem1.Contains(search1) && (item2.GiaTien1 <= search2 && item2.DienTich1 >= search3))
                            {
                                item2.show();
                                item2.showNhaPho();
                            }
                        }

                        foreach (var item3 in danhSachChungCu)
                        {
                            if (item3.DiaDiem1.Contains(search1) && (item3.GiaTien1 <= search2 && item3.DienTich1 >= search3))
                            {
                                item3.show();
                                item3.showChungCu();
                            }
                        }
                        break;
                    case 6:
                        return;
                }
            }




        }
    }
}
