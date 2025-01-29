using FinansialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using static FinansialCrm.Program;

namespace FinansialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
                {
                    Session.UserId = user.UserId;
                    MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ana ekrana yönlendirme yapılabilir
                    this.Hide(); // Giriş formunu kapat
                    FrmBanks mainForm = new FrmBanks(); // Ana formu aç
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            btnTogglePassword.Text = "🙈";
        }

        private void btnKayıt_Click(object sender, EventArgs e)
        {
            FrmKayıt frmKayıt = new FrmKayıt();
            frmKayıt.Show();
            this.Hide();
        }

        

       

        private void btnTogglePassword_CheckedChanged(object sender, EventArgs e)
        {
            // Şifre alanı gizli mi kontrol et
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0'; // Şifreyi göster
                btnTogglePassword.Text = "🙈"; // Buton ikonunu değiştir
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Şifreyi gizle
                btnTogglePassword.Text = "👁"; // Buton ikonunu değiştir
            }
        }
    }
}
