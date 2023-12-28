using sportCenter.Models;
using sportCenter.Repositories.UserRepository;

namespace sportCenter
{
    /// <summary>
    /// Represents the page for updating user membership status.
    /// </summary>
    public partial class UpdateUserMembership : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserMembership"/> class.
        /// </summary>
        public UpdateUserMembership()
        {
            InitializeComponent();

            // Set the binding context to the UserViewModel from the application
            BindingContext = App.UserViewModel;
        }

        /// <summary>
        /// Handles the "Update Membership" button click event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void UpdateMembership_Click(object sender, EventArgs e)
        {
            // Get the chkIsMember value
            var isMember = chkIsMember.IsChecked;

            // Get the classId value of isMember
            var userCode = chkIsMember.ClassId;

            // Create a UserService instance
            var userService = new UserService();

            // Get the user by userCode
            var user = await userService.GetUserAsync(Guid.Parse(userCode));

            // Update the user's membership status
            user.IsMember = isMember;

            // Save the updated user
            await userService.SaveUserAsync(user);

            // Update the SelectedUser in the UserViewModel
            App.UserViewModel.SelectedUser = user;

            // Display a success message
            await DisplayAlert("Success", "User membership updated", "OK");

            // Navigate back to the previous page
            await Shell.Current.GoToAsync("..");
        }
    }
}
