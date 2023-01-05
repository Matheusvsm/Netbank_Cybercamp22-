using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220705092842)]
    public class V20220705092842_HF95848_V37 : Migration
    {
        private string namePathScript = "V20220705092842_HF95848_V37";
        public override void Up()
        {
            Create.Table("WebhookAuthentication")
                .WithColumn("WebhookAuthenticationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("Username").AsString().NotNullable()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("Salt").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("WebhookAuthentication").ForeignColumn("CompanyId")
                .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                .FromTable("WebhookAuthentication").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("WebhookAuthentication").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetWebhookAuthenticationByCompanyId", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetWebhookAuthenticationByCompanyId", namePathScript));

            Delete.Table("WebhookAuthentication");
        }
    }
}