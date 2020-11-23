using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsRegistryApp
{
    public partial class sectionCreationForm : Form
    {
        public sectionCreationForm()
        {
            InitializeComponent();
        }

        private void button_createSection_Click(object sender, EventArgs e)
        {
            if (textBox_sectionName.Text != "")
            {
                Data.newRegKeyName = textBox_sectionName.Text;

                this.Close();
            }
            else
            {
                MessageBox.Show("Section name can't be empty");
            }
        }
    }
}
