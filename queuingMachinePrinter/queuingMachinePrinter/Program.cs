using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;
using System.IO;
using WinUI;

namespace queuingMachinePrinter
{
    class Printer
    {
        private int printInit = -1;
        private int printStatus = -1;
        
        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetInit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetInit();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetClean", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetClean();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetUsbportauto", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetUsbportauto();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetClose", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetClose();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetAlignment", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetAlignment(int iAlignment);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetBold", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetBold(int iBold);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetUnderline", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetUnderline(int underline);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetSpacechar", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetSpacechar(int iSpace);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetSpacechinese", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetSpacechinese(int iChsleftspace, int iChsrightspace);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetLeftmargin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetLeftmargin(int iLeftspace);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetLinespace", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetLinespace(int iLinespace);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetPrintport", CharSet = CharSet.Ansi , CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetPrintport(StringBuilder strPort, int iBaudrate);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintString", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintString(StringBuilder strData);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintString", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintStringA(String strData);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintSelfcheck", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintSelfcheck();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "GetStatus", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int GetStatus();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "GetStatusspecial", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int GetStatusspecial();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintFeedline", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintFeedline(int iLine);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetMarkoffsetcut", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetMarkoffsetcut(int iOffset);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetMarkoffsetprint", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetMarkoffsetprint(int iOffset);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintCutpaper", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintCutpaper(int iMode);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintMarkposition", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintMarkposition();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintMarkcutpaper", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintMarkcutpaper(int iMode);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintMarkpositioncut", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintMarkpositioncut();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintMarkpositionprint", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintMarkpositionprint();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintFeedDot", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintFeedDot(int Lnumber);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetSizetext", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetSizetext(int iHeight, int iWidth);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetSizechinese", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetSizechinese(int iHeight, int iWidth, int iUnderline, int iChinesetype);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetSizechar", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetSizechar(int iHeight, int iWidth, int iUnderline, int iAsciitype);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetItalic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetItalic(int iItalic);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetRotate", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetRotate(int iRotate);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetDirection", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetDirection(int iDirection);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetWhitemodel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetWhitemodel(int iWhite);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintDiskbmpfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintDiskbmpfile(StringBuilder strData);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintDiskimgfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintDiskimgfile(StringBuilder strData);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetNvbmp", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetNvbmp(int iNums, StringBuilder strData);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintNvmbp", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintNvmbp(int iNvindex, int iMode);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintQrcode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintQrcode(StringBuilder strData, int iLmargin, int iMside, int iRound);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintRemainQR", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintRemainQR();

        [DllImport("MsprintsdkRM.dll", EntryPoint = "Print1Dbar", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int Print1Dbar(int iWidth, int iHeight, int iHrisize, int iHriseat, int iCodetype, StringBuilder strDataint);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintPdf417", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintPdf417(int iDotwidth, int iDotheight, int iDatarows, int iDatacolumns, StringBuilder strData);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetCommmandmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetCommmandmode(int imode);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "SetCodepage", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SetCodepage(int country, int CPnumber);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "GetProductinformation", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int GetProductinformation(int Fstype, StringBuilder FIDdata, int iFidlen);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "GetSDKinformation", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int GetSDKinformation(StringBuilder FIDdata);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintTransmit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintTransmit(String strCmd, int iLength);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "PrintTransmit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int PrintTransmitA(byte[] strCmd, int iLength);

        [DllImport("MsprintsdkRM.dll", EntryPoint = "GetTransmit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int GetTransmit(byte[] strCmd, int iLength, uint[] strRecv, int iRelen);     

        public bool openSerialPort(StringBuilder Port, int iBaudrate)
        {
            SetPrintport(Port, iBaudrate);
            printInit = SetInit();
            if (printInit == 0)
                return true;
            else
                return false;
        }

        public bool openUsbPort()
        {
            SetUsbportauto();
            printInit = SetInit();
            if (printInit == 0)
                return true;
            else
                return false;
        }

        public void closeSerialPort()
        {
            SetClose();
        }

        public void cutPaper()
        {
            PrintCutpaper(1);
        }

        public void printTest(StringBuilder Text)
        {
            SetClean();
            SetSizetext(2, 2);
            SetAlignment(1);
            PrintString(Text);
            PrintFeedline(20);
            PrintCutpaper(1);
            SetClean();
        }

        public String getStatus()
        {
            printStatus = GetStatus();
            switch (printStatus)
            {
                case 0:
                    return "打印机正常";
                case 1:
                    return "打印机未连接或未上电";
                case 2:
                    return "打印机和调用库不匹配";
                case 3:
                    return "打印头打开";
                case 4:
                    return "切刀未复位";
                case 5:
                    return "打印头过热 ";
                case 6:
                    return "黑标错误";
                case 7:
                    return "纸尽";
                case 8:
                    return "纸将尽";
                default:
                    return "方法异常";
            }
        }

        public void print(StringBuilder number, StringBuilder business, StringBuilder queue)
        {
            bool[] bools = ConfigureXml.getInstance().getPrintForm_titles();
            SetClean();
            SetAlignment(1);           
            if (bools[0])
            {
                SetSizetext(3, 3);
                StringBuilder head = new StringBuilder("欢迎光临");
                PrintString(head);
                PrintFeedline(1);
            }           
            SetSizetext(2, 2);
            PrintString(business);
            PrintFeedline(1);
            if (bools[1])
            {
                SetSizetext(3, 3);
                PrintString(number);
                SetSizetext(1, 1);
                PrintFeedline(1);
            }
            if (bools[2])
            {
                PrintString(new StringBuilder("你前面还有" + queue.ToString() + "人"));
                PrintFeedline(1);
            }
            if (bools[3])
            {
                SetAlignment(0);
                SetSizetext(1, 1);
                StringBuilder time = new StringBuilder(DateTime.Now.ToLocalTime().ToString());
                PrintString(time);
                PrintFeedline(5);
            }
            PrintCutpaper(0);
            SetClean();
        }
    }
}
