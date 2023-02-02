namespace TacosLibrary
{
    public class Numbers
    {
        
        public static string IsNumberEven(string input)
        {
            int number = int.Parse(input);
            return (number % 2 == 0) ? "even" : "odd";
        }
    }
}
