﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLearnAPI.Data;
[Table("Book")]
public class Book
{
    // khoa chinh la Id
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Title { get; set; }
    public string? Description { get; set; }
    [Range(0, double.MaxValue)]
    public double Price { get; set; }
    [Range(0,100)]
    public int Quantity { get; set; }
   
}
