namespace StudentManagement.API.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(int id) : base($"Student with ID {id} was not found")
    {
    }
}