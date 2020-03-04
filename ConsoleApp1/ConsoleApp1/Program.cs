using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer syn = new SpeechSynthesizer();
            syn.Speak("Hallo Mart!");

            int tafel = 7;
            for (int i = 1; i <= 10; i++)
            {
                syn.Speak(i + "times" + tafel + "=");
                syn.Speak("" + i * tafel);
            }
        }
    }
}
