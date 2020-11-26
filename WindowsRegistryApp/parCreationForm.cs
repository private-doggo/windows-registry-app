using Microsoft.Win32;
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
  public partial class parCreationForm : Form
  {
    public parCreationForm()
    {
      InitializeComponent();

      /*Reg.regValueKindsList.Add("REG_SZ");
      Reg.regValueKindsList.Add("REG_EXPAND_SZ");
      Reg.regValueKindsList.Add("REG_BINARY");
      Reg.regValueKindsList.Add("REG_DWORD");
      Reg.regValueKindsList.Add("REG_MULTI_SZ");
      Reg.regValueKindsList.Add("REG_QWORD");*/

      comboBox_parData.DataSource = Reg.regValueKindsList;

    }

    private void button_parCreate_Click(object sender, EventArgs e)
    {
      Data.newParName = textBox_parName.Text;
      Data.newParType = (RegistryValueKind)Enum.Parse(typeof(Reg.RegistryValueKindNative), comboBox_parData.SelectedItem.ToString());
      Data.newParValue = textBox_parValue.Text;

      RegistryKey selRegKeyOpened = Reg.GetRegistryKeyByName(Data.selectedNode.Parent.Text, Data.regKeysList).OpenSubKey(Data.selectedNode.Text);

      selRegKeyOpened.SetValue(Data.newParName, Data.newParValue, Data.newParType);

      this.Close();
    }
  }
}
