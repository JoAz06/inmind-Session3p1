namespace StudentManagement.API.Exceptions;

public class ConflictException : Exception
{
    public ConflictException() : base("A student with this email already exists")
    {
    }
}