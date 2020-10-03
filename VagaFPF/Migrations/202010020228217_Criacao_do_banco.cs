namespace VagaFPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_do_banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "FPF.employee",
                c => new
                    {
                        id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        name = c.String(maxLength: 104),
                        salary = c.Decimal(nullable: false, precision: 10, scale: 2),
                        gender = c.String(maxLength: 1),
                        active = c.String(maxLength: 1),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        id_rule = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("FPF.rule", t => t.id_rule, cascadeDelete: true)
                .Index(t => t.id_rule);
            
            CreateTable(
                "FPF.rule",
                c => new
                    {
                        id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        name = c.String(maxLength: 54),
                        active = c.String(maxLength: 1),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("FPF.employee", "id_rule", "FPF.rule");
            DropIndex("FPF.employee", new[] { "id_rule" });
            DropTable("FPF.rule");
            DropTable("FPF.employee");
        }
    }
}
