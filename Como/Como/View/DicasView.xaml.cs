using Como.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Como.View
{
    public partial class DicasView : ContentPage
    {
        public DicasView()
        {
            this.InitializeComponent();

            App.FrutasVM.ObterDicas();

            this.BindingContext = App.FrutasVM;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
