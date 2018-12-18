using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OverwatchHeroPicker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroPicker : ContentPage
    {
        public HeroPicker()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ImgHeroPortrait.IsVisible = true;

            pickRandomHero();
        }

        private void NewHero_Button_Clicked(object sender, EventArgs e)
        {
            pickRandomHero();
           
        }

        private void pickRandomHero()
        {
            if (App.currentHeroes.HeroList.Count > 0)
            {
                //Get a random number within the size of the number of heroes in the current array
                int r = App.rnd.Next(App.currentHeroes.HeroList.Count);

                lblName.Text = App.currentHeroes.HeroList[r].Name;
                lblRole.Text = App.currentHeroes.HeroList[r].Role;


                ImgHeroPortrait.Source = ImageSource.FromFile(App.currentHeroes.HeroList[r].FileName);
            }
            else
            {
                lblName.Text = "You must select at least one hero on the filter page!";
                ImgHeroPortrait.IsVisible = false;
                lblRole.Text = String.Empty;
            }

        }
    }
}