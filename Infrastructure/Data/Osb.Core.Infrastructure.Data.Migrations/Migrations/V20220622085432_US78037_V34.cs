using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220622085432)]
    public class V20220622085432_US78037_V34 : Migration
    {
        public string namePathScript = "V20220622085432_US78037_V34";

        public override void Up()
        {
            Alter.Table("UserInformation").AddColumn("Reference").AsString(100).Nullable();
            Alter.Table("UserInformation").AddColumn("Country").AsString(30).Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUserInformationByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUserInformation", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUserInformation", namePathScript));
        }

        public override void Down()
        {
            Delete.Column("Reference").FromTable("UserInformation");
            Delete.Column("Country").FromTable("UserInformation");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUserInformationByUserId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUserInformation", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUserInformation", namePathScript));
        }
    }
}