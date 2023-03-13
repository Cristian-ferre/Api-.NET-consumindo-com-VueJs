using FuncionarioApi.Context;
using FuncionarioApi.Entities;
using Microsoft.AspNetCore.Mvc;
namespace FuncionarioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntranetController : ControllerBase
    {
        
        private readonly FuncionarioContext _context;

        public IntranetController(FuncionarioContext context)
        {
            _context = context;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Create(Funcionario funcionario)
        {
            
            _context.Add(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }
        [HttpGet]
        public IActionResult Obter()
        {
            var tudinho = _context.Funcionarios.ToList();
            return Ok(tudinho);
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome (string Nome)
        {
            var funcionario = _context.Funcionarios.Where(x => x.NomeFuncionario.Contains(Nome));
            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var funcionarioBanco = _context.Funcionarios.Find(id);
            if (funcionarioBanco == null)
            {
                return NotFound();
            }
            _context.Funcionarios.Remove(funcionarioBanco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarStatus(int id, Funcionario funcionario)
        {
            var funcionarioBanco = _context.Funcionarios.Find(id);

            if (funcionarioBanco == null)
                return NotFound();

            funcionarioBanco.Re = funcionario.Re;
            funcionarioBanco.Ramal = funcionario.Ramal;
            funcionarioBanco.NomeFuncionario = funcionario.NomeFuncionario;
            funcionarioBanco.Email = funcionario.Email;
            funcionarioBanco.Imagem = funcionario.Imagem;

            _context.Funcionarios.Update(funcionarioBanco);
            _context.SaveChanges();
            return Ok(funcionarioBanco);
        }


    }
}