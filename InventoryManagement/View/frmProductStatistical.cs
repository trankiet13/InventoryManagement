using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TransferObject;

namespace InventoryManagement.View
{
    public partial class frmProductStatistical : Form
    {
        private List<Product> _products;

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

            Chart chartDVT = new Chart();
            Chart chartNhom = new Chart();

            chartDVT.Dock = DockStyle.Left;
            chartNhom.Dock = DockStyle.Fill;

            // Cấu hình Chart Area
            chartDVT.ChartAreas.Add(new ChartArea("AreaDVT"));
            chartNhom.ChartAreas.Add(new ChartArea("AreaNhom"));

            var groupedByDVT = _products
                .Where(p => !string.IsNullOrEmpty(p.DVT))
                .GroupBy(p => p.DVT)
                .Select(g => new
                {
                    DVT = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .ToList();

            Series seriesDVT = new Series
            {
                Name = "Số lượng sản phẩm",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            chartDVT.Series.Add(seriesDVT);

            foreach (var item in groupedByDVT)
            {
                seriesDVT.Points.AddXY(item.DVT, item.Count);
            }

            chartDVT.Titles.Add("Số lượng sản phẩm theo Đơn vị tính");

            var groupedByGroup = _products
                .Where(p => !string.IsNullOrEmpty(p.IDNHOM))
                .GroupBy(p => p.IDNHOM)
                .Select(g => new
                {
                    IDNHOM = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .ToList();

            Series seriesNhom = new Series
            {
                Name = "Tỷ lệ nhóm sản phẩm",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.Black,
                ToolTip = "Nhóm: #VALX\nSố lượng: #VALY\nTỷ lệ: #PERCENT{P1}"
            };
            chartNhom.Series.Add(seriesNhom);

            foreach (var item in groupedByGroup)
            {
                seriesNhom.Points.AddXY(item.IDNHOM, item.Count);
            }

            chartNhom.Titles.Add("Tỷ lệ sản phẩm theo Nhóm");

            // --- Thêm 2 Chart vào Form ---
            this.Controls.Add(chartNhom);
            this.Controls.Add(chartDVT);
        }
    }
}
