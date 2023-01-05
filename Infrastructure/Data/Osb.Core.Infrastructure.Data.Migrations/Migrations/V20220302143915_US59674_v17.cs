using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220302143915)]

    public class V20220302143915_US59674_v17 : Migration
    {
        private string namePathScript = "V20220302143915_US59674_v17";

        public override void Up()
        {
            Rename.Column("Request")
                .OnTable("InputLog")
                .To("Body");

            Alter.Table("InputLog")
                .AddColumn("Method")
                .AsString()
                .Nullable();

            Alter.Table("InputLog")
                .AddColumn("Headers")
                .AsString()
                .Nullable();

            Alter.Table("InputLog")
                .AddColumn("Url")
                .AsString()
                .Nullable();

            Alter.Table("OutputLog")
                .AddColumn("StatusCode")
                .AsString()
                .Nullable();

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInputLog", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOutputLog", namePathScript));

        }

        public override void Down()
        {
            Rename.Column("Body")
                .OnTable("InputLog")
                .To("Request");
            Delete.Column("Method").FromTable("InputLog");
            Delete.Column("Headers").FromTable("InputLog");
            Delete.Column("Url").FromTable("InputLog");
            Delete.Column("StatusCode").FromTable("OutputLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertInputLog", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOutputLog", namePathScript));
        }
    }
}