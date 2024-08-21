namespace WebApp.API.Domain
{
    public class Post
    {
        private Post()
        {

        }
        public Post(
            string name,
            string breed,
            Weight weight,
            int height,
            bool vaccine,
            DateOnly birthDate,
            MainPhoto mainphoto,
            string description,
            string adress)
        {
            Name = name;
            Breed = breed;
            Weight = weight;
            Height = height;
            Vaccine = vaccine;
            BirthDate = birthDate;
            MainPhoto = mainphoto;
            Description = description;
            Adress = adress;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public string Breed { get; private set; } = string.Empty;

        public Weight Weight { get; private set; } = default!;

        public int Height { get; private set; }

        public bool Vaccine { get; private set; }

        public DateOnly BirthDate { private get; set; }

        public MainPhoto MainPhoto { get; private set; }
        public List<Photo> Photos { get; private set; }

        public string Description { get; private set; } = string.Empty;

        public string Adress { get; private set; } = string.Empty;

    }
}

