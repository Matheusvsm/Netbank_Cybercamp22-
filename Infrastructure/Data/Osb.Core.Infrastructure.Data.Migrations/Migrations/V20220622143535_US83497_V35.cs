using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220622143535)]
    public class V20220622143535_US83497_V35 : Migration
    {
        private string namePathScript = "V20220622143535_US83497_V35";

        public override void Up()
        {
            Alter.Table("User")
                .AddColumn("AcceptedTerms")
                .AsBoolean()
                .NotNullable()
                .WithDefaultValue(false);

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLoginAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUser", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLogin", namePathScript));
        }

        public override void Down()
        {
            Delete.Column("AcceptedTerms").FromTable("User");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByLoginAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUser", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByLogin", namePathScript));
        }
    }
}