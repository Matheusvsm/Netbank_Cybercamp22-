using FluentMigrator;
using Osb.Core.Infrastructure.Data.Migrations.Utils;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220927230415)]
    public class V20220927230415_vincase_V57 : Migration
    {
        private string namePathScript = "V20220927230415_vincase_V57";

        public override void Up()
        {
    	    Create.Table("Point")
	        .WithColumn("PointId").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("AccountId").AsInt64().NotNullable()
		    .WithColumn("Value").AsInt64().NotNullable()
            .WithColumn("Date").AsDateTime().NotNullable();

            Create.ForeignKey()
            .FromTable("Point").ForeignColumn("AccountId")
            .ToTable("Account").PrimaryColumn("AccountId");

            Alter.Table("Account")
            .AddColumn("Score").AsInt64().Nullable();

        }

        public override void Down()
        {
            Delete.Table("Point");
            Delete.Column("Score").FromTable("Account");
        }
    }
}