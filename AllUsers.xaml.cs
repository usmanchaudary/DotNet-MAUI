using sportCenter.Enums;
using sportCenter.Models;
using sportCenter.Repositories.UserRepository;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace sportCenter;

public partial class AllUsers : ContentPage
{
    private readonly UserService _userService = new UserService();
    //create an observable collection of users
    public ObservableCollection<User> UsersList { get; set; } = new ObservableCollection<User>();

    // Command for the "Update" action
    public ICommand UpdateCommand { get; private set; }
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
            throw;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        InitializeDataSource();
    }

    private void InitializeDataSource()
    {
        var users = _userService.GetUsersAsync().Result;
        UsersList = new ObservableCollection<User>(users);
        cvUsers.ItemsSource = UsersList;
    }
    private void InitializeCommands()
    {
        // Initialize the command for the "Update" action
        UpdateCommand = new Command<User>(OnUpdate);
    }

    private async void OnUpdate(User user)
    {
        // Handle navigation to another page for updating user details
        // You can use Navigation to navigate to the update page
        // For example: await Navigation.PushAsync(new UpdateUserPage(user));
        //Navigate to the UpdateUserMembership page with the user object
        App.UserViewModel.SelectedUser = user;
        await Shell.Current.GoToAsync($"{nameof(UpdateUserMembership)}");
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void OnItemAdded(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RegisterUser));
    }

    private async void isMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get selected item
        var picker = (Picker)sender;
        //get the selected item
        var selectedItem = picker.SelectedItem;
        //cast the selected item to a UserGender enum
        
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