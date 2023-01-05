using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220322161842)]
    public class V20220322161842_US40756_V23 : Migration
    {
        private string namePathScript = "V20220322161842_US40756_V23";

        public override void Up()
        {
            Alter.Table("UserWebhook")
                .AddColumn("LockedUser")
                .AsBoolean()
                .NotNullable()
                .WithDefaultValue(false);

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserWebhook", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserWebhook", namePathScript));
            Delete.Column("LockedUser").FromTable("UserWebhook");
        }
    }
}