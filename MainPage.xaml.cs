using sportCenter.Repositories.UserRepository;

namespace sportCenter
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        
        public MainPage()
        {
            InitializeComponent();
            //whenever this page is loaded, clear the navigation stack
            Shell.Current.Navigation.PopToRootAsync();
        }


        private async void ViewUsers_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AllUsers));
        }


        private async void RegitserUserBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(RegisterUser));
        }
    }

}
