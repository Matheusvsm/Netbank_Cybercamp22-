using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220707115814)]
    public class V20220707115814_US84184_V38 : Migration
    {
        private string namePathScript = "V20220707115814_US84184_V38";

        public override void Up()
        {
            Alter.Table("TopUp").AddColumn("IsRecurrent").AsBoolean().NotNullable().WithDefaultValue("false");
            Alter.Table("TopUp").AddColumn("PeriodicRepetition").AsInt32().Nullable();
            Alter.Table("TopUp").AddColumn("TopUpDate").AsDateTime().Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertTopUp", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpByExternalIdentifierAndProductKey", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpListByStatusAndDate", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateTopUp", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpPeriodicList", namePathScript));
            
        }

        public override void Down()
        {
            Delete.Column("IsRecurrent").FromTable("TopUp");
            Delete.Column("PeriodicRepetition").FromTable("TopUp");
            Delete.Column("TopUpDate").FromTable("TopUp");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertTopUp", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpByExternalIdentifierAndProductKey", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpListByStatusAndDate", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateTopUp", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpPeriodicList", namePathScript));
           
        }
    }
}