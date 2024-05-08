namespace SistemaEnsino.models;

public class Professor : Pessoa
{
    public Professor(string? nome, string? email, int idade) : base(nome, email, idade)
    {
    }

    public Professor()
    {
    }
}