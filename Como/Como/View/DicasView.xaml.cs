using Como.Model;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
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
            App.FrutasVM.ObterDicas();
            this.Title = "Como Escolher Frutas!";

            Content = ObterConteudo();
        }


        private StackLayout ObterConteudo()
        {
            ListView postsListView = new ListView { HasUnevenRows = true };
            postsListView.ItemTemplate = new DataTemplate(typeof(CustomPostCell));

            postsListView.ItemsSource = App.FrutasVM.Dicas;

            return new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    new Label {
                        Text = "Como Escolher Frutas!",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    postsListView
                }
            };
        }

        public class AspectRatioContainer : ContentView
        {
            protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
            {
                return new SizeRequest(new Size(widthConstraint, widthConstraint * this.AspectRatio));
            }

            public double AspectRatio { get; set; }
        }

        public class CustomPostCell : ViewCell
        {
            public CustomPostCell()
            {
                var fotoImage = new Image { Margin = new Thickness(5, 15, 5, 5), VerticalOptions = LayoutOptions.CenterAndExpand };

                var principalLayout = new StackLayout()
                {
                    Padding = new Thickness(0, 0, 0, 0),
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = new LayoutOptions { Alignment = LayoutAlignment.Center },
                    Margin = 0,
                    Children =
                        {
                            fotoImage
                        }
                };

                fotoImage.SetBinding(Image.SourceProperty, new Binding("ImagemBindingSource"));
                
                View = principalLayout;
            }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
