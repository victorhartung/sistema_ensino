using SistemaEnsino.interfaces;

namespace SistemaEnsino.models;

public class Aluno : Pessoa, ICrud<Curso>
{
    public string Matricula { get; set; }
    public List<Curso> Cursos { get; }

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
        return curso != null && Cursos.Remove(curso);
    }
}