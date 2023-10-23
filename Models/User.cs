namespace AspNetMVC.Models
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Pizza> Pizza { get; set; }
    }

}