using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220721145542)]
    public class V20220721145542_US68089_V44 : Migration
    {
        private string namePathScript = "V20220721145542_US68089_V44";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetProfileById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetProfileByNameAndUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserAccountProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserAccountProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateProfileActionFunction", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetProfileByUserAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteUserAccountProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserAccountByUserIdAndAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActionFunctionById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("DeleteProfileActionFunctionByProfileIdAndActionFunctionId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetProfileActionFunctionByProfileId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetProfileActionFunctionByProfileIdAndActionFunctionId", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetProfileById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetProfileByNameAndUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserAccountProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserAccountProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateProfileActionFunction", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetProfileByUserAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteUserAccountProfile", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserAccountByUserIdAndAccountId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetActionFunctionById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("DeleteProfileActionFunctionByProfileIdAndActionFunctionId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetProfileActionFunctionByProfileId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetProfileActionFunctionByProfileIdAndActionFunctionId", namePathScript));
        }
    }
}