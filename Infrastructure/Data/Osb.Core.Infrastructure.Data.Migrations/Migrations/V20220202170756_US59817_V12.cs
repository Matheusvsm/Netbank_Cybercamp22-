using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220202170756)]
    public class V20220202170756_US59817_V12 : Migration
    {
        private string namePathScript = "V20220202170756_US59817_V12";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertActivateCard", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertActivateCard", namePathScript));
        }
    }
}