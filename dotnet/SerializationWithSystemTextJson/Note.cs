class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string NoteText { get; set; }

    public Note() { }

    public Note(int id, string title, string text)
    {
        this.Id = id;
        this.Title = title;
        this.NoteText = text;
    }
}