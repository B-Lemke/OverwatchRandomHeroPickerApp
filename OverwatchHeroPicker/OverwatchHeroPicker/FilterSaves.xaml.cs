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
	public partial class FilterSaves : ContentPage
	{
		public FilterSaves ()
		{
			InitializeComponent ();
		}

        //On page start up we need to loop through the filters and create the row definitions for each and put the filters into the grid.
        protected override void OnAppearing()
        {

            base.OnAppearing();

            //Kill all children
            GridFilterSaves.Children.Clear();
            GridFilterSaves.RowDefinitions.Clear();

            int filterCount = 0;

            //Generate 
            foreach (Filter filter in App.filters)
            {
                    //for each filter, we need to create a row definition and add it into the grid

                    //Create a row definition
                    RowDefinition rowDef = new RowDefinition();
                    rowDef.Height = GridLength.Auto;
                    GridFilterSaves.RowDefinitions.Add(rowDef);

                    //Add an X button
                    FilterButton buttonDelete = new FilterButton();
                    buttonDelete.Text = "X";
                    buttonDelete.BtnFilter = new Filter();
                    buttonDelete.BtnFilter.HeroList.AddRange(filter.HeroList);
                    buttonDelete.BtnFilter.FilterName = filter.FilterName;

                    //Set the click event handler to change the current heroes to the filter they selecte
                    buttonDelete.Clicked += new EventHandler(deleteButton_Clicked);


                    GridFilterSaves.Children.Add(buttonDelete, 0, filterCount);

                    //Add the button with the name
                    FilterButton fb = new FilterButton();
                    fb.Text = filter.FilterName;
   

                    //Instantiate and set the filter.
                    fb.BtnFilter = new Filter();
                    fb.BtnFilter.HeroList.AddRange(filter.HeroList);
                    fb.BtnFilter.FilterName = filter.FilterName;

                    //Set the click event handler to change the current heroes to the filter they selecte
                    fb.Clicked += new EventHandler(filterButton_Clicked);

                    GridFilterSaves.Children.Add(fb, 1, filterCount);

                    //Up the counter
                    filterCount++;
            }

        }

        private void SaveFilter_Button_Clicked(object sender, EventArgs e)
        {
            //Create a new filter, add it to the filters
            Filter newFilter = new Filter();
            newFilter.FilterName = txtFilterName.Text;
            newFilter.HeroList.AddRange(App.currentHeroes.HeroList);

            App.filters.Add(newFilter);

            //Find the current number of rows in the table and add 1 to it
            int rowNum = GridFilterSaves.RowDefinitions.Count;

            ///////Add the filter to the page

            //Create a row definition
            RowDefinition rowDef = new RowDefinition();
            rowDef.Height = GridLength.Auto;
            GridFilterSaves.RowDefinitions.Add(rowDef);

            //Add an X button
            FilterButton buttonDelete = new FilterButton();
            buttonDelete.Text = "X";
            buttonDelete.BtnFilter = new Filter();
            buttonDelete.BtnFilter.HeroList.AddRange(newFilter.HeroList);
            buttonDelete.BtnFilter.FilterName = newFilter.FilterName;


            //Set the click event handler to change the current heroes to the filter they selecte
            buttonDelete.Clicked += new EventHandler(deleteButton_Clicked);

            GridFilterSaves.Children.Add(buttonDelete, 0, rowNum);

            //Add the button with their name
            FilterButton fb = new FilterButton();
            fb.Text = newFilter.FilterName;

            //Instantiate and set the filter.
            fb.BtnFilter = new Filter();
            fb.BtnFilter.HeroList.AddRange(newFilter.HeroList);
            fb.BtnFilter.FilterName = newFilter.FilterName;

            //Set the click event handler to change the current heroes to the filter they select.
            fb.Clicked += new EventHandler(filterButton_Clicked);

            GridFilterSaves.Children.Add(fb, 1, rowNum);

            //Save changes to properties
            App.SaveFiltersToProperties();
        }

        private void filterButton_Clicked(object sender, EventArgs e)
        {
            //set the filter based off the the filter button's 
            FilterButton fb = (FilterButton)sender;
            App.currentHeroes.HeroList.Clear();
            App.currentHeroes.HeroList.AddRange(fb.BtnFilter.HeroList);

            //Switch tab page.
            var parentPage = this.Parent as TabbedPage;
            parentPage.CurrentPage = parentPage.Children[1];

        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            //set the delete based off the the filter's name
            FilterButton fb = (FilterButton)sender;

            //Find the first filter in the app's filter list with this filter name and delete it, then remove it from the list.
            App.filters.Remove(App.filters.Where(filter => filter.FilterName == fb.BtnFilter.FilterName).FirstOrDefault());



            //Remove the visuals from the screen
            var button = (FilterButton)sender;
            var row = Grid.GetRow(button);
            var children = GridFilterSaves.Children.ToList();
            foreach (var child in children.Where(child => Grid.GetRow(child) == row))
            {
                GridFilterSaves.Children.Remove(child);
            }
            foreach (var child in children.Where(child => Grid.GetRow(child) > row))
            {
                Grid.SetRow(child, Grid.GetRow(child) - 1);
            }
            GridFilterSaves.RowDefinitions.RemoveAt(GridFilterSaves.RowDefinitions.Count - 1);


            //Save changes to properties
            App.SaveFiltersToProperties();
        }

    }
}