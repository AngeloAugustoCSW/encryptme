// =============================================================
// Use this if you want a "quick" read: 
// CTRL + F then [<type of operation>]
// [TST] Insert implemented, need testing
// [TST] Update implemented, need testing
// [TST] Select implemented, need testing
// [TST] Delete implemented, need testing
// =============================================================
// System libs.
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
// =============================================================
// Repository related files
using Repository;
using Models;
// =============================================================
// Main "UserController" code
namespace Controllers
{
    public class UserCtrl
    {
        // =====================================================
        // [INSERT] new user
        public static Usuario InsertUser(
            string Nome,
            string Email,
            string Senha
        )
        {
            if (String.IsNullOrEmpty(Nome)) 
            {
                throw new Exception("Nome obrigatório (Campo inválido ou vazio)");
            }
            Regex rgx = new Regex("^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+(\\.[a-z]+)?$");
            if (String.IsNullOrEmpty(Email) || !rgx.IsMatch(Email))
            {
                throw new Exception("Email inválido");
            }
            if (String.IsNullOrEmpty(Email)) 
            {
                throw new Exception("Email obrigatório (Campo inválido ou vazio)");
            }
            if (String.IsNullOrEmpty(Senha) || Senha.Length <= 8)
            {
                throw new Exception("Senha inválida (Campo inválido ou vazio)");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            return new Usuario(Nome, Email, Senha);
        }
        // =====================================================
        // [UPDATE] existing user
        public static void UpdateUser(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            Usuario usuario = Models.Usuario.GetUsuario(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }
            Regex rgx = new Regex("^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+(\\.[a-z]+)?$");
            if (String.IsNullOrEmpty(Email) || !rgx.IsMatch(Email))
            {
                throw new Exception("Email inválido");
            }
            if (!String.IsNullOrEmpty(Email))
            {
                usuario.Email = Email;
            }
            if (!String.IsNullOrEmpty(Senha))
            {
                
                if (String.IsNullOrEmpty(Senha) || Senha.Length <= 8)
                {
                    throw new Exception("Senha está inválida");
                }
                else
                {
                    Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
                    usuario.Senha = Senha;
                }
            }
            else
            {
                throw new Exception("Senha está inválida");
            }
            Usuario.AlterarUsuario(Id, Nome, Email, Senha);
        }
        // =====================================================
        // [SELECT] user
        // ======================
        // Select [ALL] users
        public static IEnumerable<Usuario> ViewUsers()
        {
            return Models.Usuario.GetUsuarios();  
        }
        // ======================
        // Select [SINGLE] user
        public static Usuario ViewUser(
            int Id
        )
        {
            Usuario usuario = (
                from Usuario in Usuario.GetUsuarios()
                    where Usuario.Id == Id
                    select Usuario
            ).First();
            
            if (usuario == null)
            {
                throw new Exception("Usuario não encontrada");
            }

            return usuario;
        }
        // =====================================================
        // [DELETE] user
        public static Usuario DeleteUser(int Id)
        {
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            Usuario.RemoverUsuario(usuario);
            return usuario;
        }
        // =====================================================
        // [AUTH] user authentication
        public static void Auth(string Email, string Senha) {
            try {
                Usuario.Auth(Email, Senha);
            }
            catch
            {
                throw new Exception("Email ou senha inválido");
            }
        }
    }
}
// =============================================================