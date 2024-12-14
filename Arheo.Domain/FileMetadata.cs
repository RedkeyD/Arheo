namespace Arheo.Domain
{
    public class FileMetadata
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}