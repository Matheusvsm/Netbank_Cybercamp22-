using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220215101400)]
    public class V20220215101400_US59345_V16 : Migration
    {
        private string namePathScript = "V20220215101400_US59345_V16";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByLoginAndCompanyId", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByLoginAndCompanyId", namePathScript));
        }
    }
}