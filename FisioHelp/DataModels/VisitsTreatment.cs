using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

using NpgsqlTypes;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "visits_treatments")]
  public partial class VisitsTreatment
  {
    [Column("visit_id"), PrimaryKey(1), NotNull] public int VisitId { get; set; } // integer
    [Column("treatment_id"), PrimaryKey(2), NotNull] public int TreatmentId { get; set; } // integer

    #region Associations

    /// <summary>
    /// visits_treatments_treatment_id_fkey
    /// </summary>
    [Association(ThisKey = "TreatmentId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "visits_treatments_treatment_id_fkey", BackReferenceName = "Visitstreatmentidfkeys")]
    public Treatment Treatment { get; set; }

    /// <summary>
    /// visits_treatments_visit_id_fkey
    /// </summary>
    [Association(ThisKey = "VisitId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "visits_treatments_visit_id_fkey", BackReferenceName = "Treatmentsvisitidfkeys")]
    public Visit Visit { get; set; }

    #endregion
  }
}
