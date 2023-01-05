using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20211013175545)]
    public class V20211013175545_Migration_V2 : Migration
    {
        private string namePathScript = "V20211013175545_Migration_V2";

        public override void Up()
        {
            Create.Table("BoletoPayment")
                .WithColumn("BoletoPaymentId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("TaxId").AsString(200).NotNullable()
                .WithColumn("ReceiverName").AsString(100).Nullable()
                .WithColumn("ReceiverTaxId").AsString(100).Nullable()
                .WithColumn("PayerName").AsString(100).Nullable()
                .WithColumn("PayerTaxId").AsString(100).Nullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Barcode").AsString(100).NotNullable()
                .WithColumn("PaymentValue").AsDecimal(15, 2).NotNullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("DueDate").AsDateTime().NotNullable()
                .WithColumn("DiscountValue").AsDecimal(15, 2).NotNullable()
                .WithColumn("Description").AsString(200).Nullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("BoletoPayment").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("BoletoPayment").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("BoletoPayment").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("BoletoPayment").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBoletoPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBoletoPaymentById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBoletoPaymentByExternalIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBoletoPaymentByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBoletoPayment", namePathScript));

            Create.Table("AccountLog")
                .WithColumn("AccountLogId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("Login").AsString().NotNullable()
                .WithColumn("LogDate").AsDateTime().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("AccountLog").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("AccountLog").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("AccountLog").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAccountLog", namePathScript));

            Create.Table("AuthorizationToken")
                .WithColumn("AuthorizationTokenId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().Nullable()
                .WithColumn("AccountId").AsInt64().Nullable()
                .WithColumn("PhoneNumber").AsString(11).Nullable()
                .WithColumn("Code").AsString(88).NotNullable()
                .WithColumn("Salt").AsString(36).NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("ExpirationDate").AsDateTime().NotNullable()
                .WithColumn("ValidateAttempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("AuthorizationToken").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("AuthorizationToken").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("AuthorizationToken").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("AuthorizationToken").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAuthorizationToken", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAuthorizationTokenByUserIdAndAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAuthorizationTokenByPhoneNumber", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateAuthorizationToken", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UnauthorizeAuthorizationTokensByUserIdAndAccountId", namePathScript));

            Create.Table("HashCode")
                .WithColumn("HashCodeId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("HashCode").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("HashCode").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("HashCode").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertHashCode", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertHashCode", namePathScript));
            Delete.Table("HashCode");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAuthorizationToken", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAuthorizationTokenByUserIdAndAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAuthorizationTokenByPhoneNumber", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateAuthorizationToken", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UnauthorizeAuthorizationTokensByUserIdAndAccountId", namePathScript));
            Delete.Table("AuthorizationToken");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAccountLog", namePathScript));
            Delete.Table("AccountLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBoletoPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBoletoPaymentById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBoletoPaymentByExternalIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBoletoPaymentByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBoletoPayment", namePathScript));
            Delete.Table("BoletoPayment");
        }
    }
}