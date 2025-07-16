using CommunityToolkit.Mvvm.ComponentModel;
using IsaacPickAndBan.Views.PickAndBan;

namespace IsaacPickAndBan.ViewModels
{
    public partial class PickAndBanManagerViewModel : ObservableObject
    {
        #region observable properties
        [ObservableProperty]
        private IPickAndBanContentView? activeContentView;
        #endregion

        public PickAndBanManagerViewModel()
        {
        }

        #region public methods
        public void LoadFilterContentView()
        {
            var ok = new FiltersContentView();
            ActiveContentView = ok;
        }
        #endregion
    }
}
