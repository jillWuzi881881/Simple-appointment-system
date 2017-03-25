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
        static void Main(string[] args)
        {
            int[] patients = new int[10000,8];
            StreamReader sr = new StreamReader(@"C:\secret_plan.txt");
            while (!sr.EndOfStream)
            { // 每次讀取一行，直到檔尾
                string line = sr.ReadLine(); // 讀取文字到 line 變數
            }
            sr.Close(); // 關閉串流

        }
    }
}
