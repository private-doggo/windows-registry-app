using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsRegistryApp
{
  public class Data
  {

    static public TreeNode selectedNode;

    static public ArrayList regKeysList = new ArrayList();
    public static string newRegKeyName { get; set; }

    public static RegistryValueKind newParType { get; set; }
    public static string newParName { get; set; }
    public static string newParValue { get; set; }
  }
}
