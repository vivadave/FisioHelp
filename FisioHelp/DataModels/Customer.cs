using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using NpgsqlTypes;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "customers")]
  public partial class Customer : BaseModel
  {
    [Column("name"), Nullable] public string Name { get; set; } // character varying(45)
    [Column("surname"), NotNull] public string Surname { get; set; } // character varying(45)
    [Column("email"), Nullable] public string Email { get; set; } // character varying(45)
    [Column("vat"), Nullable] public string Vat { get; set; } // character varying(45)
    [Column("fiscalcode"), Nullable] public string Fiscalcode { get; set; } // character varying(45)
    [Column("tel1"), Nullable] public string Tel1 { get; set; } // character varying(45)
    [Column("tel2"), Nullable] public string Tel2 { get; set; } // character varying(45)
    [Column("address_id"), Nullable] public Guid? AddressId { get; set; } // uuid
    [Column("pricelist_id"), Nullable] public Guid? PricelistId { get; set; } // uuid
    [Column("therapist_id"), NotNull] public Guid TherapistId { get; set; } // uuid
    [Column("note"), Nullable] public string Note { get; set; } // text
    [Column("language"), Nullable] public string Language { get; set; } // character varying(45)
    [Column("privacy"), NotNull] public bool Privacy { get; set; } // boolean
    [Column("creation_date"), Nullable] public NpgsqlDate? CreationDate { get; set; } // date
    [Column("legal_representative"), Nullable] public string LegalRepresentative { get; set; }
    [Column("age"), Nullable] public int Age { get; set; }

    public string FullName
    {
      get { return $"{Name} {Surname}"; }
    }

    public override string ToString()
    {
      return FullName;
    }

    public override Guid SaveToDB()
    {
      return Helper.DbManagement.SaveToDB(this);
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
    /// recent_anamnesys_customer_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "CustomerId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<RecentAnamnesy> Recentanamnesyscustomeridfkeys { get; set; }

    /// <summary>
    /// remote_anamnesys_customer_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "CustomerId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<RemoteAnamnesy> Remoteanamnesyscustomeridfkeys { get; set; }

    /// <summary>
    /// stomatognathic_test_customer_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "CustomerId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<StomatognathicTest> Stomatognathictestcustomeridfkeys { get; set; }

    /// <summary>
    /// customers_therapist_id_fkey
    /// </summary>
    [Association(ThisKey = "TherapistId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "customers_therapist_id_fkey", BackReferenceName = "Customerstherapistidfkeys")]
    public Therapist Therapist { get; set; }

    /// <summary>
    /// visits_customer_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "CustomerId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<Visit> Visitscustomeridfkeys { get; set; }

    #endregion
  }
}
