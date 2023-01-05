using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220104090821)]
    public class V20220104090821_US47297_V8 : Migration
    {
        private string namePathScript = "V20220104090821_US47297_V8";

        public override void Up()
        {
            Create.Table("Profile")
                .WithColumn("ProfileId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("Profile").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("Profile").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertProfile", namePathScript));

            Create.Table("UserAccountProfile")
                .WithColumn("UserAccountProfileId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserAccountId").AsInt64().NotNullable()
                .WithColumn("ProfileId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("UserAccountProfile").ForeignColumn("UserAccountId")
                .ToTable("UserAccount").PrimaryColumn("UserAccountId");
            Create.ForeignKey()
                .FromTable("UserAccountProfile").ForeignColumn("ProfileId")
                .ToTable("Profile").PrimaryColumn("ProfileId");
            Create.ForeignKey()
                .FromTable("UserAccountProfile").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("UserAccountProfile").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserAccountProfile", namePathScript));

            Create.Table("ActionFunction")
                .WithColumn("ActionFunctionId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Action").AsString().NotNullable()
                .WithColumn("Controller").AsString().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("ActionFunction").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("ActionFunction").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertActionFunction", namePathScript));
            // Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertActionFunctionData", namePathScript));

            Create.Table("ProfileActionFunction")
                .WithColumn("ProfileActionFunctionId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProfileId").AsInt64().NotNullable()
                .WithColumn("ActionFunctionId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("ProfileActionFunction").ForeignColumn("ProfileId")
                .ToTable("Profile").PrimaryColumn("ProfileId");
            Create.ForeignKey()
                .FromTable("ProfileActionFunction").ForeignColumn("ActionFunctionId")
                .ToTable("ActionFunction").PrimaryColumn("ActionFunctionId");
            Create.ForeignKey()
                .FromTable("ProfileActionFunction").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("ProfileActionFunction").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertProfileActionFunction", namePathScript));

            Create.Table("ProfileUIFunction")
                .WithColumn("ProfileUIFunctionId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProfileId").AsInt64().NotNullable()
                .WithColumn("UIFunctionId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.Table("UIFunction")
                .WithColumn("UIFunctionId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Code").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("UIFunction").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("UIFunction").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUIFunction", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUIFunctionListByAccountIdAndUserId", namePathScript));

            Create.ForeignKey()
                .FromTable("ProfileUIFunction").ForeignColumn("ProfileId")
                .ToTable("Profile").PrimaryColumn("ProfileId");
            Create.ForeignKey()
                .FromTable("ProfileUIFunction").ForeignColumn("UIFunctionId")
                .ToTable("UIFunction").PrimaryColumn("UIFunctionId");
            Create.ForeignKey()
                .FromTable("ProfileUIFunction").ForeignColumn("CreationUserId")
                .ToTable("User").PrimaryColumn("UserId");
            Create.ForeignKey()
                .FromTable("ProfileUIFunction").ForeignColumn("UpdateUserId")
                .ToTable("User").PrimaryColumn("UserId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertProfileUIFunction", namePathScript));

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActionFunctionByParameters", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetActionFunctionByParameters", namePathScript));

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertProfileUIFunction", namePathScript));
            Delete.Table("ProfileUIFunction");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUIFunction", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUIFunctionListByAccountIdAndUserId", namePathScript));
            Delete.Table("UIFunction");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertProfileActionFunction", namePathScript));
            Delete.Table("ProfileActionFunction");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertActionFunction", namePathScript));
            Delete.Table("ActionFunction");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserAccountProfile", namePathScript));
            Delete.Table("UserAccountProfile");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertProfile", namePathScript));
            Delete.Table("Profile");
        }
    }
}
