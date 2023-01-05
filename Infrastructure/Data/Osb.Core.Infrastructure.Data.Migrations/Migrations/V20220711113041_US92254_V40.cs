using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220711113041)]
    public class V20220711113041_US92254_V40 : Migration
    {
        private string namePathScript = "V20220711113041_US92254_V40";
        public override void Up()
        {
            Alter.Table("PixOut")
                            .AddColumn("ResponseMessage")
                            .AsString()
                            .Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("UpdatePixOut", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("UpdatePixOut", namePathScript));

            Delete.Column("ResponseMessage").FromTable("PixOut");
        }
    }
}