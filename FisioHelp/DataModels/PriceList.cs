using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "price_lists")]
  public partial class PriceList
  {
    [Column("id"), PrimaryKey, Identity] public int Id { get; set; } // integer
    [Column("name"), NotNull] public string Name { get; set; } // character varying(256)
    [Column("price"), NotNull] public double Price { get; set; } // double precision

    public override string ToString()
    {
      return $"{Name} ( {Price}€ )";
    }

    #region Associations

    /// <summary>
    /// customers_pricelist_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "PricelistId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<Customer> Customerspricelistidfkeys { get; set; }

    #endregion
  }
}
