namespace WebApp.API.Domain
{
    public class Post
    {
        public Post(
            string name,
            string breed,
            Weight weight,
            int height,
            bool vaccine,
            DateOnly birthDate,
            string photo,
            string description,
            string adress)
        {
            Name = name;
            Breed = breed;
            Weight = weight;
            Height = height;
            Vaccine = vaccine;
            BirthDate = birthDate;
            Photo = photo;
            Description = description;
            Adress = adress;
        }

        public string Name { get;private set; } = string.Empty;

        public string Breed { get;private set; } = string.Empty;

        public Weight Weight { get;private set; } = default!;

        public int Height { get;private set; }

        public bool Vaccine { get;private set; }

        public DateOnly BirthDate {private get; set; }
        
        public string Photo {get;private set;} = string.Empty;

        public string Description { get;private set; } = string.Empty ;

        public string Adress    { get;private set; } = string .Empty ;

    }
    public class Weight
    {
        public int Grams { get; set; }

        public Weight(float weight)
        {
            Grams = Convert.ToInt32(weight * 1000);
        }
    }

   
}
