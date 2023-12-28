using sportCenter.Models;
using sportCenter.ViewModel;

namespace sportCenter
{
    /// <summary>
    /// Represents the main application class responsible for initializing the application and managing global resources.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets the instance of the UserViewModel used for managing user-related data and state.
        /// </summary>
        public static UserViewModel UserViewModel { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            // Initialize the UserViewModel with a default user (provide any default values as needed)
            UserViewModel = new UserViewModel
            {
                SelectedUser = new User()
            };

            // Set the main page of the application as the AppShell
            MainPage = new AppShell();
        }
    }
}
