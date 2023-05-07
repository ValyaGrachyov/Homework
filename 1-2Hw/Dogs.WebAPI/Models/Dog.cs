namespace Dogs.WebAPI.Models
{
    public class Dog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public Family Family { get; set; }

        public string Description { get; set; }
        public string shortDescription { get; set; }

        public int Height { set; get; }

        public int MinAge { get;set; }
        public int MaxAge { get;set; }

    }
}
