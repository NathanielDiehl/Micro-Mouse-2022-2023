namespace Micromouse_Algo_Sim_C_sharp
{
    /// <summary>
    /// Handles statistically comparing two strings statistically (better than string.compare())
    /// </summary>
    [Author("Taylor Howell", 1.2)]
    public class LineAnalyzer
    {
        /// <summary>
        /// Get the token ratio of two strings
        /// </summary>
        /// <param name="aString">the first string</param>
        /// <param name="bString">the second string</param>
        /// <returns>returns a float between 0 and 100</returns>
        public static float GetTokenRatio(string aString, string bString)
        {
            bool acheck = string.IsNullOrWhiteSpace(aString);
            bool bcheck = string.IsNullOrWhiteSpace(bString);

            if ((acheck || bcheck))
            {
                return 0;
            }

            string[] a = aString.Split(" ");
            string[] b = bString.Split(" ");

            List<float> scores = new List<float>();

            a = CleanStringList(a);
            b = CleanStringList(b);


            //find any unions
            //find remainder a
            //find remainder b

            List<string> unionList = new List<string>();
            List<string> aRemainderList = new List<string>();
            List<string> bRemainderList = new List<string>();

            for (int i = 0; i < a.Length; i++)
            {
                int j = 0;
                bool found = false;

                while (j < b.Length && !found)
                {
                    if (a[i] == b[j])
                    {
                        unionList.Add(a[i]);
                        found = true;
                    }

                    j++;
                }

                if (!found)
                {
                    aRemainderList.Add(a[i]);
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                int j = 0;
                bool found = false;

                while (j < a.Length && !found)
                {
                    if (b[i] == a[j])
                    {
                        // union = union + " " + b[i];
                        found = true;
                    }

                    j++;
                }

                if (!found)
                {
                    bRemainderList.Add(b[i]);
                }
            }

            List<float> ratios = new List<float>();

            string union = "";
            string aRemainder = "";
            string bRemainder = "";

            unionList.Sort();
            aRemainderList.Sort();
            bRemainderList.Sort();

            foreach (var x in unionList)
            {
                union += " " + x;
            }

            foreach (var y in aRemainderList)
            {
                aRemainder += " " + y;
            }

            foreach (var z in bRemainderList)
            {
                bRemainder += " " + z;
            }

            // Console.WriteLine("Union: " + union);
            // Console.WriteLine("Remainder A " + aRemainder);
            // Console.WriteLine("Remainder B " + bRemainder);

            if (string.IsNullOrWhiteSpace(aRemainder) && string.IsNullOrWhiteSpace(bRemainder))
                return 100;

            //if (aRemainder.Length > 0)
            ratios.Add(GetRatio(union, union + " " + aRemainder));

            //if (bRemainder.Length > 0)
            ratios.Add(GetRatio(union, union + " " + bRemainder));

            //if (bRemainder.Length > 0 && aRemainder.Length > 0)
            ratios.Add(GetRatio(union + " " + aRemainder, union + " " + bRemainder));

            foreach (var x in ratios)
            {
                // Console.WriteLine("Result: " + x);
            }

            // Console.WriteLine();

            ratios.Sort();

            foreach (var x in ratios)
            {
                //Console.WriteLine("Result: " + x);
            }

            if (ratios.Count > 0)
                return ratios[ratios.Count - 1];
            else
                return 0;
        }

        /// <summary>
        /// Get the ratio between two strings
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static float GetRatio(string a, string b)
        {

            int lenA = a.Length;
            int lenB = b.Length;

            int match = 0;

            int matchLength = lenA;

            if (matchLength > lenB)
            {
                matchLength = lenB;
            }

            //Console.WriteLine("a " + lenA + " b " + lenB);

            for (int i = 0; i < matchLength; i++)
            {
                if (a[i] == b[i])
                {
                    match++;
                }
                else
                {
                    break;
                }
            }

            // Console.WriteLine("a " + lenA + " b " + lenB + " m " + match);

            float final = (2 * ((float)match / (float)(lenA + lenB)) * 100);

            //Console.WriteLine(final);

            return final;
        }

        
        private static string[] CleanStringList(string[] str)
        {
            List<string> stringList = new List<string>();
            stringList.AddRange(str);

            for (int i = stringList.Count - 1; i >= 0; i--)
            {
                if (isValidString(stringList[i]))
                {
                    stringList[i].Trim();
                }
                else
                {
                    stringList.RemoveAt(i);
                }
            }

            return stringList.ToArray();
        }

        private static bool isValidString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return true;
        }
    }
}