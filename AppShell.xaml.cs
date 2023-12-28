namespace sportCenter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //register the route
            Routing.RegisterRoute(nameof(AllUsers), typeof(AllUsers));
            Routing.RegisterRoute(nameof(RegisterUser), typeof(RegisterUser));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(UpdateUserMembership), typeof(UpdateUserMembership));
        }
    }
}
