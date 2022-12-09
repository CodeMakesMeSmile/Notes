using System;
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
				myCollectionView.ItemsSource = await App.Database.GetNotesAsync();
			}
			catch { }
		}

		async void OnNoteAddedClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NotesEntryPage
			{
				BindingContext = new Note()
			});
		}

		async void SwipeItem_Invoked(object sender, EventArgs e) {
			var item = sender as SwipeItem;
			var note = item.CommandParameter as Note;
			await Navigation.PushAsync(new NotesEntryPage(note));
		}

        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var note = item.CommandParameter as Note;
			var result = await DisplayAlert("Delete", $"Delete {note.taskName} from database?", "Yes", "No");
			if (result) {
				await App.database.DeleteNote(note);
				myCollectionView.ItemsSource = await App.Database.GetNotesAsync();
			}
            await Navigation.PushAsync(new NotesEntryPage(note));
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new NotesEntryPage());
        }

		async void SearchBar_TextChange(object sender, TextChangedEventArgs e) {
			myCollectionView.ItemsSource = await App.Database.Search(e.NewTextValue);

		}
    }
}