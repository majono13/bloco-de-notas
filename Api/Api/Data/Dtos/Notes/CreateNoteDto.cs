namespace Api.Data.Dtos.Notes
{
    public class CreateNoteDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
       // public DateTime CreationDate { get; set; }
        public bool IsFiled { get; set; }
        public int UserId { get; set; }
    }
}
