// =============================================================
// System libs.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
// =============================================================
// Repository related files.
using Views.Lib;
using Controllers;
// =============================================================
// Main "UpdateCategory" code
namespace Views
{
    public class UpdateCategory : BaseForm
    {
        CatgCrud parent;
        FieldForm fieldNome;
        FieldForm fieldDescricao;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public UpdateCategory(CatgCrud parent) : base("UpdateCategory",SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Nome",20,20,260,20);
            fieldDescricao = new FieldForm("Descricao",20,100,260,60);

			btnConfirmar = new ButtonForm("Confirmar", 100, 180, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 100, 220, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                ListViewItem item = this.parent.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                CategoryCtrl.UpdateCategory(
                    id,
                    this.fieldNome.txtField.Text,
                    this.fieldDescricao.txtField.Text
                );
                this.parent.LoadInfo();
                this.parent.Show();
                this.Close();
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    
    }
}
// =============================================================