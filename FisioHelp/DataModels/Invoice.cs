using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.Linq;

namespace FisioHelp.DataModels
{

  [Table(Schema = "public", Name = "invoices")]
  public partial class Invoice
  {
    [Column("id"), PrimaryKey, Identity] public int Id { get; set; } // integer
    [Column("date"), NotNull] public NpgsqlDate Date { get; set; } // date
    [Column("discount"), Nullable] public double? Discount { get; set; } // double precision
    [Column("payed"), Nullable] public bool? Payed { get; set; } // boolean
    [Column("deleted")] public bool Deleted { get; set; } // boolean
    [Column("text"), Nullable] public string Text { get; set; } // text
    [Column("title")] public string Title { get; set; } // text

    public double Total
    {
      get
      {
        var discount = Discount != null ? (double)Discount : 0.0;
        return Visitsinvoiceidfkeys.Sum(x => x.Price != null ? (double)x.Price : 0.0) - discount;
      }
    }

    #region Associations

    /// <summary>
    /// visits_invoice_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "InvoiceId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<Visit> Visitsinvoiceidfkeys { get; set; }

    #endregion
  }
}
