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


            pickRandomHero();


        }

        private void NewHero_Button_Clicked(object sender, EventArgs e)
        {
            pickRandomHero();
           
        }

        private void pickRandomHero()
        {
            if (App.currentHeroes.Count > 0)
            {
                //Get a random number within the size of the number of heroes in the current array
                int r = App.rnd.Next(App.currentHeroes.Count);

                lblName.Text = App.currentHeroes[r].Name;
                lblRole.Text = App.currentHeroes[r].Role;

                //App.currentHeroes[r].FileName

                ImgHeroPortrait.Source = ImageSource.FromFile(App.currentHeroes[r].FileName);
            }
            else
            {
                lblName.Text = "You must select at least one hero on the filter page!";

            }

        }
    }
}