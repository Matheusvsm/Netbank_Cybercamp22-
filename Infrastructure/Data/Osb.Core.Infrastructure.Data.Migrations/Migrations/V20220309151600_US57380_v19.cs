using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220309151600)]
    public class V20220309151600_US57380_v19 : Migration
    {
        private string namePathScript = "V20220309151600_US57380_v19";

        public override void Up()
        {
            Alter.Table("UserAccount")
                .AddColumn("IsFixedAccount")
                .AsBoolean()
                .NotNullable()
                .WithDefaultValue(false);

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserAccountFixing", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountListByLoginAndCompanyId", namePathScript));
        }

        public override void Down()
        {
            Delete.Column("IsFixedAccount").FromTable("UserAccount");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserAccountFixing", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountListByLoginAndCompanyId", namePathScript));
        }
    }
}