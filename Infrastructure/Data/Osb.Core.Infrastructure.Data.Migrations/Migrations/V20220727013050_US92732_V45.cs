using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220727013050)]
    public class V20220727013050_US92732_V45 : Migration
    {
        private string namePathScript = "V20220727013050_US92732_V45";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPixKeyListByStatus", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPixKeyListByStatus", namePathScript));
        }
    }

}