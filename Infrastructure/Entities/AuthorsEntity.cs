
using Infrastructure.Entities;

public class AuthorsEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<CoursesEntity> Courses { get; set; } = new List<CoursesEntity>();
}