using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220817111642)]
    public class V20220817111642_US100437_V54 : Migration
    {
        private string namePathScript = "V20220817111642_US100437_V54";

        public override void Up()
        {
            Alter.Table("BoletoPayment")
                .AddColumn("ResponseMessage")
                .AsString()
                .Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBoletoPayment", namePathScript));
        }

        public override void Down()
        {
            Delete.Column("ResponseMessage").FromTable("BoletoPayment");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBoletoPayment", namePathScript));
        }
    }
}