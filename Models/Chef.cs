using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ChefsNDishes.Models
{
  public class Chef
  {
    [Key]
    public int ChefId {get; set;}
    [Required]
    [MinLength(3)]
    public string FirstName {get;set;}
    [Required]
    [MinLength(3)]
    public string LastName {get;set;}
    [Required]
    public DateTime BirthDate {get;set;} 
    [NotMapped]
    public int Age {get;set;}
    public List<Dish> Dishes {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Chef(){}
  }
}