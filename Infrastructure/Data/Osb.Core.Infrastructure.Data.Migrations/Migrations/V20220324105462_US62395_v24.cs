using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220324105462)]
    public class V20220324105462_US62395_v24 : Migration
    {
        private string namePathScript = "V20220324105462_US62395_v24";

        public override void Up()
        {
            Delete.Column("PhoneNumber").FromTable("AuthorizationToken");

            Alter.Table("AuthorizationToken").AddColumn("TaxId").AsString().Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetAuthorizationTokenByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertAuthorizationToken", namePathScript));
        }

        public override void Down()
        {
            Delete.Column("TaxId").FromTable("AuthorizationToken");

            Alter.Table("AuthorizationToken").AddColumn("PhoneNumber").AsString().Nullable();

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetAuthorizationTokenByTaxId", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertAuthorizationToken", namePathScript));
        }
    }
}