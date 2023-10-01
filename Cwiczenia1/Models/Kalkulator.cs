using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cwiczenia1.Models;

public class Kalkulator
{
    public int Id { get; set; }
    public int firstNumber { get; set; }

    public int secondNumber { get; set; }
    public string Symbol { get; set; }
    
}
