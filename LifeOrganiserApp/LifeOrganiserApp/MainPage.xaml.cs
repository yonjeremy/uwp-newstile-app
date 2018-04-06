using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        ApplicationDataContainer settings;
        public MainPage()
        {
            this.InitializeComponent();
            GetNews(false);

            settings = ApplicationData.Current.RoamingSettings;

            if (settings.Values.Keys.Contains("isLocal"))
            {
                toggleSwitch.IsOn = Convert.ToBoolean(settings.Values["isLocal"]);
            }
        }


        private async void GetNews(bool b)
        {
            myNews = await NewsProxy.GetNews(b);

            //ResultTextBlock.Text = myNews.status.ToString() + " " + myNews.totalResults + " " + myNews.articles[1].url;

            url1.Text = myNews.articles[0].title;
            url2.Text = myNews.articles[1].title;
            url3.Text = myNews.articles[2].title;
            url4.Text = myNews.articles[3].title;
            url5.Text = myNews.articles[4].title;
            url6.Text = myNews.articles[5].title;
            url7.Text = myNews.articles[6].title;
            url8.Text = myNews.articles[7].title;

            try
            {
                Uri myUri1 = new Uri(myNews.articles[0].urlToImage);
                urlImage1.UriSource = myUri1;
            }
            catch
            {
                Uri myUri1 = new Uri("ms-appx:///noImage.png");
                urlImage1.UriSource = myUri1;
            }

            try
            {
                Uri myUri2 = new Uri(myNews.articles[1].urlToImage);
                urlImage2.UriSource = myUri2;
            }
            catch
            {
                Uri myUri2 = new Uri("ms-appx:///noImage.png");
                urlImage2.UriSource = myUri2;
            }
            try
            {
                Uri myUri3 = new Uri(myNews.articles[2].urlToImage);
                urlImage3.UriSource = myUri3;
            }
            catch
            {
                Uri myUri3 = new Uri("ms-appx:///noImage.png");
                urlImage3.UriSource = myUri3;
            }
            try
            {
                Uri myUri4 = new Uri(myNews.articles[3].urlToImage);
                urlImage4.UriSource = myUri4;
            }
            catch
            {
                Uri myUri4 = new Uri("ms-appx:///noImage.png");
                urlImage4.UriSource = myUri4;
            }
            try
            {
                Uri myUri5 = new Uri(myNews.articles[4].urlToImage);
                urlImage5.UriSource = myUri5;
            }
            catch
            {
                Uri myUri5 = new Uri("ms-appx:///noImage.png");
                urlImage5.UriSource = myUri5;
            }

            try
            {
                Uri myUri6 = new Uri(myNews.articles[5].urlToImage);
                urlImage6.UriSource = myUri6;
            }
            catch
            {
                Uri myUri6 = new Uri("ms-appx:///noImage.png");
                urlImage6.UriSource = myUri6;
            }

            try
            {
                Uri myUri7 = new Uri(myNews.articles[6].urlToImage);
                urlImage7.UriSource = myUri7;
            }
            catch
            {
                Uri myUri7 = new Uri("ms-appx:///noImage.png");
                urlImage7.UriSource = myUri7;
            }

            try
            {
                Uri myUri8 = new Uri(myNews.articles[7].urlToImage);
                urlImage8.UriSource = myUri8;
            }
            catch
            {
                Uri myUri8 = new Uri("ms-appx:///noImage.png");
                urlImage8.UriSource = myUri8;
            }
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
        private async void Image_PointerPressed5(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews.articles[4].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed6(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews.articles[5].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed7(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews.articles[6].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed8(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews.articles[7].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }



        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    GetNews(true);
                }
                else
                {
                    GetNews(false);
                }
                if (settings.Values.Keys.Contains("isLocal"))
                {
                    settings.Values["IsLocal"] = toggleSwitch.IsOn;
                }
                else
                {
                    settings.Values.Add("isLocal", toggleSwitch.IsOn);
                }
            }
        }
    }
}
