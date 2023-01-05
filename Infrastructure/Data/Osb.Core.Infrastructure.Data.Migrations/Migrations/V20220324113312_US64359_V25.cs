using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220324113312)]
    public class V20220324113312_US64359_V25 : Migration
    {
        private string namePathScript = "V20220324113312_US64359_V25";

        public override void Up()
        {
            Create.Table("SmsNotification")
                .WithColumn("SmsNotificationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("PhoneTo").AsString(50).NotNullable()
                .WithColumn("Content").AsString().NotNullable()
                .WithColumn("SentDate").AsDateTime().Nullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("SendStatus").AsInt32().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable();

            Create.ForeignKey()
                .FromTable("SmsNotification").ForeignColumn("CompanyId")
                .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                .FromTable("SmsNotification").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("SmsNotification").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertSmsNotification", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetSmsListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateSmsNotification", namePathScript));

            Create.Table("MailNotification")
               .WithColumn("MailNotificationId").AsInt64().NotNullable().PrimaryKey().Identity()
               .WithColumn("CompanyId").AsInt64().NotNullable()
               .WithColumn("MailTo").AsString(50).NotNullable()
               .WithColumn("Content").AsString().NotNullable()
               .WithColumn("SentDate").AsDateTime().Nullable()
               .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
               .WithColumn("SendStatus").AsInt32().NotNullable()
               .WithColumn("Subject").AsString().NotNullable()
               .WithColumn("CreationUserId").AsInt64().NotNullable()
               .WithColumn("UpdateUserId").AsInt64().NotNullable()
               .WithColumn("CreationDate").AsDateTime().NotNullable()
               .WithColumn("UpdateDate").AsDateTime().NotNullable()
               .WithColumn("DeletionDate").AsDateTime().Nullable();

            Create.ForeignKey()
               .FromTable("MailNotification").ForeignColumn("CompanyId")
               .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                .FromTable("MailNotification").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("MailNotification").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertMailNotification", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetMailListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateMailNotification", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertSmsNotification", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetSmsListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateSmsNotification", namePathScript));
            Delete.Table("SmsNotification");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertMailNotification", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetMailListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateMailNotification", namePathScript));
            Delete.Table("MailNotification");
        }
    }
}