using System;
using System.Collections.Generic;
using APIUsuarios.DTO;
using MySql.Data.MySqlClient;

namespace APIUsuarios.DAO
{
    public class UsuarioDAO
    {
        public List<UsuarioDTO> ListarUsuarios()
        {
            var usuarios = new List<UsuarioDTO>();
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();
                var query = "SELECT * FROM Usuarios";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    using (var dataReader = comando.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var usuario = new UsuarioDTO();
                            usuario.ID_Usu = Convert.ToInt32(dataReader["ID_Usu"]);
                            usuario.Nome = dataReader["Nome"].ToString();
                            usuario.Email = dataReader["Email"].ToString();
                            usuario.Telefone = dataReader["Telefone"].ToString();
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        public void Cadastrar(UsuarioDTO usuario)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();
                var query = @"INSERT INTO Usuarios (Nome, Email, Telefone) VALUES 
                            (@nome, @email, @telefone)";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", usuario.Nome);
                    comando.Parameters.AddWithValue("@email", usuario.Email);
                    comando.Parameters.AddWithValue("@telefone", usuario.Telefone);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public bool VerificarUsuario(UsuarioDTO usuario)
        {
            bool usuarioExiste = false;
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();
                var query = "SELECT COUNT(*) FROM Usuarios WHERE Email = @email";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@email", usuario.Email);
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    usuarioExiste = count > 0;
                }
            }
            return usuarioExiste; 
        }
    }
}
