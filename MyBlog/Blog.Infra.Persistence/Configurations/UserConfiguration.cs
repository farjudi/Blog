using Blog.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Domain.ValueObjects.User;

using System.Threading.Tasks;

namespace Blog.Infra.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //table name
            builder.ToTable("User");

            builder.HasKey(u => u.UserId);

            //*
            builder.Property(x => x.UserId)
               .HasConversion(
                   id => id.Value,
                    value => UserId.From(value)
               )
               .ValueGeneratedOnAdd();

            //*value object
            builder.Property(u => u.Email)
                .HasConversion(
                email => email.Value,
                value => Email.From(value)
                )
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnName("Email");
            // ایندکس روی ایمیل برای یکتایی و سرعت سرچ*

            builder.HasIndex(u => u.Email).IsUnique();


            //  تنظیم FullName (Complex Value Object)

            builder.OwnsOne(u => u.FullName, NavigationBuilder =>
            {
                NavigationBuilder.Property(n => n.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(100)
                .IsRequired();

                NavigationBuilder.Property(n => n.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(100)
                .IsRequired();
            });


            builder.Property(u => u.PhoneNumber)
                 .HasConversion(
                phone => phone.Value,
                value => PhoneNumber.From(value)
                )
                 .HasMaxLength(20)
                 .IsRequired(false)
                 .HasColumnName("PhoneNumber");


            builder.Property(u => u.PasswordHash)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(u => u.IsActive);

            builder.Property(u => u.CreatedAt);


            //enum
            builder.Property(u => u.Role)
                .HasConversion<string>();

        }
    }
}