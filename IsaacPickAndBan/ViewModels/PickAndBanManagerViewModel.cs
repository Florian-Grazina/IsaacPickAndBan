using CommunityToolkit.Mvvm.ComponentModel;
using IsaacPickAndBan.Views.PickAndBan;

namespace IsaacPickAndBan.ViewModels
{
    public partial class PickAndBanManagerViewModel : ObservableObject
    {
        #region observable properties
        [ObservableProperty]
        private ContentView? pickAndBanContentView;
        #endregion

        public PickAndBanManagerViewModel()
        {
        }

        #region public methods
        public void LoadFilterContentView()
        {
            PickAndBanContentView = new FiltersContentView();
        }

        public void ClearData()
        {
            PickAndBanContentView = null;
        }
        #endregion
    }
}
