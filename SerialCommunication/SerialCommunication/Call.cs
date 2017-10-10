using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunication
{
    public class Call : CallBack
    {
        void CallBack.callback()
        {
            Console.Out.WriteLine("呼叫!");
        }
    }
}
