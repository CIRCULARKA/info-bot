namespace InfoBot.Data.Configurations;

public class ArticleConfiguration : EntityConfiguration<ArticleEntity>, IEntityTypeConfiguration<ArticleEntity>
{
    public override void Configure(EntityTypeBuilder<ArticleEntity> builder)
    {
        base.Configure(builder);
        builder.Property(a => a.Source).IsRequired();
    }
}