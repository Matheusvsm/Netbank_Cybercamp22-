using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220809165400)]
    public class V20220809165400_US96639_V50 : Migration
    {
        private string namePathScript = "V20220809165400_US96639_V50";
        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("getpixoutbyexternalidentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("getpixoutbyid", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("getpixoutbyexternalidentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("getpixoutbyid", namePathScript));
        }
    }
}