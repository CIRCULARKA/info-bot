namespace InfoBot.Data.Configurations;

public class ArticleAttributeConfiguration : EntityConfiguration<ArticleAttributeEntity>, IEntityTypeConfiguration<ArticleAttributeEntity>
{
    public override void Configure(EntityTypeBuilder<ArticleAttributeEntity> builder)
    {
        base.Configure(builder);
        builder.Property(a => a.Name).IsRequired();
        builder.Property(a => a.Value).IsRequired();
    }
}