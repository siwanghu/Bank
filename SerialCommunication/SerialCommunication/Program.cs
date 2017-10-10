using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SerialCommunication
{
    class Program
    {
        static void Main()
        {
            SerialPortCom serialPort = new SerialPortCom();           
            serialPort.Port = "COM5";
            serialPort.Baudrate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.Databits = 8;
            serialPort.Stopbits = (StopBits)1;
            serialPort.openSerialPort();

            Call call = new Call();
            serialPort.receiveSerialData(call);        
        }
    }
}
