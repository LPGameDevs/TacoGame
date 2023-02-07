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
        
        public Rider(FoodName food)
        {
            HasValue = false;
            Food = food;
        }

        public void SetValue(int outcome)
        {
            HasValue = true;
            Value = outcome;
        }
    }
}
