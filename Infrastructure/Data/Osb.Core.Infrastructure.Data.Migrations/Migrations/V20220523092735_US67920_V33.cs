using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220523092735)]
    public class V20220523092735_US67920_V33 : Migration
    {
        private string namePathScript = "V20220523092735_US67920_V33";

        public override void Up()
        {
            Create.Table("StaticPixQRCode")
                .WithColumn("StaticPixQRCodeId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("ExternalIdentifier").AsInt64().NotNullable()
                .WithColumn("QRCode").AsString().Nullable()
                .WithColumn("HashCode").AsString().Nullable()
                .WithColumn("PixKeyType").AsInt32().Nullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("StaticPixQRCode").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("StaticPixQRCode").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("StaticPixQRCode").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("StaticPixQRCode").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertStaticPixQRCode", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetStaticPixQRCode", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertStaticPixQRCode", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetStaticPixQRCode", namePathScript));
            Delete.Table("StaticPixQRCode");
        }
    }
}