using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

using NpgsqlTypes;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "treatments")]
  public partial class Treatment : BaseModel
  {
    [Column("therapist_id"), NotNull] public Guid TherapistId { get; set; } // uuid
    [Column("description_de"), NotNull] public string DescriptionDe { get; set; } // text
    [Column("description_it"), NotNull] public string DescriptionIt { get; set; } // text

    public override Guid SaveToDB()
    {
      return Helper.DbManagement.SaveToDB(this);
    }

    #region Associations

    /// <summary>
    /// treatments_therapist_id_fkey
    /// </summary>
    [Association(ThisKey = "TherapistId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "treatments_therapist_id_fkey", BackReferenceName = "Treatmentstherapistidfkeys")]
    public Therapist Therapist { get; set; }

    /// <summary>
    /// visits_treatments_treatment_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "TreatmentId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<VisitsTreatment> Visitstreatmentidfkeys { get; set; }

    #endregion
  }
}
