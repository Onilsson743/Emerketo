﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;


public class ProductColoursEntity
{
    [Key]
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public string ColourId { get; set; } = null!;
    public ColourEntity Colour { get; set; } = null!;
}
