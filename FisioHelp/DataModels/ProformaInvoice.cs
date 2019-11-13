using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.Linq;

namespace FisioHelp.DataModels
{
    [Table(Schema = "public", Name = "proforma_invoices")]
    public partial class ProformaInvoice : BaseModel
    {
      [Column("date"), NotNull] public NpgsqlDate Date { get; set; } // date
      [Column("discount"), Nullable] public double? Discount { get; set; } // double precision
      [Column("payed"), NotNull] public bool Payed { get; set; } // boolean
      [Column("payed_date"), Nullable] public NpgsqlDate? PayedDate { get; set; } // date
      [Column("tax_stamp"), NotNull] public bool TaxStamp { get; set; } // boolean
      [Column("therapist_id"), NotNull] public Guid TherapistId { get; set; } // uuid
      [Column("title"), NotNull] public string Title { get; set; } // character varying(25)
      [Column("deleted"), NotNull] public bool Deleted { get; set; } // boolean
      [Column("text"), Nullable] public string Text { get; set; } // text
      [Column("invoice_id"), Nullable] public Guid? InvoiceId { get; set; } // uuid


    public double Total
      {
        get
        {
          var discount = Discount != null ? (double)Discount : 0.0;
          return Visitsproformainvoiceidfkeys.Sum(x => x.Price != null ? (double)x.Price : 0.0) - discount;
        }
      }

      public Customer Customer {
        get
        {
          var visit = Visitsproformainvoiceidfkeys.FirstOrDefault();
          return visit?.Customer;
        }
      }

      public string CustomerName
      {
        get
        {
          var visit = Visitsproformainvoiceidfkeys.FirstOrDefault();
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
    /// proforma_invoices_invoice_id_fkey
    /// </summary>
    [Association(ThisKey = "InvoiceId", OtherKey = "Id", CanBeNull = true, Relationship = Relationship.ManyToOne, KeyName = "proforma_invoices_invoice_id_fkey", BackReferenceName = "Proformainvoiceidfkeys")]
    public Invoice Invoice { get; set; }

    /// <summary>
    /// proforma_invoices_therapist_id_fkey
    /// </summary>
    [Association(ThisKey = "TherapistId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "proforma_invoices_therapist_id_fkey", BackReferenceName = "Proformainvoicestherapistidfkeys")]
      public Therapist Therapist { get; set; }

    /// <summary>
    /// visits_proforma_invoice_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "ProformaInvoiceId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<Visit> Visitsproformainvoiceidfkeys { get; set; }
    #endregion
  }
  }
