using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

using NpgsqlTypes;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "addresses")]
  public partial class Address
  {
    [Column("id"), PrimaryKey, Identity] public int Id { get; set; } // integer
    [Column("address"), Nullable] public string Address_Column { get; set; } // character varying(256)
    [Column("cap"), NotNull] public string Cap { get; set; } // character varying(45)
    [Column("city"), Nullable] public string City { get; set; } // character varying(45)

    #region Associations

    /// <summary>
    /// customers_address_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "AddressId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<Customer> Customersaddressidfkeys { get; set; }

    #endregion
  }
}
