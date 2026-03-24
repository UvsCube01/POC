namespace Test
{
    public partial class MainPage2 : ContentPage
    {
        public MainPage2()
        {
            InitializeComponent();
        }

        private async void OnPopupButtonClicked(object sender, EventArgs e)
        {
            string content = PopupEntry.Text;

            if (string.IsNullOrWhiteSpace(content))
            {
                await DisplayAlert("Popup", "Please enter some text first!", "OK");
            }
            else
            {
                // Show the entry content in a popup
                await DisplayAlert("Popup Result", content, "Close");
            }
        }
    }
}
