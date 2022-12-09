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
	public partial class NotesEntryPage : ContentPage
	{
		public NotesEntryPage ()
		{
			InitializeComponent ();
		}

		async void OnSaveButtonClicked(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(noteName.Text))
			{
				await DisplayAlert("Invalid", "Blank Notes are Invalid!", "OK");
			}
			else {
				AddNewNote();
			}	
		}

		async void AddNewNote() {
            await App.Database.SaveNoteAsync(new Note { 
				taskDescription = noteDetail.Text,
				taskName= noteName.Text,
                Date = DateTime.Now
        });
            await Navigation.PopAsync();
        }
		async void OnDeleteButtonClicked(object sender, EventArgs e) {
			//var note = (Note)BindingContext;

		
		}

    }
}