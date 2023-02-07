using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace Home_Task
{
    internal class Program
    {
        private static byte item;

        static void Main(string[] args)
        {
            Group[] groups = new Group[0];

            string opr;
            do
            {
                Console.WriteLine("1.Qrup elave et");
                Console.Write("2.Butun Qruplara bax ");
                Console.WriteLine("3.Type deyerine gore axtaris et");
                Console.WriteLine("4.Bugunedek yaradilmiw qruplara bax ");
                Console.WriteLine("5.Son 2 ayda yarilmiw qruplara bax ");
                Console.WriteLine("6.Bu ayin sonunadek baslayacaq qruplara bax ");
                Console.WriteLine("7.Verilmiw 2 tarix arasinda baslamis qruplara bax ");
                Console.WriteLine("0. Menudan cix ");
                opr = Console.ReadLine();

                switch (opr)
                {
                    case "1":

                        Console.WriteLine("Groupno daxil edin");
                        string GroupNo = Console.ReadLine();
                        Console.WriteLine("Grouptype daxil edin");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");


                        string typeStr = Console.ReadLine();
                        byte typeByte = Convert.ToByte(typeStr);
                        GroupType type = (GroupType)typeByte;

                        Console.WriteLine("StarDate daxil edin ");
                        string startDatestr = Console.ReadLine();
                        DateTime startDate = Convert.ToDateTime(startDatestr);

                        Group group = new Group()
                        {
                            GroupNo = GroupNo,
                            Type = type,
                            StartDate = startDate,



                        };
                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;
                        break;
                    case "2":

                        foreach (var item in groups)
                        {

                            Console.WriteLine($"GroupNo : {item.GroupNo} Type : {item.Type} StartDate : {item.StartDate} ");

                        }

                        break;
                    case "3":
                        foreach (var item in Enum.GetValues(typeof(GroupType))) 
                        Console.WriteLine($"{(byte)item} - {item}");
                        Console.WriteLine("Type : ");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;
                        foreach (var item in groups)
                        {

                            if (item.Type == type)
                            {
                                Console.WriteLine($"GroupNo : {item.GroupNo} Type : {item.Type} StartDate : {item.StartDate.ToString("dd-MM-yyyy HH:mm")}");


                            }
                        }
                        break;

                    case "4":
                        DateTime datetime = new DateTime();
                        datetime = DateTime.Now;
                        int count = 0;
                        foreach (var item in groups)
                        {
                            if (item.StartDate < datetime)
                            {
                                count++;
                                Console.WriteLine($"{item.Type} {item.GroupNo} {item.StartDate}");
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("bele qrup movcud deyil");

                        }

                        break;
                    case "5":

                        int count2 = 0;
                        foreach (var item in groups)
                        {

                            if (item.StartDate > DateTime.Now.AddMonths(-2) && item.StartDate < DateTime.Now) ;
                            count2++;
                        }
                        if (count2 == 0)
                        {
                            Console.WriteLine("Son 2 ayda baslamis qrup yoxdur");

                        }




                        break;
                    case "6":


                        int count3 = 0;
                        foreach (var item in groups)
                        {

                            if (item.StartDate.Month == DateTime.Now.Month && item.StartDate.Year == DateTime.Now.Year && item.StartDate.Day >= DateTime.Now.Day)
                            {

                                count3++;
                                Console.WriteLine($"GroupNo : {item.GroupNo} - Type : {item.Type} -  StartDate : {item.StartDate.ToString("dd-MM-yyyy")} ");
                            }

                            if (count3 == 0)
                            {

                                Console.WriteLine("Bu ayin sonuna qeder yeni baslayacaq qrup yoxdur");

                            }




                        }
                        break;

                    case "7":

                        Console.WriteLine("StarDate daxil edin ");
                        var  date1 = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Bitis tarixini qeyd edin ");
                        var date2=Convert.ToDateTime(Console.ReadLine());


                    


                        foreach (var item in groups)
                        {
                            if (item.StartDate>date1&&item.EndDate<date2)
                            {
                                Console.WriteLine($"{item.Type}-{item.GroupNo}-{item.StartDate}");
                            }


                        }
                       
                         
                            


                        

















                        break;



                }




            } while (opr != "0");


        }
    }
}
