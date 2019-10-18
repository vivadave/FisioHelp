using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "price_lists")]
  public partial class PriceList : BaseModel
  {
    [Column("name"), NotNull] public string Name { get; set; } // character varying(256)
    [Column("price"), NotNull] public double Price { get; set; } // double precision
    [Column("therapist_id"), NotNull] public Guid TherapistId { get; set; } // uuid

    public override string ToString()
    {
      return $"{Name} ( {Price}€ )";
    }

    public override Guid SaveToDB()
    {
      return Helper.DbManagement.SaveToDB(this);
    }

    #region Associations

    /// <summary>
    /// customers_pricelist_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "PricelistId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<Customer> Customerspricelistidfkeys { get; set; }

    /// <summary>
    /// price_lists_therapist_id_fkey
    /// </summary>
    [Association(ThisKey = "TherapistId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "price_lists_therapist_id_fkey", BackReferenceName = "Priceliststherapistidfkeys")]
    public Therapist Therapist { get; set; }

    #endregion
  }
}
