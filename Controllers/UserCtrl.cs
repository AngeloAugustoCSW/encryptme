// =============================================================
// Use this if you want a "quick" read: 
// CTRL + F then [<type of operation>]
// [TST] Insert implemented, need testing
// [WIP] Update not implemented
// [WIP] Select not implemented
// [WIP] Delete not implemented
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
        
        // =====================================================
        // [SELECT] user
        // ======================
        // Select [ALL] users
        
        // ======================
        // Select [SINGLE] user
        
        // =====================================================
        // [DELETE] user
        
        // =====================================================
    }
}
// =============================================================