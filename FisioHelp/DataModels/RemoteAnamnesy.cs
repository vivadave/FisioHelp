using System;
using LinqToDB.Mapping;
namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "remote_anamnesys")]
  public partial class RemoteAnamnesy : BaseModel
  {
    [Column("phisical_disease"), Nullable] public string PhisicalDisease { get; set; } // character varying(256)
    [Column("psychic_disease"), Nullable] public string PsychicDisease { get; set; } // character varying(256)
    [Column("surgery"), Nullable] public string Surgery { get; set; } // character varying(256)
    [Column("anesthesias"), Nullable] public string Anesthesias { get; set; } // character varying(256)
    [Column("pregnancy"), Nullable] public string Pregnancy { get; set; } // character varying(256)
    [Column("traumas"), Nullable] public string Traumas { get; set; } // character varying(256)
    [Column("recent_episodes"), Nullable] public string RecentEpisodes { get; set; } // character varying(256)
    [Column("recent_treatments"), Nullable] public string RecentTreatments { get; set; } // character varying(256)
    [Column("medicines"), Nullable] public string Medicines { get; set; } // character varying(256)
    [Column("other"), Nullable] public string Other { get; set; } // character varying(256)
    [Column("customer_id"), NotNull] public Guid CustomerId { get; set; } // uuid

    public override Guid SaveToDB()
    {
      return Helper.DbManagement.SaveToDB(this);
    }

    #region Associations

    /// <summary>
    /// remote_anamnesys_customer_id_fkey
    /// </summary>
    [Association(ThisKey = "CustomerId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "remote_anamnesys_customer_id_fkey", BackReferenceName = "Remoteanamnesyscustomeridfkeys")]
    public Customer Customer { get; set; }

    #endregion
  }
}
