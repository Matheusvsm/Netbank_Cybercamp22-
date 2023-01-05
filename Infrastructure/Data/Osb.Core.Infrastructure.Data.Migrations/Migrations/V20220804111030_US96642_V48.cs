using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220804111030)]
    public class V20220804111030_US96642_V48 : Migration
    {
        private string namePathScript = "V20220804111030_US96642_V48";
        public override void Up()
        {
            Alter.Table("PushNotification")
                    .AlterColumn("OperationId")
                    .AsInt64()
                    .Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUsersByAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBySpbAccountAndTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdatePushNotification", namePathScript));
        }

        public override void Down()
        {
            Alter.Table("PushNotification")
                   .AlterColumn("OperationId")
                   .AsInt64()
                   .NotNullable();

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUsersByAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBySpbAccountAndTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdatePushNotification", namePathScript));
        }
    }
}