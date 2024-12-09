
namespace InfoBot.Data.Configurations;

public class ArticleAttributeConfiguration : EntityConfiguration<ArticleAttributeEntity>, IEntityTypeConfiguration<ArticleAttributeEntity>
{
    public override void Configure(EntityTypeBuilder<ArticleAttributeEntity> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Value).IsRequired();
    }
}