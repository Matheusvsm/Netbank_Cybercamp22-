using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220721093015)]
    public class V20220721093015_US81444_V43 : Migration
    {
        private string namePathScript = "V20220721093015_US81444_V43";
        public override void Up()
        {
            Create.Table("PixKey")
                .WithColumn("PixKeyId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("AccountId").AsInt64().NotNullable()
                .WithColumn("PixKeyValue").AsString().Nullable()
                .WithColumn("PixKeyType").AsInt32().Nullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
            .FromTable("PixKey").ForeignColumn("UserId")
            .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("PixKey").ForeignColumn("AccountId")
                .ToTable("Account").PrimaryColumn("AccountId");
            Create.ForeignKey()
                .FromTable("PixKey").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("PixKey").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertPixKey", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPixKeyListByAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdatePixKeyStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPixKeyByPixKeyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPixKeyByPixKeyValue", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPixKeyByAccountData", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBySpbAccount", namePathScript));
        }
        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertPixKey", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPixKeyListByAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPixKeyByPixKeyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdatePixKeyStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPixKeyByPixKeyValue", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPixKeyByAccountData", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBySpbAccount", namePathScript));
            Delete.Table("PixKey");
        }
    }
}