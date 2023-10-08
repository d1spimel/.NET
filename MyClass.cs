using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1
{
    public class MyClass
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("SecondName")]
        public string SecondName { get; set; }

        [JsonPropertyName("Age")]
        public int Age { get; set; }

        public MyClass(string name, string secondName, int age) {
            Name = name;
            SecondName = secondName;
            Age = age;
        }
        public string Show()
        {
            return ("Name: " + this.Name + "\nSecond Name: " + this.SecondName + "\nAge: " + this.Age);
        }

        public static MyClass? initializeFromJson(string file)
        {
            return JsonSerializer.Deserialize<MyClass>(File.ReadAllText(file));
        }

    }
}
