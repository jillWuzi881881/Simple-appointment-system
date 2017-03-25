using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registered
{
    class searchanddel
    {
        public void 搜尋取消(string[,] patients, string[,] doctors, string[] section, int[] count, string[,] pass)
        {
            string id;
            string[] temp = new string[100];
            int i = 0,j=0, cho = 0, yn = 0,yn1=0;
            int[] cou = new int[100];
            int coun = 0;
            
            Console.Write("\n輸入身分證：\n");
            id = Console.ReadLine();//身分證
            Console.Write("編號 科別 看診日期 看診時段 醫師姓名 醫生診間 看診號\n");
            for (i = 0; i < count[0]; i++)
            {
                if (id.Equals(patients[i,0]))
                {
                    Console.Write(i + "\t" + patients[i, 4] + "\t" + patients[i, 2] + "\t" + patients[i, 3] + "\t" + patients[i, 6] + "\t" + patients[i, 5] + "\t" + patients[i, 7] + "\n");
                    cou[coun++] = i;
                }
            }
            if (coun != 0)
            {
                Console.Write("要取消的編號(輸入非以上編號為查閱完畢)：\n");
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
                    Console.Write("是否確定取消掛號：1>確定 other>取消\n");
                    yn1 = int.Parse(Console.ReadLine());//選擇功能
                    if (yn1 == 1)//輸入編號正確要取消
                    {
                        for (j = 0; j < 9; j++)
                            {
                                temp[j] = patients[cho, j];
                            }

                        for (i = cho; i <= count[0]; i++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                patients[i, j] = patients[i + 1, j];
                            }
                            if (patients[i+1 , 2] == temp[2] && patients[i + 1, 3] == temp[3] && patients[i + 1, 6] == temp[6])
                            { 
                                int number = int.Parse(patients[i + 1, 7]);
                                number--;
                                patients[i , 7] = Convert.ToString(number);
                            }
                        }
                        count[0]--;
                        for (i = 0; i <= count[1]; i++)
                        {
                            if (doctors[i, 1] == temp[2] && doctors[i, 2] == temp[3] && doctors[i, 3] == temp[6])
                            {
                                int number1 = int.Parse(doctors[i, 5]);
                                number1--;
                                doctors[i,5] = Convert.ToString(number1);
                            }
                        }
                    }
                    else
                    {
                        Console.Write("查閱完畢\n");
                    }
                }
                else
                {
                    Console.Write("查閱完畢\n");
                }
            }
            else
            {
                Console.Write("沒有掛號資料或輸入錯誤\n");
            }

        }

    }
}
