using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public static class ModelBuilderExtensions
{
    public static PropertyBuilder<TProperty> IsPhone<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
     => propertyBuilder.HasAnnotation("Phone", true);


    public static PropertyBuilder<User> UserIDProperties<User>(this PropertyBuilder<User> propertyBuilder)
    => propertyBuilder.HasColumnName("user_id").HasColumnType("Binary").HasMaxLength(16);

}