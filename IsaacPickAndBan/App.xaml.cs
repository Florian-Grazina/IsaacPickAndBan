
using IsaacPickAndBan.Database;
using IsaacPickAndBan.Views;

namespace IsaacPickAndBan
{
    public partial class App : Application
    {
        private readonly Data _data;

        public App(Data data)
        {
            InitializeComponent();
            _data = data;

            MainPage = new LoadingPage();

            InitializeApp();
        }

        private async void InitializeApp()
        {
            await _data.InitializeAsync();
            MainPage = new AppShell();
        }
    }
}
