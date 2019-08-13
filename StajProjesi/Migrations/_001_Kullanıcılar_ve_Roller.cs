using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProjesi.Migrations
{
    [Migration(1)]
    public class _001_Kullanıcılar_ve_Roller : Migration
    {
        public override void Down()
        {
           
            Delete.Table("Kullanıcılar");
            Delete.Table("Roller");
            Delete.Table("Kullanıcı_Rolleri");
        }

        public override void Up()
        {

        
            Create.Table("Kullanıcılar")
                .WithColumn("KullanıcıId").AsInt32().Identity().PrimaryKey().NotNullable()
                 .WithColumn("Ad").AsString(64).NotNullable()
                 .WithColumn("Soyad").AsString(64).NotNullable()
                 .WithColumn("KullanıcıAdı").AsString(128).NotNullable()   
                 .WithColumn("FirmaId").AsInt32()          
                 .WithColumn("Password_Hash").AsString(256).NotNullable();

            Create.Table("Roller")
            .WithColumn("RolId").AsInt32().Identity().PrimaryKey().NotNullable()
             .WithColumn("RolAdı").AsString(10).NotNullable();

            Create.Table("Kullanıcı_Rolleri")
                 .WithColumn("KullanıcıId").AsInt32().ForeignKey("Kullanıcılar", "KullanıcıId").OnDelete(System.Data.Rule.Cascade)
                  .WithColumn("RolId").AsInt32().ForeignKey("Roller", "RolId").OnDelete(System.Data.Rule.Cascade);
        }
    }
}