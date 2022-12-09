﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotesPage : ContentPage
	{
		public NotesPage ()
		{
			InitializeComponent ();
		}

		protected override async void OnAppearing()
		{
			try
			{
				base.OnAppearing();
				ListView.ItemsSource = await App.Database.GetNotesAsync();
			}
			catch { 
			
			
			}
		}

		async void OnNoteAddedClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NotesEntryPage
			{
				BindingContext = new Note()
			});
		}

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			if (e.SelectedItem != null)
			{
                await Navigation.PushAsync(new NotesEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new NotesEntryPage());
        }
    }
}