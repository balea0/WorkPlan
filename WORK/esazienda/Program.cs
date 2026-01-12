namespace esazienda
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Launch the login form first. The login form will display the
            // main application form upon successful authentication. If the
            // login form closes without showing the main form, the
            // application will exit.
            Application.Run(new LoginForm());
        }
    }
}