using CadastroPessoasApi.ViewModel;
using Dapper;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace CadastroPessoasApi.Data
{
    public class Repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CadastroPessoas;Trusted_Connection=True;MultipleActiveResultSets=True"; 
        public IEnumerable<PessoaViewModel> GettAll() 
        {
            string query = "select top 1000 *  from Pessoas "; 
            using (SqlConnection con = new SqlConnection(conexao)) 
            { 
                return con.Query<PessoaViewModel>(query); 
            
            }
        
        }
        public PessoaViewModel GetById(int pessoaId) 
        {
            string query = "Select * from Pessoas where pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { pessoaId = pessoaId } );
            
            }

        
        }
        public PessoaViewModel GetByprimeironome(string primeiroNome) 
        {
            string query = "select * from Pessoas where primeiroNome = @primeiroNome";
            using (SqlConnection con = new SqlConnection(conexao))
            { 
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { primeiroNome = primeiroNome } );
            
            }
        
        }
        public void Update(int pessoaId, string primeiroNome)
        {
            string query = "Update Pessoas set primeiroNome = @primeiroNome where pessoaId = pessoaId"; 
            using (SqlConnection con = new SqlConnection(conexao)) 
            { 
                   con.Execute(query, new { pessoaId = pessoaId, primeiroNome = primeiroNome, }); 
            
            }   
        
        }
        public string Create(PessoaViewModel pessoa)
        {
            try 
            {
                string query = @"
                insert into Pessoas(PrimeiroNome, NomeMeio, UltimoNome, CPF)
                values(@primeiroNome, @nomeMeio, @ultimoNome, @CPf)
                ";
                using (SqlConnection con = new SqlConnection(conexao)) 
                { 
                    con.Execute (query, new
                    {
                        primeiroNome = pessoa.PrimeiroNome,
                        nomeMeio = pessoa.NomeMeio,
                        CPF = pessoa.CPF,
                        ultimoNome = pessoa.UltimoNome,

                    });
                    

                    
                
                }
                return null;

            }
            catch (Exception ex) 
            {
                throw ex; 
            
            }
        
        }

    }
}
