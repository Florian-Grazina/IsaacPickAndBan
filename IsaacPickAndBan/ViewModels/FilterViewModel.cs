using CommunityToolkit.Mvvm.ComponentModel;
using IsaacPickAndBan.Models;

namespace IsaacPickAndBan.ViewModels
{
    public partial class FilterViewModel(Extension extension, bool isActif) : ObservableObject
    {
        [ObservableProperty]
        public string name = EnumExtensions.GetDescription(extension);
        [ObservableProperty]
        public Extension extension = extension;
        [ObservableProperty]
        public bool isActif = isActif;
    }
}
