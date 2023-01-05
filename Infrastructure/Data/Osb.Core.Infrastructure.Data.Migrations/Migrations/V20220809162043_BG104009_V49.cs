using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220809162043)]
    public class V20220809162043_BG104009_V49 : Migration
    {
        private string namePathScript = "V20220809162043_BG104009_V49";
        public override void Up()
        {
            Delete.ForeignKey("FK_AuthorizationToken_AccountId_Account_AccountId").OnTable("AuthorizationToken");

            Delete.Column("AccountId").FromTable("AuthorizationToken");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserAuthorizationToken", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UnauthorizeTokensByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UnauthorizeTokensByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAuthorizationTokenByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAuthorizationTokenByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAuthorizationTokenByTaxId", namePathScript));
        }
        public override void Down()
        {
            Alter.Table("AuthorizationToken").AddColumn("AccountId").AsInt64().Nullable();

            Create.ForeignKey()
                .FromTable("AuthorizationToken").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserAuthorizationToken", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UnauthorizeTokensByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UnauthorizeTokensByUserIdAndAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAuthorizationTokenByUserIdAndAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAuthorizationTokenByTaxId", namePathScript));
        }
    }
}