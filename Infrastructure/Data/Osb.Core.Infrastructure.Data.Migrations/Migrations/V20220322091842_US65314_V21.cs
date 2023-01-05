using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220322091842)]
    public class V20220322091842_US65314_V21 : Migration
    {
        private string namePathScript = "V20220322091842_US65314_V21";

        public override void Up()
        {

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLoginAndCompanyId", namePathScript));

        }

        public override void Down()
        {

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByLoginAndCompanyId", namePathScript));
        }
    }
}