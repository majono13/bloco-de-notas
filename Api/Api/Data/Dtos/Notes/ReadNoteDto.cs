﻿namespace Api.Data.Dtos.Notes
{
    public class ReadNoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ?Content { get; set; }
        public bool IsFiled { get; set; }
        public int UserId { get; set; }
    }
}
