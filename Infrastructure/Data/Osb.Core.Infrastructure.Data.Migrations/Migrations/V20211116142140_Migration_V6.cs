using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20211116142140)]
    public class V20211116142140_Migration_V6 : Migration
    {
        private string namePathScript = "V20211116142140_Migration_V6";
        public override void Up()
        {
            Create.Table("DARJPayment")
                .WithColumn("DARJPaymentId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString().NotNullable()
                .WithColumn("ContributorTaxId").AsString().NotNullable()
                .WithColumn("ReferenceNumber").AsString().NotNullable()
                .WithColumn("PrincipalValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("FineValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("InterestValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("MonetaryValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("TotalValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("RateValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("RateValueType").AsInt64().NotNullable()
                .WithColumn("DueDate").AsDateTime().NotNullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("CodeRevenue").AsString().NotNullable()
                .WithColumn("StateRegistration").AsString().NotNullable()
                .WithColumn("OriginDocument").AsInt64().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("DARJPayment").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("DARJPayment").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("DARJPayment").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("DARJPayment").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertDARJPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetDARJPaymentByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateDARJPayment", namePathScript));

            Create.Table("FGTSPayment")
                .WithColumn("FGTSPaymentId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString().NotNullable()
                .WithColumn("ContributorTaxId").AsString().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("PrincipalValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("CodeRevenue").AsString().NotNullable()
                .WithColumn("Barcode").AsString().NotNullable()
                .WithColumn("FGTSIdentifier").AsString().NotNullable()
                .WithColumn("SocialConnectivityCode").AsInt64().NotNullable()
                .WithColumn("SocialConnectivityDigit").AsInt32().NotNullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("RateValueType").AsInt64().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("FGTSPayment").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("FGTSPayment").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("FGTSPayment").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("FGTSPayment").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertFGTSPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetFGTSPaymentByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetFGTSPaymentByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateFGTSPayment", namePathScript));

            Create.Table("GAREPayment")
                .WithColumn("GAREPaymentId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString().NotNullable()
                .WithColumn("ContributorTaxId").AsString().NotNullable()
                .WithColumn("ReferenceNumber").AsString().NotNullable()
                .WithColumn("PrincipalValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("FineValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("InterestValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("TotalValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("RateValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("RateValueType").AsInt64().NotNullable()
                .WithColumn("DueDate").AsDateTime().NotNullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("CodeRevenue").AsString().NotNullable()
                .WithColumn("StateRegistration").AsString().NotNullable()
                .WithColumn("ActiveDebit").AsString().Nullable()
                .WithColumn("QuoteNumberNotification").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("GAREType").AsInt32().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("GAREPayment").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("GAREPayment").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("GAREPayment").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("GAREPayment").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");


            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertGAREPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetGAREPaymentById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetGAREPaymentListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateGAREPayment", namePathScript));

            Create.Table("DARFPayment")
                .WithColumn("DARFPaymentId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("TaxId").AsString().NotNullable()
                .WithColumn("DARFType").AsInt32().NotNullable()
                .WithColumn("CalculationPeriod").AsString().NotNullable()
                .WithColumn("CodeRevenue").AsString().NotNullable()
                .WithColumn("ContributorTaxId").AsString().NotNullable()
                .WithColumn("ReferenceNumber").AsString().Nullable()
                .WithColumn("DueDate").AsDateTime().Nullable()
                .WithColumn("GrossRevenueValue").AsDecimal(10, 2).Nullable()
                .WithColumn("GrossRevenuePercentage").AsString().Nullable()
                .WithColumn("PrincipalValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("FineValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("InterestValue").AsDecimal(10, 2).NotNullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("RateValueType").AsInt64().NotNullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("DARFPayment").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("DARFPayment").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("DARFPayment").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("DARFPayment").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertDARFPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetDARFPaymentByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateDARFPayment", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertDARFPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetDARFPaymentByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateDARFPayment", namePathScript));
            Delete.Table("DARFPayment");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertGAREPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetGAREPaymentById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetGAREPaymentListByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateGAREPayment", namePathScript));
            Delete.Table("GAREPayment");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertFGTSPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetFGTSPaymentByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetFGTSPaymentByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateFGTSPayment", namePathScript));
            Delete.Table("FGTSPayment");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertDARJPayment", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetDARJPaymentByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateDARJPayment", namePathScript));
            Delete.Table("DARJPayment");
        }
    }
}