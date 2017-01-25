using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarProject
{
    public partial class MainWindow : Form
    {
        FormWindowState _LastWindowState;

        public MainWindow() {
            InitializeComponent();
            this.ResizeEnd += Window_ResizeEnd;

            this.Resize += MainWindow_Resize;
            _LastWindowState = this.WindowState;

            this.Load += Window_Load;

            cbxType.SelectedValueChanged += Type_ValueMemberChanged;
        }

        private void Window_Load(object sender, EventArgs e) {
            cbxType.SelectedIndex = 0;
        }

        private void MainWindow_Resize(object sender, EventArgs e) {
            //if (WindowState != _LastWindowState) {
            //    this.asGrid1.InitGrid();
            //    _LastWindowState = WindowState;
            //}
        }

        private void Window_ResizeEnd(object sender, EventArgs e) {
            //this.asGrid1.InitGrid();
        }

        private void button1_Click(object sender, EventArgs e) {
            asGrid1.FindPath(chbAllowDiagonal.Checked, chbInstant.Checked);
        }

        private void Type_ValueMemberChanged(object sender, EventArgs e) {
            asGrid.SelectType = (TileType)Enum.Parse(typeof(TileType), cbxType.SelectedItem.ToString());
        }

        private void Generate_Click(object sender, EventArgs e) {
            int seed = 0;
            if (int.TryParse(txtSeed.Text, out seed)) {
                asGrid1.Seed = seed;
                asGrid1.Generate();
            }
        }

        private void btnClearField_Click(object sender, EventArgs e) { asGrid1.Reset(); }

        private void btnClearPath_Click(object sender, EventArgs e) {
            asGrid1.ClearPath();
        }

        private void btnInitTiles_Click(object sender, EventArgs e) {
            asGrid1.Rows = (int)nudRows.Value;
            asGrid1.Colums = (int)nudColums.Value;

            asGrid1.InitTiles();
        }
    }
}
