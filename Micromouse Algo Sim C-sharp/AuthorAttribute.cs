namespace Micromouse_Algo_Sim_C_sharp
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct |
                       System.AttributeTargets.Enum)]
    [Author("Taylor Howell", 2.0)]
    public class AuthorAttribute : System.Attribute
    {   
        /// <summary>
        /// The name or names of authors
        /// </summary>
        /// <value></value>
        public string[] Name { get; private set; }

        /// <summary>
        /// The script version
        /// </summary>
        /// <value></value>
        public double Version { get; private set; }

        /// <summary>
        /// Any comments?
        /// </summary>
        /// <value></value>
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
        public AuthorAttribute(string name, double version)
        {
            Name = new string[1] { name };
            Version = version;
            Comments = "";
        }

        /// <summary>
        /// Constructor with comments
        /// </summary>
        /// <param name="name">the name of the author</param>
        /// <param name="version">the version of the code</param>
        /// <param name="comments">comments for your liking</param>
        public AuthorAttribute(string name, double version, string comments)
        {
            Name = new string[1] { name };
            Version = version;
            Comments = comments;
        }

        /// <summary>
        /// Handles a list of authors
        /// </summary>
        /// <param name="names">the authors</param>
        /// <param name="version">the version of the program</param>
        public AuthorAttribute(string[] names, double version)
        {
            Name = names;
            Version = version;
            Comments = "";
        }

        /// <summary>
        /// Handles a list of authors
        /// </summary>
        /// <param name="names">the authors</param>
        /// <param name="version">the version of the script</param>
        /// <param name="comments">comments for the script</param>
        public AuthorAttribute(string[] names, double version, string comments)
        {
            Name = names;
            Version = version;
            Comments = comments;
        }
    }
}