using sportCenter.Enums;
using sportCenter.Models;
using sportCenter.Repositories.UserRepository;

namespace sportCenter;

public partial class RegisterUser : ContentPage
{
	public RegisterUser()
	{
		InitializeComponent();
	}

    private async void RegisterUser_Clicked(object sender, EventArgs e)
    {
		var userService = new UserService();
		var user = new User
		{
            FirstName = FirstName.Text,
            LastName = LastName.Text,
			DateOfBirth = dateofBirth.Date,
            Gender = Enum.Parse<UserGender>(userGender?.SelectedItem?.ToString()),
			IsMember = isMember.IsToggled
        };
		await userService.SaveUserAsync(user);
		await DisplayAlert("Success", "User registered", "OK");
    }
}