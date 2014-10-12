﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Utils
{
    public static class TextReaderExtension
    {
        public static IEnumerable<string[]> GetSplittedLines(this TextReader txtreader, char splitted)
        {
            string[] line = txtreader.ReadToEnd().Split('\n');

            foreach (var s in line)
            {
                yield return s.Split(splitted);
            }
        }
    }
}
