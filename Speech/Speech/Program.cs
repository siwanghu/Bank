using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Speech
{
    class Speech
    {
        private int volume;
        private int rate;
        private static Speech speech=null;
        private SpeechSynthesizer synthesizer = null;

        private Speech()
        {
            Volume = 100;
            Rate = 1;
            synthesizer = new SpeechSynthesizer();
        }

        public static Speech getInstance()
        {
            if (speech == null)
            {
                speech = new Speech();
                return speech;
            }
            else
            {
                return speech;
            }
        }

        public void speechText(string text)
        {
            synthesizer.Speak(text);
        }

        public int Rate
        {
            get
            {
                return rate;
            }

            set
            {
                rate = value;
            }
        }

        public int Volume
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
            }
        }

        static void Main(string[] args)
        {
            Speech.getInstance().speechText("hello world");
        }
    }
}
