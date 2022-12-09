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
        private readonly SQLiteAsyncConnection db;

        public NotesDatabase(string dbPath) { 
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Note>();
        }

        public Task<List<Note>> GetNotesAsync() 
        {
            return db.Table<Note>().ToListAsync();
        }

        public Task<int> SaveNoteAsync(Note note) {
            return db.InsertAsync(note); 
        }

        public Task<int> UpdateNoteAsync(Note note)
        {
            return db.UpdateAsync(note);
        }

        public Task<int> DeleteNote(Note note)
        {
            return db.DeleteAsync(note);
        }


        public Task<List<Note>> Search(string query)
        {
            return db.Table<Note>().Where(p=>p.taskName.StartsWith(query)).ToListAsync();
        }
    }
}
