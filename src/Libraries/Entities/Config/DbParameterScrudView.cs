using PetaPoco;
using System;

namespace MixERP.Net.Entities.Config
{
    [PrimaryKey("", autoIncrement = false)]
    [TableName("config.db_parameter_scrud_view")]
    [ExplicitColumns]
    public sealed class DbParameterScrudView : PetaPocoDB.Record<DbParameterScrudView>, IPoco
    {
        [Column("key")]
        [ColumnDbType("text", 0, true, "")]
        public string Key { get; set; }

        [Column("value")]
        [ColumnDbType("text", 0, true, "")]
        public string Value { get; set; }
    }
}