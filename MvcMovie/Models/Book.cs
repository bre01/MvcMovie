using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MvcMovie.Models;
public class Book

{
    public int Id { get; set; }
    [Display(Name = "Nick Name")]
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Kind { get; set; }
    public decimal Price { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime PlantTime { get; set; }
}