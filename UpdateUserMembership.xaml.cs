using sportCenter.Models;
using sportCenter.Repositories.UserRepository;

namespace sportCenter;

public partial class UpdateUserMembership : ContentPage
{
	public UpdateUserMembership()
	{
		InitializeComponent();
		//set the binding context
		BindingContext = App.UserViewModel;
	}

    private async void UpdateMembership_Click(object sender, EventArgs e)
    {
        //get the chkIsMember value
		var isMember = chkIsMember.IsChecked;
		//get the classId value of isMember
		var userCode = chkIsMember.ClassId;
		var userService = new UserService();
		var user =await userService.GetUserAsync(Guid.Parse(userCode));
		user.IsMember = isMember;
		await userService.SaveUserAsync(user);
		App.UserViewModel.SelectedUser = user;
		await DisplayAlert("Success", "User membership updated", "OK");
		await Shell.Current.GoToAsync("..");
    }
}