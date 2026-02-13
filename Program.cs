using static System.Windows.Forms.DataFormats;
using BrightFrame.UI;

namespace BrightFrame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new UI.MainForm());
        }
    }
}