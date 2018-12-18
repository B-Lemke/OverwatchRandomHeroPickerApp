using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OverwatchHeroPicker
{
    public partial class App : Application
    {

        public static Filter roster;
        public static Filter currentHeroes;
        public static Filters filters;
        

        const string Filters_Property_Key = "savedfilters";


        //Random number generator to be used throughout the app
        public static Random rnd = new Random();

        public App()
        {
            InitializeComponent();

            filters = new Filters();

            roster = new Filter();
            roster.FilterName = "roster";
            roster.Seed();

            currentHeroes = new Filter();
            currentHeroes.FilterName = "Current heroes";
            currentHeroes.Seed();

            MainPage = new OverwatchTabbedPage();
        }

        protected override void OnStart()
        {
            base.OnStart();

            // Handle when your app starts

            //Load the custom filters
            LoadFiltersFromProperties();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps

            //Save custom filters
            SaveFiltersToProperties();
            base.OnSleep();

        }


        public static void LoadFiltersFromProperties()
        {

            if (Application.Current.Properties.ContainsKey(Filters_Property_Key))
            {
                App.filters.Clear();


                string json = Application.Current.Properties[Filters_Property_Key] as string;

                if (json != null)
                {
                    Filters savedFilters = Newtonsoft.Json.JsonConvert.DeserializeObject<Filters>(json);

                    App.filters.AddRange(savedFilters);
                }
            }
        }

        public static void SaveFiltersToProperties()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(filters);

            Application.Current.Properties[Filters_Property_Key] = json;
        }


        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
