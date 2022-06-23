// =============================================================
// Use this if you want a "quick" read: 
// CTRL + F then [<type of operation>]
// [TST] Insert implemented, need testing
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
// Main "PassTagController" code
namespace Controllers
{
    public class PassTagCtrl
    {
        // =====================================================
        // [INSERT] new "pass tag" relation
        public static SenhaTag InserirSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            PassCtrl.ViewPass(SenhaId);
            TagCtrl.ViewTag(TagId);

            return new SenhaTag(SenhaId, TagId);
        }
        public static SenhaTag GetSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            return SenhaTag.GetSenhaTag(SenhaId, TagId);
        }

        public static IEnumerable<SenhaTag> GetSenhaTags()  
        {
            return SenhaTag.GetSenhaTags();
        }

        public static SenhaTag GetById(
            int Id
        )  
        {
            return SenhaTag.GetById(Id);
        }
        // =====================================================
        // [DELETE] "pass tag" relation
        public static Usuario DeleteUser(int Id)
        {
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            Usuario.RemoverUsuario(usuario);
            return usuario;
        }
        // =====================================================
    }
}
// =============================================================