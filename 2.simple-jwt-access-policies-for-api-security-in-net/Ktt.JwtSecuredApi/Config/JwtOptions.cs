using System.ComponentModel.DataAnnotations;

public class JwtOptions
{
    public const string SectionName = "JwtSettings";

    [Required(AllowEmptyStrings = false)]
    public string ValidAudience { get; set; } = string.Empty;

    [MinLength(1)]
    public Dictionary<string, string> TrustedServices { get; } = new();

    public Dictionary<string, string[]> AccessPolicies { get; } = new();
}