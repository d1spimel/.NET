using WebApplication8.Models;
using WebApplication8.Models.Data;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = CreateHostBuilder(args).Build();

        using (AppDbContext dbcontext = new AppDbContext())
        {
            dbcontext.Users.AddRange(
                new User { Name = "John", Surname = "Doe", Age = 25 },
                new User { Name = "Jane", Surname = "Smith", Age = 30 },
                new User { Name = "Alice", Surname = "Johnson", Age = 22 }
            );

            dbcontext.SaveChanges();

            var users = dbcontext.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Surname: {user.Surname}, Age: {user.Age}");
            }
        }
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Program>();
                webBuilder.ConfigureServices(services =>
                {
                    services.AddMvc();
                    services.AddDbContext<AppDbContext>();
                });
                webBuilder.Configure(app =>
                {
                    var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                    if (env.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }
                    else
                    {
                        app.UseExceptionHandler("/Home/Error");
                        app.UseHsts();
                    }

                    app.UseHttpsRedirection();
                    app.UseStaticFiles();

                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute(
                            name: "company",
                            pattern: "{controller=Company}/{action=Index}");
                    });
                });
            });
}
