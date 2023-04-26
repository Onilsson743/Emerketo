﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;

public class AdressEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? ApartmentNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string StreetName { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "char(6)")]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    public List<UserEntity> Users { get; set; } = null!;
    public List<OrderEntity> Orders { get; set; } = null!;
}
