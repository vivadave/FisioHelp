using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

using NpgsqlTypes;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "treatments")]
  public partial class Treatment
  {
    [Column("id"), PrimaryKey, Identity] public int Id { get; set; } // integer
    [Column("description_de"), NotNull] public string DescriptionDe { get; set; } // text
    [Column("description_it"), NotNull] public string DescriptionIt { get; set; } // text

    #region Associations

    /// <summary>
    /// visits_treatments_treatment_id_fkey_BackReference
    /// </summary>
    [Association(ThisKey = "Id", OtherKey = "TreatmentId", CanBeNull = true, Relationship = Relationship.OneToMany, IsBackReference = true)]
    public IEnumerable<VisitsTreatment> Visitstreatmentidfkeys { get; set; }

    #endregion
  }
}
