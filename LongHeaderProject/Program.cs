﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongHeaderProject
{
    internal class Program
    {
        static readonly string init = $"ZCZC-PEP-EAN-|6969-2331200-BUNNYTUB-";
        static void Main(string[] args)
        {
            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Minute + DateTime.Now.Second);
            init.Replace("|", $"{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+{rnd.Next(100000, 999999)}+");
            EASEncoderFusion.EASEncoder.CreateLongMessageFromRawData(init);
            Console.Read();
        }
    }
}