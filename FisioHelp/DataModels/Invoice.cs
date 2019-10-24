using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.Linq;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "invoices")]
  public partial class Invoice : BaseModel
  {
    [Column("date"), NotNull] public NpgsqlDate Date { get; set; } // date
    [Column("discount"), Nullable] public double? Discount { get; set; } // double precision
    [Column("payed"), NotNull] public bool Payed { get; set; } // boolean
    [Column("therapist_id"), NotNull] public Guid TherapistId { get; set; } // uuid
    [Column("text"), Nullable] public string Text { get; set; } // text
    [Column("title"), NotNull] public string Title { get; set; } // character varying(25)
    [Column("deleted"), Nullable] public bool? Deleted { get; set; } // boolean
    [Column("tax_stamp"), NotNull] public bool TaxStamp { get; set; } // boolean

    public double Total
    {
      get
      {
        var discount = Discount != null ? (double)Discount : 0.0;
        return Visitsinvoiceidfkeys.Sum(x => x.Price != null ? (double)x.Price : 0.0) - discount;
      }
    }

    public Customer Customer {
      get
      {
        var visit = Visitsinvoiceidfkeys.FirstOrDefault();
        return visit?.Customer;
      }
    }

    public string CustomerName
    {
      get
      {
        var visit = Visitsinvoiceidfkeys.FirstOrDefault();
        if (visit != null)
        {
          return visit.Customer?.FullName;
        }
        return "";
      }
    }

    public override Guid SaveToDB()
    {
      return Helper.DbManagement.SaveToDB(this);
    }
    #region Associations

    /// <summary>
    /// invoices_therapist_id_fkey
    /// </summary>
    [Association(ThisKey = "TherapistId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "invoices_therapist_id_fkey", BackReferenceName = "Invoicestherapistidfkeys")]
    public Therapist Therapist { get; set; }

    /// <summary>
    /// visits_invoice_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "InvoiceId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<Visit> Visitsinvoiceidfkeys { get; set; }

    #endregion

  }
}
