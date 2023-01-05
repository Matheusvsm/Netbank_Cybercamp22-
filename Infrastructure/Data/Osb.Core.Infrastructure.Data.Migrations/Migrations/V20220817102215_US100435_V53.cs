using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220817102215)]
    public class V20220817102215_US100435_V53 : Migration
    {
        private string namePathScript = "V20220817102215_US100435_V53";

        public override void Up()
        {
            Alter.Table("InternalTransfer")
                        .AddColumn("ResponseMessage")
                        .AsString()
                        .Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateInternalTransfer", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateInternalTransfer", namePathScript));

            Delete.Column("ResponseMessage").FromTable("InternalTransfer");
        }
    }
}