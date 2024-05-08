using SistemaEnsino.interfaces;

namespace SistemaEnsino.models;

public class Aluno : Pessoa, ICrud<Curso>
{
    public string Matricula { get; }
    public List<Curso> Cursos { get; } //relacionamento de curso com aluno

    public Aluno(string? nome, string? email, int idade, string matricula) : base(nome, email, idade)
    {
        Nome = nome;
        Email = email;
        Matricula = matricula;
        Cursos = new List<Curso>();
    }

    public bool Adicionar(Curso curso)
    {
        if (Cursos.Contains(curso)) return false;
        
        Cursos.Add(curso);
        curso.Adicionar(this);
        return true;
    }

    public string Listar()
    {
        var lista = string.Empty;

        Cursos.ForEach(curso => lista += $"{curso.Nome}, Professor: {curso.Professor.Nome}, Id: {curso.Id}\n");
        
        return lista;
    }

    public Curso? Pegar(int id)
    {
        return Cursos.Find(curso => curso.Id.Equals(id));
    }

    public void Atualizar(string? nome)
    {
        Nome = nome;
    }

    public bool Remover(int id)
    {
        var curso = Pegar(id);
        
        if (curso == null) return false;
        
        Cursos.Remove(curso);
        curso.Remover(Id);
        return true;
    }
}