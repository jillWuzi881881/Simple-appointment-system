using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace registered
{
    class Program
    {
        static string[,] patients = new string[10000, 9];//病人掛號資料
        static string[,] doctors = new string[10000, 6];//醫生看診資料
        static string[] section = new string[100];//科別一覽表
        static string[,] pass = new string[10000, 9];//看過的資料
        static int[] count = new int[100];//病人掛號數量,醫生看診資料比數,科別一覽表
        static string[] line0 = new string[5];//txt檔第一行
        static void Main(string[] args)
        {
            dataRandW data = new dataRandW();//檔案處理
            registered reg = new registered();
            searchanddel sad = new searchanddel();
            change chan = new change();
            
            data.readdata(patients, doctors, section, count, pass, line0);//讀檔
            int i = 0, j = 0, cho = 0;

            while (true)
            {
                Console.Write("\n1>查詢/取消預約掛號  2>依醫生掛號  3>依科別掛號(同科同時段不能掛號)  4>看診進度查詢  5>修改資料(醫) -1>結束\n");
                //修改資料   看診進度
                cho = int.Parse(Console.ReadLine());//選擇功能
                if (cho == 1)
                {
                    sad.搜尋取消(patients, doctors, section, count, pass);
                }
                else if (cho == 2)
                {
                    reg.醫生掛號(patients, doctors, section, count, pass);
                }
                else if (cho == 3)
                {
                    reg.掛號(patients, doctors, section, count, pass);
                }
                else if (cho == 4)
                {
                    chan.進度(patients, doctors, section, count, pass);
                }
                else if (cho == 5)
                {
                    chan.已看診(patients, doctors, section, count, pass);
                }
                else if (cho == -1)
                {
                    data.writedata(patients, doctors, section, count, pass, line0);//寫檔
                    break;
                }
                else
                {
                    Console.Write("輸入錯誤\n");
                }
                data.writedata(patients, doctors, section, count, pass, line0);//寫檔
            }

        }
    }

}