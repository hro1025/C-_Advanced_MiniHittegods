namespace MiniHittegods.Domain.Interfaces;

public interface Interfaces
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string Category { get; set; }

    public string FoundLocation { get; set; }

    public string FoundAtUtc { get; set; }

    public string Status { get; set; }

    public string ClaimedBy { get; set; }

    public string ClaimedAtUtc { get; set; }

    public string ReturnedAtUtc { get; set; }
}
