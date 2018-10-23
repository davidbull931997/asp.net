using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolWFApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private async void LoadStudents()
        {
            var list = await Functions.GetStudents();
            if (list != null)
            {
                var rs = from s in list
                         select new
                         {
                             s.Id,
                             s.StudentName,
                             s.Birthday
                         };
                dgvStudent.DataSource = rs.ToList();
            }
            else
            {
                MessageBox.Show("Error get student");
            }
        }

        private void dgvStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvStudent.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            frmStudent f = new frmStudent(id);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadStudents();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStudent f = new frmStudent(0);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadStudents();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 0) return;

            var selectedIndex = dgvStudent.SelectedRows;
            if (MessageBox.Show(
                "Are you sure to delete this student",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(dgvStudent.SelectedRows[0].Cells["Id"].Value.ToString());
                if (await Functions.DeleteStudent(id))
                {
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("Fail to delete student");
                }
            }
        }
    }
}
