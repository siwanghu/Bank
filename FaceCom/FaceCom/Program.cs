using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using ComminterFace;

namespace Face
{
    static class Program
    {

        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            readBankCard();
        }

        public static void readBankCard()
        {
            AllocConsole();
            FaceSynCom faceSynCom = new FaceSynCom();
            faceSynCom.openDevie();
            Console.Out.WriteLine("请放置银行卡");
            Console.In.ReadLine();
            Console.Clear();
            try
            {
                string[] strs = faceSynCom.getBankCardInfo();
                foreach (string str in strs)
                {
                    Console.Out.WriteLine(str);
                }
                Console.In.ReadLine();
            }
            catch(Exception e)
            {
                Console.Out.WriteLine(e);
            }
        }

        public static void readIdCard()
        {
            AllocConsole();
            FaceSynCom faceSynCom = new FaceSynCom();
            faceSynCom.openDevie();
            Console.Out.WriteLine("请放置身份证");
            Console.In.ReadLine();
            Console.Clear();
            if (faceSynCom.hasIdCard())
            {
                string[] strs = faceSynCom.getIdCardInfo();
                foreach (string str in strs)
                {
                    Console.Out.WriteLine(str);
                }
                Console.In.ReadLine();
            }
            else
            {
                Console.Out.WriteLine("身份证没有放置");
                Console.In.ReadLine();
            }
        }
    }
}

