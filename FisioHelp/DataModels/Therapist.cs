using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Threading.Tasks;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "therapists")]
  public partial class Therapist
  {
    [Column("id"), PrimaryKey, Identity] public int Id { get; set; } // integer
    [Column("full_name"), Nullable] public string FullName { get; set; } // character varying(45)
    [Column("address"), Nullable] public string Address { get; set; } // character varying(255)
    [Column("email"), Nullable] public string Email { get; set; } // character varying(45)
    [Column("tax_number"), Nullable] public string Vat { get; set; } // character varying(45)
    [Column("fiscal_code"), Nullable] public string Fiscalcode { get; set; } // character varying(45)
    [Column("iban"), Nullable] public string Iban { get; set; } // character varying(45)
    [Column("postit"), Nullable] public string Postit { get; set; } // character varying(45)
    [Column("invoices_folder"), Nullable] public string InvoicesFolder { get; set; } // character varying(45)
    [Column("privacy_folder"), Nullable] public string PrivacyFolder { get; set; } // character varying(45)


  }
}
