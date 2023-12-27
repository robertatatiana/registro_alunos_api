using Microsoft.AspNetCore.Mvc;
using RegistroAlunos.Models;
using RegistroAlunos.Repositorios.Interfaces;

namespace RegistroAlunos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosAlunos()
        {
            List<Aluno> alunos = await _alunoRepositorio.BuscarTodosAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAlunoPorId(int id)
        {
            Aluno aluno = await _alunoRepositorio.BuscarAlunoPorId(id);

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAluno([FromBody] Aluno aluno)
        {
            Aluno alunoAdicionado = await _alunoRepositorio.AdicionarAluno(aluno);

            return Ok(alunoAdicionado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAluno([FromBody] Aluno aluno, int id)
        {
            Aluno alunoAtualizado = await _alunoRepositorio.AtualizarAluno(aluno, id);

            return Ok(alunoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAluno(int id)
        {
            bool alunoDeletado = await _alunoRepositorio.DeletarAluno(id);

            return Ok(alunoDeletado);
        }
    }
}
