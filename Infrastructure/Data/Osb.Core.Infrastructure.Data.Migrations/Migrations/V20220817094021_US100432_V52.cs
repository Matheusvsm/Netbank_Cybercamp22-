using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220817094021)]
    public class V20220817094021_US100432_V52 : Migration
    {
        private string namePathScript = "V20220817094021_US100432_V52";
        public override void Up()
        {
            Alter.Table("MoneyTransfer").AddColumn("ResponseMessage").AsString().Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetMoneyTransferByStatus", namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateMoneyTransfer", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetMoneyTransferByStatus", namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateMoneyTransfer", namePathScript));

            Delete.Column("ResponseMessage").FromTable("MoneyTransfer");
        }
    }
}