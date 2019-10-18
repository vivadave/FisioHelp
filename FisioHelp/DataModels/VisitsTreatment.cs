using System;
using System.Linq;
using LinqToDB.Mapping;
using LinqToDB;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "visits_treatments")]
  public partial class VisitsTreatment
  {
    [Column("visit_id"), PrimaryKey(1), NotNull] public Guid VisitId { get; set; } // uuid
    [Column("treatment_id"), PrimaryKey(2), NotNull] public Guid TreatmentId { get; set; } // uuid

    public void SaveToDB(Visit _visit)
    {
      using (var db = new Db.PhisioDB())
      {
        if (_visit.Id != null)
        {
          db.VisitsTreatments.Where(x => x.VisitId == _visit.Id).Delete();
          foreach (var visitTreatment in _visit.Treatmentsvisitidfkeys)
            db.Insert(visitTreatment);

          db.Update(_visit);
        }
        else
        {
          _visit.Id = Guid.Parse(db.InsertWithIdentity(_visit).ToString());
          if (_visit.Treatmentsvisitidfkeys != null)
            foreach (var visitTreatment in _visit.Treatmentsvisitidfkeys)
            {
              visitTreatment.Visit = _visit;
              visitTreatment.VisitId = _visit.Id;
              db.Insert(visitTreatment);
            }
        }
      }
    }

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
