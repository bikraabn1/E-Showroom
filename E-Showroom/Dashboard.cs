using System;
using System.Drawing;
using System.Windows.Forms;
using E_Showroom.model;
using E_Transport.view;

namespace E_Showroom
{
    public partial class Dashboard : Form
    {
        private UserModel _userModel;
        private Control[] originalControls; // Simpan controls asli
        private bool isDashboardMode = true;

        public Dashboard()
        {
            InitializeComponent();
            _userModel = new UserModel();

            // Delay save controls sampai form fully loaded
            this.Load += Dashboard_FullyLoaded;
        }

        private void Dashboard_FullyLoaded(object sender, EventArgs e)
        {
            // Simpan controls setelah form fully loaded
            SaveOriginalControls();
            LoadUserCount();
        }

        private void SaveOriginalControls()
        {
            try
            {
                if (panel3 != null && panel3.Controls.Count > 0)
                {
                    // Simpan semua controls asli dari panel3
                    originalControls = new Control[panel3.Controls.Count];
                    for (int i = 0; i < panel3.Controls.Count; i++)
                    {
                        originalControls[i] = panel3.Controls[i];
                    }
                }
                else
                {
                    // Jika panel3 kosong, buat array kosong
                    originalControls = new Control[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving controls: {ex.Message}");
                originalControls = new Control[0];
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Method ini dipanggil otomatis, kosongkan saja atau pindah ke FullyLoaded
        }

        void LoadUserCount()
        {
            try
            {
                if (_userModel == null)
                {
                    _userModel = new UserModel();
                }

                string userCount = _userModel.getTotalUser();

                // Cari lblUserCount dengan lebih aman
                Label lblUserCount = FindLabelUserCount();
                if (lblUserCount != null)
                {
                    lblUserCount.Text = userCount ?? "0";
                }
                else
                {
                    // Debug: tampilkan pesan jika lblUserCount tidak ditemukan
                    MessageBox.Show("lblUserCount not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user count: {ex.Message}");

                // Tetap coba set lblUserCount ke "0" jika ada error
                Label lblUserCount = FindLabelUserCount();
                if (lblUserCount != null)
                {
                    lblUserCount.Text = "0";
                }
            }
        }

        private Label FindLabelUserCount()
        {
            try
            {
                // Method 1: Cari di controls asli (jika ada)
                if (originalControls != null && originalControls.Length > 0)
                {
                    foreach (Control control in originalControls)
                    {
                        if (control != null && control is Label && control.Name == "lblUserCount")
                        {
                            return (Label)control;
                        }
                    }
                }

                // Method 2: Cari di panel3 yang aktif
                if (panel3 != null && panel3.Controls.Count > 0)
                {
                    foreach (Control control in panel3.Controls)
                    {
                        if (control != null && control is Label && control.Name == "lblUserCount")
                        {
                            return (Label)control;
                        }
                    }
                }

                // Method 3: Cari di seluruh form (fallback)
                Control[] allControls = this.Controls.Find("lblUserCount", true);
                if (allControls.Length > 0 && allControls[0] is Label)
                {
                    return (Label)allControls[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding lblUserCount: {ex.Message}");
                return null;
            }
        }

        private void lblUserCount_Click(object sender, EventArgs e)
        {
        }

        private void LoadUserControl(UserControl control)
        {
            try
            {
                if (panel3 != null && control != null)
                {
                    panel3.Controls.Clear();
                    control.Dock = DockStyle.Fill;
                    panel3.Controls.Add(control);
                    isDashboardMode = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user control: {ex.Message}");
            }
        }

        private void RestoreDashboard()
        {
            try
            {
                if (panel3 != null)
                {
                    panel3.Controls.Clear();

                    // Restore semua controls asli ke panel3
                    if (originalControls != null && originalControls.Length > 0)
                    {
                        foreach (Control control in originalControls)
                        {
                            if (control != null)
                            {
                                panel3.Controls.Add(control);
                            }
                        }
                    }

                    LoadUserCount(); // Refresh user count
                    isDashboardMode = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring dashboard: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Tombol Dashboard - kembali ke dashboard
                if (!isDashboardMode)
                {
                    RestoreDashboard();
                }
                else
                {
                    // Jika sudah di dashboard, refresh user count saja
                    LoadUserCount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button1_Click: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Tombol User Management
                LoadUserControl(new UserControl1());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button2_Click: {ex.Message}");
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}