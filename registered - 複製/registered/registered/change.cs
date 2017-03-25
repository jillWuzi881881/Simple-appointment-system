using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registered
{
    class change
    {
        public void 已看診(string[,] patients, string[,] doctors, string[] section, int[] count, string[,] pass)
        {
            string mm = "20160423", open;
            int i = 0, j = 0;
            string[] temp = new string[100];
            Console.WriteLine("請輸入密碼:");
            open = Console.ReadLine();
            if (open == mm)
            {
                Console.WriteLine("請輸入編號:");
                int num = int.Parse(Console.ReadLine());
                if (num >= count[0])
                {
                    Console.WriteLine("輸入錯誤");
                }
                else
                {
                    patients[num, 8] = "1";
                    for (j = 0; j < 9; j++)
                    {
                        temp[j] = patients[num, j];
                    }
                    for (i = num; i <= count[0]; i++)
                    {
                        for (j = 0; j < 9; j++)
                        {
                            patients[i, j] = patients[i + 1, j];
                        }
                    }
                    count[0]--;
                    for (j = 0; j < 9; j++)
                    {
                        pass[count[3], j] = temp[j];
                    }
                    count[3]++;
                }
            }
            else
            {
                Console.WriteLine("密碼錯誤");
            }
        }

        public void 進度(string[,] patients, string[,] doctors, string[] section, int[] count, string[,] pass)
        {
            string id;
            string[] temp = new string[100];
            int i = 0, j = 0, cho = 0, yn = 0, yn1 = 0;
            int[] cou = new int[100];
            int coun = 0;
            int pa = 0, no = 0, now = 0;//自己前面看過的有幾個，還沒看過的有幾個,現在看到幾號
            Console.Write("\n輸入身分證：\n");
            id = Console.ReadLine();//身分證
            Console.Write("編號 科別 看診日期 看診時段 醫師姓名 醫生診間 看診號\n");
            for (i = 0; i < count[0]; i++)
            {
                if (id.Equals(patients[i, 0]))
                {
                    Console.Write(i + "\t" + patients[i, 4] + "\t" + patients[i, 2] + "\t" + patients[i, 3] + "\t" + patients[i, 6] + "\t" + patients[i, 5] + "\t" + patients[i, 7] + "\n");
                    cou[coun++] = i;
                }
            }
            if (coun != 0)
            {
                Console.Write("要察看進度的編號：\n");
                cho = int.Parse(Console.ReadLine());//選擇功能
                for (i = 0; i < coun; i++)
                {
                    if (cou[i] == cho)
                    {
                        yn = 1;
                    }
                }
                if (yn == 1)//輸入編號正確要取消
                {
                    temp[0] = patients[cho, 2];//日期
                    temp[1] = patients[cho, 3];//時間
                    temp[2] = patients[cho, 6];//醫生
                    temp[3] = patients[cho, 7];//號碼
                    int n1, n2;
                    now = 0;
                    for (i = 0; i < count[3]; i++)
                    {
                        if (pass[i, 2] == temp[0] && pass[i, 3] == temp[1] && pass[i, 6] == temp[2])
                        {
                            n1 = int.Parse(pass[i, 7]);
                            n2 = int.Parse(temp[3]);
                            if (n1 < n2)
                            {
                                pa++;
                                if (now < n1)
                                {
                                    now = n1;
                                }
                            }
                        }
                    }
                    Console.Write("前面已看診數：" + pa + "\n目前看到" + now + "號\n");
                }
                else
                {
                    Console.Write("沒有掛號資料或輸入錯誤\n");
                }
            }
        }
    }
}