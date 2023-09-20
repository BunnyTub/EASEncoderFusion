using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using EASEncoder.Models;
//using SpeechLib;

namespace EASEncoderFusion
{
    public static class EASEncoder
    {
        private static readonly SAMEAudioBit Mark = new SAMEAudioBit(2083, (decimal)0.00192);
        private static readonly SAMEAudioBit Space = new SAMEAudioBit(1563, (decimal)0.00192);
        private static int[] _headerSamples;
        private static int TotalHeaderSamples => _headerSamples.Length;
        private static List<int> _silenceSamples;
        //private static List<int> _SASMEXSamples;
        private static int[] _eomSamples;
        private static int TotalEomSamples => _eomSamples.Length;
        private static byte[] _ebsTonesStream;
        private static int _ebsToneSamples = 352800;
        private static byte[] _nwsTonesStream;
        private static int _nwstoneSamples = 352800;
        private static byte[] _censorTonesStream;
        private static int _censorToneSamples = 352800;
        private static byte[] _announcementStream;
        private static int _announcementSamples;
        //private static readonly int totalSilenceSamples = 176400;
        private static readonly int totalSilenceSamples = 176400;
        //private static readonly int totalSASMEXSamples = 44100;
        private static int _totalSamples;
        private static bool _useEbsTone = true;
        private static bool _useNwsTone;
        private static bool _useCensorTone;
        private static string _announcement = string.Empty;

        private static readonly Dictionary<decimal, List<int>> headerByteCache = new Dictionary<decimal, List<int>>();

        public static void CreateNewMessageFromRawData(string message, bool ebsTone = true, bool nwsTone = false, bool censorTone = false, string announcement = "", string filename = "output")
        {
            // These two strings are VERY important and altering them will cause any listening radios to malfunction or not respond to the EAS message.
            // Do not alter these strings!
            string Preamble = "\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab";
            string EOM = "\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xabNNNN";
            _useEbsTone = ebsTone;
            _useNwsTone = nwsTone;
            _useCensorTone = censorTone;
            _announcement = announcement;

            _headerSamples = new int[0];
            var byteArray = Encoding.Default.GetBytes($"{Preamble}ZCZC-{message}");
            var volume = 5000;

            var byteSpec = new List<SameWavBit>();
            byte thisByte;
            SAMEAudioBit thisBit;

            for (var i = 0; i < byteArray.Length; i++)
            {
                thisByte = byteArray[i];

                for (var e = 0; e < 8; e++)
                {
                    thisBit = ((thisByte & (short)Math.Pow(2, e)) != 0 ? Mark : Space);
                    byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, volume));
                }
            }

            foreach (var currentSpec in byteSpec)
            {
                int[] returnedBytes = RenderTone(currentSpec);
                int[] c = new int[_headerSamples.Length + returnedBytes.Length];
                Array.Copy(_headerSamples, 0, c, 0, _headerSamples.Length);
                Array.Copy(returnedBytes, 0, c, _headerSamples.Length, returnedBytes.Length);

                _headerSamples = c;
            }

            _eomSamples = new int[0];
            byteArray = Encoding.Default.GetBytes($"{EOM}");
            volume = 5000;

            byteSpec = new List<SameWavBit>();

