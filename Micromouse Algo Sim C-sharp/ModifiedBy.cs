namespace Micromouse_Algo_Sim_C_sharp
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct | System.AttributeTargets.Enum
                        | System.AttributeTargets.Struct | System.AttributeTargets.Interface)]
    [Author("Taylor Howell", 1.0)]
    public class ModifiedByAttribute : System.Attribute
    {
        public string Name { get; private set; }
        public double Version { get; private set; }

        public string Comments { get; private set; }

        public static readonly string Liscense = "The MIT License (MIT)" +
        "Copyright © 2022-2023 KSU MicroMouse Team" +
        "Permission is hereby granted, free of charge, to any person obtaining a copy " +
        "of this software and associated documentation files (the “Software”), to deal" +
        "in the Software without restriction, including without limitation the rights to" +
        "use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of" +
        "the Software, and to permit persons to whom the Software is furnished to do so," +
        "subject to the following conditions:" + "\n\n" +
        "The above copyright notice and this permission notice shall be included in all" +
        "copies or substantial portions of the Software." + "\n\n" +
        "THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR" +
        "IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS" +
        "FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR" +
        "COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN" +
        "AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION" +
        "WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">the name of the author</param>
        /// <param name="version">the version of the code</param>
        public ModifiedByAttribute(string name, double version)
        {
            Name = name;
            Version = version;
            Comments = "";
        }

        /// <summary>
        /// Constructor with comments
        /// </summary>
        /// <param name="name">the name of the author</param>
        /// <param name="version">the version of the code</param>
        /// <param name="comments">comments for your liking</param>
        public ModifiedByAttribute(string name, double version, string comments)
        {
            Name = name;
            Version = version;
            Comments = comments;
        }
    }
}