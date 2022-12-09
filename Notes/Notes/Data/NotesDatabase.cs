using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data
{
    public class NotesDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public NotesDatabase(string dbPath) { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>();

        }

        public Task<List<Note>> GetNoteAsync() 
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<int> SaveNote(Note note) {
            return _database.InsertAsync(note);
        }
    }
}
