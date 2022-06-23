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
// Main "PasswordController" code
namespace Controllers
{
    public class PassCtrl
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
        public static void UpdatePass(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario, 
            string SenhaEncrypt, 
            string Procedimento)
        {
            Senha senha = Models.Senha.GetSenha(Id);
            if (!String.IsNullOrEmpty(Nome))
            {
                senha.Nome = Nome;
            }
            if (CategoriaId != 0)
            {
                senha.CategoriaId = CategoriaId;
            }
            if (!String.IsNullOrEmpty(Url))
            {
                senha.Url = Url;
            }
             if (!String.IsNullOrEmpty(Usuario))
            {
                senha.Usuario = Usuario;
            }
            if (!String.IsNullOrEmpty(SenhaEncrypt))
            {
                senha.SenhaEncrypt = SenhaEncrypt;
            }
            if (!String.IsNullOrEmpty(Procedimento))
            {
                senha.Procedimento = Procedimento;
            }
            Senha.AlterarSenha(Id,Nome,CategoriaId,Url,Usuario,SenhaEncrypt,Procedimento);
        }
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