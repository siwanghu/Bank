using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace SerialCommunication
{
    class SerialPortCom
    {       
        private SerialPort serialPort;
        private string port;
        private int baudrate;
        private Parity parity;
        private int databits;
        private StopBits stopbits;
        private bool read_again;
        private Thread thread;
        private List<string> buffer;
        private CallBack callback;

        public SerialPortCom()
        {
            serialPort = new SerialPort();
        }

        private void readSerialPort()
        {
            while (read_again)
            {
                byte[] data = new byte[1];
                try
                {
                    serialPort.Read(data,0,data.Length);
                    buffer.Add(data[0].ToString("X2"));
                    Console.Out.WriteLine(data[0].ToString("X2"));
                    if (data[0].ToString("X2").Equals("16"))
                    {
                        callback.callback();
                        buffer.Clear();
                    }              
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("超时错误!");
                }
            }
        }

        public void openSerialPort()
        {
            serialPort.PortName = port;
            serialPort.BaudRate = baudrate;
            serialPort.Parity = parity;
            serialPort.DataBits = databits;
            serialPort.StopBits = stopbits;
            buffer = new List<string>();
            serialPort.Open();
        }

        public void receiveSerialData(CallBack callback)
        {
            this.callback = callback;          
            read_again = true;
            thread = new Thread(readSerialPort);
            thread.Start(); 
        }

        public void callPager(byte id)
        {
            byte[] data = new byte[] { 255, 104, 2, 2, 104, id, 3, 4, 22 };
            serialPort.Write(data, 0, data.Length);
        }

        public void stopReceiveSerialData()
        {
            read_again = false;
        }

        public void closeSerialPort()
        {
            read_again = false;
            serialPort.Close();
        }

        public string Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        public int Baudrate
        {
            get
            {
                return baudrate;
            }
            set
            {
                baudrate = value;
            }
        }

        public Parity Parity
        {
            get
            {
                return parity;
            }
            set
            {
                parity = value;
            }
        }

        public int Databits
        {
            get
            {
                return databits;
            }
            set
            {
                databits = value;
            }
        }

        public StopBits Stopbits
        {
            get
            {
                return stopbits;
            }
            set
            {
                stopbits = value;
            }
        }     
    }
}
