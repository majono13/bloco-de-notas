using Api.Models.Notes;

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
    }
}
