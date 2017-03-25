using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registered
{
    class registered
    {
        public void 掛號(string[,] patients, string[,] doctors, string[] section, int[] count, string[,] pass)
        {
            string num;
            int i = 0, cho = 0, yn = 0,numpor=0;
            int[] cou = new int[100];
            int coun = 0;
            NewlyDiagnosed first = new NewlyDiagnosed();
            
            for (i = 0; i < count[2]; i++)
            {
                Console.Write(section[i] + "\n");
            }
            Console.Write("\n輸入欲掛號診次的編號\n");
            num = Console.ReadLine();//選擇功能
            Console.Write("編號 看診日期 看診時段 醫師姓名 醫生診間 已預約人數(45滿)\n");
            for (i = 0; i < count[1]; i++)
            {
                if (num.Equals(doctors[i, 0]))
                {
                    Console.Write(i + "\t" + doctors[i, 1] + "\t" + doctors[i, 2] + "\t" + doctors[i, 3] + "\t" + doctors[i, 4] + "\t" + doctors[i, 5] + "\n");
                    cou[coun++] = i;
                }
            }
            if (coun != 0)
            {
                Console.Write("要掛號的編號\n");
                cho = int.Parse(Console.ReadLine());//選擇功能
                for (i = 0; i < coun; i++)
                {
                    if (cou[i] == cho)
                    {
                        yn = 1;
                    }
                }
                numpor=int.Parse(doctors[cho, 5]);
                if (numpor >= 45)//額滿
                {
                    yn = 0;
                }
               
                if (yn == 1)//輸入編號正確,沒有額滿沒有重複
                {
                    first.fi(patients, doctors, section, count, pass,cho);
                }
                else
                {
                    Console.Write("輸入錯誤或者人數已滿\n");
                }
            }
            else 
            {
                Console.Write("沒有資料或輸入錯誤\n");
            }
        }

        public void 醫生掛號(string[,] patients, string[,] doctors, string[] section, int[] count, string[,] pass)
        {
            string dname;
            int i = 0, cho = 0, yn = 0, numpor = 0;
            int[] cou = new int[100];
            int coun = 0;
            NewlyDiagnosed first = new NewlyDiagnosed();

            Console.Write("\n輸入醫生姓名(必須完全正確)：\n");
            dname = Console.ReadLine();//醫生姓名
            Console.Write("編號 科別 看診日期 看診時段 醫師姓名 醫生診間 已預約人數(45滿)\n");
            for (i = 0; i < count[1]; i++)
            {
                if (dname.Equals(doctors[i,3]))
                {
                    Console.Write(i + "\t" + doctors[i, 0] + "\t" + doctors[i, 1] + "\t" + doctors[i, 2] + "\t" + doctors[i, 3] + "\t" + doctors[i, 4] + "\t" + doctors[i, 5] + "\n");
                    cou[coun++] = i;
                }
            }
            if (coun != 0)
            {
                Console.Write("要掛號的編號\n");
                cho = int.Parse(Console.ReadLine());//選擇功能
                for (i = 0; i < coun; i++)
                {
                    if (cou[i] == cho)
                    {
                        yn = 1;
                    }
                }
                numpor = int.Parse(doctors[cho, 5]);
                if (numpor >= 45)//額滿
                {
                    yn = 0;
                }
                
                if (yn == 1)//輸入編號正確,沒有額滿沒有重複
                {
                    first.fi(patients, doctors, section, count, pass, cho);
                }
                else
                {
                    Console.Write("輸入錯誤或者人數已滿\n");
                }
            }
            else
            {
                Console.Write("沒有資料或輸入錯誤\n");
            }
        }
    }
}
