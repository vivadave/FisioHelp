using System;
using LinqToDB.Mapping;

namespace FisioHelp.DataModels
{
  [Table(Schema = "public", Name = "stomatognathic_test")]
  public partial class StomatognathicTest
  {
    [Column("id"), PrimaryKey, Identity] public int Id { get; set; } // integer
    [Column("lastissimus_dors_1r"), Nullable] public int? LastissimusDors1r { get; set; } // integer
    [Column("lastissimus_dors_1l"), Nullable] public int? LastissimusDors1l { get; set; } // integer
    [Column("lastissimus_dors_2r"), Nullable] public int? LastissimusDors2r { get; set; } // integer
    [Column("lastissimus_dors_2l"), Nullable] public int? LastissimusDors2l { get; set; } // integer
    [Column("lastissimus_dors_3r"), Nullable] public int? LastissimusDors3r { get; set; } // integer
    [Column("lastissimus_dors_3l"), Nullable] public int? LastissimusDors3l { get; set; } // integer
    [Column("lastissimus_dors_4r"), Nullable] public int? LastissimusDors4r { get; set; } // integer
    [Column("lastissimus_dors_4l"), Nullable] public int? LastissimusDors4l { get; set; } // integer
    [Column("lastissimus_dors_5r"), Nullable] public int? LastissimusDors5r { get; set; } // integer
    [Column("lastissimus_dors_5l"), Nullable] public int? LastissimusDors5l { get; set; } // integer
    [Column("neck_flex_r"), Nullable] public int? NeckFlexR { get; set; } // integer
    [Column("neck_flex_l"), Nullable] public int? NeckFlexL { get; set; } // integer
    [Column("neck_extflex_r"), Nullable] public int? NeckExtflexR { get; set; } // integer
    [Column("neck_extflex_l"), Nullable] public int? NeckExtflexL { get; set; } // integer
    [Column("sterncleid_r"), Nullable] public int? SterncleidR { get; set; } // integer
    [Column("sterncleid_l"), Nullable] public int? SterncleidL { get; set; } // integer
    [Column("rectfem_r"), Nullable] public int? RectfemR { get; set; } // integer
    [Column("rectfem_l"), Nullable] public int? RectfemL { get; set; } // integer
    [Column("pirif_r"), Nullable] public int? PirifR { get; set; } // integer
    [Column("pirif_l"), Nullable] public int? PirifL { get; set; } // integer
    [Column("iliopsoas_r"), Nullable] public int? IliopsoasR { get; set; } // integer
    [Column("iliopsoas_l"), Nullable] public int? IliopsoasL { get; set; } // integer
    [Column("cat1_err"), Nullable] public bool? Cat1Err { get; set; } // boolean
    [Column("cat1_err_pos"), Nullable] public string Cat1ErrPos { get; set; } // character varying(64)
    [Column("cat2_err_r"), Nullable] public int? Cat2ErrR { get; set; } // integer
    [Column("cat2_err_l"), Nullable] public int? Cat2ErrL { get; set; } // integer
    [Column("inicator"), Nullable] public string Inicator { get; set; } // character varying(64)
    [Column("tl_okziput"), Nullable] public int? TlOkziput { get; set; } // integer
    [Column("double_tl_cat"), Nullable] public int? DoubleTlCat { get; set; } // integer
    [Column("double_tl_okz"), Nullable] public int? DoubleTlOkz { get; set; } // integer
    [Column("ruheschwebe_r"), Nullable] public string RuheschwebeR { get; set; } // character varying(64)
    [Column("ruheschwebe_l"), Nullable] public string RuheschwebeL { get; set; } // character varying(64)
    [Column("fester_r"), Nullable] public string FesterR { get; set; } // character varying(64)
    [Column("fester_l"), Nullable] public string FesterL { get; set; } // character varying(64)
    [Column("weite_off_r"), Nullable] public string WeiteOffR { get; set; } // character varying(64)
    [Column("weite_off_l"), Nullable] public string WeiteOffL { get; set; } // character varying(64)
    [Column("priener_abduck_ein"), Nullable] public bool? PrienerAbduckEin { get; set; } // boolean
    [Column("priener_abduck_ander"), Nullable] public bool? PrienerAbduckAnder { get; set; } // boolean
    [Column("torax_rotat"), Nullable] public bool? ToraxRotat { get; set; } // boolean
    [Column("meersemann"), Nullable] public bool? Meersemann { get; set; } // boolean
    [Column("m_klefergelenk_lat_r"), Nullable] public int? MKlefergelenkLatR { get; set; } // integer
    [Column("m_klefergelenk_lat_l"), Nullable] public int? MKlefergelenkLatL { get; set; } // integer
    [Column("m_klefergelenk_dor_r"), Nullable] public int? MKlefergelenkDorR { get; set; } // integer
    [Column("m_klefergelenk_dor_l"), Nullable] public int? MKlefergelenkDorL { get; set; } // integer
    [Column("m_klefergelenk_kompr_r"), Nullable] public int? MKlefergelenkKomprR { get; set; } // integer
    [Column("m_klefergelenk_kompr_l"), Nullable] public int? MKlefergelenkKomprL { get; set; } // integer
    [Column("m_masseter_prof_r"), Nullable] public int? MMasseterProfR { get; set; } // integer
    [Column("m_masseter_prof_l"), Nullable] public int? MMasseterProfL { get; set; } // integer
    [Column("m_masseter_sup_r"), Nullable] public int? MMasseterSupR { get; set; } // integer
    [Column("m_masseter_sup_l"), Nullable] public int? MMasseterSupL { get; set; } // integer
    [Column("m_temporalis_ant_r"), Nullable] public int? MTemporalisAntR { get; set; } // integer
    [Column("m_temporalis_ant_l"), Nullable] public int? MTemporalisAntL { get; set; } // integer
    [Column("m_temporalis_post_r"), Nullable] public int? MTemporalisPostR { get; set; } // integer
    [Column("m_temporalis_post_l"), Nullable] public int? MTemporalisPostL { get; set; } // integer
    [Column("m_suboccip_r"), Nullable] public int? MSuboccipR { get; set; } // integer
    [Column("m_suboccip_l"), Nullable] public int? MSuboccipL { get; set; } // integer
    [Column("m_trapezius_r"), Nullable] public int? MTrapeziusR { get; set; } // integer
    [Column("m_trapezius_l"), Nullable] public int? MTrapeziusL { get; set; } // integer
    [Column("m_sterncleid_r"), Nullable] public int? MSterncleidR { get; set; } // integer
    [Column("m_sterncleid_l"), Nullable] public int? MSterncleidL { get; set; } // integer
    [Column("m_digastr_r"), Nullable] public int? MDigastrR { get; set; } // integer
    [Column("m_digastr_l"), Nullable] public int? MDigastrL { get; set; } // integer
    [Column("m_temporaliss_r"), Nullable] public int? MTemporalissR { get; set; } // integer
    [Column("m_temporaliss_l"), Nullable] public int? MTemporalissL { get; set; } // integer
    [Column("m_pterygoid_lat_r"), Nullable] public int? MPterygoidLatR { get; set; } // integer
    [Column("m_pterygoid_lat_l"), Nullable] public int? MPterygoidLatL { get; set; } // integer
    [Column("m_pterygoid_med_r"), Nullable] public int? MPterygoidMedR { get; set; } // integer
    [Column("m_pterygoid_med_l"), Nullable] public int? MPterygoidMedL { get; set; } // integer
    [Column("m_scaleni_r"), Nullable] public int? MScaleniR { get; set; } // integer
    [Column("m_scaleni_l"), Nullable] public int? MScaleniL { get; set; } // integer
    [Column("c0_r"), Nullable] public int? C0R { get; set; } // integer
    [Column("c0_l"), Nullable] public int? C0L { get; set; } // integer
    [Column("c0_d"), Nullable] public int? C0D { get; set; } // integer
    [Column("c1_r"), Nullable] public int? C1R { get; set; } // integer
    [Column("c1_l"), Nullable] public int? C1L { get; set; } // integer
    [Column("c1_d"), Nullable] public int? C1D { get; set; } // integer
    [Column("c2_r"), Nullable] public int? C2R { get; set; } // integer
    [Column("c2_l"), Nullable] public int? C2L { get; set; } // integer
    [Column("c2_d"), Nullable] public int? C2D { get; set; } // integer
    [Column("c3_r"), Nullable] public int? C3R { get; set; } // integer
    [Column("c3_l"), Nullable] public int? C3L { get; set; } // integer
    [Column("c3_d"), Nullable] public int? C3D { get; set; } // integer
    [Column("c4_r"), Nullable] public int? C4R { get; set; } // integer
    [Column("c4_l"), Nullable] public int? C4L { get; set; } // integer
    [Column("c4_d"), Nullable] public int? C4D { get; set; } // integer
    [Column("c5_r"), Nullable] public int? C5R { get; set; } // integer
    [Column("c5_l"), Nullable] public int? C5L { get; set; } // integer
    [Column("c5_d"), Nullable] public int? C5D { get; set; } // integer
    [Column("g_r"), Nullable] public int? GR { get; set; } // integer
    [Column("g_l"), Nullable] public int? GL { get; set; } // integer
    [Column("g_d"), Nullable] public int? GD { get; set; } // integer
    [Column("t1_r"), Nullable] public int? T1R { get; set; } // integer
    [Column("t1_l"), Nullable] public int? T1L { get; set; } // integer
    [Column("t1_d"), Nullable] public int? T1D { get; set; } // integer
    [Column("t2_r"), Nullable] public int? T2R { get; set; } // integer
    [Column("t2_l"), Nullable] public int? T2L { get; set; } // integer
    [Column("t2_d"), Nullable] public int? T2D { get; set; } // integer
    [Column("customer_id"), NotNull] public int CustomerId { get; set; } // integer

    #region Associations

    /// <summary>
    /// stomatognathic_test_customer_id_fkey
    /// </summary>
    [Association(ThisKey = "CustomerId", OtherKey = "Id", CanBeNull = false, Relationship = Relationship.ManyToOne, KeyName = "stomatognathic_test_customer_id_fkey", BackReferenceName = "Stomatognathictestcustomeridfkeys")]
    public Customer Customer { get; set; }

    #endregion
  }
}
