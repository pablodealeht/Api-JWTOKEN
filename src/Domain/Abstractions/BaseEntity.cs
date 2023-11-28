namespace Domain.Abstractions;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}