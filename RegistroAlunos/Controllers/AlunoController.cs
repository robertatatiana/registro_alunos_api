using Microsoft.AspNetCore.Mvc;
using RegistroAlunos.Models;
using RegistroAlunos.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Obtém todos os alunos cadastrados.
        /// </summary>
        /// <returns>Lista de alunos</returns>
        [HttpGet]
        public async Task<IActionResult> BuscarTodosAlunos()
        {
            List<Aluno> alunos = await _alunoRepositorio.BuscarTodosAlunos();
            return Ok(alunos);
        }

        /// <summary>
        /// Obtém um aluno pelo seu ID.
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <returns>O aluno correspondente ao ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAlunoPorId(int id)
        {
            Aluno aluno = await _alunoRepositorio.BuscarAlunoPorId(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        /// <summary>
        /// Adiciona um novo aluno.
        /// </summary>
        /// <param name="aluno">Dados do aluno a ser adicionado</param>
        /// <returns>O aluno recém-adicionado</returns>
        [HttpPost]
        public async Task<IActionResult> AdicionarAluno([FromBody] Aluno aluno)
        {
            Aluno alunoAdicionado = await _alunoRepositorio.AdicionarAluno(aluno);

            return Ok(alunoAdicionado);
        }

        /// <summary>
        /// Atualiza um aluno pelo seu ID.
        /// </summary>
        /// <param name="id">ID do aluno a ser atualizado</param>
        /// <param name="aluno">Dados do aluno atualizado</param>
        /// <returns>O aluno atualizado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAluno([FromBody] Aluno aluno, int id)
        {
            Aluno alunoAtualizado = await _alunoRepositorio.AtualizarAluno(aluno, id);

            if (alunoAtualizado == null)
            {
                return NotFound();
            }

            return Ok(alunoAtualizado);
        }

        /// <summary>
        /// Deleta um aluno pelo seu ID.
        /// </summary>
        /// <param name="id">ID do aluno a ser deletado</param>
        /// <returns>True se o aluno foi deletado com sucesso</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAluno(int id)
        {
            bool alunoDeletado = await _alunoRepositorio.DeletarAluno(id);

            if (!alunoDeletado)
            {
                return NotFound();
            }

            return Ok(alunoDeletado);
        }
    }
}
