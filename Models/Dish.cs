using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ChefsNDishes.Models
{
  public class Dish
  {
    [Key]
    public int DishId {get;set;}
    [Required]
    [MinLength(3)]
    public string Name {get;set;}
    [Required]
    [Range(0, 100000000)]
    public int Calories {get;set;}
    [Required]
    public int Tastiness {get;set;}
    [Required]
    [MinLength(10)]
    [MaxLength(255)]
    public string Description {get;set;}
    [Required]
    public int ChefId { get; set; }
    public Chef ChefWhoMade {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Dish(){}
    
  }
}