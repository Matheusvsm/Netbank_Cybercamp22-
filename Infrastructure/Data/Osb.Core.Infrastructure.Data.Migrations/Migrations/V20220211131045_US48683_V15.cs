using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220211131045)]
    public class V20220211131045_US48683_V15 : Migration
    {
        private string namePathScript = "V20220211131045_US48683_V15";

        public override void Up()
        {
            Create.Table("CancelCard")
                .WithColumn("CancelCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString().NotNullable()
                .WithColumn("Status").AsInt16().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("CancelCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("CancelCard").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("CancelCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("CancelCard").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCancelCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateCancelCard", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCancelCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateCancelCard", namePathScript));
            Delete.Table("CancelCard");
        }
    }
}