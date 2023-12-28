using sportCenter.Repositories.UserRepository;

namespace sportCenter
{
    /// <summary>
    /// Represents the main page of the application with basic navigation actions.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            // Whenever this page is loaded, clear the navigation stack
            Shell.Current.Navigation.PopToRootAsync();
        }

        /// <summary>
        /// Handles the "View Users" button click event, navigating to the AllUsers page.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void ViewUsers_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AllUsers));
        }

        /// <summary>
        /// Handles the "Register User" button click event, navigating to the RegisterUser page.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void RegitserUserBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(RegisterUser));
        }
    }
}
