using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220203093310)]
    public class V20220203093310_US54138_V13 : Migration
    {
        private string namePathScript = "V20220203093310_US54138_V13";

        public override void Up()
        {
            Alter.Table("User")
                .AddColumn("IsFirstAccess")
                .AsBoolean()
                .NotNullable()
                .WithDefaultValue(false);

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUser", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUser", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByLogin", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserById", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByLogin", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUser", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUser", namePathScript));
            Delete.Column("IsFirstAccess").FromTable("User");
        }
    }
}
