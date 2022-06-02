// =============================================================
// Use this if you want a "quick" read: 
// CTRL + F then [<type of operation>]
// [TST] Insert implemented, need testing
// [WIP] Update not implemented, 
// [WIP] Select not implemented, 
// [WIP] Delete not implemented, 
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
// Main "TagController" code
namespace Controllers
{
    public class TagCtrl
    {
        // =====================================================
        // [INSERT] new tag
        public static Tag InsertTag(string Descricao)
        {
            if (String.IsNullOrEmpty(Descricao)) 
            {
                throw new Exception("Campo descrição é obrigatório");
            }
            return new Tag(Descricao);
        }
        // =====================================================
        // [UPDATE] existing tag
        
        // =====================================================
        // [SELECT] tag
        // ======================
        // Select [ALL] tags
        
        // ======================
        // Select [SINGLE] tag
        
        // =====================================================
        // [DELETE] tag
        
        // =====================================================
    }
}
// =============================================================