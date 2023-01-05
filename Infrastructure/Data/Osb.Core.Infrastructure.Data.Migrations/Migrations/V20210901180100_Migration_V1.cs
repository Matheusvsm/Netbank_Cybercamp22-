using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20210901180100)]
    public class V20210901180100_Migration_V1 : Migration
    {
        private string namePathScript = "V20210901180100_Migration_V1";
        public override void Up()
        {
            Create.Table("Operation")
                .WithColumn("OperationId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("OperationType").AsInt32().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("Operation").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("Operation").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOperation", namePathScript));

            Create.Table("OperationTag")
                .WithColumn("OperationTagId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("Tag").AsString(50).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("OperationTag").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("OperationTag").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("OperationTag").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOperationTag", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetOperationTagByOperationId", namePathScript));

            Create.Table("InternalTransfer")
                .WithColumn("InternalTransferId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Identifier").AsString(50).NotNullable()
                .WithColumn("FromAccountId").AsInt64().NotNullable()
                .WithColumn("ToAccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("TransferValue").AsDecimal(15, 2).NotNullable()
                .WithColumn("TransferDate").AsDateTime().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("FromAccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("ToAccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("InternalTransfer").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInternalTransfer", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInternalTransferByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInternalTransferById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInternalTransferByExternalIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateInternalTransfer", namePathScript));

            Create.Table("BankingData")
                .WithColumn("BankingDataId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Bank").AsString().NotNullable()
                .WithColumn("BankBranch").AsString().NotNullable()
                .WithColumn("BankAccount").AsString().NotNullable()
                .WithColumn("BankAccountDigit").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("BankingData").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("BankingData").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBankingData", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBankingdataById", namePathScript));

            Create.Table("MoneyTransfer")
                .WithColumn("MoneyTransferId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("FromAccountId").AsInt64().NotNullable()
                .WithColumn("ToTaxId").AsString().NotNullable()
                .WithColumn("ToName").AsString().Nullable()
                .WithColumn("BankingDataId").AsInt64().NotNullable()
                .WithColumn("TransferValue").AsDecimal(15, 2).NotNullable()
                .WithColumn("TransferDate").AsDateTime().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("MoneyTransfer").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("MoneyTransfer").ForeignColumn("BankingDataId")
                .ToTable("BankingData").PrimaryColumn("BankingDataId");
            Create.ForeignKey()
                .FromTable("MoneyTransfer").ForeignColumn("FromAccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("MoneyTransfer").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("MoneyTransfer").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetMoneyTransferByExternalIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertMoneyTransfer", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetMoneyTransferbyStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateMoneyTransfer", namePathScript));

            Create.Table("Favored")
                .WithColumn("FavoredId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString(20).NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("OperationType").AsInt32().NotNullable()
                .WithColumn("BankName").AsString(50).Nullable()
                .WithColumn("Bank").AsString(4).Nullable()
                .WithColumn("BankBranch").AsString(10).Nullable()
                .WithColumn("BankAccount").AsString(20).Nullable()
                .WithColumn("BankAccountDigit").AsString(2).Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("Favored").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("Favored").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("Favored").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertFavored", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetFavored", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertFavored", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetFavored", namePathScript));
            Delete.Table("Favored");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetMoneyTransferByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetMoneyTransferByExternalIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertMoneyTransfer", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateMoneyTransfer", namePathScript));
            Delete.Table("MoneyTransfer");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBankingData", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBankingdataById", namePathScript));
            Delete.Table("BankingData");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateInternalTransfer", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInternalTransferByExternalIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInternalTransferById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertInternalTransfer", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInternalTransferByStatus", namePathScript));
            Delete.Table("InternalTransfer");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetOperationTagByOperationId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOperationTag", namePathScript));
            Delete.Table("OperationTag");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOperation", namePathScript));
            Delete.Table("Operation");
        }
    }
}