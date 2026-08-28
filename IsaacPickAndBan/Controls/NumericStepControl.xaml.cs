using CommunityToolkit.Mvvm.Input;

namespace IsaacPickAndBan.Controls;

public partial class NumericStepControl : ContentView
{
    #region constructor
    public NumericStepControl()
    {
        InitializeComponent();
    }
    #endregion

    #region bindable properties
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(NumericStepControl), string.Empty);

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(int), typeof(NumericStepControl), 0, defaultBindingMode: BindingMode.TwoWay);
    #endregion

    #region properties
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    #endregion

    #region events
    private void Button_Plus_Clicked(object sender, EventArgs e) => Value++;
    private void Button_Minus_Clicked(object sender, EventArgs e) => Value--;
    #endregion
}