            foreach (var t in byteArray)
            {
                thisByte = t;

                for (var e = 0; e < 8; e++)
                {
                    thisBit = ((thisByte & (short)Math.Pow(2, e)) != 0 ? Mark : Space);
                    byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, volume));
                }
            }

            foreach (var currentSpec in byteSpec)
            {
                int[] returnedBytes = RenderTone(currentSpec);
                int[] c = new int[_eomSamples.Length + returnedBytes.Length];
                Array.Copy(_eomSamples, 0, c, 0, _eomSamples.Length);
                Array.Copy(returnedBytes, 0, c, _eomSamples.Length, returnedBytes.Length);
                _eomSamples = c;
            }

            // We add a 1 second silence here.
            _silenceSamples = new List<int>();
            while (_silenceSamples.Count < 176400)
            {
                _silenceSamples.Add(0);
            }

            _ebsTonesStream = GenerateEbsTones();
            _ebsToneSamples = _ebsTonesStream.Length;

            _nwsTonesStream = GenerateNwsTones();
            _nwstoneSamples = _nwsTonesStream.Length;

            _censorTonesStream = GenerateCensorTones();
            _censorToneSamples = _censorTonesStream.Length;

            _totalSamples = (TotalHeaderSamples * 3) + (totalSilenceSamples * 7) + (TotalEomSamples * 3) + (_ebsToneSamples * 8) +
                           (_nwstoneSamples * 8) + (_censorToneSamples * 8);

            _announcementStream =
                GenerateVoiceAnnouncement(announcement);
            _announcementSamples = _announcementStream.Length;

            GenerateWavFile(filename);
        }

        // Save new message
        public static string CreateNewMessage(EASMessage message, bool ebsTone = true, bool nwsTone = false, bool censorTone = false, string announcement = "", bool burst = false, string filename = "output")
        {
            // These two strings are VERY important and altering them will cause any listening radios to malfunction or not respond to the EAS message.
            // Do not alter these strings!
            string EOM = "\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xabNNNN";
            _useEbsTone = ebsTone;
            _useNwsTone = nwsTone;
            _useCensorTone = censorTone;

            _announcement = announcement;

            _headerSamples = new int[0];

            Byte[] byteArray;
            var volume = 5000;

            byteArray = Encoding.Default.GetBytes(message.ToSameHeaderString());

            var byteSpec = new List<SameWavBit>();
            byte thisByte;
            SAMEAudioBit thisBit;

            for (var i = 0; i < byteArray.Length; i++)
            {
                thisByte = byteArray[i];

                for (var e = 0; e < 8; e++)
                {
                    thisBit = ((thisByte & (short)Math.Pow(2, e)) != 0 ? Mark : Space);
                    byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, volume));
                }
            }

            foreach (var currentSpec in byteSpec)
            {
                int[] returnedBytes = RenderTone(currentSpec);
                int[] c = new int[_headerSamples.Length + returnedBytes.Length];
                Array.Copy(_headerSamples, 0, c, 0, _headerSamples.Length);
                Array.Copy(returnedBytes, 0, c, _headerSamples.Length, returnedBytes.Length);

                _headerSamples = c;
            }

            // END OF MESSAGE ----------------------------------------------------------------------------------------
            _eomSamples = new int[0];
            byteArray = Encoding.Default.GetBytes(EOM);
            volume = 5000;

            byteSpec = new List<SameWavBit>();

            foreach (var t in byteArray)
            {
                thisByte = t;

                for (var e = 0; e < 8; e++)
                {
                    thisBit = ((thisByte & (short)Math.Pow(2, e)) != 0 ? Mark : Space);
                    byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, volume));
                }
            }

            foreach (var currentSpec in byteSpec)
            {
                int[] returnedBytes = RenderTone(currentSpec);
                int[] c = new int[_eomSamples.Length + returnedBytes.Length];
                Array.Copy(_eomSamples, 0, c, 0, _eomSamples.Length);
                Array.Copy(returnedBytes, 0, c, _eomSamples.Length, returnedBytes.Length);
                _eomSamples = c;
            }

            // We add a 1 second silence here.
            _silenceSamples = new List<int>();
            while (_silenceSamples.Count < 176400)
            {
                _silenceSamples.Add(0);
            }

            _ebsTonesStream = GenerateEbsTones();
            _ebsToneSamples = _ebsTonesStream.Length;

            _nwsTonesStream = GenerateNwsTones();
            _nwstoneSamples = _nwsTonesStream.Length;

            _censorTonesStream = GenerateCensorTones();
            _censorToneSamples = _censorTonesStream.Length;

            _totalSamples = (TotalHeaderSamples * 3) + (totalSilenceSamples * 7) + (TotalEomSamples * 3) + (_ebsToneSamples * 8) +
                           (_nwstoneSamples * 8) + (_censorToneSamples * 8);

            _announcementStream =
                GenerateVoiceAnnouncement(announcement);
            _announcementSamples = _announcementStream.Length;

            GenerateWavFile(filename);

            return message.ToSameHeaderString();
        }

        internal static string ZeroPad(string String, int Length)
        {
            if (string.IsNullOrEmpty(String))
            {
                String = "0";
            }
            if (String.Length > Length)
            {
                return String;
            }

            while (String.Length < Length)
            {
                String = "0" + String;
            }

            return String;
        }

        /// <summary>
        /// Generates a stream from a message.
        /// </summary>
        /// <param name="message">Contains information about the message.</param>
        /// <param name="ebsTone">Plays the EBS tone after the headers.</param>
        /// <param name="nwsTone">Plays the NWS tone after the headers.</param>
        /// <param name="censorTone">Plays the CENSOR tone after the headers.</param>
        /// <param name="announcement">Plays the text specified. Leave blank for no message.</param>
        /// <param name="burst">Deprecated, does not take effect. Use new method GetMemoryStreamFromSASMEX.</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream GetMemoryStreamFromNewMessage(EASMessage message, bool ebsTone = true, bool nwsTone = false, bool censorTone = false,
            string announcement = "", bool burst = false)
        {
            _useEbsTone = ebsTone;
            _useNwsTone = nwsTone;
            _useCensorTone = censorTone;

            _announcement = announcement;

            _headerSamples = new int[0];

            byte[] byteArray;

            //1 second silence

            _silenceSamples = new List<int>();
            while (_silenceSamples.Count < 176400)
            {
                _silenceSamples.Add(0);
            }

            string SameHeaderStr = message.ToSameHeaderString();

            byteArray = Encoding.Default.GetBytes(SameHeaderStr);
            var volume = 5000;

            var byteSpec = new List<SameWavBit>();
            byte thisByte;
            SAMEAudioBit thisBit;

            var powersOf2 = new short[8];
            for (var i = 0; i < 8; i++)
            {
                powersOf2[i] = (short)(1 << i);
            }

            foreach (var t in byteArray)
            {
                thisByte = t;

                for (var e = 0; e < 8; e++)
                {
                    thisBit = (thisByte & powersOf2[e]) != 0 ? Mark : Space;
                    byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, volume));
                }
            }

            List<int> combinedSamples = new List<int>(_headerSamples);

            foreach (SameWavBit currentSpec in byteSpec)
            {
                int[] returnedBytes = RenderTone(currentSpec);
                combinedSamples.AddRange(returnedBytes);
            }

            _headerSamples = combinedSamples.ToArray();

            _eomSamples = new int[0];
            byteArray = Encoding.Default.GetBytes(message.ToSameEndOfMessageString());
            volume = 5000;

            byteSpec = new List<SameWavBit>();

            foreach (var t in byteArray)
            {
                thisByte = t;

                for (var e = 0; e < 8; e++)
                {
                    thisBit = (thisByte & (short)Math.Pow(2, e)) != 0 ? Mark : Space;
                    byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, volume));
                }
            }

            foreach (var currentSpec in byteSpec)
            {
                int[] returnedBytes = RenderTone(currentSpec);
                int[] c = new int[_eomSamples.Length + returnedBytes.Length];
                Array.Copy(_eomSamples, 0, c, 0, _eomSamples.Length);
                Array.Copy(returnedBytes, 0, c, _eomSamples.Length, returnedBytes.Length);
                _eomSamples = c;
            }

            _ebsTonesStream = GenerateEbsTones();
            _ebsToneSamples = _ebsTonesStream.Length;

            _nwsTonesStream = GenerateNwsTones();
            _nwstoneSamples = _nwsTonesStream.Length;

            _censorTonesStream = GenerateCensorTones();
            _censorToneSamples = _censorTonesStream.Length;

            _totalSamples = (TotalHeaderSamples * 3) + (totalSilenceSamples * 7) + (TotalEomSamples * 3) + (_ebsToneSamples * 8) +
                           (_nwstoneSamples * 8) + (_censorToneSamples * 8);

            _announcementStream =
                GenerateVoiceAnnouncement(announcement);
            _announcementSamples = _announcementStream.Length;

            return GenerateMemoryStream();
        }

        /// <summary>
        /// Generates a SASMEX stream using the current time.
        /// </summary>
        /// <param name="originator">Contains the 8-character originator string.</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream GetMemoryStreamFromSASMEX(string originator)
        {
            _headerSamples = new int[0];

            byte[] byteArray;

            //1 second silence

            _silenceSamples = new List<int>();
            while (_silenceSamples.Count < 22050)
            {
                _silenceSamples.Add(0);
            }

            string byteFranie = $"{ZeroPad(DateTime.Now.ToUniversalTime().DayOfYear.ToString(), 3)}" + $"{ZeroPad(DateTime.Now.ToUniversalTime().Hour.ToString(), 2)}" + $"{ZeroPad(DateTime.Now.ToUniversalTime().Minute.ToString(), 2)}";
            string byteFrank = $"\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab" +
                $"ZCZC-CIV-EQW-000000+0005-{byteFranie}-{originator}-";
            byteArray = Encoding.Default.GetBytes(byteFrank);
            var volume = 5000;

            var byteSpec = new List<SameWavBit>();
            byte thisByte;
            SAMEAudioBit thisBit;

            var powersOf2 = new short[8];
            for (var i = 0; i < 8; i++)
            {
                powersOf2[i] = (short)(1 << i);
            }

            foreach (var t in byteArray)
            {
                thisByte = t;

                for (var e = 0; e < 8; e++)
                {
                    thisBit = (thisByte & powersOf2[e]) != 0 ? Mark : Space;
                    byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, volume));
                }
            }

            List<int> combinedSamples = new List<int>(_headerSamples);

            foreach (SameWavBit currentSpec in byteSpec)
            {
                int[] returnedBytes = RenderTone(currentSpec);
                combinedSamples.AddRange(returnedBytes);
            }

            _headerSamples = combinedSamples.ToArray();
            _eomSamples = new int[0];
            //byteArray = Encoding.Default.GetBytes("\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xabNNNN");
            volume = 5000;
            byteSpec = new List<SameWavBit>();
            foreach (var t in byteArray)
            {
                thisByte = t;
                for (var e = 0; e < 8; e++)
                {
                    thisBit = (thisByte & (short)Math.Pow(2, e)) != 0 ? Mark : Space;
                    byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, volume));
                }
            }
            //foreach (var currentSpec in byteSpec)
            //{
            //    int[] returnedBytes = RenderTone(currentSpec);
            //    int[] c = new int[_eomSamples.Length + returnedBytes.Length];
            //    Array.Copy(_eomSamples, 0, c, 0, _eomSamples.Length);
            //    Array.Copy(returnedBytes, 0, c, _eomSamples.Length, returnedBytes.Length);
            //    _eomSamples = c;
            //}
            _ebsTonesStream = null;
            _ebsToneSamples = 0;
            _nwsTonesStream = null;
            _nwstoneSamples = 0;
            _censorTonesStream = null;
            _censorToneSamples = 0;
            _totalSamples = (TotalHeaderSamples * 3) + (totalSilenceSamples * 7) + (TotalEomSamples * 3);
            _announcementStream = null;
            _announcementSamples = 0;

            return GenerateSASMEXMemoryStream();
        }

        /// <summary>
        /// Renders bytes as audible tones.
        /// </summary>
        /// <param name="byteSpec">No description.</param>
        /// <returns>int[]</returns>
        private static int[] RenderTone(SameWavBit byteSpec)
        {
            var computedSamples = new List<int>();
            for (var i = 0; i < (44100 * byteSpec.length); i++)
            {
                for (var c = 0; c < 2; c++)
                {
                    var sample = (decimal)(byteSpec.volume * Math.Sin(2 * Math.PI * (i / 44100d) * byteSpec.frequency));
                    if (headerByteCache.ContainsKey(sample))
                    {
                        computedSamples.AddRange(headerByteCache[sample]);
                    }
                    else
                    {
                        List<int> thisSample = PackBytes("v", sample);
                        computedSamples.AddRange(thisSample);
                        headerByteCache.Add(sample, thisSample);
                    }
                }

            }
            return computedSamples.ToArray();
        }

        // Create bytes
        private static List<int> PackBytes(string format, decimal sample)
        {
            var output = new List<int>();
            foreach (var c in format)
            {
                var arg = sample;

                switch (c)
                {
                    case 'v': // little-endian unsigned short
                        output.Add(((int)arg & 255));
                        output.Add((((int)arg >> 8) & 255));

                        break;
                }
            }
            return output;
        }

        /// <summary>
        /// Exports wave file from memory.
        /// </summary>
        /// <param name="filename">The file name (optionally path) to be used for the output excluding extension.</param>
        private static void GenerateWavFile(string filename = "output")
        {
            var f = new FileStream(filename + ".wav", FileMode.Create);
            using (var wr = new BinaryWriter(f))
            {
                GenerateMemoryStream().CopyTo(wr.BaseStream);
            }
            f.Close();
        }

        // Generate wave stream
        private static MemoryStream GenerateMemoryStream(int header_samp = 3, int silence_samp = 8, int eom_samp = 3)
        {
            _totalSamples = (TotalHeaderSamples * header_samp) + (totalSilenceSamples * silence_samp) + (TotalEomSamples * eom_samp); //SAME Header & EOM

            //EBS Tone
            if (_useEbsTone)
            {
                _totalSamples += (_ebsToneSamples * 8) + totalSilenceSamples;
            }

            //NWS Tone
            if (_useNwsTone)
            {
                _totalSamples += (_nwstoneSamples * 8) + totalSilenceSamples;
            }

            //CENSOR Tone
            if (_useCensorTone)
            {
                _totalSamples += (_censorToneSamples * 8) + totalSilenceSamples;
            }

            //Spoken announcement
            if (!string.IsNullOrEmpty(_announcement))
            {
                _totalSamples += _announcementSamples;
            }

            uint sampleRate = 44100;
            ushort channels = 2;
            ushort bitsPerSample = 16;
            var bytesPerSample = (ushort)(bitsPerSample / 8);

            var f = new MemoryStream();
            var wr = new BinaryWriter(f);
            wr.Write("RIFF".ToArray());
            wr.Write(36 + _totalSamples * channels * bytesPerSample);
            wr.Write("WAVE".ToArray());
            //    // Sub-chunk 1.
            //    // Sub-chunk 1 ID.
            wr.Write("fmt ".ToArray());
            wr.Write(BitConverter.GetBytes(16), 0, 4);

            //    // Audio format (floating point (3) or PCM (1)). Any other format indicates compression.
            wr.Write(BitConverter.GetBytes((ushort)(1)), 0, 2);

            //    // Channels.
            wr.Write(BitConverter.GetBytes(channels), 0, 2);

            //    // Sample rate.
            wr.Write(BitConverter.GetBytes(sampleRate), 0, 4);

            //    // Bytes rate.
            wr.Write(BitConverter.GetBytes(sampleRate * channels * bytesPerSample), 0, 4);

            //    // Block align.
            wr.Write(BitConverter.GetBytes(channels * bytesPerSample), 0, 2);

            //    // Bits per sample.
            wr.Write(BitConverter.GetBytes(bitsPerSample), 0, 2);

            //    // Sub-chunk 2.
            wr.Write("data".ToArray());

            //    // Sub-chunk 2 size.
            wr.Write(BitConverter.GetBytes(_totalSamples / channels * bytesPerSample));

            foreach (var thisChar in _silenceSamples)
            {
                wr.Write((byte)(thisChar));
            }

            var loopCount = 0;
            while (loopCount < 3)
            {
                foreach (var thisChar in _headerSamples)
                {
                    wr.Write((byte)(thisChar));
                }

                foreach (var thisChar in _silenceSamples)
                {
                    wr.Write((byte)(thisChar));
                }
                loopCount++;
            }


            // EBS Tone
            if (_useEbsTone)
            {
                for (int seconds = 0; seconds < 8; seconds++)
                {
                    for (int loopCounta = 0; loopCounta < _ebsTonesStream.Length; loopCounta++)
                    {
                        wr.Write(_ebsTonesStream[loopCounta]);
                    }
                }

                foreach (var thisChar in _silenceSamples)
                {
                    wr.Write((byte)thisChar);
                }
            }

            // NWS Tone
            if (_useNwsTone)
            {
                for (int seconds = 0; seconds < 8; seconds++)
                {
                    for (int loopCountz = 0; loopCountz < _nwsTonesStream.Length; loopCountz++)
                    {
                        wr.Write(_nwsTonesStream[loopCountz]);
                    }
                }

                foreach (var thisChar in _silenceSamples)
                {
                    wr.Write((byte)thisChar);
                }
            }
            
            // CENSOR Tone
            if (_useCensorTone)
            {
                for (int seconds = 0; seconds < 8; seconds++)
                {
                    for (int loopCountz = 0; loopCountz < _censorTonesStream.Length; loopCountz++)
                    {
                        wr.Write(_censorTonesStream[loopCountz]);
                    }
                }

                foreach (var thisChar in _silenceSamples)
                {
                    wr.Write((byte)thisChar);
                }
            }

            // Spoken announcement
            if (!string.IsNullOrEmpty(_announcement))
            {
                for (int announcementLoop = 0; announcementLoop < _announcementSamples; announcementLoop++)
                {
                    wr.Write(_announcementStream[announcementLoop]);
                }
            }

            for (int silenceLoop = 0; silenceLoop < 3; silenceLoop++)
            {
                foreach (var thisChar in _silenceSamples)
                {
                    wr.Write((byte)thisChar);
                }

                foreach (var thisChar in _eomSamples)
                {
                    wr.Write((byte)thisChar);
                }
            }

            foreach (var thisChar in _silenceSamples)
            {
                wr.Write((byte)thisChar);
            }

            wr.Flush();
            f.Position = 0;
            return f;
        }

        // Generate SASMEX wave stream
        private static MemoryStream GenerateSASMEXMemoryStream(int header_samp = 3, int silence_samp = 8)
        {
            _totalSamples = (TotalHeaderSamples * header_samp) + (totalSilenceSamples * silence_samp); //+ (TotalEomSamples * eom_samp); //SAME Header & EOM

            uint sampleRate = 44100;
            ushort channels = 2;
            ushort bitsPerSample = 16;
            var bytesPerSample = (ushort)(bitsPerSample / 8);

            var f = new MemoryStream();
            var wr = new BinaryWriter(f);
            wr.Write("RIFF".ToArray());
            wr.Write(36 + _totalSamples * channels * bytesPerSample);
            wr.Write("WAVE".ToArray());
            //    // Sub-chunk 1.
            //    // Sub-chunk 1 ID.
            wr.Write("fmt ".ToArray());
            wr.Write(BitConverter.GetBytes(16), 0, 4);

            //    // Audio format (floating point (3) or PCM (1)). Any other format indicates compression.
            wr.Write(BitConverter.GetBytes((ushort)1), 0, 2);

            //    // Channels.
            wr.Write(BitConverter.GetBytes(channels), 0, 2);

            //    // Sample rate.
            wr.Write(BitConverter.GetBytes(sampleRate), 0, 4);

            //    // Bytes rate.
            wr.Write(BitConverter.GetBytes(sampleRate * channels * bytesPerSample), 0, 4);

            //    // Block align.
            wr.Write(BitConverter.GetBytes(channels * bytesPerSample), 0, 2);

            //    // Bits per sample.
            wr.Write(BitConverter.GetBytes(bitsPerSample), 0, 2);

            //    // Sub-chunk 2.
            wr.Write("data".ToArray());

            //    // Sub-chunk 2 size.
            wr.Write(BitConverter.GetBytes(_totalSamples / channels * bytesPerSample));

            foreach (var thisChar in _silenceSamples)
            {
                wr.Write((byte)thisChar);
            }

            // DATA AREA
            var g = new MemoryStream();
            var xs = new BinaryWriter(g);

            //for (int ignore = 0; ignore < 3; ignore++)
            {
                int loopCount = 0;
                while (loopCount < 3)
                {
                    foreach (var thisChar in _headerSamples)
                    {
                        xs.Write((byte)thisChar);
                    }

                    foreach (var thisChar in _silenceSamples)
                    {
                        xs.Write((byte)thisChar);
                    }
                    loopCount++;
                }

                foreach (var thisChar in _silenceSamples)
                {
                    xs.Write((byte)thisChar);
                }

                // SILENCE AREA

                _silenceSamples = new List<int>();
                while (_silenceSamples.Count < 176400)
                {
                    _silenceSamples.Add(0);
                }

                foreach (var thisChar in _silenceSamples)
                {
                    xs.Write((byte)thisChar);
                }

                // EOM

                List<SameWavBit> byteSpec = new List<SameWavBit>();
                byte thisByte;
                SAMEAudioBit thisBit;

                _eomSamples = new int[0];
                foreach (var t in Encoding.Default.GetBytes("NNNN\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab"))
                {
                    thisByte = t;
                    for (var e = 0; e < 8; e++)
                    {
                        thisBit = (thisByte & (short)Math.Pow(2, e)) != 0 ? Mark : Space;
                        byteSpec.Add(new SameWavBit(thisBit.frequency, thisBit.length, 5000));
                    }
                }

                foreach (var currentSpec in byteSpec)
                {
                    int[] returnedBytes = RenderTone(currentSpec);
                    int[] c = new int[_eomSamples.Length + returnedBytes.Length];
                    Array.Copy(_eomSamples, 0, c, 0, _eomSamples.Length);
                    Array.Copy(returnedBytes, 0, c, _eomSamples.Length, returnedBytes.Length);
                    _eomSamples = c;
                }

                foreach (var thisChar in _eomSamples)
                {
                    xs.Write((byte)thisChar);
                }

                // 2 SECOND SILENCE

                List<int> _silenceSASMEXSamples = new List<int>();
                while (_silenceSASMEXSamples.Count < 352800)
                {
                    _silenceSASMEXSamples.Add(0);
                }

                foreach (var thisChar in _silenceSASMEXSamples)
                {
                    xs.Write((byte)thisChar);
                }
            }

            xs.Flush();
            g.Position = 0;

            foreach (byte character in g.ToArray())
            {
                wr.Write(character);
            }

            foreach (byte character in g.ToArray())
            {
                wr.Write(character);
            }

            foreach (byte character in g.ToArray())
            {
                wr.Write(character);
            }

            wr.Flush();
            f.Position = 0;
            return f;
        }

        private static byte[] GenerateEbsTones()
        {
            // Create a memory stream, and a binary writer pointing to the memory stream.
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            // Set the samples, and double it.
            var samplesPerSecond = 44100;
            var samples = samplesPerSecond * 2;

            // Play the EBS tone for 5000 milliseconds.
            double ampl = 5000;
            var concert = 1.0;
            for (var i = 0; i < samples / 2; i++)
            {
                if (i % 2 == 0)
                {
                    var t = i / (double)samplesPerSecond;
                    var s = (short)(ampl * Math.Sin(t * 853.0 * concert * 2.0 * Math.PI));
                    writer.Write(s);
                    writer.Write(s);
                }
                else
                {
                    var t = i / (double)samplesPerSecond;
                    var s = (short)(ampl * Math.Sin(t * 960.0 * concert * 2.0 * Math.PI));
                    writer.Write(s);
                    writer.Write(s);
                }
            }
            writer.Close();
            stream.Close();
            return stream.ToArray();
        }

        private static byte[] GenerateNwsTones()
        {
            // Create a memory stream, and a binary writer pointing to the memory stream.
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            // Set the samples, and double it.
            var samplesPerSecond = 44100;
            var samples = samplesPerSecond * 2;

            // Play the NWS tone for 5000 milliseconds.
            double ampl = 5000;
            var concert = 1.0;
            for (var i = 0; i < samples / 2; i++)
            {
                var t = i / (double)samplesPerSecond;
                var s = (short)(ampl * Math.Sin(t * 1050.0 * concert * 2.0 * Math.PI));
                writer.Write(s);
                writer.Write(s);
            }
            writer.Close();
            stream.Close();
            return stream.ToArray();
        }

        private static byte[] GenerateCensorTones()
        {
            // Create a memory stream, and a binary writer pointing to the memory stream.
            var stream = new MemoryStream();
            var writer = new BinaryWriter(stream);

            // Set the samples, and double it.
            var samplesPerSecond = 44100;
            var samples = samplesPerSecond * 2;

            // Play the CENSOR tone for 5000 milliseconds.
            double ampl = 5000;
            var concert = 1.0;
            for (var i = 0; i < samples / 2; i++)
            {
                var t = i / (double)samplesPerSecond;
                var s = (short)(ampl * Math.Sin(t * 1000.0 * concert * 2.0 * Math.PI));
                writer.Write(s);
                writer.Write(s);
            }
            writer.Close();
            stream.Close();
            return stream.ToArray();
        }

        //public static byte[] GenerateVoiceClip(string announcement)
        //{
        //    // Create a SpVoice instance
        //    SpVoice voice = new SpVoice();

        //    // Create a MemoryStream to store the speech output
        //    MemoryStream waveStream = new MemoryStream();

        //    // Set the audio output to the MemoryStream
        //    SpMemoryStream outputStream = new SpMemoryStream();
        //    voice.AudioOutputStream = outputStream;

        //    // Set the voice to "ScanSoft Tom" (SAPI 4 voice)
        //    SpObjectToken desiredVoice = GetVoiceByName(voice, "VW Paul");

        //    if (desiredVoice != null)
        //    {
        //        voice.Voice = desiredVoice;
        //    }
        //    else
        //    {
        //        voice.Voice = voice.GetVoices().Item(0);
        //    }

        //    // Set the volume and rate
        //    voice.Volume = 100; // Adjust the volume if desired
        //    voice.Rate = 1; // Adjust the rate if desired

        //    // Speak the input
        //    voice.Speak(announcement, SpeechVoiceSpeakFlags.SVSFlagsAsync);

        //    // Wait for the speech to complete
        //    while (voice.Status.RunningState == SpeechRunState.SRSEIsSpeaking)
        //    {
        //        System.Threading.Thread.Sleep(50);
        //    }

        //    // Reset the MemoryStream position to the beginning
        //    waveStream.Position = 0;

        //    // Read the speech output from the MemoryStream
        //    byte[] buffer = outputStream.GetData() as byte[];
        //    waveStream.Write(buffer, 0, buffer.Length);

        //    // Obtain the processed announcement as an array
        //    byte[] announcementBytes = waveStream.ToArray();

        //    // Clean up resources
        //    voice.AudioOutputStream = null;
        //    waveStream.Close();

        //    return announcementBytes;
        //}


        public static byte[] GenerateVoiceAnnouncement(string announcement, int volume = 100, int rate = 1)
        {
            //return Generate(announcement).ToArray();
            //return Generate(announcement);
            // Create a speech synthesizer, then a memory stream to pipe the output.
            var synthesizer = new SpeechSynthesizer();
            var waveStream = new MemoryStream();

            // We also set the speech output.
            synthesizer.SetOutputToAudioStream(waveStream,
                new SpeechAudioFormatInfo(EncodingFormat.Pcm,
                    44100, 16, 2, 176400, 2, null));

            // We can also set the volume, and how fast the rate of speech is.
            synthesizer.Volume = volume;

            // This section is used for error correction. Used to avoid uncaught exceptions.
            #region Error Correction
            if (volume > 100)
            {
                synthesizer.Volume = 100;
            }
            else if (volume < 0)
            {
                synthesizer.Volume = 0;
            }
            synthesizer.Volume = volume;
            if (rate > 10)
            {
                synthesizer.Rate = 10;
            }
            else if (volume < -10)
            {
                synthesizer.Rate = -10;
            }
            synthesizer.Rate = rate;
            // Original defaults:
            // volume: 100
            // speech rate: 1
            #endregion

            // Select the voice we will use for the announcement.
            synthesizer.SelectVoiceByHints(VoiceGender.Female);

            // Now, we create the announcement.
            synthesizer.Speak(announcement);

            // After the announcement finishes processing, we null the output.
            synthesizer.SetOutputToNull();
            // Now that we have the processed announcement, we return it as an array waveStream.
            return waveStream.ToArray();
        }

        //static SpObjectToken GetVoiceByName(SpVoice voice, string voiceName)
        //{
        //    // Get the available voices
        //    ISpeechObjectTokens voices = voice.GetVoices();

        //    foreach (ISpeechObjectToken voiceToken in voices)
        //    {
        //        if (voiceToken.GetDescription() == voiceName)
        //        {
        //            return (SpObjectToken)voiceToken;
        //        }
        //    }

        //    return null;
        //}
    }
}