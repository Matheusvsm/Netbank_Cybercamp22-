using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220201090523)]
    public class V20220201090523_US59056_V10 : Migration
    {
        private string namePathScript = "V20220201090523_US59056_V10";

        public override void Up()
        {
            Create.Table("SPBAccount")
                  .WithColumn("SPBAccountId").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("AccountId").AsInt64().NotNullable()
                  .WithColumn("Bank").AsString()
                  .WithColumn("BankBranch").AsString()
                  .WithColumn("BankAccount").AsString()
                  .WithColumn("BankAccountDigit").AsString()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("UpdateDate").AsDateTime().NotNullable()
                  .WithColumn("DeletionDate").AsDateTime().Nullable()
                  .WithColumn("CreationUserId").AsInt64().NotNullable()
                  .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("SPBAccount").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                  .FromTable("SPBAccount").ForeignColumn("CreationUserId")
                  .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                  .FromTable("SPBAccount").ForeignColumn("UpdateUserId")
                  .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertSPBAccount", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertSPBAccount", namePathScript));
            Delete.Table("SPBAccount");
        }
    }
}
