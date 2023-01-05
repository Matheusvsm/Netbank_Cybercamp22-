using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220321113152)]
    public class V20220321113152_US61895_V20 : Migration
    {
        private string namePathScript = "V20220321113152_US61895_V20";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByPhoneNumberAndCompanyId", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByPhoneNumberAndCompanyId", namePathScript));
        }
    }
}