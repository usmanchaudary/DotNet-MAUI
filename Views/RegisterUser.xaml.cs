using sportCenter.Enums;
using sportCenter.Models;
using sportCenter.Repositories.UserRepository;

namespace sportCenter
{
    /// <summary>
    /// Represents the page for registering new users.
    /// </summary>
    public partial class RegisterUser : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUser"/> class.
        /// </summary>
        public RegisterUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the "Register User" button click event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void RegisterUser_Clicked(object sender, EventArgs e)
        {
            // Create a UserService instance for interacting with user data
            var userService = new UserService();

            // Create a new User object with input values
            var user = new User
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                DateOfBirth = dateofBirth.Date,
                Gender = Enum.Parse<UserGender>(userGender?.SelectedItem?.ToString()),
                IsMember = isMember.IsToggled
            };

            // Save the new user to the data store
            await userService.SaveUserAsync(user);

            // Display a success message to the user
            await DisplayAlert("Success", "User registered", "OK");
            //navigate to the main page
            await Shell.Current.GoToAsync("..");
        }
    }
}
