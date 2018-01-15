using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proj.Models;

namespace Proj.Repositorio
{
    public class CidadeRep
    {
        string ConnectionString = @"Data source=.\SqlExpress;Initial Catalog=ProjetoCidades;User Id=sa;Password=senai@123;";
        //variavel de conexão
        SqlConnection Cn;
        //função para listar todos os dads do banco, retorna eles dentro de uma lista
        public List<Cidade> ListarCidades()
        {
            //lista de cidades
            List<Cidade> Cidades = new List<Cidade>();
            //criando a conexão
            SqlConnection Cn = new SqlConnection(ConnectionString);
            //variavel com query
            string SqlQuery = "SELECT * FROM Cidades";
            //lendo query e definindo em qual conexão ela será realizada
            SqlCommand Cmd = new SqlCommand(SqlQuery, Cn);
            //abrindo conexão
            Cn.Open();
            //executando leitura
            SqlDataReader Sdr = Cmd.ExecuteReader();
            //loop para ler os dados do banco e jogar dentro da lista
            while (Sdr.Read())
            {
                //construindo objetos
                Cidade cidade = new Cidade(Convert.ToInt32(Sdr["Id"]), Sdr["Nome"].ToString(), Sdr["Estado"].ToString(), Convert.ToInt32(Sdr["Habitantes"]));
                //inserindo na lista
                Cidades.Add(cidade);
            }
            //fechando conexão
            Cn.Close();
            //retornando a lista
            return Cidades;
        }

        public List<Cidade> ListarCidades(int Id)
        {
            List<Cidade> Cidades = new List<Cidade>();
            //criando a conexão
            SqlConnection Cn = new SqlConnection(ConnectionString);
            //variavel com query
            string SqlQuery = "SELECT * FROM Cidades WHERE Id = @Id";
            //lendo query e definindo em qual conexão ela será realizada
            SqlCommand Cmd = new SqlCommand(SqlQuery, Cn);
            Cmd.Parameters.AddWithValue("@Id", Id);
            //abrindo conexão
            Cn.Open();
            //executando leitura
            SqlDataReader Sdr = Cmd.ExecuteReader();
            //loop para ler os dados do banco e jogar dentro da lista
            if (Sdr.Read())
            {
                 //construindo objetos
                Cidade cidade = new Cidade(Convert.ToInt32(Sdr["Id"]), Sdr["Nome"].ToString(), Sdr["Estado"].ToString(), Convert.ToInt32(Sdr["Habitantes"]));
                //inserindo na lista
                Cidades.Add(cidade);
            }
            //fechando conexão
            Cn.Close();
            //retornando a lista
            return Cidades;
        }

        public void Cadastrar(Cidade cidade)
        {
            SqlConnection Cn = new SqlConnection(ConnectionString);
            string SqlQuery = "INSERT INTO Cidades(Nome, Estado, Habitantes)VALUES('" + cidade.Nome + "','" + cidade.Estado + "','" + cidade.Habitantes + "')";
            SqlCommand Cmd = new SqlCommand(SqlQuery, Cn);
            Cn.Open();
            Cmd.ExecuteNonQuery();
            Cn.Close();
        }

        public string Editar(Cidade cidade)
        {
            string msg;
            try
            {
                Cn = new SqlConnection(ConnectionString);
                string SqlQuery = "UPDATE Cidades SET Nome = @n, Estado = @e, Habitantes = @h WHERE Id = @Id";
                SqlCommand Cmd = new SqlCommand(SqlQuery, Cn);
                Cmd.Parameters.AddWithValue("@n", cidade.Nome);
                Cmd.Parameters.AddWithValue("@e", cidade.Estado);
                Cmd.Parameters.AddWithValue("@h", cidade.Habitantes);
                Cmd.Parameters.AddWithValue("@Id", cidade.Id);
                Cn.Open();
                int r = Cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    msg = "Atualização efetuada com sucesso.";
                }
                else
                {
                    msg = "Não foi possivel atualizar.";
                }

                Cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar dados: " + se.Message);
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao realizar processo: " + e.Message);
            }
            finally
            {
                Cn.Close();
            }
            return msg;
        }

        public string Deletar(int Id)
        {
            string msg = "";
            try
            {
                Cn = new SqlConnection(ConnectionString);
                Cn.Open();
                string SqlQuery = "DELETE FROM Cidades WHERE Id= @Id";
                SqlCommand cmd = new SqlCommand(SqlQuery,Cn);
                cmd.Parameters.AddWithValue("@Id", Id);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    msg = "dado deletado com sucesso.";
                }
                else
                {
                    msg = "não foi possivel apagar.";
                }
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar apagar dados: " + se.Message);
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro inesperado: " + e.Message);
            }
            finally
            {
                Cn.Close();
            }
            return msg;
        }
    }
}