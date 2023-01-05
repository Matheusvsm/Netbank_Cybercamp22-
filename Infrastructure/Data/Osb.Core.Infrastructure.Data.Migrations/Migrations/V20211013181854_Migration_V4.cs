using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20211013181854)]
    public class V20211013181854_Migration_V4 : Migration
    {
        private string namePathScript = "V20211013181854_Migration_V4";
        public override void Up()
        {
            Create.Table("ActivateCard")
                .WithColumn("ActivateCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString(50).NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("ActivateCard").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("ActivateCard").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("ActivateCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("ActivateCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertActivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActivateCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActivateCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateActivateCard", namePathScript));

            Create.Table("CardOwner")
                .WithColumn("CardOwnerId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("OwnerTaxId").AsString().NotNullable()
                .WithColumn("FullName").AsString().NotNullable()
                .WithColumn("Phone").AsString().NotNullable()
                .WithColumn("Mail").AsString().NotNullable()
                .WithColumn("Bank").AsString().Nullable()
                .WithColumn("BankBranch").AsString().Nullable()
                .WithColumn("BankAccount").AsString().Nullable()
                .WithColumn("BankAccountDigit").AsString().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("CardOwner").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("CardOwner").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCardOwner", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCardOwnerById", namePathScript));

            Create.Table("CardHolder")
                .WithColumn("CardHolderId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("HolderTaxId").AsString().NotNullable()
                .WithColumn("Nationality").AsString().NotNullable()
                .WithColumn("MotherName").AsString().NotNullable()
                .WithColumn("Gender").AsInt32().NotNullable()
                .WithColumn("FullName").AsString().NotNullable()
                .WithColumn("BirthDate").AsString().NotNullable()
                .WithColumn("MaritalStatus").AsInt32().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("CardHolder").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("CardHolder").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCardHolder", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCardHolderById", namePathScript));

            Create.Table("CardHolderContact")
                .WithColumn("CardHolderContactId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Phone").AsString().NotNullable()
                .WithColumn("Mail").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("CardHolderContact").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("CardHolderContact").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetCardHolderContactById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertCardHolderContact", namePathScript));

            Create.Table("BindCard")
                .WithColumn("BindCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("CardOwnerId").AsInt64().NotNullable()
                .WithColumn("CardHolderId").AsInt64().NotNullable()
                .WithColumn("CardHolderContactId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString().NotNullable()
                .WithColumn("UsageType").AsInt32().Nullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("BindCard").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("BindCard").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("BindCard").ForeignColumn("CardOwnerId")
                .ToTable("CardOwner").PrimaryColumn("CardOwnerId");
            Create.ForeignKey()
                .FromTable("BindCard").ForeignColumn("CardHolderId")
                .ToTable("CardHolder").PrimaryColumn("CardHolderId");
            Create.ForeignKey()
                .FromTable("BindCard").ForeignColumn("CardHolderContactId")
                .ToTable("CardHolderContact").PrimaryColumn("CardHolderContactId");
            Create.ForeignKey()
                .FromTable("BindCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("BindCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBindCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBindCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBindCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBindCardByStatus", namePathScript));

            Create.Table("BlockCard")
                .WithColumn("BlockCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString().NotNullable()
                .WithColumn("Pin").AsString().NotNullable()
                .WithColumn("Salt").AsString().NotNullable()
                .WithColumn("ReasonCode").AsInt32().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("BlockCard").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("BlockCard").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("BlockCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("BlockCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBlockCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBlockCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBlockCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBlockCard", namePathScript));

            Create.Table("InactivateCard")
                .WithColumn("InactivateCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString().NotNullable()
                .WithColumn("Pin").AsString().NotNullable()
                .WithColumn("Salt").AsString(36).NotNullable()
                .WithColumn("ReasonCode").AsInt32().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("InactivateCard").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("InactivateCard").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("InactivateCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("InactivateCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInactivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateInactivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInactivateCardById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInactivateCardByStatus", namePathScript));

            Create.Table("ChangePinCard")
                .WithColumn("ChangePinCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString().NotNullable()
                .WithColumn("CurrentPin").AsString(200).NotNullable()
                .WithColumn("Pin").AsString(200).NotNullable()
                .WithColumn("ConfirmationPin").AsString(200).NotNullable()
                .WithColumn("Salt").AsString(200).NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("ChangePinCard").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("ChangePinCard").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("ChangePinCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("ChangePinCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetChangePinCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetChangePinCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertChangePinCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateChangePinCard", namePathScript));

            Create.Table("UnblockCard")
                .WithColumn("UnblockCardId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("IdentifierCard").AsString().NotNullable()
                .WithColumn("Pin").AsString().NotNullable()
                .WithColumn("Salt").AsString().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("UnblockCard").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("UnblockCard").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("UnblockCard").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("UnblockCard").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUnblockCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUnblockCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUnblockCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUnblockCard", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetChangePinCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetChangePinCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertChangePinCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateChangePinCard", namePathScript));
            Delete.Table("ChangePinCard");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertInactivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateInactivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInactivateCardById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInactivateCardByStatus", namePathScript));
            Delete.Table("InactivateCard");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBlockCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBlockCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBlockCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBlockCard", namePathScript));
            Delete.Table("BlockCard");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBindCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBindCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBindCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBindCardByStatus", namePathScript));
            Delete.Table("BindCard");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCardHolderContactById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCardHolderContact", namePathScript));
            Delete.Table("CardHolderContact");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCardHolder", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCardHolderById", namePathScript));
            Delete.Table("CardHolder");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetCardOwnerById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertCardOwner", namePathScript));
            Delete.Table("CardOwner");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertActivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetActivateCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateActivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetActivateCardByIdentifier", namePathScript));
            Delete.Table("ActivateCard");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUnblockCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUnblockCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUnblockCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUnblockCard", namePathScript));
            Delete.Table("UnblockCard");
        }
    }
}