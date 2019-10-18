using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using NpgsqlTypes;
using System.Linq;
using LinqToDB;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "visits")]
  public partial class Visit : BaseModel
  {
    [Column("date"), NotNull] public NpgsqlDate Date { get; set; } // date
    [Column("customer_id"), NotNull] public Guid CustomerId { get; set; } // uuid
    [Column("invoice_id"), Nullable] public Guid? InvoiceId { get; set; } // uuid
    [Column("therapist_id"), NotNull] public Guid TherapistId { get; set; } // uuid
    [Column("price"), Nullable] public double? Price { get; set; } // double precision
    [Column("duration"), Nullable] public string Duration { get; set; } // integer
    [Column("invoiced"), NotNull] public bool Invoiced { get; set; } // boolean
    [Column("payed"), NotNull] public bool Payed { get; set; } // boolean
    [Column("initial_evaluetion"), Nullable] public string InitialEvaluetion { get; set; } // text
    [Column("final_evaluetion"), Nullable] public string FinalEvaluetion { get; set; } // text
    [Column("start_time"), Nullable] public string StartTime { get; set; } // character varying(45)

    public bool HasInvoice()
    {
      return InvoiceId != null;
    }

    public override Guid SaveToDB()
    {
      using (var db = new Db.PhisioDB())
      {
        if (Id != null && Guid.Empty != Id)
        {
          db.VisitsTreatments.Where(x => x.VisitId == Id).Delete();
          foreach (var visitTreatment in Treatmentsvisitidfkeys)
          {
            visitTreatment.VisitId = Id;
            db.Insert(visitTreatment);
          }

          db.Update(this);
        }
        else
        {
          Id = Guid.NewGuid();
          Id = Guid.Parse(db.InsertWithIdentity(this).ToString());
          if (Treatmentsvisitidfkeys != null)
            foreach (var visitTreatment in Treatmentsvisitidfkeys)
            {
              visitTreatment.Visit = this;
              visitTreatment.VisitId = Id;
              db.Insert(visitTreatment);
            }
        }
      }
      return Id;
    }

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

    /// <summary>
    /// visits_therapist_id_fkey
    /// </summary>
    [Association(ThisKey = "TherapistId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "visits_therapist_id_fkey", BackReferenceName = "Visitstherapistidfkeys")]
    public Therapist Therapist { get; set; }

    /// <summary>
    /// visits_treatments_visit_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "VisitId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<VisitsTreatment> Treatmentsvisitidfkeys { get; set; }

    #endregion
  }
}
