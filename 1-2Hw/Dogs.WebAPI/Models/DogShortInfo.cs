namespace Dogs.WebAPI.Models
{
    public class DogShortInfo
    {
        public object id { get; set; }

        public string name { get; set; }

        public string ImgUrl { set; get; }

        public Family Family { set; get; }

    }
}
