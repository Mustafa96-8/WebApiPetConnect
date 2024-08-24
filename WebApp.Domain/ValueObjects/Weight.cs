namespace WebApp.Domain.ValueObjects
{
    public record Weight
    {
        private Weight()
        {
            
        }
        public Weight(float weight)
        {
            Grams = Convert.ToInt32(weight * 1000);
        }
        public int Grams { get; private set; }


    }

}
