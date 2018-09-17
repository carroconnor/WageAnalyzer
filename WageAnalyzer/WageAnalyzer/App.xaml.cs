using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WageAnalyzer
{
    public partial class App : Application
    {
        public static WageRespository WageRepo { get; private set; }

        public App(string dbPath)
        {
            InitializeComponent();

            WageRepo = new WageRespository(dbPath);

            MainPage = new TabbedPage
            {
                Children =
                {
                    new WageAnalyzer.MainPage(),
                    new WageAnalyzer.WageCollector(),
                    new WageAnalyzer.TipCalculator(),
                    new WageAnalyzer.Reports(),
                    new WageAnalyzer.Settings()
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
