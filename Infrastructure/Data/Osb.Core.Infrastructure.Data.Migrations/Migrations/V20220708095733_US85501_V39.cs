using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220708095733)]
    public class V20220708095733_US85501_V39 : Migration
    {
        private string namePathScript = "V20220708095733_US85501_V39";

        public override void Up()
        {
            Create.Table("RememberLoginToken")
                .WithColumn("RememberLoginTokenId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("HashTokenAccess").AsString().NotNullable()
                .WithColumn("TokenAccess").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("RememberLoginToken").ForeignColumn("UserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("RememberLoginToken").ForeignColumn("CompanyId")
                .ToTable("Company").PrimaryColumn("CompanyId");
            Create.ForeignKey()
                .FromTable("RememberLoginToken").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("RememberLoginToken").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertRememberLoginToken", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserByTokenAccessAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateRememberLoginToken", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertRememberLoginToken", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserByTokenAccessAndCompanyId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateRememberLoginToken", namePathScript));
            Delete.Table("RememberLoginToken");
        }

    }
}