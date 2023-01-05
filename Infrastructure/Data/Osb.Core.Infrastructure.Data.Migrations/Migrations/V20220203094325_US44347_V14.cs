using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220203094325)]
    public class V20220203094325_US44347_V14 : Migration
    {
        private string namePathScript = "V20220203094325_US44347_V14";
        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserCredential", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserCredential", namePathScript));
        }
    }
}
