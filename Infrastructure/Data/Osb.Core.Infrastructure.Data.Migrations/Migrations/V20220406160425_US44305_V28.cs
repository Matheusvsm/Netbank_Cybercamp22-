using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220406160425)]
    public class V20220406160425_US44305_V28 : Migration
    {
        private string namePathScript = "V20220406160425_US44305_V28";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInputLog", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertInputLog", namePathScript));
        }
    }
}