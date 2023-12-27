using Microsoft.EntityFrameworkCore;
using RegistroAlunos.Data;
using RegistroAlunos.Models;
using RegistroAlunos.Repositorios.Interfaces;

namespace RegistroAlunos.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public AlunoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Aluno>> BuscarTodosAlunos()
        {
            return await _appDbContext.Alunos.Where(x => x.Ativo).ToListAsync();
        }

        public async Task<Aluno> BuscarAlunoPorId(int id)
        {
            var aluno = await _appDbContext.Alunos.FirstOrDefaultAsync(x => x.Id == id && x.Ativo);

            if(aluno == null) 
            {
                throw new Exception("Aluno não encontrado");
            }

            return aluno;  
        }

        public async Task<Aluno> AdicionarAluno(Aluno aluno)
        {
            await _appDbContext.Alunos.AddAsync(aluno);
            _appDbContext.SaveChanges();

            return aluno;
        }

        public async Task<Aluno> AtualizarAluno(Aluno aluno, int id)
        {
            Aluno alunoId = await BuscarAlunoPorId(id);

            if(alunoId == null)
            {
                throw new Exception("Aluno não encontrado");
            }

            alunoId.Nome = aluno.Nome;
            alunoId.NotaGlobal = aluno.NotaGlobal;
            alunoId.Matricula = aluno.Matricula;
            alunoId.Ativo = aluno.Ativo;   

            _appDbContext.Alunos.Update(alunoId);
            _appDbContext.SaveChanges();

            return alunoId;
        }

        public async Task<bool> DeletarAluno(int id)
        {
            Aluno alunoId = await BuscarAlunoPorId(id);

            if (alunoId == null)
            {
                throw new Exception("Aluno não encontrado");
            }

            alunoId.Ativo = false;

            _appDbContext.Alunos.Update(alunoId);
            _appDbContext.SaveChanges();

            return true;
        }
    }
}
