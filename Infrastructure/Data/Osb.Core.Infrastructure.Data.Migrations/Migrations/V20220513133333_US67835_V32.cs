using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations

{
    [Migration(20220513133333)]
    public class V20220513133333_US67835_V32 : Migration
    {
        private string namePathScript = "V20220513133333_US67835_V32";

        public override void Up()
        {
            Create.Table("PixOut")
                .WithColumn("PixOutId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("OperationId").AsInt64().NotNullable()
                .WithColumn("ToTaxId").AsString().NotNullable()
                .WithColumn("ToName").AsString().NotNullable()
                .WithColumn("ToBank").AsString().NotNullable()
                .WithColumn("ToBankBranch").AsString().NotNullable()
                .WithColumn("ToBankAccount").AsString().NotNullable()
                .WithColumn("ToBankAccountDigit").AsString().NotNullable()
                .WithColumn("Value").AsDecimal(10, 2).NotNullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("Identifier").AsString().NotNullable()
                .WithColumn("PixKey").AsString().Nullable()
                .WithColumn("PixKeyType").AsInt32().Nullable()
                .WithColumn("AccountType").AsInt32().Nullable()
                .WithColumn("CustomerMessage").AsString().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("PixOut").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("PixOut").ForeignColumn("OperationId")
                .ToTable("Operation").PrimaryColumn("OperationId");
            Create.ForeignKey()
                .FromTable("PixOut").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("PixOut").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertPixOut", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdatePixOut", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPixOutByStatus", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertPixOut", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdatePixOut", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPixOutByStatus", namePathScript));

            Delete.Table("PixOut");
        }
    }
}