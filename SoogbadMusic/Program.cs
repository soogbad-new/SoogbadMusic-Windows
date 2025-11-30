namespace SoogbadMusic
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool instanceCountOne = false;
            using(Mutex mutex = new(true, "SoogbadMusic", out instanceCountOne))
            {
                if(instanceCountOne)
                {
                    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2); // helps Windows choose proper icon sizes on high DPI
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                    mutex.ReleaseMutex();
                }
                else
                    MessageBox.Show("An application instance is already running");
            }
        }

    }

}
