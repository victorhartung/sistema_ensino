using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaEnsino.models;

namespace SistemaEnsino.Tests.models;

[TestClass]
[TestSubject(typeof(Curso))]
public class CursoTest
{

    [TestMethod]
    public void DeveConstruir()
    {
        var curso = new Curso("curso");
        
        Assert.IsNotNull(curso);
        Assert.IsNotNull(curso.Id);
        Assert.AreEqual("curso", curso.Nome);
        Assert.AreEqual(0, curso.Alunos.Count);
        Assert.IsNotNull(curso.Professor);
    }
    
    [TestMethod]
    public void DeveAdicionarAluno()
    {
        var curso = new Curso("C#");
        var aluno = new Aluno("nome", "email", 1, "1");

        var resultado = curso.Adicionar(aluno);
        
        Assert.IsTrue(resultado);
        Assert.AreEqual(1, aluno.Cursos.Count);
    }
    
    [TestMethod]
    public void NaoDeveAdicionarAluno()
    {
        var curso = new Curso("C#");
        var aluno = new Aluno("nome", "email", 1, "1");

        curso.Adicionar(aluno);
        var resultado = curso.Adicionar(aluno);
        
        Assert.IsFalse(resultado);
        Assert.AreEqual(1, curso.Alunos.Count);
    }
    
    [TestMethod]
    public void DeveAdicionarProfessor()
    {
        var curso = new Curso("C#");
        var professor = new Professor("nome", "email", 1);

        curso.Adicionar(professor);
        
        Assert.AreEqual("nome", curso.Professor.Nome);
        Assert.AreEqual("email", curso.Professor.Email);
        Assert.AreEqual(1, curso.Professor.Idade);
    }
    
    [TestMethod]
    public void DeveListarAlunos()
    {
        var curso = new Curso("C#");
        var aluno = new Aluno("nome", "email", 1, "1");
        
        curso.Adicionar(aluno);

        var resultado = curso.Listar();
        var id = aluno.Id;
        
        Assert.AreEqual($"nome, Id: {id}\n", resultado);
    }
    
    [TestMethod]
    public void DeveAcharAluno()
    {
        var curso = new Curso("C#");
        var aluno = new Aluno("nome", "email", 1, "1");
        
        curso.Adicionar(aluno);

        var resultado = curso.Pegar(aluno.Id);
        
        Assert.IsNotNull(resultado);
    }
    
    [TestMethod]
    public void NaoDeveAcharAluno()
    {
        var curso = new Curso("C#");
        var aluno = new Aluno("nome", "email", 1, "1");
        
        curso.Adicionar(aluno);

        var resultado = curso.Pegar(aluno.Id + 1);
        
        Assert.IsNull(resultado);
    }
    
    [TestMethod]
    public void DeveAtualizarNome()
    {
        var curso = new Curso("C#");

        curso.Atualizar("nome2");
        
        Assert.AreEqual("nome2", curso.Nome);
    }
    
    [TestMethod]
    public void DeveRemoverAluno()
    {
        var curso = new Curso("C#");
        var aluno = new Aluno("nome", "email", 1, "1");

        curso.Adicionar(aluno);

        var resultado = curso.Remover(aluno.Id);
        
        Assert.IsTrue(resultado);
    }
    
    [TestMethod]
    public void NaoDeveRemoverAluno()
    {
        var curso = new Curso("C#");

        var resultado = curso.Remover(1);
        
        Assert.IsFalse(resultado);
    }
    
    [TestMethod]
    public void DeveRemoverProfessor()
    {
        var curso = new Curso("C#");
        curso.Adicionar(new Professor("nome", "email", 1));

        curso.Remover();
        
        Assert.IsNull(curso.Professor.Nome);
        Assert.IsNull(curso.Professor.Email);
        Assert.AreEqual(0, curso.Professor.Idade);
    }
}