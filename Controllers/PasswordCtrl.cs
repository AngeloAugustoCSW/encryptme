// =============================================================
// Use this if you want a "quick" read: 
// CTRL + F then [<type of operation>]
// [TST] Insert implemented, need testing
// [WIP] Update not implemented
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
// Main "PasswordController" code
namespace Controllers
{
    public class SenhasCtrl
    {
        // =====================================================
        // [INSERT] new password
        public static Senha InsertPass(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario, 
            string SenhaEncrypt, 
            string Procedimento)
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome de usuário inválido");
            }
            return new Senha(Nome,CategoriaId,Url,Usuario,SenhaEncrypt,Procedimento);
        }
        // =====================================================
        // [UPDATE] existing password
        // =====================================================
        // [SELECT] password
        // ======================
        // Select [ALL]
        public static IEnumerable<Senha> ViewPasses()
        {
            return Models.Senha.GetSenhas();
        }
        // ======================
        // Select [SINGLE]
        public static Senha ViewPass(int Id)
        {
            return Models.Senha.GetSenha(Id);
        }
        // =====================================================
        // [DELETE] password
         public static Senha DeletePass(int Id)
        {
            Senha senhas = Models.Senha.GetSenha(Id);
            Senha.RemoverSenha(senhas);
            return senhas;
        }
        // =====================================================
    }
}
// =============================================================