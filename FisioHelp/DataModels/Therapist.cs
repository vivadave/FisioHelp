using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Threading.Tasks;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "therapists")]
  public partial class Therapist : BaseModel
  {
      [Column("address"), Nullable] public string Address { get; set; } // character varying(256)
      [Column("address_de"), Nullable] public string AddressDe { get; set; } // character varying(256)
      [Column("full_name"), NotNull] public string FullName { get; set; } // character varying(45)
      [Column("tax_number"), Nullable] public string TaxNumber { get; set; } // character varying(45)
      [Column("fiscal_code"), Nullable] public string FiscalCode { get; set; } // character varying(45)
      [Column("iban"), Nullable] public string Iban { get; set; } // character varying(45)
      [Column("postit"), Nullable] public string Postit { get; set; } // text
      [Column("invoices_folder"), Nullable] public string InvoicesFolder { get; set; } // text
      [Column("privacy_folder"), Nullable] public string PrivacyFolder { get; set; } // text
      [Column("email"), Nullable] public string Email { get; set; } // text

    public override Guid SaveToDB()
    {
      return Helper.DbManagement.SaveToDB(this);
    }

    #region Associations

    /// <summary>
    /// customers_therapist_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "TherapistId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
      public IEnumerable<Customer> Customerstherapistidfkeys { get; set; }

      /// <summary>
      /// invoices_therapist_id_fkey_BackReference
      /// </summary>
      [Association(ThisKey = "Id", OtherKey = "TherapistId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
      public IEnumerable<Invoice> Invoicestherapistidfkeys { get; set; }

      /// <summary>
      /// price_lists_therapist_id_fkey_BackReference
      /// </summary>
      [Association(ThisKey = "Id", OtherKey = "TherapistId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
      public IEnumerable<PriceList> Priceliststherapistidfkeys { get; set; }

      /// <summary>
      /// treatments_therapist_id_fkey_BackReference
      /// </summary>
      [Association(ThisKey = "Id", OtherKey = "TherapistId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
      public IEnumerable<Treatment> Treatmentstherapistidfkeys { get; set; }

      /// <summary>
      /// visits_therapist_id_fkey_BackReference
      /// </summary>
      [Association(ThisKey = "Id", OtherKey = "TherapistId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
      public IEnumerable<Visit> Visitstherapistidfkeys { get; set; }

      #endregion

    }
  }
