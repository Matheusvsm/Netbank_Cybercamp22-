using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220713110912)]
    public class V20220713110912_US98570_V41 : Migration
    {
        private string namePathScript = "V20220713110912_US98570_V41";
        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetOperationByOperationIdAndOperationType", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetOperationByOperationIdAndOperationType", namePathScript));
        }
    }
}