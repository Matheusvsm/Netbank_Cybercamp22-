using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220412160425)]
    public class V20220412160425_US64355_V29 : Migration
    {
        private string namePathScript = "V20220412160425_US64355_V29";

        public override void Up()
        {
            Create.Table("ScanLicenseKey")
                .WithColumn("ScanLicenseKeyId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("CompanyId").AsInt64().NotNullable()
                .WithColumn("LicenseKey").AsString().NotNullable()
                .WithColumn("CreationUserId").AsInt64().NotNullable()
                .WithColumn("UpdateUserId").AsInt64().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable();

            Create.ForeignKey()
            .FromTable("ScanLicenseKey").ForeignColumn("CompanyId")
            .ToTable("Company").PrimaryColumn("CompanyId");

            Execute.Script(ScriptsUtil.GetCreateProcedureFilePath("GetScanLicenseKeyByCompanyId", namePathScript));
        }

        public override void Down()
        {
            Execute.Script(ScriptsUtil.GetDropProcedureFilePath("GetScanLicenseKeyByCompanyId", namePathScript));
            Delete.Table("ScanLicenseKey");
        }
    }
}