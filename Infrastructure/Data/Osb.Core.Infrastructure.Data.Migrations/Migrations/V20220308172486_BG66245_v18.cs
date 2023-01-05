using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220308172486)]

    public class V20220308172486_BG66245_v18 : Migration
    {
        private string namePathScript = "V20220308172486_BG66245_v18";

        public override void Up()
        {
            Delete.Column("SubAccountId").FromTable("Account");

            Alter.Table("SubAccount").AddColumn("AccountId").AsInt64().NotNullable().WithDefaultValue(1);

            Create.ForeignKey()
                .FromTable("SubAccount").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByLoginAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByTaxIdAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertSubAccount", namePathScript));
        }

        public override void Down()
        {
            Delete.Column("AccountId").FromTable("SubAccount");

            Alter.Table("Account").AddColumn("SubAccountId").AsInt64().Nullable();

            Create.ForeignKey()
                .FromTable("Account").ForeignColumn("SubAccountId")
                .ToTable("SubAccount").PrimaryColumn("SubAccountId");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByLoginAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByTaxIdAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAccount", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertSubAccount", namePathScript));
        }
    }
}