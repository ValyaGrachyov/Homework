using Dogs.WebAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace Dogs.WebAPI.Data
{
    public static class DataSeeds
    {
        public static readonly List<Dog> DogList= new List<Dog>();
        public static  List<Dog> GetDog()
        {
            DogList.Add(
                new Dog
                {
                    Id = 1,
                    Description = "Vla-Vla1",
                    Family = null,
                    MaxAge = 10,
                    MinAge = 5,
                    ImgUrl = "https://cdn2.thedogapi.com/images/SyfsC19NQ_1280.jpg",
                    Height = 100,
                    shortDescription = "Bla1",
                    Name = "Матильда1"
                });
            DogList.Add(
                new Dog
                {
                    Id = 2,
                    Description = "Vla-Vla2",
                    Family = null,
                    MaxAge = 10,
                    MinAge = 5,
                    ImgUrl = "https://cdn2.thedogapi.com/images/SyfsC19NQ_1280.jpg",
                    Height = 100,
                    shortDescription = "Bla2",
                    Name = "Матильда2"
                });
            DogList.Add(
                new Dog
                {
                    Id = 3,
                    Description = "Vla-Vla3",
                    Family = null,
                    MaxAge = 10,
                    MinAge = 5,
                    ImgUrl = "https://cdn2.thedogapi.com/images/SyfsC19NQ_1280.jpg",
                    Height = 100,
                    shortDescription = "Bla3",
                    Name = "Матильда3"
                }
                );

            

            return DogList;
        }
    }
}
