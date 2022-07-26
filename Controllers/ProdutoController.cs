using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Controllers
{
    public class ProdutoController
    {
        public void CadastrarProduto()
        {

            try
            {
                var produto = new Produto();
                produto.IdProduto = Guid.NewGuid();
                produto.DataCadastro = DateTime.Now;

                Console.Write("Entre com o nome do produto...:");
                produto.Nome = Console.ReadLine();

                Console.Write("Entre com o preço do produto...:");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Entre com a quantidade do produto...:");
                produto.Quantidade = int.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Create(produto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao cadastrar produto: {e.Message}");

            }
        }
        public void ExcluirProduto()
        {
            try
            {
                Console.WriteLine("\n ***EXCLUSÃO DE PRODUTO***\n");
                Console.WriteLine("Entre com o ID do produto desejado....:");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);
                if(produto != null)
                {
                    produtoRepository.Delete(produto);
                    Console.WriteLine("\n PRODUTO EXCLUÍDO COM SUCESSO NO BANCO DE DADOS");

                }
                else
                {
                    Console.WriteLine("\nProduto não encontrado, verifique o ID informado.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"\nFalha ao excluir produto: {e.Message}");
            }
        }
        public void AtualizarProduto()
        {
            try
            {
                Console.WriteLine("\n *** ATUALIZAÇÃO DE PRODUTO***\n");
                Console.WriteLine("Entre com o ID do produto desejado.....:");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);


                if(produto != null)
                {
                    Console.WriteLine("Entre com o novo nome produto.....:");
                    produto.Nome = Console.ReadLine();

                    Console.WriteLine("Entre com o novo preço do produto.....:");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                   Console.WriteLine("Entre com a nova quantidade do produto.....:");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                   produtoRepository.Update(produto);
                    Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO NO BANCO DE DADOS!");
                    
                }

                else
                {
                    Console.WriteLine("\nProduto não encontrado, verifique o ID informado.");
                }


            }catch(Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar produto: {e.Message}");
            }
        }
        
        public void ConsultarProduto()
        {
            try
            {
                Console.WriteLine("\n *** CONSULTA DE PRODUTO***\n");

                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.GetAll();

                foreach (var item in produtos)
                {
                    Console.WriteLine($"Id do produto......:{item.IdProduto}");
                    Console.WriteLine($"Nome do produto......:{item.Nome}");
                    Console.WriteLine($"Quantidade do produto......:{item.Quantidade}");
                    Console.WriteLine($"Preço do produto......:{item.Preco}");
                    Console.WriteLine($"Data/Hora de Cadastro......:{item.DataCadastro}"); ;
                    Console.WriteLine("...");

                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"\nFalha ao excluir produto: {e.Message}");
            }
        }
    }
}


