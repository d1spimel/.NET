using System.Text.Json;
using System.Xml;

namespace WebApplication1
{
    public class Company
    {
        public string Name { get; set; }
        public int Employees { get; set; }
        public int Year { get; set; }
        public Company(string name, int employees, int year)
        {
            this.Name = name;
            this.Employees = employees;
            this.Year = year;
        }
        public string Show()
        {
            return ("\nName: " + this.Name + "\nEmployees: " + this.Employees + "\nYear: " + this.Year);
        }
        public static Company? initializeFromJson(string file)
        {
            return JsonSerializer.Deserialize<Company>(File.ReadAllText(file));
        }

        public static Company initializeFromXML(string file)
        {
            XmlReader reader = XmlReader.Create(file, new XmlReaderSettings { IgnoreWhitespace = true });
            reader.ReadStartElement("Company");
            string name = reader.ReadElementContentAsString("Name", "");
            int employees = reader.ReadElementContentAsInt("Employees", "");
            int year = reader.ReadElementContentAsInt("Year", "");

            return new Company(name, employees, year);
        }

        public static Company initializeFromIni(string file)
        {
            IConfiguration cfg = new ConfigurationBuilder().AddIniFile(file).Build();
            string name = cfg["Company:Name"];
            int employees = Convert.ToInt32(cfg["Company:Employees"]);
            int year = Convert.ToInt32(cfg["Company:Year"]);

            return new Company(name, employees, year);
        }

        public static Company? getMaxEmployees(Company[] companies)
        {
            if (companies == null || !companies.Any())
            {
                return null;
            }

            return companies.OrderByDescending(company => company.Employees).First();
        }
    }
}
