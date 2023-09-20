using System;
using System.Speech.Synthesis;

namespace BroadcastCycle_UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            
            // Customize speech properties
            synthesizer.Volume = 100;
            synthesizer.Rate = 0;
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            //synthesizer.Speak("The time is " + DateTime.Now.ToString("t") + ", " + localTimeZone.StandardName + ".");
            //while (true)
            //{
            //    synthesizer.Speak("The current time is, " + DateTime.Now.ToString("t") + ", " + localTimeZone.StandardName + ".");
            //    synthesizer.Speak("The Bell East 1 6 2 point 4 7 5 telephone slash pots line repeater, is currently off the air for routine work and maintenance. As a result, this station will not be able to relay any messages or alerts from the National Weather Service. Until service is restored, you can find information from the National Weather Service at w w w dot weather dot gov slash melbourne, or from media sources. If you are hearing this loss of audio message, please contact Bell East. If you choose to contact Bell East, please include the platform you are listening on, which is currently, Bell East 1 6 2 point 4 7 5 telephone slash pots line repeater.");
            //}

            while (true)
            synthesizer.Speak("NOAH Weather Radio Station K I H 63 serving, Orlando, and the surrounding area is off the air due to loss of its audio programming information. As a result, this station will not be able to broadcast warnings for forecasts. Until service is restored, listeners may obtain information on local weather from the National Weather Service at w w w dot weather dot gov slash m a f, or from local media. Anyone hearing this loss of audio message should report this condition to the National Weather Service via email at nws dot m a f audio at NOAH dot gov. Please include the station callsign, K I H 63, in your email message reporting this loss of audio condition.");
        }
    }
}
