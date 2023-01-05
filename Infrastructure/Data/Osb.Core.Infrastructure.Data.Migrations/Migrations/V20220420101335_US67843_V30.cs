using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations

{
    [Migration(20220420101335)]
    public class V20220420101335_US67843_V30 : Migration
    {
        private string namePathScript = "V20220420101335_US67843_V30";

        public override void Up()
        {
            Create.Table("RefundPixIn")
                .WithColumn("RefundPixInId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("ToTaxId").AsString().NotNullable()
                .WithColumn("ToName").AsString().NotNullable()
                .WithColumn("ToBank").AsString().NotNullable()
                .WithColumn("ToBankBranch").AsString().NotNullable()
                .WithColumn("ToBankAccount").AsString().NotNullable()
                .WithColumn("ToBankAccountDigit").AsString().NotNullable()
                .WithColumn("RefundValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("CustomerMessage").AsString().Nullable()
                .WithColumn("DocumentNumber").AsInt64().NotNullable()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("RefundPixIn").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("RefundPixIn").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("RefundPixIn").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("RefundPixIn").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertRefundPixIn", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateRefundPixIn", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetRefundPixInByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAccountById", namePathScript));

        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertRefundPixIn", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateRefundPixIn", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetRefundPixInByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAccountById", namePathScript));

            
            Delete.Table("RefundPixIn");
        }
    }
}