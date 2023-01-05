using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220131103348)]
    public class V20220131103348_US59035_V9 : Migration
    {
        private string namePathScript = "V20220131103348_US59035_V9";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertActivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActivateCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetActivateCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateActivateCard", namePathScript));
            Delete.Column("Attempts").FromTable("ActivateCard");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBlockCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBlockCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBlockCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBlockCard", namePathScript));
            Delete.Column("Attempts").FromTable("BlockCard");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUnblockCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetUnblockCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateUnblockCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertUnblockCard", namePathScript));
            Delete.Column("Attempts").FromTable("UnblockCard");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertChangePinCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetChangePinCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetChangePinCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateChangePinCard", namePathScript));
            Delete.Column("Attempts").FromTable("ChangePinCard");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertBindCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBindCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetBindCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateBindCard", namePathScript));
            Delete.Column("Attempts").FromTable("BindCard");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInactivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInactivateCardById", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetInactivateCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdateInactivateCard", namePathScript));
            Delete.Column("Attempts").FromTable("InactivateCard");
        }

        public override void Down()
        {
            Alter.Table("ActivateCard").AddColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0);
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertActivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetActivateCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetActivateCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateActivateCard", namePathScript));

            Alter.Table("BlockCard").AddColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0);
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBlockCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBlockCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBlockCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBlockCard", namePathScript));

            Alter.Table("UnblockCard").AddColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0);
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertUnblockCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUnblockCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetUnblockCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateUnblockCard", namePathScript));

            Alter.Table("ChangePinCard").AddColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0);
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertChangePinCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetChangePinCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetChangePinCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateChangePinCard", namePathScript));

            Alter.Table("BindCard").AddColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0);
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertBindCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBindCardByIdentifier", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetBindCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateBindCard", namePathScript));

            Alter.Table("InactivateCard").AddColumn("Attempts").AsInt32().NotNullable().WithDefaultValue(0);
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertInactivateCard", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInactivateCardById", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetInactivateCardByStatus", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdateInactivateCard", namePathScript));
        }
    }
}
