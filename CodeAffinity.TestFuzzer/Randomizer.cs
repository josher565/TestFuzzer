using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CodeAffinity.TestFuzzer
{
    public static class Randomizer
    {
        public static readonly int MaxUtf16Value = 1114111;

        /// <summary>
        /// Get a randomized ref type
        /// </summary>
        /// <param name="t">a ref type that needs a random val</param>
        /// <returns>the variable with a random value specific to type</returns>
        public static object GetFuzzValue(Type t)
        {

            //signed
            if (t == typeof(Int16))
                return BitConverter.ToInt16(GetRandomValue(3, true), 0);

            if (t == typeof(Int32))
                return BitConverter.ToInt32(GetRandomValue(4, true), 0);

            if (t == typeof(Int64))
                return BitConverter.ToInt64(GetRandomValue(8, true), 0);


            //unsigned
            if (t == typeof(UInt16))
                return BitConverter.ToUInt16(GetRandomValue(3, false), 0);

            if (t == typeof(UInt32))
                return BitConverter.ToUInt32(GetRandomValue(4, false), 0);

            if (t == typeof(UInt64))
                return BitConverter.ToUInt64(GetRandomValue(5, false), 0);


            //floating point
            if (t == typeof(Single))
                return BitConverter.ToSingle(GetRandomValue(5, true), 0);

            if (t == typeof(Double))
                return BitConverter.ToDouble(GetRandomValue(8, true), 0);

            //string
            if (t == typeof(String)){
                var rando =GetRandomValue((int)Math.Pow(2,10), false);
                var str = System.Text.Encoding.UTF8.GetString(rando);
                return str;
            }

            if (t == typeof(Char)){
                return BitConverter.ToChar(GetRandomValue(1, false),0);
            }

            //datetime
            if (t == typeof(DateTime))
            {
                Int64 randVal = 0;
                DateTime? r = null;

                while (randVal == 0)
                    try
                    {
                        randVal = Math.Abs(BitConverter.ToInt64(GetRandomValue(8, true), 0));
                        r = new DateTime(randVal);
                    }
                    catch { randVal = 0; }

                return r;
            }

            return null;
        }

        public static byte[] GetRandomValue(int power, bool signed)
        {
            byte[] charVal = new byte[power];

            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(charVal);
            }
          
            return charVal;
        }
    }
}
