using WebApplication1;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<CalculateService>();
builder.Services.AddControllers();
builder.Services.AddTransient<TimeService>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseMiddleware<ErrorLogMiddleware>();
app.MapControllers();


string jsonFile = "apple.json";
string xmlFile = "microsoft.xml";
string iniFile = "google.ini";
string myJson = "me.json";

Company Apple = Company.initializeFromJson(jsonFile);
Company Microsoft = Company.initializeFromXML(xmlFile);
Company Google = Company.initializeFromIni(iniFile);
Company[] companies = { Apple, Microsoft, Google };



app.MapGet("/", () => Microsoft.Show());
app.MapGet("/getMaxEmployees", () =>
{
    var maxEmployeesCompany = Company.getMaxEmployees(companies);

    if (maxEmployeesCompany != null)
    {
        return maxEmployeesCompany.Show();
    }
    else
    {
        return "No companies found or all companies have no employees.";
    }
});
app.MapGet("/myInfo", () =>
{
    var I = MyClass.initializeFromJson(myJson);
    if (I != null)
    {
        return I.Show();
    }
    else {
        return "File is null!";
    }
});

app.Run();