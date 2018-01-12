using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proj.Models;

namespace Proj.Repositorio
{
    public class CidadeRep
    {
        string ConnectionString = @"Data source=.\SqlExpress;Initial Catalog=ProjetoCidades;User Id=sa;Password=senai@123;";

        public List<Cidade> ListarCidades()
        {
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

        public void Cadastrar(Cidade cidade)
        {
            SqlConnection Cn = new SqlConnection(ConnectionString);
            string SqlQuery = "INSERT INTO Cidades(Nome, Estado, Habitantes)VALUES('" + cidade.Nome + "','" + cidade.Estado + "','" + cidade.Habitantes + "')";
            SqlCommand Cmd = new SqlCommand(SqlQuery, Cn);
            Cn.Open();
            Cmd.ExecuteNonQuery();
            Cn.Close();
        }
    }
}