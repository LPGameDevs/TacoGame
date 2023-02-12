namespace TacosLibrary
{
    public class Rider
    {
        public enum FoodName
        {
            Tacos = 0,
            Veggie = 1,
        }
        
        public int Value { get; set; }
        public bool HasValue { get; private set; }

        public FoodName Food;
        public bool Delivered = false;
        public int Path = 0;
        
        public Rider(FoodName food)
        {
            HasValue = false;
            Food = food;
        }
        
        public Rider()
        {
            HasValue = false;
            Food = FoodName.Tacos;
        }

        public void SetValue(int outcome)
        {
            HasValue = true;
            Value = outcome;
        }
    }
}
