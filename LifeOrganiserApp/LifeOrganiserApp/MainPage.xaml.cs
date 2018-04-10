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
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace LifeOrganiserApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 


    public sealed partial class MainPage : Page
    {
        public RootObject myNews;
        public RootObject myNews2;
        public RootObject myNews3;
        public RootObject myNews4;
        ApplicationDataContainer settings;
        
        public MainPage()
        {
            this.InitializeComponent();
            GetNews(false);
            GetSportsNews(false);
            GetBusinessNews(false);
            GetSearchNews("General", "");
            InitialiseComboBoxes();

            settings = ApplicationData.Current.RoamingSettings;

            if (settings.Values.Keys.Contains("isLocal"))
            {
                toggleSwitch.IsOn = Convert.ToBoolean(settings.Values["isLocal"]);
            }
            if (settings.Values.Keys.Contains("lightTheme"))
            {
                toggleSwitch2.IsOn = Convert.ToBoolean(settings.Values["lightTheme"]);
            }
        }

        private void InitialiseComboBoxes()
        {
            CategoryCombo.SelectedIndex = 0;
          

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    GetNews(true);
                    GetSportsNews(true);
                    GetBusinessNews(true);
                }
                else
                {
                    GetNews(false);
                    GetSportsNews(false);
                    GetBusinessNews(false);
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

        private void toggleSwitch2_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch2 = sender as ToggleSwitch;
            if (toggleSwitch2 != null)
            {
                if (toggleSwitch2.IsOn == true)
                {
                    rootPivot.Background = new SolidColorBrush(Colors.DarkGray);
                    
                }
                else
                {
                    rootPivot.Background = new SolidColorBrush(Colors.Black);
                }
                if (settings.Values.Keys.Contains("lightTheme"))
                {
                    settings.Values["lightTheme"] = toggleSwitch2.IsOn;
                }
                else
                {
                    settings.Values.Add("lightTheme", toggleSwitch2.IsOn);
                }

            }
        }


        private async void GetNews(bool b)
        {
            myNews = await NewsProxy.GetNews(b,1);


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

        private async void GetSportsNews(bool b)
        {
            myNews2 = await NewsProxy.GetNews(b, 2);
            url1Sports.Text = myNews2.articles[0].title;
            url2Sports.Text = myNews2.articles[1].title;
            url3Sports.Text = myNews2.articles[2].title;
            url4Sports.Text = myNews2.articles[3].title;
            url5Sports.Text = myNews2.articles[4].title;
            url6Sports.Text = myNews2.articles[5].title;
            url7Sports.Text = myNews2.articles[6].title;
            url8Sports.Text = myNews2.articles[7].title;
            try
            {
                Uri myUri1Sports = new Uri(myNews2.articles[0].urlToImage);
                urlImage1Sports.UriSource = myUri1Sports;
            }
            catch
            {
                Uri myUri1Sports = new Uri("ms-appx:///noImage.png");
                urlImage1Sports.UriSource = myUri1Sports;
            }

            try
            {
                Uri myUri2Sports = new Uri(myNews2.articles[1].urlToImage);
                urlImage2Sports.UriSource = myUri2Sports;
            }
            catch
            {
                Uri myUri2Sports = new Uri("ms-appx:///noImage.png");
                urlImage2Sports.UriSource = myUri2Sports;
            }
            try
            {
                Uri myUri3Sports = new Uri(myNews2.articles[2].urlToImage);
                urlImage3Sports.UriSource = myUri3Sports;
            }
            catch
            {
                Uri myUri3Sports = new Uri("ms-appx:///noImage.png");
                urlImage3Sports.UriSource = myUri3Sports;
            }
            try
            {
                Uri myUri4Sports = new Uri(myNews2.articles[3].urlToImage);
                urlImage4Sports.UriSource = myUri4Sports;
            }
            catch
            {
                Uri myUri4Sports = new Uri("ms-appx:///noImage.png");
                urlImage4Sports.UriSource = myUri4Sports;
            }
            try
            {
                Uri myUri5Sports = new Uri(myNews2.articles[4].urlToImage);
                urlImage5Sports.UriSource = myUri5Sports;
            }
            catch
            {
                Uri myUri5Sports = new Uri("ms-appx:///noImage.png");
                urlImage5Sports.UriSource = myUri5Sports;
            }

            try
            {
                Uri myUri6Sports = new Uri(myNews2.articles[5].urlToImage);
                urlImage6Sports.UriSource = myUri6Sports;
            }
            catch
            {
                Uri myUri6Sports = new Uri("ms-appx:///noImage.png");
                urlImage6Sports.UriSource = myUri6Sports;
            }

            try
            {
                Uri myUri7Sports = new Uri(myNews2.articles[6].urlToImage);
                urlImage7Sports.UriSource = myUri7Sports;
            }
            catch
            {
                Uri myUri7Sports = new Uri("ms-appx:///noImage.png");
                urlImage7Sports.UriSource = myUri7Sports;
            }

            try
            {
                Uri myUri8Sports = new Uri(myNews2.articles[7].urlToImage);
                urlImage8Sports.UriSource = myUri8Sports;
            }
            catch
            {
                Uri myUri8Sports = new Uri("ms-appx:///noImage.png");
                urlImage8Sports.UriSource = myUri8Sports;
            }
        }

        private async void GetBusinessNews(bool b)
        {
            myNews3 = await NewsProxy.GetNews(b, 3);


            url1Business.Text = myNews3.articles[0].title;
            url2Business.Text = myNews3.articles[1].title;
            url3Business.Text = myNews3.articles[2].title;
            url4Business.Text = myNews3.articles[3].title;
            url5Business.Text = myNews3.articles[4].title;
            url6Business.Text = myNews3.articles[5].title;
            url7Business.Text = myNews3.articles[6].title;
            url8Business.Text = myNews3.articles[7].title;



            try
            {
                Uri myUri1Business = new Uri(myNews3.articles[0].urlToImage);
                urlImage1Business.UriSource = myUri1Business;
            }
            catch
            {
                Uri myUri1Business = new Uri("ms-appx:///noImage.png");
                urlImage1Business.UriSource = myUri1Business;
            }

            try
            {
                Uri myUri2Business = new Uri(myNews3.articles[1].urlToImage);
                urlImage2Business.UriSource = myUri2Business;
            }
            catch
            {
                Uri myUri2Business = new Uri("ms-appx:///noImage.png");
                urlImage2Business.UriSource = myUri2Business;
            }
            try
            {
                Uri myUri3Business = new Uri(myNews3.articles[2].urlToImage);
                urlImage3Business.UriSource = myUri3Business;
            }
            catch
            {
                Uri myUri3Business = new Uri("ms-appx:///noImage.png");
                urlImage3Business.UriSource = myUri3Business;
            }
            try
            {
                Uri myUri4Business = new Uri(myNews3.articles[3].urlToImage);
                urlImage4Business.UriSource = myUri4Business;
            }
            catch
            {
                Uri myUri4Business = new Uri("ms-appx:///noImage.png");
                urlImage4Business.UriSource = myUri4Business;
            }
            try
            {
                Uri myUri5Business = new Uri(myNews3.articles[4].urlToImage);
                urlImage5Business.UriSource = myUri5Business;
            }
            catch
            {
                Uri myUri5Business = new Uri("ms-appx:///noImage.png");
                urlImage5Business.UriSource = myUri5Business;
            }

            try
            {
                Uri myUri6Business = new Uri(myNews3.articles[5].urlToImage);
                urlImage6Business.UriSource = myUri6Business;
            }
            catch
            {
                Uri myUri6Business = new Uri("ms-appx:///noImage.png");
                urlImage6Business.UriSource = myUri6Business;
            }

            try
            {
                Uri myUri7Business = new Uri(myNews3.articles[6].urlToImage);
                urlImage7Business.UriSource = myUri7Business;
            }
            catch
            {
                Uri myUri7Business = new Uri("ms-appx:///noImage.png");
                urlImage7Business.UriSource = myUri7Business;
            }

            try
            {
                Uri myUri8Business = new Uri(myNews3.articles[7].urlToImage);
                urlImage8Business.UriSource = myUri8Business;
            }
            catch
            {
                Uri myUri8Business = new Uri("ms-appx:///noImage.png");
                urlImage8Business.UriSource = myUri8Business;
            }


        }
        private async void GetSearchNews(String category, String keywords)
        {
            myNews4 = await NewsProxy.SearchNews(category, keywords);

            try
            {
                url1Search.Text = myNews4.articles[0].title;
            }
            catch
            {
                url1Search.Text = "News not found";
            }
            try
            {
                url2Search.Text = myNews4.articles[1].title;
            }
            catch
            {
                url2Search.Text = "News not found";
            }
            try
            {
                url3Search.Text = myNews4.articles[2].title;
            }
            catch
            {
                url3Search.Text = "News not found";
            }
            try
            {
                url4Search.Text = myNews4.articles[3].title;
            }
            catch
            {
                url4Search.Text = "News not found";
            }
            try
            {
                
                Uri myUri1Search = new Uri(myNews4.articles[0].urlToImage);
                urlImage1Search.UriSource = myUri1Search;
            }
            catch
            {
                
                Uri myUri1Search = new Uri("ms-appx:///noImage.png");
                urlImage1Search.UriSource = myUri1Search;
            }

            try
            {
                Uri myUri2Search = new Uri(myNews4.articles[1].urlToImage);
                urlImage2Search.UriSource = myUri2Search;
            }
            catch
            {
                Uri myUri2Search = new Uri("ms-appx:///noImage.png");
                urlImage2Search.UriSource = myUri2Search;
            }
            try
            {
                Uri myUri3Search = new Uri(myNews4.articles[2].urlToImage);
                urlImage3Search.UriSource = myUri3Search;
            }
            catch
            {
                Uri myUri3Search = new Uri("ms-appx:///noImage.png");
                urlImage3Search.UriSource = myUri3Search;
            }
            try
            {
                Uri myUri4Search = new Uri(myNews4.articles[3].urlToImage);
                urlImage4Search.UriSource = myUri4Search;
            }
            catch
            {
                Uri myUri4Search = new Uri("ms-appx:///noImage.png");
                urlImage4Search.UriSource = myUri4Search;
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

        private async void Image_PointerPressed1Sports(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews2.articles[0].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void Image_PointerPressed2Sports(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews2.articles[1].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed3Sports(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews2.articles[2].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed4Sports(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews2.articles[3].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed5Sports(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews2.articles[4].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed6Sports(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews2.articles[5].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed7Sports(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews2.articles[6].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed8Sports(object sender, PointerRoutedEventArgs e) 
        {
            string link = @myNews2.articles[7].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void Image_PointerPressed1Business(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews3.articles[0].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void Image_PointerPressed2Business(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews3.articles[1].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed3Business(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews3.articles[2].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed4Business(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews3.articles[3].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed5Business(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews3.articles[4].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed6Business(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews3.articles[5].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed7Business(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews3.articles[6].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed8Business(object sender, PointerRoutedEventArgs e)
        {
            string link = @myNews3.articles[7].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void Image_PointerPressed1Search(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                string link = @myNews4.articles[0].url;
                var uri = new Uri(link);
                var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            catch { }

        }

        private async void Image_PointerPressed2Search(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                string link = @myNews4.articles[1].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            catch { }
        }
        private async void Image_PointerPressed3Search(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                string link = @myNews4.articles[2].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            catch { }
        }
        private async void Image_PointerPressed4Search(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                string link = @myNews4.articles[3].url;
            var uri = new Uri(link);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            catch { }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            
            ComboBoxItem typeItem = (ComboBoxItem)CategoryCombo.SelectedItem;
            string c = typeItem.Content.ToString();
            
            Debug.WriteLine(c);
            GetSearchNews(c, SearchKeyword.Text);
        }


    }
}
