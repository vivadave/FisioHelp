using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using NpgsqlTypes;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "customers")]
  public partial class Customer
  {
    [Column("id"), PrimaryKey, Identity] public int Id { get; set; } // integer
    [Column("name"), Nullable] public string Name { get; set; } // character varying(45)
    [Column("surname"), NotNull] public string Surname { get; set; } // character varying(45)
    [Column("email"), Nullable] public string Email { get; set; } // character varying(45)
    [Column("vat"), Nullable] public string Vat { get; set; } // character varying(45)
    [Column("fiscalcode"), Nullable] public string Fiscalcode { get; set; } // character varying(45)
    [Column("tel1"), Nullable] public string Tel1 { get; set; } // character varying(45)
    [Column("tel2"), Nullable] public string Tel2 { get; set; } // character varying(45)
    [Column("address_id"), Nullable] public int? AddressId { get; set; } // integer
    [Column("pricelist_id"), Nullable] public int? PricelistId { get; set; } // integer
    [Column("note"), Nullable] public string Note { get; set; } // text
    [Column("language"), Nullable] public string Language { get; set; } // text
    [Column("creation_date"), Nullable] public NpgsqlDate CreationDate { get; set; } // date
    [Column("privacy"), NotNull] public bool Privacy { get; set; } // bool

    public string FullName
    {
      get { return $"{Name} {Surname}"; }
    }

    public override string ToString()
    {
      return FullName;
    }

    #region Associations

    /// <summary>
    /// customers_address_id_fkey
    /// </summary>
    [Association(ThisKey = "AddressId", OtherKey = "Id", CanBeNull = true, Relationship = Relationship.ManyToOne, KeyName = "customers_address_id_fkey", BackReferenceName = "Customersaddressidfkeys")]
    public Address Address { get; set; }

    /// <summary>
    /// customers_pricelist_id_fkey
    /// </summary>
    [Association(ThisKey = "PricelistId", OtherKey = "Id", CanBeNull = true, Relationship = Relationship.ManyToOne, KeyName = "customers_pricelist_id_fkey", BackReferenceName = "Customerspricelistidfkeys")]
    public PriceList Pricelist { get; set; }

    /// <summary>
    /// visits_customer_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "CustomerId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<Visit> Visitscustomeridfkeys { get; set; }

    #endregion
  }
}
