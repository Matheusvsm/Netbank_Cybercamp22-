using FluentMigrator;

namespace Osb.Core.Infrastructure.Data.Migrations.Migrations
{
    [Migration(20220815161914)]
    public class V20220815161914_BG107279_V51 : Migration
    {
        public override void Up()
        {
            Alter.Table("BoletoPayment")
                .AlterColumn("DueDate")
                .AsDateTime().Nullable();
        }
        public override void Down()
        {
            Alter.Table("BoletoPayment")
                .AlterColumn("DueDate")
                .AsDateTime().NotNullable();
        }
    }
}