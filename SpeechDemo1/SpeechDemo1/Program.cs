using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;

namespace SpeechDemo1
{
    class Program
    {
        private static readonly SpeechSynthesizer syn = new SpeechSynthesizer();
        private static readonly Choices list = new Choices();
        private static bool stop = false, please = false;

        static void Main(string[] args)
        {
            syn.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            list.Add(new String[] { "hello", "how are you", "stop", "please" });

            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.LoadGrammarAsync(gr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load speech grammar thingies : " + ex.Message);
            }
            rec.SpeechRecognized += rec_SpeechRecognized;
            rec.RequestRecognizerUpdate();
            try
            {
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to set input device : " + ex.Message);
            }
            //            syn.Speak("Hello Mart!");

            //            int table = 7;
            //            for (int i=1;i<=10;i++)
            //            {
            //                syn.Speak(""+i+"times"+table+"equals");
            //                syn.Speak("" + i * table);
            //           }

            // Tellertje bijhouden
            // 
            int hoogste = 0;
            int hoogsteIndex;
            for (int i = 27; i < 1000; i++)
            {
                int aantal = colatz(i);

                //syn.Speak("The colatz sequence for "+i+ " contains " + aantal+" iterations.");

                Thread.Sleep(100);

                if (stop)
                {
                    syn.Speak("Didn't you find this interesting?");
                    break;
                }
            }
        }

        private static void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "hello": { syn.Speak("Hi"); please = false; break; }
                case "how are you": { syn.Speak("I'm a bit busy"); please = false;  break; }
                case "stop": { if (!please) { syn.Speak("No"); } else { stop = true; } break; }
                case "please": { please = true; break; }
            }
        }

        static int colatz(int n) {
            // Maak een nieuwe Speech synthesyzer aan
            SpeechSynthesizer syn = new SpeechSynthesizer();
            // Dit is de Colatz procedure
            int count = 0;
            while (n>1)
            {
                count++;
                if (n%2==0)
                {
                    n = n / 2;
                } else
                {
                    n = n * 3 + 1;
                }
                //syn.Speak("" + n);
            }
            return count;
        }
    }
}
