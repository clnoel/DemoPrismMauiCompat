namespace DemoPrismMauiCompat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MauiProgram.SetMainPage(this);
        }
    }
}
