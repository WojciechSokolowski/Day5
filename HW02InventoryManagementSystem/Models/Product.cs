using System;
using System.Collections.Generic;

namespace HW02InventoryManagementSystem.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int? SupplierId { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
