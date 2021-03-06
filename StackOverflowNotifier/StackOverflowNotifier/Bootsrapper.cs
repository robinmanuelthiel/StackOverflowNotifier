﻿using System;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using PCLStorage;
using StackOverflowNotifier.Shared;
using Xamarin.Forms;

namespace StackOverflowNotifier
{
	public class Bootstrapper
	{
		public Bootstrapper()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<IUrlService, UrlService>();
			SimpleIoc.Default.Register<StackOverflowService>();
			SimpleIoc.Default.Register<HttpService>();

			var localStorageServiceImpl = DependencyService.Get<ILocalStorageService>();
			SimpleIoc.Default.Register<ILocalStorageService>(() => localStorageServiceImpl);

			SimpleIoc.Default.Register<MainViewModel>();
		}

		public MainViewModel MainViewModel { get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }}

		public void InitalizeNavigationService(Page rootPage)
		{			
			var navigationService = new NavigationService(rootPage);
			navigationService.Configure(NavigationService.RootPageKey, typeof(MainPage));
			navigationService.Configure("Tags", typeof(TagPage));
			navigationService.Configure("Settings", typeof(SettingsPage));

			SimpleIoc.Default.Register<INavigationService>(() => navigationService); ;
		}
	}
}