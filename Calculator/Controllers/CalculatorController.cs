using Calculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: /Calculator/
        public IActionResult Index()
        {
            return View(new calculatorModel());

        }

        // POST: /Calculator/Calculate
        [HttpPost]
        public IActionResult Calculate(calculatorModel model)
        {
            switch (model.Operation)
            {
                case "Add":
                    model.Result = model.Number1 + model.Number2;
                    break;
                case "Subtract":
                    model.Result = model.Number1 - model.Number2;
                    break;
                case "Multiply":
                    model.Result = model.Number1 * model.Number2;
                    break;
                case "Divide":
                    if (model.Number2 != 0)
                    {
                        model.Result = model.Number1 / model.Number2;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cannot divide by zero.");
                    }
                    break;
            }
            return View("Index", model);
        }
    }
}
