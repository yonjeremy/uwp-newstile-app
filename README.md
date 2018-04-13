# News Tile
<a href="https://i.imgur.com/YkQaeFe"><img src="https://i.imgur.com/YkQaeFe.png" height="200" width="200" title="NewsTile"/></a>

## Introduction
This project was done by Jeremy Yon of Galway-Mayo Institute technology, for the Mobile Applications Development Module, Year 3.

## Getting started
1. Git clone this repository to local machine
```
git clone https://github.com/yonjeremy/uwp-life-organiser-app
```
2. Open up the cloned repository, click on LifeOrganiserApp.sln file.
3. Pick visual studio 2015.

## Prerequisites
1. Visual Studio 2015

## App overview
News Tile is a Universal windows news app that can be run on windows supported devices such as any windows computer, xbox or windows phone. News Tile is an app that provides up to date and most current news, sports news, business news etc. It allows the user the search for news using keywords, and also allows users to pick news from different categories. News Tile also detects the users location and searches for news from local news sources based on the country location.

## Screenshots of the app
### Main page
<a href="https://i.imgur.com/wVeDgRt"><img src="https://i.imgur.com/wVeDgRt.png" height="450" width="350" title="NewsTile"/></a><br>
The main page of the app displays the most current top news. The app displays 8 tiles of news, and clicking on the tile will open up the default browser of the device and display the news item.<br>

<a href="https://i.imgur.com/YvR0Zo3.png"><img src="https://i.imgur.com/YvR0Zo3.png" height="450" width="350" title="NewsTile"/></a><a href="https://i.imgur.com/EznGZ3n.png"><img src="https://i.imgur.com/EznGZ3n.png" height="450" width="350" title="NewsTile"/></a><br>
The next two tabs (or pivet items) displays sports news and business news.<br>

<a href="https://i.imgur.com/6rTHU5a.png"><img src="https://i.imgur.com/6rTHU5a.png" height="450" width="350" title="NewsTile"/></a><br>
The next pivot item is a search menu. This will enable the user to search through all the news sources using keywords and/or any selected category in the combobox drop down menu. If no such news matches the keyword and category, a news not found error image will be displayed.<br>

<a href="https://i.imgur.com/netoj1C.png"><img src="https://i.imgur.com/netoj1C.png" height="450" width="350" title="NewsTile"/></a><br>
The final tab is the settings menu. The first toggle allows the user to switch between a light theme or a dark theme. The next setting allows the user to choose whether the news will be from local sources or not. All settings are stored in roaming storage, so that the user settings are stored on multiple devices.<br>

## Design methods
1. NewsApi
This App uses NewsAPI, an API that allows the user to make http queries, and receives a json file that can be serialised and have its data parsed into different root objects. This api provides great functionality as it allows the user to make different queries based on categories, location, language, keywords etc.
```
response = await http.GetAsync("https://newsapi.org/v2/top-headlines?country=" + GetLocation() + &apiKey=96eea05140b246f5beb991ced70bfe8c");
```

2. Parsing Json
As mentioned above, the json file that is received will have to be parsed as a json file. The news tile app handles all the parsing of the json, by serialising it into a type news root object.
```
var result = await response.Content.ReadAsStringAsync();
var serializer = new DataContractJsonSerializer(typeof(RootObject));
var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
var data = (RootObject)serializer.ReadObject(ms);
```


3. Roaming settings storage
The app contains a few toggle switches that store the user settings. These settings can be passed on from different devices as long as the user is logged into a windows account. 
```
settings = ApplicationData.Current.RoamingSettings;
```

4. User location
The app allows the user to get news from local sources. This is done by getting the user location by calling the geographicregion() function, that returns a two letter country code variable. The two letter country code is then inserted into the newsapi query.
```
var geographicRegion = new Windows.Globalization.GeographicRegion();
var code = geographicRegion.CodeTwoLetter;
```
            

5. Pivot Items
The easiest way to display different pages in a UWP app is to use the pivot item tag. This allows the user to scroll through different pages with the mouse or touchscreen.

## App link and certification

<a href="https://i.imgur.com/8OFZ63S.png"><img src=https://i.imgur.com/8OFZ63S.png" height="300" width="400" title="Certification"/></a><br>
As of today (13/04/2018) the app has been sent to the app store to be certified. 

## App link
(to be filled in here after certification)

## Publisher name
Yonjeremy

## Authors
Jeremy Yon- All source code and assets

## Credits
NewsApi for your amazing api functionality













