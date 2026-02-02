namespace PasswordGeneratorModels;

public class PasswordEntry
{
    public int PasswordId { get; set; }
    public string Label { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int Length { get; set; }
    public int StrengthScore { get; set; }
    public string Site { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
