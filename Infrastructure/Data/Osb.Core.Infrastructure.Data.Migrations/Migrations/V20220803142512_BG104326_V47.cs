using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220803142512)]
    public class V20220803142512_BG104326_V47 : Migration
    {
        private string namePathScript = "V20220803142512_BG104326_V47";
        public override void Up()
        {
            Alter.Table("PixOut")
                            .AddColumn("SearchProtocol")
                            .AsInt64()
                            .Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertPixOut", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPixOutByStatus", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertPixOut", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPixOutByStatus", namePathScript));

            Delete.Column("SearchProtocol").FromTable("PixOut");
        }
    }
}