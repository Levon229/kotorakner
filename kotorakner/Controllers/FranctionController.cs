using System;
using Microsoft.AspNetCore.Mvc;
using Kotorakner.Models;

namespace Kotorakner.Controllers
{
    public class FractionController : Controller
    {
        public IActionResult Index()
        {
            FractionModel model = new FractionModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Calculate(FractionModel model)
        {
            if (model.Denominator1 == 0 || model.Denominator2 == 0)
            {
                model.Result = "Sxal haytararnery chen karogh 0 linel";
                return View("Index", model);
            }

            int resultNumerator;
            int resultDenominator;

            switch (model.Operation)
            {
                case "+":
                    resultNumerator =
                        model.Numerator1 * model.Denominator2 +
                        model.Numerator2 * model.Denominator1;

                    resultDenominator =
                        model.Denominator1 * model.Denominator2;
                    break;

                case "-":
                    resultNumerator =
                        model.Numerator1 * model.Denominator2 -
                        model.Numerator2 * model.Denominator1;

                    resultDenominator =
                        model.Denominator1 * model.Denominator2;
                    break;

                case "*":
                    resultNumerator =
                        model.Numerator1 * model.Numerator2;

                    resultDenominator =
                        model.Denominator1 * model.Denominator2;
                    break;

                case "/":
                    if (model.Numerator2 == 0)
                    {
                        model.Result = "Sxal 0 i bajanel chi karli";
                        return View("Index", model);
                    }

                    resultNumerator =
                        model.Numerator1 * model.Denominator2;

                    resultDenominator =
                        model.Denominator1 * model.Numerator2;
                    break;

                default:
                    model.Result = "yntrvac gorcoxutyuny anhayt e։";
                    return View("Index", model);
            }

            int divisor = GreatestCommonDivisor(
                resultNumerator,
                resultDenominator
            );

            resultNumerator /= divisor;
            resultDenominator /= divisor;

            if (resultDenominator < 0)
            {
                resultNumerator *= -1;
                resultDenominator *= -1;
            }

            model.Result = $"{resultNumerator}/{resultDenominator}";

            return View("Index", model);
        }

        private int GreatestCommonDivisor(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }
    }
}