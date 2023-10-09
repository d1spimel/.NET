using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly string booksPath = "./books.json";
        private readonly string profilesPath = "./profiles.json";

        public IActionResult GetGreeting()
        {
            return Content("Hello, user!");
        }

        [HttpGet("books")]
        public IActionResult ListBooks()
        {
            if (System.IO.File.Exists(booksPath))
            {
                string jsonString = System.IO.File.ReadAllText(booksPath);
                List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonString);

                string tableHtml = "<html><head><style>";
                tableHtml += @"
                    table {
                        border-collapse: collapse;
                        width: 50%;
                        margin: 20px auto;
                        font-family: 'Trebuchet MS';
                        background-color: '#d4e3fa';
                        text-align: center;
                    }
                    
                    table, th, td {
                        border: 1px solid black;
                    }
                    
                    th, td {
                        padding: 10px;
                    }
                    
                    h2 {
                        font-family: 'Trebuchet MS';
                        text-align: center;
                    }
                ";
                tableHtml += "</style></head><body><h2>Library</h2><table><tr><th>Name of book</th><th>Author</th></tr>";

                foreach (var book in books)
                {
                    tableHtml += $"<tr><td>{book.Title}</td><td>{book.Author}</td></tr>";
                }

                tableHtml += "</table></body></html>";

                return Content(tableHtml, "text/html; charset=utf-8");
            }
            else
            {
                return NotFound("File not found!");
            }
        }



       [HttpGet("profile/{id?}")]
        public IActionResult GetProfile(int? id)
        {
            if (System.IO.File.Exists(profilesPath))
            {
                var content = System.IO.File.ReadAllText(profilesPath);
                var profiles = JsonSerializer.Deserialize<Dictionary<string, Profile>>(content);

                if (id.HasValue && id >= 0 && profiles.ContainsKey(id.ToString()))
                {
                    var userInfo = profiles[id.ToString()];
                    string tableHtml = GenerateProfileHtml(userInfo);
                    return Content(tableHtml, "text/html; charset=utf-8");
                }
                else if (profiles.ContainsKey("CurrentUser"))
                {
                    var currentUserInfo = profiles["CurrentUser"];
                    string tableHtml = GenerateProfileHtml(currentUserInfo);
                    return Content(tableHtml, "text/html; charset=utf-8");
                }
                else
                {
                    return NotFound("Info not found!");
                }
            }
            else
            {
                return NotFound("File not found!");
            }
        }

        private string GenerateProfileHtml(Profile userInfo)
        {
            string tableHtml = "<html><head><style>";
            tableHtml += @"
                table {
                    border-collapse: collapse;
                    width: 50%;
                    margin: 20px auto;
                    font-family: 'Trebuchet MS';
                    background-color: '#d4e3fa';
                    text-align: center;
                }
                
                table, th, td {
                    border: 1px solid black;
                }
                
                th, td {
                    padding: 10px;
                }
                
                h2 {
                    font-family: 'Trebuchet MS';
                    text-align: center;
                }
            ";
            tableHtml += "</style></head><body><h2>User Profile</h2><table><tr><th>Id</th><th>Name</th><th>Age</th></tr>";

            tableHtml += $"<tr><td>{userInfo.Id}</td><td>{userInfo.Name}</td><td>{userInfo.Age}</td></tr>";

            tableHtml += "</table></body></html>";

            return tableHtml;
        }

    }
}
