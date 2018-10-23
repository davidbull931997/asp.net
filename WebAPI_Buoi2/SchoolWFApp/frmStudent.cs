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
    public partial class frmStudent : Form
    {
        int id = 0;
        Student student;
        public frmStudent(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void frmStudent_Shown(object sender, EventArgs e)
        {
            if (id == 0)
            {
                //add new student
                student = new Student()
                {
                    Gender = "Male",
                    Birthday = DateTime.Now
                };
            }
            else
            {
                //edit existed student
                student = await Functions.GetStudent(id);
                if (student == null)
                {
                    MessageBox.Show("Error load student");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }
            bindingSource1.DataSource = student;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                //add new student
                if (await Functions.PostStudent(student))
                {
                    //add success
                    MessageBox.Show("Add new student success");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    //add fail
                    MessageBox.Show("Add new student fail, please try again later");
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                //update existed student
                if (await Functions.PutStudent(student))
                {
                    //add success
                    MessageBox.Show("Update student success");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    //add fail
                    MessageBox.Show("Update student fail, please try again later");
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
