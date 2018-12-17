using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OverwatchHeroPicker
{
    public partial class App : Application
    {

        public static Heroes roster;
        public static Heroes currentHeroes;
        public static Filters filters;

        //Random number generator to be used throughout the app
        public static Random rnd = new Random();

        public App()
        {
            InitializeComponent();

            roster = new Heroes();
            roster.FilterName = "roster";
            roster.Seed();

            currentHeroes = new Heroes();
            currentHeroes.FilterName = "Current heroes";
            currentHeroes.AddRange(roster);

            filters = new Filters();
            filters.Add(currentHeroes);
            filters.Add(roster);

            MainPage = new OverwatchTabbedPage();
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
