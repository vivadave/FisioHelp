using System;
using LinqToDB.Mapping;
using NpgsqlTypes;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "recent_anamnesys")]
  public partial class RecentAnamnesy : BaseModel
  {
    [Column("main_disease_1"), Nullable] public string MainDisease1 { get; set; } // character varying(256)
    [Column("main_disease_2"), Nullable] public string MainDisease2 { get; set; } // character varying(256)
    [Column("main_disease_3"), Nullable] public string MainDisease3 { get; set; } // character varying(256)
    [Column("main_disease_4"), Nullable] public string MainDisease4 { get; set; } // character varying(256)
    [Column("main_disease_5"), Nullable] public string MainDisease5 { get; set; } // character varying(256)
    [Column("global_health"), Nullable] public string GlobalHealth { get; set; } // character varying(256)
    [Column("other_diseases"), Nullable] public string OtherDiseases { get; set; } // character varying(256)
    [Column("disease_in_life"), Nullable] public int? DiseaseInLife { get; set; } // integer
    [Column("disease_in_family"), Nullable] public int? DiseaseInFamily { get; set; } // integer
    [Column("disease_in_work"), Nullable] public int? DiseaseInWork { get; set; } // integer
    [Column("disease_in_social"), Nullable] public int? DiseaseInSocial { get; set; } // integer
    [Column("posture"), Nullable] public string Posture { get; set; } // character varying(256)
    [Column("medicine"), Nullable] public string Medicine { get; set; } // character varying(256)
    [Column("pre_treatment"), Nullable] public string PreTreatment { get; set; } // character varying(256)
    [Column("main_disease_intensity"), Nullable] public int? MainDiseaseIntensity { get; set; } // integer
    [Column("main_disease_description"), Nullable] public string MainDiseaseDescription { get; set; } // character varying(256)
    [Column("main_disease_date"), Nullable] public NpgsqlDate? MainDiseaseDate { get; set; } // date
    [Column("main_disease_modality"), Nullable] public string MainDiseaseModality { get; set; } // character varying(256)
    [Column("main_disease_course"), Nullable] public string MainDiseaseCourse { get; set; } // character varying(256)
    [Column("main_disease_factor_plus"), Nullable] public string MainDiseaseFactorPlus { get; set; } // character varying(256)
    [Column("main_disease_factor_minor"), Nullable] public string MainDiseaseFactorMinor { get; set; } // character varying(256)
    [Column("main_disease_nervous_system"), Nullable] public string MainDiseaseNervousSystem { get; set; } // character varying(256)
    [Column("main_disease_symptoms_24"), Nullable] public string MainDiseaseSymptoms24 { get; set; } // character varying(256)
    [Column("images_diagnostics"), Nullable] public string ImagesDiagnostics { get; set; } // character varying(256)
    [Column("customer_id"), NotNull] public Guid CustomerId { get; set; } // uuid

    public override Guid SaveToDB()
    {
      return Helper.DbManagement.SaveToDB(this);
    }

    #region Associations

    /// <summary>
    /// recent_anamnesys_customer_id_fkey
    /// </summary>
    [Association(ThisKey = "CustomerId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "recent_anamnesys_customer_id_fkey", BackReferenceName = "Recentanamnesyscustomeridfkeys")]
    public Customer Customer { get; set; }

    #endregion
  }
}
