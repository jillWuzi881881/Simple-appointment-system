using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace registered
{
    class NewlyDiagnosed
    {

        static string[,] tdata = new string[3, 10];//三種資料 10個人 
        public void fi(string[,] patients, string[,] doctors, string[] section, int[] count, string[,] pass, int cho)
        {
            Random ranObj = new Random();
            string id;
            string name = null;
            string phone = null;
            int on=-1;
            int idcount = 0;
            int checkcount = 0;
            int check, timem,cho2 = 0;

            Console.WriteLine("請確認您所掛號的資料是否正確：");
            Console.WriteLine("");
            Console.WriteLine("掛號院區：花蓮慈濟醫院");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("科別名稱：" + doctors[cho, 0] + "\n");
            Console.Write("看診醫生：" + doctors[cho, 3] + "\n");
            Console.Write("看診日期：" + doctors[cho, 1] + "\n");
            Console.Write("看診時段：");
            timem = int.Parse(doctors[cho, 2]);
            if (timem == 1)
            {
                Console.Write("上午");
            }
            else if (timem == 2)
            {
                Console.Write("下午");
            }
            else
            {
                Console.Write("夜間");
            }
            Console.Write("\n看診診間：第" + doctors[cho, 4] + "診\n");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("請確認掛診資料：<1正確  其他<錯誤");
            cho2 = int.Parse(Console.ReadLine());//選擇功能

            if (cho2 == 1)
            {
                
                do//身分證防呆
                {
                    if (idcount > 0)
                    {
                        Console.Write("身分證字號有誤，");
                    }
                    idcount++;
                    Console.Write("請輸入身分證字號:");
                    id = Console.ReadLine();//存身分證
                    //Console.WriteLine("1) The length of '{0}' is {1}", id[0], id.Length);
                } while (('A' > id[0] || id[0] > 'Z') || id.Length != 10);

                int i = 0;
                for (i = 0; i < count[0]; i++)
                {
                    if (patients[i, 0] == id && patients[i, 2] == doctors[cho, 1] && patients[i, 3] == doctors[cho, 2] && patients[i, 4] == doctors[cho, 0])
                    {
                        on = i;
                    }
                }

                if (on == -1)
                {
                    int op = 0;//判定初診或複診
                    int index = 0;

                    for (i = 0; i < count[3]; i++)
                    {
                        if (pass[i, 0] == id)
                        {
                            op = 1;//複診
                            index = i;//存病患的index
                        }
                    }

                    if (op == 1)//複診
                    {
                        Console.WriteLine("");
                        name = pass[index, 1];
                        Console.WriteLine(pass[index, 1] + "大德您為複診病患");
                    }
                    else//初診
                    {
                        Console.Write("您為初診病患請輸入您的大名：");
                        name = Console.ReadLine();//存名字
                    }

                    int ranNum = ranObj.Next(1000, 10000);//產生亂數
                    do//驗證碼
                    {
                        if (checkcount > 0)
                        {
                            Console.WriteLine("驗證失敗!");
                            ranNum = ranObj.Next(1000, 10000);
                        }
                        checkcount++;
                        Console.Write("請輸入驗證碼(驗證碼通過即掛號成功)'{0}':", ranNum);
                        check = int.Parse(Console.ReadLine());
                    } while (ranNum != check);
                    

                    Console.WriteLine("取號成功！(花蓮慈濟醫院)");
                    Console.WriteLine("");
                    Console.WriteLine("您所掛號的資料如下：");
                    Console.WriteLine("");
                    Console.WriteLine("掛號院區：花蓮慈濟醫院");
                    Console.WriteLine("--------------------------------------------------");
                    Console.Write("科別名稱：" + doctors[cho, 0] + "\n");
                    Console.Write("看診醫生：" + doctors[cho, 3] + "\n");
                    Console.Write("看診日期：" + doctors[cho, 1] + "\n");
                    Console.Write("看診時段：");
                    timem = int.Parse(doctors[cho, 2]);
                    if (timem == 1)
                    {
                        Console.Write("上午");
                    }
                    else if (timem == 2)
                    {
                        Console.Write("下午");
                    }
                    else
                    {
                        Console.Write("夜間");
                    }
                    Console.Write("\n看診診間：第" + doctors[cho, 4] + "診\n");
                    ////科別看診資料  以約人數加1
                    int numper = int.Parse(doctors[cho, 5]);
                    numper += 1;
                    doctors[cho, 5] = Convert.ToString(numper);
                    Console.WriteLine("看診號碼：" + doctors[cho, 5] + "\n");
                    Console.WriteLine("--------------------------------------------------");

                    if (op != 1)//初診
                    {
                        Console.WriteLine("初診" + name + "大德(病歷號：{0}{1}{2}{3}****{4}{5})您好！", id[0], id[1], id[2], id[3], id[8], id[9]);
                        Console.WriteLine("您為初診病患，請於看診前提前三十分鐘至「服務台」辦理初診報到手續！");
                    }
                    else
                    {
                        Console.WriteLine("{0} 大德(病歷號：{1}{2}{3}{4}****{5}{6})您好！", tdata[2, index], id[0], id[1], id[2], id[3], id[8], id[9]);
                        Console.WriteLine("1.您為複診病患，預估看診時間為(11:30)！");
                        Console.WriteLine("2.預估看診時間受醫師實際看診狀況影響，如與現場看診時間不同，敬請見諒!");
                        Console.WriteLine("3.建議可於當天看診時段，來電診間，詢問實際看診進度，以為參考，感恩。");
                    }

                    ////病人掛號資料  新增在最後一筆
                    patients[count[0], 0] = id;
                    patients[count[0], 1] = name;
                    patients[count[0], 2] = doctors[cho, 1];
                    patients[count[0], 3] = doctors[cho, 2];
                    patients[count[0], 4] = doctors[cho, 0];
                    patients[count[0], 5] = doctors[cho, 4];
                    patients[count[0], 6] = doctors[cho, 3];
                    patients[count[0], 7] = doctors[cho, 5];
                    patients[count[0], 8] += 0;
                    count[0]++;

                }
                else
                {
                    Console.WriteLine("您已有同科別同時段掛診資料");
                    Console.Write("看診醫生：" + doctors[cho, 3] + "\n");
                    Console.Write("看診日期：" + doctors[cho, 1] + "\n");
                    Console.Write("看診時段：");
                    timem = int.Parse(doctors[cho, 2]);
                    if (timem == 1)
                    {
                        Console.Write("上午");
                    }
                    else if (timem == 2)
                    {
                        Console.Write("下午");
                    }
                    else
                    {
                        Console.Write("夜間");
                    }
                    Console.Write("\n看診診間：第" + doctors[cho, 4] + "診\n");
                    Console.WriteLine("看診號碼：" + doctors[cho, 5] + "\n");
                }
            }
        }
    }
}

