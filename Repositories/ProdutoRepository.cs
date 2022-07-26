using Dapper;
using ProjetoAula05.Configurations;
using ProjetoAula05.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Repositories
{
    public class ProdutoRepository
    {
        private object connection;
        private string sql;
        private object idProduto;

        public void Create(Produto produto)
        {
            var sql = @"
                INSERT INTO PRODUTO(
                IDPRODUTO,
                NOME,
                PRECO,
                QUANTIDADE,
                DATACADASTRO)
             VALUES(
                  @IdProduto,
                  @Nome,
                  @Preco,
                  @Quantidade,
                  @DataCadastro)
            ";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(sql, produto);

            }
        }
        public void Update(Produto produto)
        {
            var sql = @"
                UPDATE PRODUTO
                SET
                NOME  = @Nome,
                PRECO = @Preco,
                QUANTIDADE = @Quantidade
             WHERE
                 IDPRODUTO = @IdProduto

           
          ";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(sql, produto);
            }

        }
        public void Delete(Produto produto)
        {
            var sql = @"        
               DELETE FROM PRODUTO
               WHERE IDPRODUTO = @IdProduto
               ";

            using (var connection = new SqlConnection
           (SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute(sql, produto);
            }
        }
        public List<Produto> GetAll()
        {
            var sql = @"
              SELECT * FROM PRODUTO
            ORDER BY NOME";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(sql).ToList();
            }
                    
  
               }
        public Produto GetById(Guid idProduto)
        {
            var sql = @"
        SELECT * FROM PRODUTO
         WHERE IDPRODUTO = @idProduto
           ";
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Produto>(sql, new { idProduto }).FirstOrDefault();
            }


        }
    }
}
