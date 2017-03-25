using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace registered
{
    class dataRandW
    {
        public void readdata(string[,] patients, string[,] doctors, string[] section, int[] count, string[,] pass,string[] line0)
        {
            string s,s1,s2,s3;
            int i = 0,j=0;
            //Console.WriteLine("輸入檔案位置：小老鼠加雙引號中放位置，不用檔案名稱");
            s = Directory.GetCurrentDirectory();//找位置(透過Directory的GetCurrentDirectory (WinForm、WPF)取得目前應用程式工作目錄)
            //s = Console.ReadLine();
            s1 = Directory.GetCurrentDirectory();
            s2 = Directory.GetCurrentDirectory();
            s3 = Directory.GetCurrentDirectory();
            s += "\\病患掛號資料.txt";
            StreamReader sr = new StreamReader(@s);
            line0[0] = sr.ReadLine();
            Console.Write(line0[0]+"\n");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] temp = line.Split(' ');
                for (j = 0; j < 9; j++)
                {
                    patients[count[0], j] = temp[j];
                    Console.Write(patients[count[0],j] + "\t");
                }
                Console.WriteLine();
                count[0]++;
            }
            sr.Close(); // 關閉串流

            s1 += "\\科別醫師看診資料.txt";
            StreamReader sr1 = new StreamReader(@s1);
            line0[1] = sr1.ReadLine();
           // Console.Write(line0[1] + "\n");
            while (!sr1.EndOfStream)
            {
                string line = sr1.ReadLine();
                string[] temp1 = line.Split(' ');
                for (j = 0; j < 6; j++)
                {
                    doctors[count[1], j] = temp1[j];
                    //Console.Write(doctors[count[1], j] + "\t");
                }
                count[1]++;
                
            }
            sr1.Close(); // 關閉串流
            s2 += "\\科別一覽表.txt";
            StreamReader sr2 = new StreamReader(@s2);
            while (!sr2.EndOfStream)
            {
                string line = sr2.ReadLine();
                section[count[2]] = line;
                //Console.Write(section[count[2]] + "\n");
                count[2]++;
            }
            sr2.Close(); // 關閉串流

            s3 += "\\已看過診的資料.txt";
            StreamReader sr3 = new StreamReader(@s3);
            line0[2] = sr3.ReadLine();
            //Console.Write(line0[2]+"\n");
            while (!sr3.EndOfStream)
            {
                string line = sr3.ReadLine();
                string[] temp = line.Split(' ');
                for (j = 0; j < 9; j++)
                {
                    pass[count[3], j] = temp[j];
               //     Console.Write(pass[count[3], j] + "\t");
                }
               //  Console.WriteLine();
                count[3]++;
            }
            sr3.Close(); // 關閉串流
        }
        public void writedata(string[,] patients, string[,] doctors, string[] section, int[] count, string[,] pass, string[] line0)
        {
           
            string s, s1, s2, s3;
            int i = 0, j = 0;
            
            s = Directory.GetCurrentDirectory();//找位置(透過Directory的GetCurrentDirectory (WinForm、WPF)取得目前應用程式工作目錄)
            s1 = Directory.GetCurrentDirectory();
            s2 = Directory.GetCurrentDirectory();
            s3 = Directory.GetCurrentDirectory();
            s += "\\病患掛號資料.txt";
            StreamWriter sw = new StreamWriter(@s);
            sw.Write(line0[0]);
            for (i = 0; i < count[0];i++ )
            {
                sw.WriteLine();
                for (j = 0; j < 9; j++)
                {
                    sw.Write(patients[i, j]);
                    if (j != 8)
                    {
                        sw.Write(" ");
                    }
                }
            }
            sw.Close();
            s1 += "\\科別醫師看診資料.txt";
            sw = new StreamWriter(@s1);
            sw.Write(line0[1]);
            for (i = 0; i < count[1]; i++)
            {
                sw.WriteLine();
                for (j = 0; j < 6; j++)
                {
                    sw.Write(doctors[i, j]);
                    if (j != 5)
                    {
                        sw.Write(" ");
                    }
                }
            }
            sw.Close();

            s3 += "\\已看過診的資料.txt";
            sw = new StreamWriter(@s3);
            sw.Write(line0[2]);
            for (i = 0; i < count[3]; i++)
            {
                sw.WriteLine();
                for (j = 0; j < 9; j++)
                {
                    sw.Write(pass[i, j]);
                    if (j != 8)
                    {
                        sw.Write(" ");
                    }
                }
            }
            sw.Close();
        }
    }
}
