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
	public partial class FilterPage : ContentPage
	{
		public FilterPage ()
		{
			InitializeComponent ();
		}

        //On page start up we need to loop through the roster and create the row definitions for each class and put the heros into it.
        protected override void OnAppearing()
        {
            try
            {
                int tankCount = 0;
                int damageCount = 0;
                int supportCount = 0;

                base.OnAppearing();

                //Kill all children
                GridTank.Children.Clear();
                GridDamage.Children.Clear();
                GridSupport.Children.Clear();

                GridTank.RowDefinitions.Clear();
                GridDamage.RowDefinitions.Clear();
                GridSupport.RowDefinitions.Clear();

                //Generate 
                foreach (Hero hero in App.roster)
                {
                    if (hero.Role == "Tank")
                    {
                        //If the hero is a tank, add them to the tank roster

                        //Create a row definition
                        RowDefinition rowDef = new RowDefinition();
                        GridTank.RowDefinitions.Add(rowDef);

                        //Add a switch
                        DataSwitch switchControl = new DataSwitch();
                        switchControl.HeroName = hero.Name;
                        switchControl.VerticalOptions = LayoutOptions.Center;

                        //If the hero is previously selected, set the switch to true
                        if (App.currentHeroes.Contains(hero))
                        {
                            switchControl.IsToggled = true;
                        }

                        GridTank.Children.Add(switchControl, 0, tankCount);

                        //Add their name
                        Label displayName = new Label();
                        displayName.Text = hero.Name;
                        displayName.VerticalOptions = LayoutOptions.Center;
                        GridTank.Children.Add(displayName, 1, tankCount);

                        //Up the counter
                        tankCount++;
                    }

                    if (hero.Role == "Damage")
                    {
                        //If the hero is damage, add them to the damage roster

                        //Create a row definiton
                        RowDefinition rowDef = new RowDefinition();
                        GridDamage.RowDefinitions.Add(rowDef);

                        //Add a switch
                        DataSwitch switchControl = new DataSwitch();
                        switchControl.HeroName = hero.Name;
                        switchControl.VerticalOptions = LayoutOptions.Center;

                        //If the hero is currently selected, set the switch to true
                        if (App.currentHeroes.Contains(hero))
                        {
                            switchControl.IsToggled = true;
                        }

                        GridDamage.Children.Add(switchControl, 0, damageCount);

                        //Add their name
                        Label displayName = new Label();
                        displayName.Text = hero.Name;
                        displayName.VerticalOptions = LayoutOptions.Center;
                        GridDamage.Children.Add(displayName, 1, damageCount);

                        damageCount++;
                    }

                    if (hero.Role == "Support")
                    {
                        //If the hero is a support, add them to the support roster

                        //Create a row definition
                        RowDefinition rowDef = new RowDefinition();
                        GridSupport.RowDefinitions.Add(rowDef);

                        //Add a switch
                        DataSwitch switchControl = new DataSwitch();
                        switchControl.HeroName = hero.Name;
                        switchControl.VerticalOptions = LayoutOptions.Center;
                        GridSupport.Children.Add(switchControl, 0, supportCount);

                        //If the hero is currently selected, set the switch to true
                        if (App.currentHeroes.Contains(hero))
                        {
                            switchControl.IsToggled = true;
                        }

                        //Add their name
                        Label displayName = new Label();
                        displayName.Text = hero.Name;
                        displayName.VerticalOptions = LayoutOptions.Center;
                        GridSupport.Children.Add(displayName, 1, supportCount);

                        supportCount++;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }


        protected override void OnDisappearing()
        {
            try
            {
                base.OnDisappearing();

                //Clear out the currentHeroes
                App.currentHeroes.Clear();

                //Go through each switch in tanks 
                foreach (DataSwitch dataSwitch in  GridTank.Children.OfType<DataSwitch>())
                {
                    addHeroToCurrentHeroes(dataSwitch);
                }

                //Go through each switch in tanks 
                foreach (DataSwitch dataSwitch in GridDamage.Children.OfType<DataSwitch>())
                {
                    addHeroToCurrentHeroes(dataSwitch);
                }

                //Go through each switch in tanks 
                foreach (DataSwitch dataSwitch in GridSupport.Children.OfType<DataSwitch>())
                {
                    addHeroToCurrentHeroes(dataSwitch);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private static void addHeroToCurrentHeroes(DataSwitch dataSwitch)
        {
            //Check the switches value
            bool selected = dataSwitch.IsToggled;

            if (selected)
            {
                //Look up the hero in the roster that's assosciated with this switch
                Hero hero = App.roster.First(item => item.Name.Equals(dataSwitch.HeroName));

                //Add the hero to the current heros.
                App.currentHeroes.Add(hero);
            }
        }

        private void TankSelectAll_Button_Clicked(object sender, EventArgs e)
        {
            foreach (DataSwitch dataSwitch in GridTank.Children.OfType<DataSwitch>())
            {
                dataSwitch.IsToggled = true;
            }
        }

        private void TankDeSelectAll_Button_Clicked(object sender, EventArgs e)
        {
            foreach (DataSwitch dataSwitch in GridTank.Children.OfType<DataSwitch>())
            {
                dataSwitch.IsToggled = false;
            }
        }

        private void DamageSelectAll_Button_Clicked(object sender, EventArgs e)
        {
            foreach (DataSwitch dataSwitch in GridDamage.Children.OfType<DataSwitch>())
            {
                dataSwitch.IsToggled = true;
            }
        }

        private void DamageDeSelectAll_Button_Clicked(object sender, EventArgs e)
        {
            foreach (DataSwitch dataSwitch in GridDamage.Children.OfType<DataSwitch>())
            {
                dataSwitch.IsToggled = false;
            }
        }

        private void SupportSelectAll_Button_Clicked(object sender, EventArgs e)
        {
            foreach (DataSwitch dataSwitch in GridSupport.Children.OfType<DataSwitch>())
            {
                dataSwitch.IsToggled = true;
            }
        }

        private void SupportDeSelectAll_Button_Clicked(object sender, EventArgs e)
        {
            foreach (DataSwitch dataSwitch in GridSupport.Children.OfType<DataSwitch>())
            {
                dataSwitch.IsToggled = false;
            }
        }
    }
}