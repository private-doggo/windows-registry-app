using Microsoft.Win32;
using System;
using System.Collections;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // filling treeView with keys

            treeView_registryKeys.Nodes.Add(new TreeNode("Computer"));

            RegistryKey[] regKeyArray = new RegistryKey[] { Registry.ClassesRoot,
                                                            Registry.CurrentUser,
                                                            Registry.LocalMachine,
                                                            Registry.Users,
                                                            Registry.CurrentConfig,
                                                            // Registry.PerformanceData
															// Registry.DynData
			                                                };

            foreach (RegistryKey key in regKeyArray)
            {
                TreeNode node = new TreeNode() { Name = "node", Text = key.ToString() };
                treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "Computer").Nodes.Add(node);
            }

            treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "Computer").Expand();

            String[] regClassesRootKeyArray = new String[1000];
            regClassesRootKeyArray = Registry.ClassesRoot.GetSubKeyNames();

            foreach (String subKey in regClassesRootKeyArray)
            {
                TreeNode node = new TreeNode() { Name = "node", Text = subKey };
                treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "HKEY_CLASSES_ROOT").Nodes.Add(node);
            }

            String[] regCurrentUserKeyArray = new String[1000];
            regCurrentUserKeyArray = Registry.CurrentUser.GetSubKeyNames();

            foreach (String subKey in regCurrentUserKeyArray)
            {
                TreeNode node = new TreeNode() { Name = "node", Text = subKey };
                treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "HKEY_CURRENT_USER").Nodes.Add(node);
            }

            String[] regLocalMachineKeyArray = new String[1000];
            regLocalMachineKeyArray = Registry.LocalMachine.GetSubKeyNames();

            foreach (String subKey in regLocalMachineKeyArray)
            {
                TreeNode node = new TreeNode() { Name = "node", Text = subKey };
                treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "HKEY_LOCAL_MACHINE").Nodes.Add(node);
            }

            String[] regUsersKeyArray = new String[1000];
            regUsersKeyArray = Registry.Users.GetSubKeyNames();

            foreach (String subKey in regUsersKeyArray)
            {
                TreeNode node = new TreeNode() { Name = "node", Text = subKey };
                treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "HKEY_USERS").Nodes.Add(node);
            }

            String[] regCurrentConfigKeyArray = new String[1000];
            regCurrentConfigKeyArray = Registry.CurrentConfig.GetSubKeyNames();

            foreach (String subKey in regCurrentConfigKeyArray)
            {
                TreeNode node = new TreeNode() { Name = "node", Text = subKey };
                treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "HKEY_CURRENT_CONFIG").Nodes.Add(node);
            }
        }

        ArrayList path = new ArrayList();
        String textbox_path_str;

        private void treeView_registryKeys_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tempNode = treeView_registryKeys.SelectedNode;

            path.Clear();

            for (int i = 0; i < 100; i++)
            {
                path.Add(tempNode.Text);

                if (tempNode.Parent == null)
                {
                    break;
                }
                else
                {
                    tempNode = tempNode.Parent;
                }
            }

            textbox_path_str = "";

            path.Reverse();

            foreach (String tn in path)
            {
                textbox_path_str += "/ " + tn;
            }

            textBox_path.Text = textbox_path_str;
        }
    }
}
