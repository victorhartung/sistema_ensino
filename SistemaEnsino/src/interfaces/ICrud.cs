namespace SistemaEnsino.interfaces;

public interface ICrud<T>
{
    bool Adicionar(T t);
    string Listar();
    T? Pegar(int id);
    void Atualizar(string? nome);
    bool Remover(int id);
}