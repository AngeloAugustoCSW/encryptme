// =============================================================
// System libs.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// =============================================================
// Repository related files.
using Controllers;
using Views.Lib;
// =============================================================
// Main "RegisterUser" code
namespace Views
{
    public class RegisterUser : BaseForm
    {
        private System.ComponentModel.IContainer components = null;
        Label lblNome;
        Label lblEmail;
        Label lblSenha;
        
        TextBox txtNome;
        TextBox txtEmail;
        TextBox txtSenha;
        
        Button btnConfirmar;
        Button btnCancelar;
        public RegisterUser() : base("Registrar", SizeScreen.Small)
        {
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(130, 30);
            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(60, 60);
            this.txtNome.Size = new Size(180, 20);
            this.lblEmail = new Label();
            this.lblEmail.Text = "E-mail";
            this.lblEmail.Location = new Point(130, 90);
            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(60, 115);
            this.txtEmail.Size = new Size(180, 20);
            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(130, 140);
            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(60, 170);
            this.txtSenha.Size = new Size(180, 20);
            this.btnConfirmar = new ButtonForm("Confirmar", 100, 200, this.btnConfirmarClick);
            this.btnCancelar = new ButtonForm("Cancelar",100, 230, this.btnCancelarClick);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Cadastro Usuário";
        }
        private void btnCancelarClick(object sender, EventArgs e)
           {
                this.Close();
           }

           public void btnConfirmarClick(object sender, EventArgs e)
        {
            try 
            {
            string message = "Usuário cadastrado com sucesso!";
            string caption = "SUCCESS";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            UserCtrl.InsertUser(this.txtNome.Text, this.txtEmail.Text, this.txtSenha.Text);
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
           {
            	this.Close();
           }
            }catch(Exception){
            string message = "Dados inválidos, tente novamente";
            string caption = "ERROR";
            MessageBox.Show(message, caption);
            }
        }
    }
}
// =============================================================