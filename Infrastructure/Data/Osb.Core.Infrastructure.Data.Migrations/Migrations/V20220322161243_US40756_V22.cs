using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220322161243)]
    public class V20220322161243_US40756_V22 : Migration
    {
        private string namePathScript = "V20220322161243_US40756_V22";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCompanyAuthenticationByUsername", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCompanyAuthenticationByUsername", namePathScript));
        }
    }
}