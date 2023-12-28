using sportCenter.Enums;
using sportCenter.Models;
using sportCenter.Repositories.UserRepository;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace sportCenter
{
    /// <summary>
    /// Represents the page displaying a list of all users.
    /// </summary>
    public partial class AllUsers : ContentPage
    {
        private readonly UserService _userService = new UserService();

        /// <summary>
        /// Gets or sets the observable collection of users.
        /// </summary>
        public ObservableCollection<User> UsersList { get; set; } = new ObservableCollection<User>();

        /// <summary>
        /// Gets or sets the command for the "Update" action.
        /// </summary>
        public ICommand UpdateCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AllUsers"/> class.
        /// </summary>
        public AllUsers()
        {
            InitializeComponent();
            try
            {
                InitializeCommands();
                BindingContext = this;
            }
            catch (Exception e)
            {
                // Handle exceptions during initialization
                throw;
            }
        }

        /// <summary>
        /// Occurs when the page is about to be displayed.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeDataSource();
        }

        /// <summary>
        /// Initializes the data source for the users.
        /// </summary>
        private void InitializeDataSource()
        {
            var users = _userService.GetUsersAsync().Result;
            UsersList = new ObservableCollection<User>(users);
            cvUsers.ItemsSource = UsersList;
        }

        /// <summary>
        /// Initializes the commands for the page.
        /// </summary>
        private void InitializeCommands()
        {
            // Initialize the command for the "Update" action
            UpdateCommand = new Command<User>(OnUpdate);
        }

        /// <summary>
        /// Handles the "Update" action for a user.
        /// </summary>
        /// <param name="user">The user to be updated.</param>
        private async void OnUpdate(User user)
        {
            // Handle navigation to another page for updating user details
            // You can use Navigation to navigate to the update page
            // For example: await Navigation.PushAsync(new UpdateUserPage(user));
            //Navigate to the UpdateUserMembership page with the user object
            App.UserViewModel.SelectedUser = user;
            await Shell.Current.GoToAsync($"{nameof(UpdateUserMembership)}");
        }

        /// <summary>
        /// Handles the selection change in the CollectionView.
        /// </summary>
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Implementation for selection change
        }

        /// <summary>
        /// Handles the "Add New Item" button click.
        /// </summary>
        private void OnItemAdded(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(RegisterUser));
        }

        /// <summary>
        /// Handles the selected index change in the membership status picker.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void isMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected item
            var picker = (Picker)sender;
            //get the selected item
            var selectedItem = picker.SelectedItem;

            if (selectedItem != null)
            {
                switch (selectedItem.ToString())
                {
                    case "All Users":
                        UsersList = new ObservableCollection<User>(await _userService.GetUsersAsync());
                        break;
                    case "Members":
                        UsersList = new ObservableCollection<User>(await _userService.GetUsersByMembership(true));
                        break;
                    case "Non-Members":
                        UsersList = new ObservableCollection<User>(await _userService.GetUsersByMembership(false));
                        break;
                    default:
                        break;
                }
                cvUsers.ItemsSource = UsersList;
            }
        }
    }
}
