using RegistroAlunos.Models;

namespace RegistroAlunos.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<List<Aluno>> BuscarTodosAlunos();
        Task<Aluno> BuscarAlunoPorId(int id);
        Task<Aluno> AdicionarAluno(Aluno aluno);
        Task<Aluno> AtualizarAluno(Aluno aluno, int id);
        Task<bool> DeletarAluno(int id);
    }
}
