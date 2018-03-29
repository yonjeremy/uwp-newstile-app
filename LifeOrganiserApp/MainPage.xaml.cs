using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LifeOrganiserApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

   
    public sealed partial class MainPage : Page
    {
        public RootObject myNews;

        public MainPage()
        {
            this.InitializeComponent();
            GetNews();
            GetLocation();
        }

        private async void GetNews()
        {
            myNews = await NewsProxy.GetNews();

            //ResultTextBlock.Text = myNews.status.ToString() + " " + myNews.totalResults + " " + myNews.articles[1].url;

            url1.Text = myNews.articles[0].title;
            Uri myUri1 = new Uri(myNews.articles[0].urlToImage);
            urlImage1.UriSource = myUri1;
            url2.Text = myNews.articles[1].title;
            Uri myUri2 = new Uri(myNews.articles[1].urlToImage);
            urlImage2.UriSource = myUri2;
            url3.Text = myNews.articles[2].title;
            Uri myUri3 = new Uri(myNews.articles[2].urlToImage);
            urlImage3.UriSource = myUri3;
            url4.Text = myNews.articles[3].title;
            Uri myUri4 = new Uri(myNews.articles[3].urlToImage);
            urlImage4.UriSource = myUri4;
        }

        private async void Image_PointerPressed1(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews.articles[0].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void Image_PointerPressed2(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews.articles[1].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed3(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews.articles[2].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed4(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews.articles[3].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void GetLocation()
        {
            var geographicRegion = new Windows.Globalization.GeographicRegion();
            var code = geographicRegion.CodeTwoLetter;

            textblock.Text = code;
        }
    }
}
