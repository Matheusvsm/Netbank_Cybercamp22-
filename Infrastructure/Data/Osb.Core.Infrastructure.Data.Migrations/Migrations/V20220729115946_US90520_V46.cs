using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220729115946)]
    public class V20220729115946_US90520_V46 : Migration
    {
        private string namePathScript = "V20220729115946_US90520_V46";
        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("getfavoredbyaccountid", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("updatefavored", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("getfavoredbyaccountid", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("updatefavored", namePathScript));
        }
    }
}