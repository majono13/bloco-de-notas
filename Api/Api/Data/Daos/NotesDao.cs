﻿using Api.Models.Notes;

namespace Api.Data.Daos
{
    public class NotesDao
    {
        private AppDbContext _appDbContext;

        public NotesDao(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateNote(Note note)
        {

            _appDbContext.Notes.Add(note);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Note> GetNotesByUserId(int id)
        {

           if(id != null)
            {
              return  _appDbContext.Notes.Where(note => note.UserId == id);
            }


            return null;
        }

        public Note GetNoteById(int id)
        {

            if(id !=null)
            {
                return _appDbContext.Notes.FirstOrDefault(note => note.Id == id);
            }
            return null;
        }

        public bool DeleteNote(int id)
        {
            if(id !=null)
            {
                Note  note = GetNoteById(id);

                if(note !=null)
                {
                    _appDbContext.Remove(note);
                    _appDbContext.SaveChanges();

                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
