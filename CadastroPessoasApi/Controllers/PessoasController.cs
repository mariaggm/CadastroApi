using CadastroPessoasApi.Service;
using CadastroPessoasApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        [HttpGet("getAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var service = new ServicePessoa();
            return service.GetAll();


        }
        [HttpGet("GetById/{pessoaId}")]
        public PessoaViewModel GetById(int pessoaId)
        {
            var service = new ServicePessoa();
            return service.GetById(pessoaId);

        }
        [HttpGet("GetByprimeironome{primeiroNome}")]
        public PessoaViewModel GetByprimeironome(string primeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByprimeironome(primeiroNome);

        }
        [HttpPut("Update/{pessoaId}/{primeiroNome}")]
        public void Update(int pessoaId, string primeiroNome)
        {
            var service = new ServicePessoa();
             service.Update(pessoaId, primeiroNome);
        
        }
        [HttpPost("Create")]
        public ActionResult Create (PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            var result = new
            {
                Success = true,
                Data = resultado,


            };
            return Ok(result);
        
        }
      
        
        
        
    }
}
