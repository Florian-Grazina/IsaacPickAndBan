using IsaacPickAndBan.Database;
using IsaacPickAndBan.Views;

namespace IsaacPickAndBan
{
    public partial class App : Application
    {
        private readonly Data _data;
        private Page _mainPage;

        public App(Data data)
        {
            InitializeComponent();
            _data = data;

            _mainPage = new LoadingPage();
            InitializeApp();
        }

        private async void InitializeApp()
        {
            await _data.InitializeAsync();
            _mainPage = new AppShell();

            if (Current?.Windows[0] is Window window)
                window.Page = _mainPage;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(_mainPage);
        }
    }
}
