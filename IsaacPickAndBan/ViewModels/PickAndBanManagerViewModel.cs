using CommunityToolkit.Mvvm.ComponentModel;
using IsaacPickAndBan.Views.PickAndBan;

namespace IsaacPickAndBan.ViewModels
{
    public partial class PickAndBanManagerViewModel : ObservableObject
    {
        #region fields
        private readonly FiltersContentView _filtersContentView;
        #endregion

        #region observable properties
        [ObservableProperty]
        private ContentView? pickAndBanContentView;
        #endregion

        public PickAndBanManagerViewModel(FiltersContentView filtersContentView)
        {
            _filtersContentView = filtersContentView;
        }

        #region public methods
        public void LoadFilterContentView()
        {
            PickAndBanContentView = _filtersContentView;
        }

        public void ClearData()
        {
            PickAndBanContentView = null;
        }
        #endregion
    }
}
