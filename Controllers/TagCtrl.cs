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
        public static void UpdateTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = Models.Tag.GetTag(Id);
            if (!String.IsNullOrEmpty(Descricao))
            {
                tag.Descricao = Descricao;
            }
            Tag.AlterarTag(Id, Descricao);
        }
        // =====================================================
        // [SELECT] tag
        // ======================
        // Select [ALL] tags
        public static IEnumerable<Tag> ViewTags()
        {
            return Models.Tag.GetTags();  
        }
        // ======================
        // Select [SINGLE] tag
        public static Tag ViewTag(int Id)
        {
            return Models.Tag.GetTag(Id);
        }
        // =====================================================
        // [DELETE] tag
        public static Tag DeleteTag(int Id)
        {
            Tag tag = Models.Tag.GetTag(Id);
            Tag.RemoverTag(tag);
            return tag;
        }
        // =====================================================
    }
}
// =============================================================