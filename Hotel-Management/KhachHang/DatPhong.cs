using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Hotel_Management
{
    public partial class DatPhong : DevComponents.DotNetBar.RibbonForm
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        public DatPhong()
        {
            InitializeComponent();
            dataGridViewX2.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch(dataGridViewX2.Columns[e.ColumnIndex].Name)
            {
                case "Column1":
                    _Rectangle = dataGridViewX2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    break;
                case "Column10":
                    _Rectangle = dataGridViewX2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    break;
            }
        }
        private void dtp_TextChange(object sender,EventArgs e)
        {
            dataGridViewX2.CurrentCell.Value = dtp.Text.ToString();
        }
    }
}