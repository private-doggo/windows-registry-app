using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsRegistryApp
{
    class treeView
    {
        static public TreeNode FindNodeByName(TreeNode root, string name)
        {
            if (root == null)
                return null;

            if (root.Text == name)
                return root;
            return FindNodeByName(root.FirstNode, name) ?? FindNodeByName(root.NextNode, name);
        }
    }
}
