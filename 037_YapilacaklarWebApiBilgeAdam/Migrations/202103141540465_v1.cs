namespace _037_YapilacaklarWebApiBilgeAdam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicilar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(nullable: false, maxLength: 32),
                        Sifre = c.String(nullable: false, maxLength: 16),
                        Adi = c.String(maxLength: 50),
                        Soyadi = c.String(maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 32),
                        UpdateDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 32),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yapilacaklar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gorev = c.String(nullable: false),
                        Tarih = c.DateTime(),
                        YapildiMi = c.Boolean(nullable: false),
                        KullaniciId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 32),
                        UpdateDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 32),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanicilar", t => t.KullaniciId)
                .Index(t => t.KullaniciId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yapilacaklar", "KullaniciId", "dbo.Kullanicilar");
            DropIndex("dbo.Yapilacaklar", new[] { "KullaniciId" });
            DropTable("dbo.Yapilacaklar");
            DropTable("dbo.Kullanicilar");
        }
    }
}
