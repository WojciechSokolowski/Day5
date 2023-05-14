using System;
using System.Collections.Generic;

namespace HW02InventoryManagementSystem.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string? Name { get; set; }

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
