using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Models;

namespace IsaacPickAndBan.ViewModels
{
    public partial class ExtensionFilterViewModel : ObservableObject
    {
        #region constructor
        public ExtensionFilterViewModel(Extension extension, bool isActif)
        {
            Extension = extension;
            IsActif = isActif;
            Name = EnumExtensions.GetDescription(extension);
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private Extension extension;

        [NotifyPropertyChangedFor(nameof(BackgroundColor))]
        [NotifyPropertyChangedFor(nameof(ForegroundColor))]
        [ObservableProperty]
        private bool isActif;

        public Color BackgroundColor => GetBackgroundColor();

        public Color ForegroundColor => GetForegroundColor();

        #endregion

        #region commands
        [RelayCommand]
        private void Toggle() => IsActif = !IsActif;
        #endregion

        #region private methods
        private Color GetBackgroundColor() => IsActif
            ? Colors.LightGreen.WithAlpha(0.35f)
            : Colors.Black.WithAlpha(0.45f);

        private Color GetForegroundColor() => IsActif
            ? Colors.LightGray
            : Colors.DarkGray.WithAlpha(0.8f);

        #endregion
    }
}
