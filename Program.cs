using System;
using System.Windows.Forms;
using Controllers;
using Views;

namespace EncryptMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Login());
            //Console.WriteLine("Hellow");
        }
    }
}
