using System;

namespace Micromouse_Algo_Sim_C_sharp
{
    /// <summary>
    /// The Program Class
    /// </summary>
    [Author("Taylor Howell and generated by cmd", 1.0)]
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LineGUI.Menu();
            }
            catch (Exception ex)
            {
                LineGUI.ShowError(ex.Message); //help debug a crash (hopefully)
            }
        }
    }
}
