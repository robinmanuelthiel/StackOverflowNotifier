﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StackOverflowNotifier
{
	public partial class TagPage : ContentPage
	{
		public TagPage()
		{
			InitializeComponent();

			// Add icon to tab on iOS
			if (Device.OS == TargetPlatform.iOS)
			{
				Icon = "Tag.png";
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			BindingContext = App.Bootstrapper.MainViewModel;
		}

		public void TagEntry_Completed(object sender, EventArgs e)
		{
			App.Bootstrapper.MainViewModel.AddTagCommand.Execute(TagEntry.Text);
		}


		public void RemoveEntry_Clicked(object sender, EventArgs e)
		{
			App.Bootstrapper.MainViewModel.RemoveTagCommand.Execute((sender as Button).BindingContext);
		}
	}
}
