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

		readonly Note _note;
        public NotesEntryPage(Note note)
        {
            InitializeComponent();
			Title = "Edit Note";
			_note = note;
            noteName.Text = note.taskName;
			noteDetail.Text = note.taskDescription;
            noteName.Focus();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(noteName.Text))
			{
				await DisplayAlert("Invalid", "Blank Notes are Invalid!", "OK");
			} else if (_note != null) {
				EditNote();
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

        async void EditNote()
        {
			_note.taskName = noteName.Text;
            _note.taskDescription = noteDetail.Text;
			_note.Date= DateTime.Now;

			await App.Database.UpdateNoteAsync(_note);
			await Navigation.PopAsync();
        }
    }
}