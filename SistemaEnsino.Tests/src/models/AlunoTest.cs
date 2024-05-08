using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaEnsino.models;

namespace SistemaEnsino.Tests.models;

[TestClass]
[TestSubject(typeof(Aluno))]
public class AlunoTest
{

    [TestMethod]
    public void DeveConstruir()
    {
        var aluno = new Aluno("Pablo", "pablo@email.com", 20, "1234567890");
        
        Assert.IsNotNull(aluno);
        Assert.IsNotNull(aluno.Id);
        Assert.AreEqual("Pablo", aluno.Nome);
        Assert.AreEqual("pablo@email.com", aluno.Email);
        Assert.AreEqual(20, aluno.Idade);
        Assert.AreEqual("1234567890", aluno.Matricula);
        Assert.AreEqual(0, aluno.Cursos.Count);
    }
    
    [TestMethod]
    public void DeveAdicionarCurso()
    {
        var aluno = new Aluno("nome", "email", 1, "1");
        var curso = new Curso("C#");

        var resultado = aluno.Adicionar(curso);
        
        Assert.IsTrue(resultado);
        Assert.AreEqual(1, aluno.Cursos.Count);
    }
    
    [TestMethod]
    public void NaoDeveAdicionarCurso()
    {
        var aluno = new Aluno("nome", "email", 1, "1");
        var curso = new Curso("C#");

        aluno.Adicionar(curso);
        var resultado = aluno.Adicionar(curso);
        
        Assert.IsFalse(resultado);
        Assert.AreEqual(1, aluno.Cursos.Count);
    }
    
    [TestMethod]
    public void DeveListarCursos()
    {
        var aluno = new Aluno("nome", "email", 1, "1");
        var curso = new Curso("C#");
        
        curso.Adicionar(new Professor("professor", "email", 1));
        aluno.Adicionar(curso);

        var resultado = aluno.Listar();
        var id = curso.Id;
        
        Assert.AreEqual($"C#, Professor: professor, Id: {id}\n", resultado);
    }
    
    [TestMethod]
    public void DeveAcharCurso()
    {
        var aluno = new Aluno("nome", "email", 1, "1");
        var curso = new Curso("C#");
        
        aluno.Adicionar(curso);

        var resultado = aluno.Pegar(curso.Id);
        
        Assert.IsNotNull(resultado);
    }
    
    [TestMethod]
    public void NaoDeveAcharCurso()
    {
        var aluno = new Aluno("nome", "email", 1, "1");
        var curso = new Curso("C#");
        
        aluno.Adicionar(curso);

        var resultado = aluno.Pegar(curso.Id + 1);
        
        Assert.IsNull(resultado);
    }
    
    [TestMethod]
    public void DeveAtualizarNome()
    {
        var aluno = new Aluno("nome", "email", 1, "1");
        
        aluno.Atualizar("nome2");
        
        Assert.AreEqual("nome2", aluno.Nome);
    }
    
    [TestMethod]
    public void DeveRemoverCurso()
    {
        var aluno = new Aluno("nome", "email", 1, "1");
        var curso = new Curso("C#");

        aluno.Adicionar(curso);

        var resultado = aluno.Remover(curso.Id);
        
        Assert.IsTrue(resultado);
    }
    
    [TestMethod]
    public void NaoDeveRemoverCurso()
    {
        var aluno = new Aluno("nome", "email", 1, "1");

        var resultado = aluno.Remover(1);
        
        Assert.IsFalse(resultado);
    }
}