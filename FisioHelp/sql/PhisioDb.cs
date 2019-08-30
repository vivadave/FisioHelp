using System;
using FisioHelp.DataModels;
using LinqToDB;
using LinqToDB.Mapping;
using System.Reflection;

using NpgsqlTypes;

namespace FisioHelp.Db
{
  public partial class PhisioDB : LinqToDB.Data.DataConnection
  {
    public ITable<Address> Addresses { get { return this.GetTable<Address>(); } }
    public ITable<Customer> Customers { get { return this.GetTable<Customer>(); } }
    public ITable<Invoice> Invoices { get { return this.GetTable<Invoice>(); } }
    public ITable<PriceList> PriceLists { get { return this.GetTable<PriceList>(); } }
    public ITable<Visit> Visits { get { return this.GetTable<Visit>(); } }

    partial void InitMappingSchema()
    {
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_control_checkpointResult > (tuple => new global::DataModels.pg_control_checkpointResult() { checkpoint_lsn = (object)tuple[0], redo_lsn = (object)tuple[1], redo_wal_file = (string)tuple[2], timeline_id = (int?)tuple[3], prev_timeline_id = (int?)tuple[4], full_page_writes = (bool?)tuple[5], next_xid = (string)tuple[6], next_oid = (int?)tuple[7], next_multixact_id = (int?)tuple[8], next_multi_offset = (int?)tuple[9], oldest_xid = (int?)tuple[10], oldest_xid_dbid = (int?)tuple[11], oldest_active_xid = (int?)tuple[12], oldest_multi_xid = (int?)tuple[13], oldest_multi_dbid = (int?)tuple[14], oldest_commit_ts_xid = (int?)tuple[15], newest_commit_ts_xid = (int?)tuple[16], checkpoint_time = (DateTimeOffset?)tuple[17] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_control_initResult>(tuple => new global::DataModels.pg_control_initResult() { max_data_alignment = (int?)tuple[0], database_block_size = (int?)tuple[1], blocks_per_segment = (int?)tuple[2], wal_block_size = (int?)tuple[3], bytes_per_wal_segment = (int?)tuple[4], max_identifier_length = (int?)tuple[5], max_index_columns = (int?)tuple[6], max_toast_chunk_size = (int?)tuple[7], large_object_chunk_size = (int?)tuple[8], float4_pass_by_value = (bool?)tuple[9], float8_pass_by_value = (bool?)tuple[10], data_page_checksum_version = (int?)tuple[11] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_control_recoveryResult>(tuple => new global::DataModels.pg_control_recoveryResult() { min_recovery_end_lsn = (object)tuple[0], min_recovery_end_timeline = (int?)tuple[1], backup_start_lsn = (object)tuple[2], backup_end_lsn = (object)tuple[3], end_of_backup_record_required = (bool?)tuple[4] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_control_systemResult>(tuple => new global::DataModels.pg_control_systemResult() { pg_control_version = (int?)tuple[0], catalog_version_no = (int?)tuple[1], system_identifier = (long?)tuple[2], pg_control_last_modified = (DateTimeOffset?)tuple[3] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_create_logical_replication_slotResult>(tuple => new global::DataModels.pg_create_logical_replication_slotResult() { slot_name = (string)tuple[0], lsn = (object)tuple[1] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_create_physical_replication_slotResult>(tuple => new global::DataModels.pg_create_physical_replication_slotResult() { slot_name = (string)tuple[0], lsn = (object)tuple[1] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_get_object_addressResult>(tuple => new global::DataModels.pg_get_object_addressResult() { classid = (int?)tuple[0], objid = (int?)tuple[1], objsubid = (int?)tuple[2] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_identify_objectResult>(tuple => new global::DataModels.pg_identify_objectResult() { type = (string)tuple[0], schema = (string)tuple[1], name = (string)tuple[2], identity = (string)tuple[3] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_identify_object_as_addressResult>(tuple => new global::DataModels.pg_identify_object_as_addressResult() { type = (string)tuple[0], object_names = (object)tuple[1], object_args = (object)tuple[2] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_last_committed_xactResult>(tuple => new global::DataModels.pg_last_committed_xactResult() { xid = (int?)tuple[0], timestamp = (DateTimeOffset?)tuple[1] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_replication_slot_advanceResult>(tuple => new global::DataModels.pg_replication_slot_advanceResult() { slot_name = (string)tuple[0], end_lsn = (object)tuple[1] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_sequence_parametersResult>(tuple => new global::DataModels.pg_sequence_parametersResult() { start_value = (long?)tuple[0], minimum_value = (long?)tuple[1], maximum_value = (long?)tuple[2], increment = (long?)tuple[3], cycle_option = (bool?)tuple[4], cache_size = (long?)tuple[5], data_type = (int?)tuple[6] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_stat_fileResult>(tuple => new global::DataModels.pg_stat_fileResult() { size = (long?)tuple[0], access = (DateTimeOffset?)tuple[1], modification = (DateTimeOffset?)tuple[2], change = (DateTimeOffset?)tuple[3], creation = (DateTimeOffset?)tuple[4], isdir = (bool?)tuple[5] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_stat_get_archiverResult>(tuple => new global::DataModels.pg_stat_get_archiverResult() { archived_count = (long?)tuple[0], last_archived_wal = (string)tuple[1], last_archived_time = (DateTimeOffset?)tuple[2], failed_count = (long?)tuple[3], last_failed_wal = (string)tuple[4], last_failed_time = (DateTimeOffset?)tuple[5], stats_reset = (DateTimeOffset?)tuple[6] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_stat_get_subscriptionResult>(tuple => new global::DataModels.pg_stat_get_subscriptionResult() { subid = (int?)tuple[0], relid = (int?)tuple[1], pid = (int?)tuple[2], received_lsn = (object)tuple[3], last_msg_send_time = (DateTimeOffset?)tuple[4], last_msg_receipt_time = (DateTimeOffset?)tuple[5], latest_end_lsn = (object)tuple[6], latest_end_time = (DateTimeOffset?)tuple[7] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_stat_get_wal_receiverResult>(tuple => new global::DataModels.pg_stat_get_wal_receiverResult() { pid = (int?)tuple[0], status = (string)tuple[1], receive_start_lsn = (object)tuple[2], receive_start_tli = (int?)tuple[3], received_lsn = (object)tuple[4], received_tli = (int?)tuple[5], last_msg_send_time = (DateTimeOffset?)tuple[6], last_msg_receipt_time = (DateTimeOffset?)tuple[7], latest_end_lsn = (object)tuple[8], latest_end_time = (DateTimeOffset?)tuple[9], slot_name = (string)tuple[10], sender_host = (string)tuple[11], sender_port = (int?)tuple[12], conninfo = (string)tuple[13] });
      MappingSchema.SetConvertExpression<object[], global::DataModels.pg_walfile_name_offsetResult>(tuple => new global::DataModels.pg_walfile_name_offsetResult() { file_name = (string)tuple[0], file_offset = (int?)tuple[1] });
    }

    public PhisioDB()
    {
      InitDataContext();
      InitMappingSchema();
    }

    public PhisioDB(string configuration)
      : base(configuration)
    {
      InitDataContext();
      InitMappingSchema();
    }

    partial void InitDataContext();
    partial void InitMappingSchema();

    #region Table Functions

    #region PgExpandarray

    [Sql.TableFunction(Schema = "information_schema", Name = "_pg_expandarray")]
    public ITable<PgExpandarrayResult> PgExpandarray(object par4)
    {
      return this.GetTable<PgExpandarrayResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par4);
    }

    public partial class PgExpandarrayResult
    {
      public int? x { get; set; }
      public int? n { get; set; }
    }

    #endregion

    #region Aclexplode

    [Sql.TableFunction(Schema = "pg_catalog", Name = "aclexplode")]
    public ITable<AclexplodeResult> Aclexplode(object acl)
    {
      return this.GetTable<AclexplodeResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        acl);
    }

    public partial class AclexplodeResult
    {
      public int? grantor { get; set; }
      public int? grantee { get; set; }
      public string privilege_type { get; set; }
      public bool? is_grantable { get; set; }
    }

    #endregion

    #region GenerateSeries

    [Sql.TableFunction(Schema = "pg_catalog", Name = "generate_series")]
    public ITable<GenerateSeriesResult> GenerateSeries(DateTimeOffset? par1916, DateTimeOffset? par1917, NpgsqlTimeSpan? par1918)
    {
      return this.GetTable<GenerateSeriesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par1916,
        par1917,
        par1918);
    }

    public partial class GenerateSeriesResult
    {
      public DateTimeOffset? generate_series { get; set; }
    }

    #endregion

    #region GenerateSubscripts

    [Sql.TableFunction(Schema = "pg_catalog", Name = "generate_subscripts")]
    public ITable<GenerateSubscriptsResult> GenerateSubscripts(object par1922, int? par1923)
    {
      return this.GetTable<GenerateSubscriptsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par1922,
        par1923);
    }

    public partial class GenerateSubscriptsResult
    {
      public int? generate_subscripts { get; set; }
    }

    #endregion

    #region JsonArrayElements

    [Sql.TableFunction(Schema = "pg_catalog", Name = "json_array_elements")]
    public ITable<JsonArrayElementsResult> JsonArrayElements(string from_json)
    {
      return this.GetTable<JsonArrayElementsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        from_json);
    }

    public partial class JsonArrayElementsResult
    {
      public string value { get; set; }
    }

    #endregion

    #region JsonArrayElementsText

    [Sql.TableFunction(Schema = "pg_catalog", Name = "json_array_elements_text")]
    public ITable<JsonArrayElementsTextResult> JsonArrayElementsText(string from_json)
    {
      return this.GetTable<JsonArrayElementsTextResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        from_json);
    }

    public partial class JsonArrayElementsTextResult
    {
      public string value { get; set; }
    }

    #endregion

    #region JsonEach

    [Sql.TableFunction(Schema = "pg_catalog", Name = "json_each")]
    public ITable<JsonEachResult> JsonEach(string from_json)
    {
      return this.GetTable<JsonEachResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        from_json);
    }

    public partial class JsonEachResult
    {
      public string key { get; set; }
      public string value { get; set; }
    }

    #endregion

    #region JsonEachText

    [Sql.TableFunction(Schema = "pg_catalog", Name = "json_each_text")]
    public ITable<JsonEachTextResult> JsonEachText(string from_json)
    {
      return this.GetTable<JsonEachTextResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        from_json);
    }

    public partial class JsonEachTextResult
    {
      public string key { get; set; }
      public string value { get; set; }
    }

    #endregion

    #region JsonObjectKeys

    [Sql.TableFunction(Schema = "pg_catalog", Name = "json_object_keys")]
    public ITable<JsonObjectKeysResult> JsonObjectKeys(string par3639)
    {
      return this.GetTable<JsonObjectKeysResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par3639);
    }

    public partial class JsonObjectKeysResult
    {
      public string json_object_keys { get; set; }
    }

    #endregion

    #region JsonPopulateRecordset

    [Sql.TableFunction(Schema = "pg_catalog", Name = "json_populate_recordset")]
    public ITable<JsonPopulateRecordsetResult> JsonPopulateRecordset(object @base, string from_json, bool? use_json_as_text)
    {
      return this.GetTable<JsonPopulateRecordsetResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        @base,
        from_json,
        use_json_as_text);
    }

    public partial class JsonPopulateRecordsetResult
    {
      public int? json_populate_recordset { get; set; }
    }

    #endregion

    #region JsonbArrayElements

    [Sql.TableFunction(Schema = "pg_catalog", Name = "jsonb_array_elements")]
    public ITable<JsonbArrayElementsResult> JsonbArrayElements(string from_json)
    {
      return this.GetTable<JsonbArrayElementsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        from_json);
    }

    public partial class JsonbArrayElementsResult
    {
      public string value { get; set; }
    }

    #endregion

    #region JsonbArrayElementsText

    [Sql.TableFunction(Schema = "pg_catalog", Name = "jsonb_array_elements_text")]
    public ITable<JsonbArrayElementsTextResult> JsonbArrayElementsText(string from_json)
    {
      return this.GetTable<JsonbArrayElementsTextResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        from_json);
    }

    public partial class JsonbArrayElementsTextResult
    {
      public string value { get; set; }
    }

    #endregion

    #region JsonbEach

    [Sql.TableFunction(Schema = "pg_catalog", Name = "jsonb_each")]
    public ITable<JsonbEachResult> JsonbEach(string from_json)
    {
      return this.GetTable<JsonbEachResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        from_json);
    }

    public partial class JsonbEachResult
    {
      public string key { get; set; }
      public string value { get; set; }
    }

    #endregion

    #region JsonbEachText

    [Sql.TableFunction(Schema = "pg_catalog", Name = "jsonb_each_text")]
    public ITable<JsonbEachTextResult> JsonbEachText(string from_json)
    {
      return this.GetTable<JsonbEachTextResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        from_json);
    }

    public partial class JsonbEachTextResult
    {
      public string key { get; set; }
      public string value { get; set; }
    }

    #endregion

    #region JsonbObjectKeys

    [Sql.TableFunction(Schema = "pg_catalog", Name = "jsonb_object_keys")]
    public ITable<JsonbObjectKeysResult> JsonbObjectKeys(string par3752)
    {
      return this.GetTable<JsonbObjectKeysResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par3752);
    }

    public partial class JsonbObjectKeysResult
    {
      public string jsonb_object_keys { get; set; }
    }

    #endregion

    #region JsonbPopulateRecordset

    [Sql.TableFunction(Schema = "pg_catalog", Name = "jsonb_populate_recordset")]
    public ITable<JsonbPopulateRecordsetResult> JsonbPopulateRecordset(object par3758, string par3759)
    {
      return this.GetTable<JsonbPopulateRecordsetResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par3758,
        par3759);
    }

    public partial class JsonbPopulateRecordsetResult
    {
      public int? jsonb_populate_recordset { get; set; }
    }

    #endregion

    #region PgAvailableExtensionVersions

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_available_extension_versions")]
    public ITable<PgAvailableExtensionVersionsResult> PgAvailableExtensionVersions()
    {
      return this.GetTable<PgAvailableExtensionVersionsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgAvailableExtensionVersionsResult
    {
      public string name { get; set; }
      public string version { get; set; }
      public bool? superuser { get; set; }
      public bool? relocatable { get; set; }
      public string schema { get; set; }
      public Array requires { get; set; }
      public string comment { get; set; }
    }

    #endregion

    #region PgAvailableExtensions

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_available_extensions")]
    public ITable<PgAvailableExtensionsResult> PgAvailableExtensions()
    {
      return this.GetTable<PgAvailableExtensionsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgAvailableExtensionsResult
    {
      public string name { get; set; }
      public string default_version { get; set; }
      public string comment { get; set; }
    }

    #endregion

    #region PgConfig

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_config")]
    public ITable<PgConfigResult> PgConfig()
    {
      return this.GetTable<PgConfigResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgConfigResult
    {
      public string name { get; set; }
      public string setting { get; set; }
    }

    #endregion

    #region PgCursor

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_cursor")]
    public ITable<PgCursorResult> PgCursor()
    {
      return this.GetTable<PgCursorResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgCursorResult
    {
      public string name { get; set; }
      public string statement { get; set; }
      public bool? is_holdable { get; set; }
      public bool? is_binary { get; set; }
      public bool? is_scrollable { get; set; }
      public DateTimeOffset? creation_time { get; set; }
    }

    #endregion

    #region PgEventTriggerDdlCommands

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_event_trigger_ddl_commands")]
    public ITable<PgEventTriggerDdlCommandsResult> PgEventTriggerDdlCommands()
    {
      return this.GetTable<PgEventTriggerDdlCommandsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgEventTriggerDdlCommandsResult
    {
      public int? classid { get; set; }
      public int? objid { get; set; }
      public int? objsubid { get; set; }
      public string command_tag { get; set; }
      public string object_type { get; set; }
      public string schema_name { get; set; }
      public string object_identity { get; set; }
      public bool? in_extension { get; set; }
      public object command { get; set; }
    }

    #endregion

    #region PgEventTriggerDroppedObjects

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_event_trigger_dropped_objects")]
    public ITable<PgEventTriggerDroppedObjectsResult> PgEventTriggerDroppedObjects()
    {
      return this.GetTable<PgEventTriggerDroppedObjectsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgEventTriggerDroppedObjectsResult
    {
      public int? classid { get; set; }
      public int? objid { get; set; }
      public int? objsubid { get; set; }
      public bool? original { get; set; }
      public bool? normal { get; set; }
      public bool? is_temporary { get; set; }
      public string object_type { get; set; }
      public string schema_name { get; set; }
      public string object_name { get; set; }
      public string object_identity { get; set; }
      public Array address_names { get; set; }
      public Array address_args { get; set; }
    }

    #endregion

    #region PgExtensionUpdatePaths

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_extension_update_paths")]
    public ITable<PgExtensionUpdatePathsResult> PgExtensionUpdatePaths(string name)
    {
      return this.GetTable<PgExtensionUpdatePathsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        name);
    }

    public partial class PgExtensionUpdatePathsResult
    {
      public string source { get; set; }
      public string target { get; set; }
      public string path { get; set; }
    }

    #endregion

    #region PgGetKeywords

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_get_keywords")]
    public ITable<PgGetKeywordsResult> PgGetKeywords()
    {
      return this.GetTable<PgGetKeywordsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgGetKeywordsResult
    {
      public string word { get; set; }
      public char? catcode { get; set; }
      public string catdesc { get; set; }
    }

    #endregion

    #region PgGetMultixactMembers

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_get_multixact_members")]
    public ITable<PgGetMultixactMembersResult> PgGetMultixactMembers(int? multixid)
    {
      return this.GetTable<PgGetMultixactMembersResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        multixid);
    }

    public partial class PgGetMultixactMembersResult
    {
      public int? xid { get; set; }
      public string mode { get; set; }
    }

    #endregion

    #region PgGetPublicationTables

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_get_publication_tables")]
    public ITable<PgGetPublicationTablesResult> PgGetPublicationTables(string pubname)
    {
      return this.GetTable<PgGetPublicationTablesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        pubname);
    }

    public partial class PgGetPublicationTablesResult
    {
      public int? relid { get; set; }
    }

    #endregion

    #region PgGetReplicationSlots

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_get_replication_slots")]
    public ITable<PgGetReplicationSlotsResult> PgGetReplicationSlots()
    {
      return this.GetTable<PgGetReplicationSlotsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgGetReplicationSlotsResult
    {
      public string slot_name { get; set; }
      public string plugin { get; set; }
      public string slot_type { get; set; }
      public int? datoid { get; set; }
      public bool? temporary { get; set; }
      public bool? active { get; set; }
      public int? active_pid { get; set; }
      public int? xmin { get; set; }
      public int? catalog_xmin { get; set; }
      public string restart_lsn { get; set; }
      public string confirmed_flush_lsn { get; set; }
    }

    #endregion

    #region PgHbaFileRules

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_hba_file_rules")]
    public ITable<PgHbaFileRulesResult> PgHbaFileRules()
    {
      return this.GetTable<PgHbaFileRulesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgHbaFileRulesResult
    {
      public int? line_number { get; set; }
      public string type { get; set; }
      public Array database { get; set; }
      public Array user_name { get; set; }
      public string address { get; set; }
      public string netmask { get; set; }
      public string auth_method { get; set; }
      public Array options { get; set; }
      public string error { get; set; }
    }

    #endregion

    #region PgListeningChannels

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_listening_channels")]
    public ITable<PgListeningChannelsResult> PgListeningChannels()
    {
      return this.GetTable<PgListeningChannelsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgListeningChannelsResult
    {
      public string pg_listening_channels { get; set; }
    }

    #endregion

    #region PgLockStatus

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_lock_status")]
    public ITable<PgLockStatusResult> PgLockStatus()
    {
      return this.GetTable<PgLockStatusResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgLockStatusResult
    {
      public string locktype { get; set; }
      public int? database { get; set; }
      public int? relation { get; set; }
      public int? page { get; set; }
      public short? tuple { get; set; }
      public string virtualxid { get; set; }
      public int? transactionid { get; set; }
      public int? classid { get; set; }
      public int? objid { get; set; }
      public short? objsubid { get; set; }
      public string virtualtransaction { get; set; }
      public int? pid { get; set; }
      public string mode { get; set; }
      public bool? granted { get; set; }
      public bool? fastpath { get; set; }
    }

    #endregion

    #region PgLogicalSlotGetBinaryChanges

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_logical_slot_get_binary_changes")]
    public ITable<PgLogicalSlotGetBinaryChangesResult> PgLogicalSlotGetBinaryChanges(string slot_name, object upto_lsn, int? upto_nchanges, object options)
    {
      return this.GetTable<PgLogicalSlotGetBinaryChangesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        slot_name,
        upto_lsn,
        upto_nchanges,
        options);
    }

    public partial class PgLogicalSlotGetBinaryChangesResult
    {
      public string lsn { get; set; }
      public int? xid { get; set; }
      public byte[] data { get; set; }
    }

    #endregion

    #region PgLogicalSlotGetChanges

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_logical_slot_get_changes")]
    public ITable<PgLogicalSlotGetChangesResult> PgLogicalSlotGetChanges(string slot_name, object upto_lsn, int? upto_nchanges, object options)
    {
      return this.GetTable<PgLogicalSlotGetChangesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        slot_name,
        upto_lsn,
        upto_nchanges,
        options);
    }

    public partial class PgLogicalSlotGetChangesResult
    {
      public string lsn { get; set; }
      public int? xid { get; set; }
      public string data { get; set; }
    }

    #endregion

    #region PgLogicalSlotPeekBinaryChanges

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_logical_slot_peek_binary_changes")]
    public ITable<PgLogicalSlotPeekBinaryChangesResult> PgLogicalSlotPeekBinaryChanges(string slot_name, object upto_lsn, int? upto_nchanges, object options)
    {
      return this.GetTable<PgLogicalSlotPeekBinaryChangesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        slot_name,
        upto_lsn,
        upto_nchanges,
        options);
    }

    public partial class PgLogicalSlotPeekBinaryChangesResult
    {
      public string lsn { get; set; }
      public int? xid { get; set; }
      public byte[] data { get; set; }
    }

    #endregion

    #region PgLogicalSlotPeekChanges

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_logical_slot_peek_changes")]
    public ITable<PgLogicalSlotPeekChangesResult> PgLogicalSlotPeekChanges(string slot_name, object upto_lsn, int? upto_nchanges, object options)
    {
      return this.GetTable<PgLogicalSlotPeekChangesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        slot_name,
        upto_lsn,
        upto_nchanges,
        options);
    }

    public partial class PgLogicalSlotPeekChangesResult
    {
      public string lsn { get; set; }
      public int? xid { get; set; }
      public string data { get; set; }
    }

    #endregion

    #region PgLsDir

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_ls_dir")]
    public ITable<PgLsDirResult> PgLsDir(string par5221, bool? par5222, bool? par5223)
    {
      return this.GetTable<PgLsDirResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par5221,
        par5222,
        par5223);
    }

    public partial class PgLsDirResult
    {
      public string pg_ls_dir { get; set; }
    }

    #endregion

    #region PgLsLogdir

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_ls_logdir")]
    public ITable<PgLsLogdirResult> PgLsLogdir()
    {
      return this.GetTable<PgLsLogdirResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgLsLogdirResult
    {
      public string name { get; set; }
      public long? size { get; set; }
      public DateTimeOffset? modification { get; set; }
    }

    #endregion

    #region PgLsWaldir

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_ls_waldir")]
    public ITable<PgLsWaldirResult> PgLsWaldir()
    {
      return this.GetTable<PgLsWaldirResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgLsWaldirResult
    {
      public string name { get; set; }
      public long? size { get; set; }
      public DateTimeOffset? modification { get; set; }
    }

    #endregion

    #region PgOptionsToTable

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_options_to_table")]
    public ITable<PgOptionsToTableResult> PgOptionsToTable(object options_array)
    {
      return this.GetTable<PgOptionsToTableResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        options_array);
    }

    public partial class PgOptionsToTableResult
    {
      public string option_name { get; set; }
      public string option_value { get; set; }
    }

    #endregion

    #region PgPreparedStatement

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_prepared_statement")]
    public ITable<PgPreparedStatementResult> PgPreparedStatement()
    {
      return this.GetTable<PgPreparedStatementResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgPreparedStatementResult
    {
      public string name { get; set; }
      public string statement { get; set; }
      public DateTimeOffset? prepare_time { get; set; }
      public Array parameter_types { get; set; }
      public bool? from_sql { get; set; }
    }

    #endregion

    #region PgPreparedXact

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_prepared_xact")]
    public ITable<PgPreparedXactResult> PgPreparedXact()
    {
      return this.GetTable<PgPreparedXactResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgPreparedXactResult
    {
      public int? transaction { get; set; }
      public string gid { get; set; }
      public DateTimeOffset? prepared { get; set; }
      public int? ownerid { get; set; }
      public int? dbid { get; set; }
    }

    #endregion

    #region PgShowAllFileSettings

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_show_all_file_settings")]
    public ITable<PgShowAllFileSettingsResult> PgShowAllFileSettings()
    {
      return this.GetTable<PgShowAllFileSettingsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgShowAllFileSettingsResult
    {
      public string sourcefile { get; set; }
      public int? sourceline { get; set; }
      public int? seqno { get; set; }
      public string name { get; set; }
      public string setting { get; set; }
      public bool? applied { get; set; }
      public string error { get; set; }
    }

    #endregion

    #region PgShowAllSettings

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_show_all_settings")]
    public ITable<PgShowAllSettingsResult> PgShowAllSettings()
    {
      return this.GetTable<PgShowAllSettingsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgShowAllSettingsResult
    {
      public string name { get; set; }
      public string setting { get; set; }
      public string unit { get; set; }
      public string category { get; set; }
      public string short_desc { get; set; }
      public string extra_desc { get; set; }
      public string context { get; set; }
      public string vartype { get; set; }
      public string source { get; set; }
      public string min_val { get; set; }
      public string max_val { get; set; }
      public Array enumvals { get; set; }
      public string boot_val { get; set; }
      public string reset_val { get; set; }
      public string sourcefile { get; set; }
      public int? sourceline { get; set; }
      public bool? pending_restart { get; set; }
    }

    #endregion

    #region PgShowReplicationOriginStatus

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_show_replication_origin_status")]
    public ITable<PgShowReplicationOriginStatusResult> PgShowReplicationOriginStatus()
    {
      return this.GetTable<PgShowReplicationOriginStatusResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgShowReplicationOriginStatusResult
    {
      public int? local_id { get; set; }
      public string external_id { get; set; }
      public string remote_lsn { get; set; }
      public string local_lsn { get; set; }
    }

    #endregion

    #region PgStatGetActivity

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_stat_get_activity")]
    public ITable<PgStatGetActivityResult> PgStatGetActivity(int? pid)
    {
      return this.GetTable<PgStatGetActivityResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        pid);
    }

    public partial class PgStatGetActivityResult
    {
      public int? datid { get; set; }
      public int? pid { get; set; }
      public int? usesysid { get; set; }
      public string application_name { get; set; }
      public string state { get; set; }
      public string query { get; set; }
      public string wait_event_type { get; set; }
      public string wait_event { get; set; }
      public DateTimeOffset? xact_start { get; set; }
      public DateTimeOffset? query_start { get; set; }
      public DateTimeOffset? backend_start { get; set; }
      public DateTimeOffset? state_change { get; set; }
      public NpgsqlInet? client_addr { get; set; }
      public string client_hostname { get; set; }
      public int? client_port { get; set; }
      public int? backend_xid { get; set; }
      public int? backend_xmin { get; set; }
      public string backend_type { get; set; }
      public bool? ssl { get; set; }
      public string sslversion { get; set; }
      public string sslcipher { get; set; }
      public int? sslbits { get; set; }
      public bool? sslcompression { get; set; }
      public string sslclientdn { get; set; }
    }

    #endregion

    #region PgStatGetBackendIdset

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_stat_get_backend_idset")]
    public ITable<PgStatGetBackendIdsetResult> PgStatGetBackendIdset()
    {
      return this.GetTable<PgStatGetBackendIdsetResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgStatGetBackendIdsetResult
    {
      public int? pg_stat_get_backend_idset { get; set; }
    }

    #endregion

    #region PgStatGetProgressInfo

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_stat_get_progress_info")]
    public ITable<PgStatGetProgressInfoResult> PgStatGetProgressInfo(string cmdtype)
    {
      return this.GetTable<PgStatGetProgressInfoResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        cmdtype);
    }

    public partial class PgStatGetProgressInfoResult
    {
      public int? pid { get; set; }
      public int? datid { get; set; }
      public int? relid { get; set; }
      public long? param1 { get; set; }
      public long? param2 { get; set; }
      public long? param3 { get; set; }
      public long? param4 { get; set; }
      public long? param5 { get; set; }
      public long? param6 { get; set; }
      public long? param7 { get; set; }
      public long? param8 { get; set; }
      public long? param9 { get; set; }
      public long? param10 { get; set; }
    }

    #endregion

    #region PgStatGetWalSenders

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_stat_get_wal_senders")]
    public ITable<PgStatGetWalSendersResult> PgStatGetWalSenders()
    {
      return this.GetTable<PgStatGetWalSendersResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgStatGetWalSendersResult
    {
      public int? pid { get; set; }
      public string state { get; set; }
      public string sent_lsn { get; set; }
      public string write_lsn { get; set; }
      public string flush_lsn { get; set; }
      public string replay_lsn { get; set; }
      public NpgsqlTimeSpan? write_lag { get; set; }
      public NpgsqlTimeSpan? flush_lag { get; set; }
      public NpgsqlTimeSpan? replay_lag { get; set; }
      public int? sync_priority { get; set; }
      public string sync_state { get; set; }
    }

    #endregion

    #region PgStopBackup

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_stop_backup")]
    public ITable<PgStopBackupResult> PgStopBackup(bool? exclusive, bool? wait_for_archive)
    {
      return this.GetTable<PgStopBackupResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        exclusive,
        wait_for_archive);
    }

    public partial class PgStopBackupResult
    {
      public string lsn { get; set; }
      public string labelfile { get; set; }
      public string spcmapfile { get; set; }
    }

    #endregion

    #region PgTablespaceDatabases

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_tablespace_databases")]
    public ITable<PgTablespaceDatabasesResult> PgTablespaceDatabases(int? par5520)
    {
      return this.GetTable<PgTablespaceDatabasesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par5520);
    }

    public partial class PgTablespaceDatabasesResult
    {
      public int? pg_tablespace_databases { get; set; }
    }

    #endregion

    #region PgTimezoneAbbrevs

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_timezone_abbrevs")]
    public ITable<PgTimezoneAbbrevsResult> PgTimezoneAbbrevs()
    {
      return this.GetTable<PgTimezoneAbbrevsResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgTimezoneAbbrevsResult
    {
      public string abbrev { get; set; }
      public NpgsqlTimeSpan? utc_offset { get; set; }
      public bool? is_dst { get; set; }
    }

    #endregion

    #region PgTimezoneNames

    [Sql.TableFunction(Schema = "pg_catalog", Name = "pg_timezone_names")]
    public ITable<PgTimezoneNamesResult> PgTimezoneNames()
    {
      return this.GetTable<PgTimezoneNamesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod());
    }

    public partial class PgTimezoneNamesResult
    {
      public string name { get; set; }
      public string abbrev { get; set; }
      public NpgsqlTimeSpan? utc_offset { get; set; }
      public bool? is_dst { get; set; }
    }

    #endregion

    #region RegexpMatches

    [Sql.TableFunction(Schema = "pg_catalog", Name = "regexp_matches")]
    public ITable<RegexpMatchesResult> RegexpMatches(string par6004, string par6005, string par6006)
    {
      return this.GetTable<RegexpMatchesResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par6004,
        par6005,
        par6006);
    }

    public partial class RegexpMatchesResult
    {
      public Array regexp_matches { get; set; }
    }

    #endregion

    #region RegexpSplitToTable

    [Sql.TableFunction(Schema = "pg_catalog", Name = "regexp_split_to_table")]
    public ITable<RegexpSplitToTableResult> RegexpSplitToTable(string par6025, string par6026, string par6027)
    {
      return this.GetTable<RegexpSplitToTableResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par6025,
        par6026,
        par6027);
    }

    public partial class RegexpSplitToTableResult
    {
      public string regexp_split_to_table { get; set; }
    }

    #endregion

    #region TsDebug

    [Sql.TableFunction(Schema = "pg_catalog", Name = "ts_debug")]
    public ITable<TsDebugResult> TsDebug(string document)
    {
      return this.GetTable<TsDebugResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        document);
    }

    public partial class TsDebugResult
    {
      public string alias { get; set; }
      public string description { get; set; }
      public string token { get; set; }
      public Array dictionaries { get; set; }
      public string dictionary { get; set; }
      public Array lexemes { get; set; }
    }

    #endregion

    #region TsParse

    [Sql.TableFunction(Schema = "pg_catalog", Name = "ts_parse")]
    public ITable<TsParseResult> TsParse(string parser_name, string txt)
    {
      return this.GetTable<TsParseResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        parser_name,
        txt);
    }

    public partial class TsParseResult
    {
      public int? tokid { get; set; }
      public string token { get; set; }
    }

    #endregion

    #region TsStat

    [Sql.TableFunction(Schema = "pg_catalog", Name = "ts_stat")]
    public ITable<TsStatResult> TsStat(string query, string weights)
    {
      return this.GetTable<TsStatResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        query,
        weights);
    }

    public partial class TsStatResult
    {
      public string word { get; set; }
      public int? ndoc { get; set; }
      public int? nentry { get; set; }
    }

    #endregion

    #region TsTokenType

    [Sql.TableFunction(Schema = "pg_catalog", Name = "ts_token_type")]
    public ITable<TsTokenTypeResult> TsTokenType(string parser_name)
    {
      return this.GetTable<TsTokenTypeResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        parser_name);
    }

    public partial class TsTokenTypeResult
    {
      public int? tokid { get; set; }
      public string alias { get; set; }
      public string description { get; set; }
    }

    #endregion

    #region TxidSnapshotXip

    [Sql.TableFunction(Schema = "pg_catalog", Name = "txid_snapshot_xip")]
    public ITable<TxidSnapshotXipResult> TxidSnapshotXip(object par7479)
    {
      return this.GetTable<TxidSnapshotXipResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        par7479);
    }

    public partial class TxidSnapshotXipResult
    {
      public long? txid_snapshot_xip { get; set; }
    }

    #endregion

    #region Unnest

    [Sql.TableFunction(Schema = "pg_catalog", Name = "unnest")]
    public ITable<UnnestResult> Unnest(object tsvector)
    {
      return this.GetTable<UnnestResult>(this, (MethodInfo)MethodBase.GetCurrentMethod(),
        tsvector);
    }

    public partial class UnnestResult
    {
      public string lexeme { get; set; }
      public Array positions { get; set; }
      public Array weights { get; set; }
    }

    #endregion

    #endregion
  }

}
