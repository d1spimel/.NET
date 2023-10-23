using Microsoft.AspNetCore.Mvc;
using AspNetMVC.Models;
using System.Collections.Generic;

public class PizzaController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (user.Age >= 16)
        {
            var pizza = new List<Pizza>
            {
                new Pizza { Name = "Pepperoni", Count = 0 },
                new Pizza { Name = "Margherita", Count = 0 },
                new Pizza { Name = "100 Cheeses", Count = 0 },
                new Pizza { Name = "Hawaiian", Count = 0 },
                new Pizza { Name = "Vegetarian", Count = 0 },
                new Pizza { Name = "Supreme", Count = 0 },
                new Pizza { Name = "BBQ Chicken", Count = 0 }
            };
            user.Pizza = pizza; 
            return View("OrderPage", user);

        }
        else
        {
            return Content("You so younger... Maybe you calling parents?");
        }
    }

    [HttpPost]
    public IActionResult OrderPage(User user)
    {
        return View("OrderSummary", user);
    }

    [HttpPost]
    public IActionResult OrderSummary(List<Pizza> pizza)
    {
        return View(pizza);
    }
}