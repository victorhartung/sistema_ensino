using SistemaEnsino.interfaces;

namespace SistemaEnsino.models;

public class Curso : ICrud<Aluno>
{
    private static int _contador;
    public int Id { get; private set; } 
    public string? Nome { get; private set; }
    private List<Aluno> Alunos { get; }
    public Professor Professor { get; private set; }

    public Curso(string? nome)
    {
        Id = _contador++;
        Nome = nome;
        Alunos = new List<Aluno>();
        Professor = new Professor();
    }

    public bool Adicionar(Aluno aluno)
    {
        if (Alunos.Contains(aluno)) return false;
        
        Alunos.Add(aluno);
        aluno.Adicionar(this);
        return true;

    }
    
    public void Adicionar(Professor professor)
    {
        Professor = professor;
    }

    public string Listar()
    {
        var lista = string.Empty;

        Alunos.ForEach(aluno => lista += $"{aluno.Nome}, Id: {aluno.Id}\n");
        
        return lista;
    }

    public Aluno? Pegar(int id)
    {
        return Alunos.Find(aluno => aluno.Id.Equals(id));
    }

    public void Atualizar(string? nome)
    {
        Nome = nome;
    }

    public bool Remover(int id)
    {
        var aluno = Pegar(id);
        return aluno != null && Alunos.Remove(aluno);
    }
    
    public void Remover()
    {
        Professor = new Professor();
    }
}