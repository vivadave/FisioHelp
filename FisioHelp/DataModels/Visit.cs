using System;
using LinqToDB.Mapping;
using NpgsqlTypes;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "visits")]
  public partial class Visit
  {
    [Column("id"), PrimaryKey, Identity] public int Id { get; set; } // integer
    [Column("date"), NotNull] public NpgsqlDate Date { get; set; } // date
    [Column("customer_id"), NotNull] public int CustomerId { get; set; } // integer
    [Column("invoice_id"), Nullable] public int? InvoiceId { get; set; } // integer
    [Column("price"), Nullable] public double? Price { get; set; } // double precision
    [Column("duration"), Nullable] public int? Duration { get; set; } // integer
    [Column("invoiced"), Nullable] public bool? Invoiced { get; set; } // boolean
    [Column("payed"), Nullable] public bool? Payed { get; set; } // boolean
    [Column("note"), Nullable] public string Note { get; set; } // text

    #region Associations

    /// <summary>
    /// visits_customer_id_fkey
    /// </summary>
    [Association(ThisKey = "CustomerId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "visits_customer_id_fkey", BackReferenceName = "Visitscustomeridfkeys")]
    public Customer Customer { get; set; }

    /// <summary>
    /// visits_invoice_id_fkey
    /// </summary>
    [Association(ThisKey = "InvoiceId", OtherKey = "Id", CanBeNull = true, Relationship = Relationship.ManyToOne, KeyName = "visits_invoice_id_fkey", BackReferenceName = "Visitsinvoiceidfkeys")]
    public Invoice Invoice { get; set; }

    #endregion
  }
}
