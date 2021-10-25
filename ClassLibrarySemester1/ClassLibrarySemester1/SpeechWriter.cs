using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1
{
    public class SpeechWriter
    {
        /// <summary>
        /// Enum to determin how much the SpeechWriter will say.
        /// </summary>
        public enum SpeechVerbosity
        {
            SILENT, // Don't say anything.
            MINIMAL, // Only say required things.
            VERBOSE, // Say additional information.
            POLITE // Also be polite. (@TODO: Can we delete this?)
        };

        // Variables to manage things to say.
        private readonly SpeechSynthesizer SS;
        // List all the things that need to be said.
        private BlockingCollection<string> speech = new BlockingCollection<string>();
        // Thead to manage each sentence.
        private Thread speaker;
        // Stop saying anything and start over.
        private bool stop = false;
        // How talky the application to be.
        private SpeechVerbosity verbosity = SpeechVerbosity.VERBOSE;

        public SpeechWriter()
        {
            // Create a new speech synthesizer.
            SS = new SpeechSynthesizer();
            // Configure the desired voice.
            SS.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            // Set a high speech rate.
            SS.Rate = 5;

            speak("SQL Editor is online", SpeechVerbosity.MINIMAL);
            speak("Ready to connect.", SpeechVerbosity.POLITE);
            speaker = new Thread(new ThreadStart(speaker_job));
            speaker.Start();
        }

        /// <summary>
        /// Whenever a sentence was completely pronounced, 
        /// check if there are more things to say...
        /// </summary>
        private void speaker_job()
        {
            while (!stop)
            {
                foreach (string text in speech.GetConsumingEnumerable())
                {
                    SS.Speak(text);
                }
                Thread.Sleep(100);
            }
        }

        public SpeechSynthesizer Synthesizer
        {
            get { return this.SS; }
        }

        public SpeechVerbosity Verbosity
        {
            get { return this.verbosity; }
            set { this.verbosity = value; }
        }

        public void Clear()
        {
            clearSpeechQueue();
        }

        /// <summary>
        /// Remove all the remaining items in the queue.
        /// There is no more need to say these things.
        /// </summary>
        public void clearSpeechQueue()
        {
            string item;
            while (speech.TryTake(out item)) ;
        }

        /// <summary>
        /// Say the provided text out loud.
        /// </summary>
        /// <param name="text">what to say.</param>
        /// <param name="verbosity">How important is this.</param>
        public void speak(string text, SpeechVerbosity verbosity = SpeechVerbosity.VERBOSE)
        {
            if (verbosity <= this.verbosity)
            {
                speech.Add(text);
            }
        }

        /// <summary>
        /// Say one of the following messages, depending on the current verbosity mode.
        /// </summary>
        /// <param name="v1">Say this when running in polite mode.</param>
        /// <param name="v2">Say this when running in verbose mode.</param>
        /// <param name="v3">Say this when running in minimal mode.</param>
        public void speak(string v1, string v2, string v3)
        {
            switch (this.verbosity)
            {
                case SpeechVerbosity.POLITE: { speak(v1, SpeechVerbosity.POLITE); break; }
                case SpeechVerbosity.VERBOSE: { speak(v2, SpeechVerbosity.VERBOSE); break; }
                case SpeechVerbosity.MINIMAL: { speak(v3, SpeechVerbosity.MINIMAL); break; }
            }
        }

        /// <summary>
        /// Similar to the three version one.
        /// </summary>
        /// <param name="v1">Say this when running in polite or verbose mode.</param>
        /// <param name="v2">Say this when running in minimal mode.</param>
        public void speak(string v1, string v2)
        {
            speak(v1, v1, v2);
        }

        public void Write(char value)
        {
            Write(""+value);
        }

        public void Write(bool value)
        {
            Write(""+value);
        }

        public void Write(long value)
        {
            Write("" + value);
        }

        public void Write(double value, int decimals = 2)
        {
            Write(value.ToString("F" + decimals));
        }

        public void Write(string value = "")
        {
            if (value.Length>0)
            {
                speak(value);
            }
        }

        public void Write(object value, string nullValue = "object is null")
        {
            if (value == null)
            {
                Write(nullValue);
            } 
            else
            {
                Write(value.ToString());
            }
        }

        public void WriteLine(char value)
        {
            Write(value);
        }

        public void WriteLine(bool value)
        {
            Write(value);
        }

        public void WriteLine(long value)
        {
            Write(value);
        }

        public void WriteLine(double value, int decimals = 2)
        {
            Write(value, decimals);
        }

        public void WriteLine(string value = "")
        {
            Write(value);
        }

        public void WriteLine(object value)
        {
            Write(value);
        }
    }
}
