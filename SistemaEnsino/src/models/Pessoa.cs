namespace SistemaEnsino.models;

public abstract class Pessoa
{
	private static int _contador = 1;
	public int Id { get; private set; }
    public string? Nome { get; protected set; }
    public string? Email { get; protected set; }
	public int Idade { get; }
	
	protected Pessoa()
	{
		Id = _contador++;
	}

	protected Pessoa(string? nome, string? email, int idade)
	{
		Id = _contador++;
		Nome = nome;
		Email = email;
		Idade = idade;
	}
}