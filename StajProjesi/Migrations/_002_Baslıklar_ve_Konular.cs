using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Migrations
{
    [Migration(2)]
    public class _002_Baslıklar_ve_Konular : Migration
    {
        public override void Down()
        {
            Delete.Table("Baslıklar");
            Delete.Table("Konular");
            Delete.Table("Firmalar");
        }

        public override void Up()
        {
            Create.Table("Baslıklar")
                .WithColumn("BaslıkId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("BaslıkAdı").AsString(128).NotNullable()
                .WithColumn("FirmaId").AsInt32().NotNullable();


            Create.Table("Konular")
                .WithColumn("KonuId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Konu").AsString(1024).NotNullable()
                 .WithColumn("BaslıkId").AsInt32().NotNullable();

            Create.Table("Firmalar")
                .WithColumn("FirmaId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("FirmaAdı").AsString(256).NotNullable()
                .WithColumn("TeslimSaati").AsString(5);

        }
    }
}