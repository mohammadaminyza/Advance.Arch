namespace Advance.Arch.Infra.Data.SqlQueries.Common.Models;

public partial class TodoTask
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public int State { get; set; }
}