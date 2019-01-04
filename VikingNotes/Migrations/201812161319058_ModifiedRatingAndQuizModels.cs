namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedRatingAndQuizModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ratings", "CreateDate");
            DropColumn("dbo.Ratings", "EditDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "EditDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ratings", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
