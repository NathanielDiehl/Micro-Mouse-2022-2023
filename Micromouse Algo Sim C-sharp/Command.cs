namespace Micromouse_Algo_Sim_C_sharp
{
    /// <summary>
    /// Class representation of a command
    /// </summary>
    [Author("Taylor Howell", 1.0)]
    public struct Command
    {
        /// <summary>
        /// The title of the command
        /// </summary>
        /// <value></value>
        public string Title { get; init; }

        /// <summary>
        /// The description of the command
        /// </summary>
        /// <value></value>
        public string Description { get; init; }

        /// <summary>
        /// The action (code of) the command if the command is chosen from the list
        /// </summary>
        /// <value></value>
        public Action Action {get; init;}

        /// <summary>
        /// Default constructor for a command
        /// </summary>
        /// <param name="title">the title of the command</param>
        /// <param name="description">the description</param>
        public Command(string title, string description)
        {
            Title = title;
            Description = description;
            Action = null;
        }

        /// <summary>
        /// Default constructor for a command
        /// </summary>
        /// <remarks>the method must be a void method with no perameters (use a lambda expression if needed).</remarks>
        /// <param name="title">the title of the command</param>
        /// <param name="description">the description</param>
        /// <param name="method">the method to call</param>
        public Command(string title, string description, Action method)
        {
            Title = title;
            Description = description;
            Action = method;
        }
    }
}