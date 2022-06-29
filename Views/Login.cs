// =============================================================
// System libs.
using System;
using System.Windows.Forms;
// =============================================================
// Repository related files.
using Views.Lib;
using Controllers;
// =============================================================
// Main "LoginScreen" code
namespace Views
{
    public class Login : BaseForm
    {
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
		ButtonForm btnConfirmar;
        ButtonForm btnRegistrar;
        ButtonForm btnCancelar;

        public Login() : base("Login", SizeScreen.Small)
        {
            fieldUsuario = new FieldForm("Usuário",20,20,260,20);
            fieldSenha = new FieldForm("Senha",20,100,260,60);
            fieldSenha.txtField.PasswordChar = '*';

			btnConfirmar = new ButtonForm("Confirmar", 100, 180, this.handleConfirm);
            btnRegistrar = new ButtonForm("Registrar", 100, 220, this.handleRegister);
            btnCancelar = new ButtonForm("Cancelar", 100, 260, this.handleCancel);
            
            this.Controls.Add(fieldUsuario.lblField);
            this.Controls.Add(fieldUsuario.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnRegistrar);
            this.Controls.Add(btnCancelar);
        }

         private void handleRegister(object sender, EventArgs e)
        {
            RegisterUser registerUser = new RegisterUser();
            registerUser.ShowDialog();
            
        }
        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                UserCtrl.Auth(
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text
                );
                (new Menu(this)).Show();
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