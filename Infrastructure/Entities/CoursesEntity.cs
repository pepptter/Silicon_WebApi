namespace Infrastructure.Entities
{
    public class CoursesEntity
    {
        public int Id { get; set; }
        public bool IsBestseller { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string? DiscountPrice { get; set; }
        public string Hours { get; set; } = null!;
        public string LikesInPercent { get; set; } = null!;
        public string LikesInNumbers { get; set; } = null!;

        public ICollection<AuthorsEntity> Authors { get; set; } = new List<AuthorsEntity>();
    }

}
