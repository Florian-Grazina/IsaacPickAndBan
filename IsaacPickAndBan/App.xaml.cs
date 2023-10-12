using IsaacPickAndBan.Database;

namespace IsaacPickAndBan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Data.InitDatabase();
            MainPage = new AppShell();
        }
    }
}
