namespace Application.Common.Exceptions;

public class NotFoundException<T> : Exception
{
    public NotFoundException(Guid id)
        : base($"No se encontro el recurso {typeof(T).Name} con Id: {id}")
    {
    }
}