using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220504153434)]

    public class V20220504153434_US74375_V31 : Migration
    {
        private string namePathScript = "V20220504153434_US74375_V31";

        public override void Up()
        {
            Alter.Table("OutputLog")
            .AddColumn("InputLogId")
            .AsInt64()
            .Nullable();

            Create.ForeignKey()
            .FromTable("OutputLog").ForeignColumn("InputLogId")
            .ToTable("InputLog").PrimaryColumn("InputLogId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertInputLog", namePathScript));
            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("InsertOutputLog", namePathScript));
        }

        public override void Down()
        {
            Delete.ForeignKey()
            .FromTable("OutputLog").ForeignColumn("InputLogId")
            .ToTable("InputLog").PrimaryColumn("InputLogId");

            Delete.Column("InputLogId").FromTable("OutputLog");

            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertInputLog", namePathScript));
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("InsertOutputLog", namePathScript));
        }
    }
}