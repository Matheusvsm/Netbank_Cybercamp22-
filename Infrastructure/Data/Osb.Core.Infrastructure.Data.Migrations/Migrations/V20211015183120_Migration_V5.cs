using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20211015183120)]
    public class V20211015183120_Migration_V5 : Migration
    {
        private string namePathScript = "V20211015183120_Migration_V5";
        public override void Up()
        {
            Create.Table("TopUp")
                .WithColumn("TopUpId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("ProductType").AsInt32().NotNullable()
                .WithColumn("BatchIdentifier").AsString().NotNullable()
                .WithColumn("ProductKey").AsString().NotNullable()
                .WithColumn("ProductValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("ContractIdentifier").AsString().NotNullable()
                .WithColumn("OriginNSU").AsString().NotNullable()
                .WithColumn("UrlReceipt").AsString().Nullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("TopUp").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("TopUp").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("TopUp").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("TopUp").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpByExternaIidentifierAndProductKey", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetTopUpListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertTopUp", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateTopup", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpByExternaIidentifierAndProductKey", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetTopUpListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertTopUp", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateTopup", namePathScript));
            Delete.Table("TopUp");
        }
    }
}
