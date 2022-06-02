// =============================================================
// Use this if you want a "quick" read: 
// CTRL + F then [<type of operation>]
// [WIP] Insert not implemented
// [WIP] Update not implemented
// [TST] Select implemented, need testing
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
// Main "PasswordController" code
namespace Controllers
{
    public class SenhasCtrl
    {
        // =====================================================
        // [INSERT] new password
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
        // =====================================================
    }
}
// =============================================================