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
using Models;
// =============================================================
// Main "CategoryController" code
namespace Controllers
{
    public class CategoryCtrl
    {
        // =====================================================
        // [INSERT] new category
        public static Categoria InsertCategory(
            string Nome,
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Campo nome é obrigatorio");
            }
            return new Categoria(Nome, Descricao);
        }
        // =====================================================
        // [UPDATE] existing category
        public static void UpdateCategory(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = Models.Categoria.GetCategoria(Id);
            if (!String.IsNullOrEmpty(Nome))
            {
                categoria.Nome = Nome;
            }
            if (!String.IsNullOrEmpty(Descricao))
            {
                categoria.Descricao = Descricao;
            }
            Categoria.AlterarCategoria(Id, Nome, Descricao);
        }
        // =====================================================
        // [SELECT] categories
        // ======================
        // Select [ALL]
        public static IEnumerable<Categoria> ViewCategories()
         {
             return Models.Categoria.GetCategorias();  
         }
        // ======================
        // Select [SINGLE]         
        public static Categoria ViewCategory(int Id)
        {
            return Models.Categoria.GetCategoria(Id);
        }
        // =====================================================
        // [DELETE] category
        public static Categoria DeleteCategory(int Id)
        {
            Categoria categoria = Models.Categoria.GetCategoria(Id);
            Categoria.RemoverCategoria(categoria);
            return categoria;
        }
        // =====================================================
    }
}
// =============================================================