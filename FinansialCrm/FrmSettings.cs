using FinansialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using static FinansialCrm.Program;

namespace FinansialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {

            int userId = Session.UserId; // Giriş yapan kullanıcının ID'sini al

            // Kullanıcının verilerini çek
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            lblusername.Text = "HOŞGELDİN " + user.Username.ToUpper();


            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            int userId = Session.UserId; // Giriş yapan kullanıcının ID'sini al

            // Kullanıcının verilerini çek
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                MessageBox.Show("Kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Eski şifre kontrolü
            if (user.Password != txtOldPassword.Text)
            {
                MessageBox.Show("Eski şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni şifreler eşleşiyor mu?
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Yeni şifreler uyuşmuyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni şifre eski şifreyle aynı mı? (Güvenlik için)
            if (txtNewPassword.Text == txtOldPassword.Text)
            {
                MessageBox.Show("Yeni şifre eski şifreyle aynı olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şifreyi güncelle
            user.Password = txtNewPassword.Text;
            db.SaveChanges();

            MessageBox.Show("Şifreniz başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBillings frmBillings = new FrmBillings();
            frmBillings.Show();
            this.Hide();
        }

        private void btnSpendingd_Click(object sender, EventArgs e)
        {
            FrmSpending frmSpendingd = new FrmSpending();   
            frmSpendingd.Show();
            this.Hide();
        }

        private void btnBankProcesses_Click(object sender, EventArgs e)
        {
            FrmBankProcess frmBankProcess = new FrmBankProcess();
            frmBankProcess.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard(); 
            frmDashboard.Show();
            this.Hide();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }
    }
}
