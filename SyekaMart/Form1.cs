using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyekaMart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbSyeka.marts' table. You can move, or remove it, as needed.
            this.martsTableAdapter.Fill(this.dbSyeka.marts);
            martsBindingSource.DataSource = this.dbSyeka.marts;
        }

        private void btTambah_Click(object sender, EventArgs e)
        {
            try {
                this.dbSyeka.marts.AddmartsRow(this.dbSyeka.marts.NewmartsRow());
                martsBindingSource.MoveLast();
                martsBindingSource.EndEdit();
                martsTableAdapter.Update(this.dbSyeka.marts);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                martsBindingSource.ResetBindings(false);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                martsBindingSource.EndEdit();
                martsTableAdapter.Update(this.dbSyeka.marts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                martsBindingSource.ResetBindings(false);
            }
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("kamu akan menghapus item ini?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                martsBindingSource.RemoveCurrent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
