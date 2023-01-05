using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220713164500)]
    public class V20220713164500_US86067_V42 : Migration
    {
        private string namePathScript = "V20220713164500_US86067_V42";
        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("getmoneytransferbyid", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("getmoneytransferbyid", namePathScript));
        }
    }
}