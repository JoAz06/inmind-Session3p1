namespace StudentManagement.API.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message/*Dictionnarys of erros*/) : base(message)
    {
    }
}