namespace Hospitals.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
