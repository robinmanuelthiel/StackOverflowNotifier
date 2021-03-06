﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace StackOverflowNotifier
{
    public class App : Application
    {
		public static Bootstrapper Bootstrapper;

		public App()
		{
			Bootstrapper = new Bootstrapper();

			// The root page of your application
			var tabbedPage = new TabbedPage();
			tabbedPage.Title = "Stack Overflow";
			tabbedPage.Children.Add(new MainPage());
			tabbedPage.Children.Add(new TagPage());

			// On iOS, put the settings menu into the tab bar as it is closer to the iOS design guidelines
			if (Device.OS == TargetPlatform.iOS)
			{
				tabbedPage.Children.Add(new SettingsPage());
			}

			MainPage = new NavigationPage(tabbedPage)
			{
				BarBackgroundColor = Color.FromHex("f37e22"),
				BarTextColor = Color.White
			};

			Bootstrapper.InitalizeNavigationService(MainPage);
		}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
