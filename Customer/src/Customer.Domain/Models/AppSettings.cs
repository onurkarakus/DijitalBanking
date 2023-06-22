namespace Customer.Domain.Models;

/// <summary>App Settings</summary>
public class AppSettings
{
    /// <summary>Gets or sets the secret.</summary>
    /// <value>The secret.</value>
    public string Secret { get; set; } = string.Empty;
}
