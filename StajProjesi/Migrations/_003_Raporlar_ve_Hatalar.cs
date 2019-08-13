using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Migrations
{
    [Migration(3)]
    public class _003_Raporlar_ve_Hatalar : Migration
    {
        public override void Down()
        {
            Delete.Table("Raporlar");
            Delete.Table("Hatalar");
            Delete.Table("Görevli");
        }

        public override void Up()
        {
            Create.Table("Raporlar")
                .WithColumn("RaporId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("RaporTarihi").AsDate().NotNullable()
                .WithColumn("RaporSaati").AsString(5).NotNullable()
                .WithColumn("KullanıcıId").AsInt32().NotNullable()
                .WithColumn("FirmaId").AsInt32().NotNullable();

            Create.Table("Hatalar")
                .WithColumn("RaporId").AsInt32().ForeignKey("Raporlar", "RaporId").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("KonuId").AsInt32().ForeignKey("Konular", "KonuId").OnDelete(System.Data.Rule.Cascade);

            Create.Table("Gorevler")
                .WithColumn("GorevId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("KullanıcıId").AsInt32().NotNullable()
            .WithColumn("FirmaId").AsInt32().NotNullable()
            .WithColumn("Tarih").AsDate()
            .WithColumn("Hafta").AsInt32();


        }
    }
}