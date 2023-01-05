using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220819103443)]
    public class V20220819103443_BG108955_V56 : Migration
    {
        private string namePathScript = "V20220819103443_BG108955_V56";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetFavoredByAccountIdAndOperationType", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetFavoredByAccountIdAndOperationType", namePathScript));
        }
    }
}