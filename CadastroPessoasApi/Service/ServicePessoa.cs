using CadastroPessoasApi.Data;
using CadastroPessoasApi.ViewModel;

namespace CadastroPessoasApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();
            return repository.GettAll().ToList();

        }
        public PessoaViewModel GetById(int pessoaId)
        {
            var repository = new Repository();
            return repository.GetById(pessoaId);
        
        }
        public PessoaViewModel GetByprimeironome(string primeiroNome)
        { 
            var repository = new Repository();
            return repository.GetByprimeironome(primeiroNome);


        }
        public void Update(int pessoaId, string primeiroNome)
        {
            var repository = new Repository();
             repository.Update(pessoaId, primeiroNome);
        
        }
        public dynamic Create(PessoaViewModel pessoa) 
        {
            if (pessoa == null)
                return "os dados são obrigatorios";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.NomeMeio))
                return "o campo nomeMeio é obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.UltimoNome))
                return "o campo ultimoNome é obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "o campo cpf é obrigatorio";

            var repository = new Repository();
            return repository.Create(pessoa);
                    
           
            
                
            
            
        
        }





    }
}
