using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220819094820)]
    public class V20220819094820_BG108818_V55 : Migration
    {
        private string namePathScript = "V20220819094820_BG108818_V55";

        public override void Up()
        {
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetPixKeyByPixKeyValue", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertPixKey", namePathScript));

            Delete.Column("UserId").FromTable("PixKey");
        }

        public override void Down()
        {
            Alter.Table("PixKey")
                .AddColumn("UserId")
                .AsInt64()
                .NotNullable().WithDefaultValue(0);

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetPixKeyByPixKeyValue", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertPixKey", namePathScript));
        }
    }
}