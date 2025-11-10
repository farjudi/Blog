using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ValueObjects;

public record FullName
{
    public string FirstName { get; }
    public string LastName { get; }

    private FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public static FullName From(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException(" نام نمی تواند خالی باشد ", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("نام خانوادگی نمیتواند خالی باشد ", nameof(lastName);
        return new FullName(firstName.Trim(), lastName.Trim());


    }
    public string GetFullName() => $"{FirstName} {LastName}";
    public override string ToString()=>GetFullName();
 
}
