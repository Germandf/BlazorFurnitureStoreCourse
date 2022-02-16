namespace BlazorFurnitureStoreCourse.Shared
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
