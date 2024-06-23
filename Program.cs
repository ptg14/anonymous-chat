namespace anonymous_chat
{
    internal static class Program
    {
        public static bool RestartRequested = false;
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            do
            {
                RestartRequested = false;
                using (Main mainForm = new Main())
                {
                    Application.Run(mainForm);
                }
            } while (RestartRequested);
        }

        public static void RestartApplication()
        {
            RestartRequested = true;
        }
    }
}