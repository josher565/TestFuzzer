using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;

namespace CodeAffinity.TestFuzzer
{
    public class Fuzzer<T> where T : new()
    {
        /// <summary>
        /// randomize a complete object for reference types only
        /// </summary>
        /// <returns>randomized object</returns>
        public T Fuzzify()
        {
            T fuzzResult = new T();

            foreach (PropertyInfo pi in fuzzResult.GetType().GetProperties())
                if (pi != null && pi.CanWrite)
                    pi.SetValue(fuzzResult, Randomizer.GetFuzzValue(pi.PropertyType), null);

            return fuzzResult;
        }
    }
}
