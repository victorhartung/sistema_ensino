using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaEnsino.models;

namespace SistemaEnsino.Tests.src.models;

[TestClass]
[TestSubject(typeof(Professor))]
public class ProfessorTest
{

    [TestMethod]
    public void DeveConstruirSemParametros()
    {
        var professor = new Professor();

        Assert.IsNotNull(professor);
        Assert.IsNotNull(professor.Id);
        Assert.IsNull(professor.Nome);
        Assert.IsNull(professor.Email);
        Assert.AreEqual(0, professor.Idade);
    }
    
    [TestMethod]
    public void DeveConstruirComTodosParametros()
    {
        var professor = new Professor("Rosen", "rosen@email.com", 38);

        Assert.IsNotNull(professor);
        Assert.IsNotNull(professor.Id);
        Assert.AreEqual("Rosen", professor.Nome);
        Assert.AreEqual("rosen@email.com", professor.Email);
        Assert.AreEqual(38, professor.Idade);
    }
}