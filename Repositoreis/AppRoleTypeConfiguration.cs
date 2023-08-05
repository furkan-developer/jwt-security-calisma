using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWT_Security.Repositoreis
{
    public class AppRoleTypeConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                    new AppRole(){Name="Visitor",NormalizedName="VISITOR"},
                    new AppRole(){Name="Admin",NormalizedName="ADMIN"}
                );
        }
    }
}