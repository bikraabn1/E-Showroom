using System;
using System.Drawing;
using System.Windows.Forms;
using E_Showroom.model;
using E_Showroom.view;
using E_Transport.view;

namespace E_Showroom
{
    public partial class Dashboard : Form
    {
        private UserModel _userModel;
        private VehicleModel _vehicleModel;
        private ClientModel _clientModel;
        private SaleModel _saleModel;
        private Control[] originalControls; 
        private bool isDashboardMode = true;

        public Dashboard()
        {
            InitializeComponent();
            _userModel = new UserModel();

            this.Load += Dashboard_FullyLoaded;
        }

        private void Dashboard_FullyLoaded(object sender, EventArgs e)
        {
            SaveOriginalControls();
            LoadUserCount();
            LoadVehicleCount();
            LoadClientCount();
            LoadSalesmentCount();
        }

        private void SaveOriginalControls()
        {
            try
            {
                if (panel3 != null && panel3.Controls.Count > 0)
                {
                    originalControls = new Control[panel3.Controls.Count];
                    for (int i = 0; i < panel3.Controls.Count; i++)
                    {
                        originalControls[i] = panel3.Controls[i];
                    }
                }
                else
                {
                    originalControls = new Control[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving controls: {ex.Message}");
                originalControls = new Control[0];
            }
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

                Label lblUserCount = FindLabelUserCount();
                if (lblUserCount != null)
                {
                    lblUserCount.Text = userCount ?? "0";
                }
                else
                {
                    MessageBox.Show("lblUserCount not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user count: {ex.Message}");

                Label lblUserCount = FindLabelUserCount();
                if (lblUserCount != null)
                {
                    lblUserCount.Text = "0";
                }
            }
        }
        void LoadVehicleCount()
        {
            try
            {
                if (_vehicleModel == null)
                {
                    _vehicleModel = new VehicleModel();
                }

                string vehicleCount = _vehicleModel.getTotalVehicle();

                Label lblVehicleCount = FindLabelVehicleCount();
                if (lblVehicleCount != null)
                {
                    lblVehicleCount.Text = vehicleCount ?? "0";
                }
                else
                {
                    MessageBox.Show("lblVehicleCount not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicle count: {ex.Message}");

                Label lblVehicleCount = FindLabelVehicleCount();
                if (lblVehicleCount != null)
                {
                    lblVehicleCount.Text = "0";
                }
            }
        }
        void LoadClientCount()
        {
            try
            {
                if (_clientModel == null)
                {
                    _clientModel = new ClientModel();
                }

                string clientCount = _clientModel.getTotalClient();

                Label lblClientCount = FindLabelClientCount();
                if (lblClientCount != null)
                {
                    lblClientCount.Text = clientCount ?? "0";
                }
                else
                {
                    MessageBox.Show("lblPelangganCount not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading client count: {ex.Message}");

                Label lblClientCount = FindLabelVehicleCount();
                if (lblClientCount != null)
                {
                    lblClientCount.Text = "0";
                }
            }
        }
        void LoadSalesmentCount()
        {
            try
            {
                if (_saleModel == null)
                {
                    _saleModel = new SaleModel();
                }

                string salesmentCount = _saleModel.getJumlahPenjualan();

                Label lblSalesmentCount = FindLabelSalesmentCount();
                if (lblSalesmentCount != null)
                {
                    lblSalesmentCount.Text = salesmentCount ?? "0";
                }
                else
                {
                    MessageBox.Show("lblPenjualanCount not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading salesment count: {ex.Message}");

                Label lblSalesmentCount = FindLabelSalesmentCount();
                if (lblSalesmentCount != null)
                {
                    lblSalesmentCount.Text = "0";
                }
            }
        }

        private Label FindLabelUserCount()
        {
            try
            {
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

        private Label FindLabelVehicleCount()
        {
            try
            {
                if (originalControls != null && originalControls.Length > 0)
                {
                    foreach (Control control in originalControls)
                    {
                        if (control != null && control is Label && control.Name == "lblKendaraanCount")
                        {
                            return (Label)control;
                        }
                    }
                }

                if (panel3 != null && panel3.Controls.Count > 0)
                {
                    foreach (Control control in panel3.Controls)
                    {
                        if (control != null && control is Label && control.Name == "lblKendaraanCount")
                        {
                            return (Label)control;
                        }
                    }
                }

                Control[] allControls = this.Controls.Find("lblKendaraanCount", true);
                if (allControls.Length > 0 && allControls[0] is Label)
                {
                    return (Label)allControls[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding lblKendaraanCount: {ex.Message}");
                return null;
            }
        }
        private Label FindLabelClientCount()
        {
            try
            {
                if (originalControls != null && originalControls.Length > 0)
                {
                    foreach (Control control in originalControls)
                    {
                        if (control != null && control is Label && control.Name == "lblPelangganCount")
                        {
                            return (Label)control;
                        }
                    }
                }

                if (panel3 != null && panel3.Controls.Count > 0)
                {
                    foreach (Control control in panel3.Controls)
                    {
                        if (control != null && control is Label && control.Name == "lblPelangganCount")
                        {
                            return (Label)control;
                        }
                    }
                }

                Control[] allControls = this.Controls.Find("lblPelangganCount", true);
                if (allControls.Length > 0 && allControls[0] is Label)
                {
                    return (Label)allControls[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding lblKendaraanCount: {ex.Message}");
                return null;
            }
        }
        private Label FindLabelSalesmentCount()
        {
            try
            {
                if (originalControls != null && originalControls.Length > 0)
                {
                    foreach (Control control in originalControls)
                    {
                        if (control != null && control is Label && control.Name == "lblPenjualanCount")
                        {
                            return (Label)control;
                        }
                    }
                }

                if (panel3 != null && panel3.Controls.Count > 0)
                {
                    foreach (Control control in panel3.Controls)
                    {
                        if (control != null && control is Label && control.Name == "lblPenjualanCount")
                        {
                            return (Label)control;
                        }
                    }
                }

                Control[] allControls = this.Controls.Find("lblPenjualanCount", true);
                if (allControls.Length > 0 && allControls[0] is Label)
                {
                    return (Label)allControls[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding lblPenjualanCount: {ex.Message}");
                return null;
            }
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

                    LoadUserCount(); 
                    LoadVehicleCount(); 
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
                if (!isDashboardMode)
                {
                    RestoreDashboard();
                }
                else
                {
                    LoadUserCount();
                    LoadVehicleCount();
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
                LoadUserControl(new UserControl1());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button2_Click: {ex.Message}");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new VehicleView());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button2_Click: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new VehicleCategoryView());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button2_Click: {ex.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new ClientView());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button2_Click: {ex.Message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserControl(new SalesmentView());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in button2_Click: {ex.Message}");
            }
        }
    }
}