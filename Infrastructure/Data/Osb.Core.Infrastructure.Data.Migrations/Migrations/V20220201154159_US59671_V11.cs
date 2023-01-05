using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220201154159)]
    public class V20220201154159_US59671_V11 : Migration
    {
        private string namePathScript = "V20220201154159_US59671_V11";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByLogin", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByLogin", namePathScript));
        }
    }
}