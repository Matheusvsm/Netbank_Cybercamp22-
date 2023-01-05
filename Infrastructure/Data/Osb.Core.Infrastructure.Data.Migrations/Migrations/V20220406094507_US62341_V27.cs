using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220406094507)]
    public class V20220406094507_US62341_V27 : Migration
    {
        private string namePathScript = "V20220406094507_US62341_V27";

        public override void Up()
        {
            Create.Table("OperationAttachment")
                .WithColumn("OperationAttachmentId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Extension").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("OperationAttachment").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("OperationAttachment").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("OperationAttachment").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOperationAttachment", namePathScript));
        }

        public override void Down()
        {
            Delete.Table("OperationAttachment");
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOperationAttachment", namePathScript));
        }
    }
}