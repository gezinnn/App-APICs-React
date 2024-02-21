using APIUsuarios.DTO;
using MySql.Data.MySqlClient;

namespace APIUsuarios.DAO
{
    public class UsuarioDAO
    {
            public List<UsuarioDTO> ListarUsuarios()
            {
                var usuarios = new List<UsuarioDTO>();
                var conexao = ConnectionFactory.Build();
                conexao.Open();
                var query = "SELECT*FROM Usuarios";
                var comando = new MySqlCommand(query, conexao);
                var dataReader = comando.ExecuteReader();

            while (dataReader.Read())
            {
                var usuario = new UsuarioDTO();
                usuario.ID_Usu = int.Parse(dataReader["ID_Usu"].ToString());
                usuario.Nome = dataReader["Nome"].ToString();
                usuario.Email = dataReader["Email"].ToString();
                usuario.Telefone = dataReader["Telefone"].ToString();

                usuarios.Add(usuario);

            }
                conexao.Close();
                return usuarios;
            }        
    }
}
