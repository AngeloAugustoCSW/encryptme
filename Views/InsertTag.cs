// =============================================================
// System libs.
using System;
using System.Windows.Forms;
// =============================================================
// Repository related files.
using Views.Lib;
using Controllers;
// =============================================================
// Main "" code
namespace Views
{
    public class InsertTag : BaseForm
    {
        TagCrud parent;
        FieldForm fieldDescricao;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public InsertTag(TagCrud parent) : base("InsertTag",SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldDescricao = new FieldForm("Descrição",20,70,260,50);

			btnConfirmar = new ButtonForm("Confirmar", 100, 180, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 100, 220, this.handleCancel);

            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }
        private void handleConfirm(object sender, EventArgs e)
        {
           try {
                TagCtrl.InsertTag(
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
                this.parent.Show();
                this.Close();
            }
        }
    
    }
}
// =============================================================