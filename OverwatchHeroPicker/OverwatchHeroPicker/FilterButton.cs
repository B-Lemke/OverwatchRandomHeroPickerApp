using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OverwatchHeroPicker
{
    class FilterButton : Button
    {
        public Heroes Filter { get; set; }



        public void setCustomFilter()
        {
            App.currentHeroes = this.Filter;
        }

    }

}
