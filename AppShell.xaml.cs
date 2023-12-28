namespace sportCenter
{
    /// <summary>
    /// Represents the main application shell that defines the structure and navigation routes for the application.
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();

            // Register navigation routes for pages in the application
            Routing.RegisterRoute(nameof(AllUsers), typeof(AllUsers));
            Routing.RegisterRoute(nameof(RegisterUser), typeof(RegisterUser));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(UpdateUserMembership), typeof(UpdateUserMembership));
        }
    }
}
