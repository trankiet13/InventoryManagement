using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BusinessLayer;
using TransferObject;

namespace InventoryManagement.View
{
    public partial class frmProductStatistical : Form
    {
        private List<Product> _products;
        private UserBL userBL = new UserBL();

        public frmProductStatistical(List<Product> products)
        {
            InitializeComponent();
            _products = products;
        }

        private void frmProductStatistical_Load(object sender, EventArgs e)
        {
            if (_products == null || _products.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu sản phẩm để thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // --- Chart DVT (Modern Dashboard Style) ---
            chartDVT.Series.Clear();
            chartDVT.ChartAreas.Clear();
            chartDVT.Titles.Clear();
            chartDVT.Legends.Clear();

            var areaDVT = new ChartArea("AreaDVT")
            {
                BackColor = Color.FromArgb(30, 35, 70), 
            };
            areaDVT.AxisX.Title = "Đơn vị tính";
            areaDVT.AxisX.TitleForeColor = Color.White;
            areaDVT.AxisX.LabelStyle.Angle = -45;
            areaDVT.AxisX.LabelStyle.ForeColor = Color.White;
            areaDVT.AxisX.LineColor = Color.White;
            areaDVT.AxisX.MajorGrid.Enabled = false;

            areaDVT.AxisY.Title = "Số lượng";
            areaDVT.AxisY.TitleForeColor = Color.White;
            areaDVT.AxisY.LabelStyle.ForeColor = Color.White;
            areaDVT.AxisY.LineColor = Color.White;
            areaDVT.AxisY.MajorGrid.LineColor = Color.Gray;

            chartDVT.ChartAreas.Add(areaDVT);

            // Dữ liệu thống kê theo DVT
            var groupedByDVT = _products
                .Where(p => !string.IsNullOrEmpty(p.DVT))
                .GroupBy(p => p.DVT)
                .Select(g => new { DVT = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList();

            // Cấu hình series
            Series seriesDVT = new Series("Số lượng sản phẩm")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Color = Color.DeepSkyBlue,
                LabelForeColor = Color.White
            };

            foreach (var item in groupedByDVT)
            {
                seriesDVT.Points.AddXY(item.DVT, item.Count);
            }

            chartDVT.Series.Add(seriesDVT);

            // Cấu hình tiêu đề
            chartDVT.Titles.Add("Số lượng sản phẩm theo Đơn vị tính");
            chartDVT.Titles[0].ForeColor = Color.White;
            chartDVT.Titles[0].Font = new Font("Segoe UI", 14, FontStyle.Bold);

            // Nền biểu đồ chung
            chartDVT.BackColor = Color.FromArgb(30, 35, 70);


            // --- Chart Nhóm ---
            chartNhom.Series.Clear();
            chartNhom.ChartAreas.Clear();
            chartNhom.Titles.Clear();
            chartNhom.Legends.Clear();

            chartNhom.ChartAreas.Add(new ChartArea("AreaNhom"));
            chartNhom.ChartAreas[0].BackColor = Color.FromArgb(30, 35, 70);

            var groupedByGroup = _products
                .Where(p => !string.IsNullOrEmpty(p.IDNHOM))
                .GroupBy(p => p.IDNHOM)
                .Select(g => new { IDNHOM = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList();

            Series seriesNhom = new Series("Tỷ lệ nhóm sản phẩm")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                LabelForeColor = Color.White
            };

            foreach (var item in groupedByGroup)
            {
                seriesNhom.Points.AddXY(item.IDNHOM, item.Count);
            }

            seriesNhom["PieLabelStyle"] = "Outside";
            seriesNhom["PieLineColor"] = "White";
            seriesNhom.Label = "#PERCENT{P1}";
            seriesNhom.LegendText = "#VALX";

            chartNhom.Series.Add(seriesNhom);
            chartNhom.Titles.Add("Tỷ lệ sản phẩm theo Nhóm");
            chartNhom.Titles[0].ForeColor = Color.White;
            chartNhom.Titles[0].Font = new Font("Segoe UI", 14, FontStyle.Bold);
            chartNhom.Legends.Add(new Legend("LegendNhom") { Docking = Docking.Right });
            chartNhom.BackColor = Color.FromArgb(30, 35, 70);

            // hiển thị số lượng các label
            lbTotalProduct.Text = $"Tổng sản phẩm: {_products.Count}";
            int totalUsers = userBL.GetAccounts().Count;
            lbTotalUser.Text = $"Tổng user: {totalUsers}";


            // Đảm bảo label luôn hiển thị trên cùng
            lbTotalProduct.BringToFront();
            lbTotalUser.BringToFront();

            pnlTotal.Controls.Add(linkProduct);
            pnlTotal.Controls.Add(linkUser);
        }

        private void linkProduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProductView frm = new frmProductView();
            frm.Show();
        }

        private void linkUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmViewUser frm = new frmViewUser();
            frm.Show();
        }
    }
}
