using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
using System.Windows.Forms;

namespace WFMulti
{
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string idade { get; set; }

        MySqlConnection con = new MySqlConnection("server=db4free.net;port=3306;database=aula2023;user id=camargo;password=abc321973;charset=utf8");

        public List<Pessoa> listapessoa()
        {
            List<Pessoa> li = new List<Pessoa>();
            string sql = "SELECT * FROM pessoa";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pessoa p = new Pessoa();
                p.id = (int)dr["id"];
                p.nome = dr["nome"].ToString();
                p.idade = dr["idade"].ToString();
                li.Add(p);
            }
            dr.Close();
            con.Close();
            return li;
        }
        public void Inserir(string nome, string idade)
        {
            string sql = "INSERT INTO pessoa(nome,idade) VALUES ('" + nome + "','" + idade + "')";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Atualizar(int id, string nome, string idade)
        {
            string sql = "UPDATE pessoa SET nome='" + nome + "',idade='" + idade + "' WHERE id= '" + id + "')";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM pessoa WHERE id='" + id + "'";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int id)
        {
            string sql = "SELECT * FROM pessoa WHERE id='" + id + "'";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                idade = dr["idade"].ToString();
            }
            dr.Close();
            con.Close();

        }
        public bool RegistroRepitido(string nome, string idade)
        {
            string sql = "SELECT * FROM pessoa WHERE nome='" + nome + "' AND idade='" + idade + "'";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return (int)result > 0;
            }
            con.Close();
            return false;

        }
    }
}