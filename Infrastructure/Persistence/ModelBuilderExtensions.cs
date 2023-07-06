using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public static class ModelBuilderExtensions
{
    public static PropertyBuilder<TProperty> IsPhone<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
    {
        return propertyBuilder.HasAnnotation("Phone", true);
    }

    public static PropertyBuilder<User> UserIDProperties<User>(this PropertyBuilder<User> propertyBuilder) { 
        
        return propertyBuilder.HasColumnName("user_id").HasColumnType("Binary").HasMaxLength(16);
    }
}