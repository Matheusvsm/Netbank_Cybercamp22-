using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220629095236)]
    public class V20220629095236_US85307_V36 : Migration
    {
        private string namePathScript = "V20220629095236_US85307_V36";
        public override void Up()
        {
            Create.Table("Device")
                .WithColumn("DeviceId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Token").AsString().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("Device").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Create.ForeignKey()
                .FromTable("Device").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertDevice", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetDeviceByUserIdAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateTokenDeviceByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteDeviceByDeviceId", namePathScript));


            Create.Table("PushNotification")
            .WithColumn("PushNotificationId").AsInt64().NotNullable().PrimaryKey().Identity()
            .WithColumn("OperationId").AsInt64().NotNullable()
            .WithColumn("UserId").AsInt64().NotNullable()
            .WithColumn("CompanyId").AsInt64().NotNullable()
            .WithColumn("Title").AsString().Nullable()
            .WithColumn("Body").AsString().Nullable()
            .WithColumn("Status").AsInt32().NotNullable()
            .WithColumn("SendDate").AsDateTime().Nullable()
            .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
            .WithColumn("CreationDate").AsDateTime().NotNullable()
            .WithColumn("UpdateDate").AsDateTime().NotNullable()
            .WithColumn("DeletionDate").AsDateTime().Nullable()
            .WithColumn("CreationUserId").AsInt64().NotNullable()
            .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("PushNotification").ForeignColumn("OperationId")
            .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
            .FromTable("PushNotification").ForeignColumn("UserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("PushNotification").ForeignColumn("CompanyId")
            .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
            .FromTable("PushNotification").ForeignColumn("CreationUserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
            .FromTable("PushNotification").ForeignColumn("UpdateUserId")
            .ToTable("User").PrimaryColumn("UserId");
            
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertPushNotification", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdatePushNotification", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPushNotificationListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPushNotificationByOperationId", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertPushNotification", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdatePushNotification", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPushNotificationListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPushNotificationByOperationId", namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertDevice", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetDeviceByUserIdAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateTokenDeviceByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteDeviceByDeviceId", namePathScript));

            Delete.Table("Device");

            Delete.Table("PushNotification");
        }
    }
}