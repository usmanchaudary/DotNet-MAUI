using sportCenter.Models;
using sportCenter.ViewModel;

namespace sportCenter
{
    public partial class App : Application
    {
        public static UserViewModel UserViewModel { get; private set; }
        public App()
        {
            InitializeComponent();
            UserViewModel = new UserViewModel
            {
                SelectedUser = new User() // Provide any default values as needed
            };
            MainPage = new AppShell();
        }
    }
}
