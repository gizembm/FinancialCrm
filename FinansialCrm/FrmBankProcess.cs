using FinansialCrm.Models;
using System;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using static FinansialCrm.Program;

namespace FinansialCrm
{
    public partial class FrmBankProcess : Form
    {
        public FrmBankProcess()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmBankProcess_Load(object sender, EventArgs e)
        {
            int userId = Session.UserId; // Giriş yapan kullanıcının ID'sini al

            // Kullanıcının verilerini çek
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            label1.Text = "HOŞGELDİN " + user.Username.ToUpper();



            var banks = db.Banks
                      .Select(b => new { b.BankId, b.BankTitle })
                      .ToList();

            cmbBanks.DataSource = banks;
            cmbBanks.DisplayMember = "BankTitle";  // ComboBox'ta bankaların adlarını göster
            cmbBanks.ValueMember = "BankId";      // BankId, seçilen değerin karşılığı olacak
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (cmbBanks.SelectedValue != null) // Eğer combobox'ta seçili bir banka varsa
            {
                int selectedBankId = Convert.ToInt32(cmbBanks.SelectedValue); // Seçili bankanın ID'sini al

                var bankProcesses = db.BankProcesses
                                          .Where(bp => bp.BankId == selectedBankId) // Seçili bankaya ait kayıtları getir
                                          .Select(bp => new
                                          {
                                              bp.Description,
                                              bp.ProcessDate,
                                              bp.ProcessType,
                                              bp.Amount
                                          })
                                          .ToList();

                    dataGridView1.DataSource = bankProcesses; // DataGridView'e verileri ata
                
            }
            else
            {
                MessageBox.Show("Lütfen bir banka seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.ShowDialog();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBillings frmBillings = new FrmBillings();
            frmBillings.ShowDialog();
            this.Hide();
        }

        private void btnSpendingd_Click(object sender, EventArgs e)
        {
            FrmSpending frmSpending = new FrmSpending();
            frmSpending.ShowDialog();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.ShowDialog();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBankProcesses_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}
