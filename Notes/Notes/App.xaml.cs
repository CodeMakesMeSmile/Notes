using Notes.Data;
using Notes.Services;
using Notes.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Notes
{
    public partial class App : Application
    {
        public static NotesDatabase database;

        public static NotesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NotesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.db3"));
                }

                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
