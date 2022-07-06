using PM2P2_T2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P2_T2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            list.ItemsSource = await new SignatureService().GetSignatures();
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            OnBackButtonPressed();
        }
    }
}