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
            // nodes images adding

            ImageList regImageList = new ImageList();
            regImageList.Images.Add(Image.FromFile(@"img/folder.png"));
            treeView_registryKeys.ImageList = regImageList;

            // filling treeView with keys

            treeView_registryKeys.Nodes.Add(new TreeNode("Computer"));

            RegistryKey[] regKeyArray = new RegistryKey[] { //Registry.ClassesRoot, // causes StackOverFlowExeption
                                                            Registry.CurrentUser,
                                                            Registry.LocalMachine,
                                                            Registry.Users,
                                                            Registry.CurrentConfig,
                                                            // Registry.PerformanceData // old
															// Registry.DynData // old
			                                                };

            foreach (RegistryKey key in regKeyArray)
            {
                TreeNode node = new TreeNode() { Name = "key", Text = key.ToString() };
                treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "Computer").Nodes.Add(node);
            }

            treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "Computer").Expand();

            foreach (RegistryKey key in regKeyArray)
            {
                foreach (String subKey in key.GetSubKeyNames())
                {
                    TreeNode subNode = new TreeNode() { Name = "key", Text = subKey };
                    treeView.FindNodeByName(treeView_registryKeys.Nodes[0], key.ToString()).Nodes.Add(subNode);

                    try
                    {
                        RegistryKey subKeyOpened = key.OpenSubKey(subKey);

                        foreach (String subSubKey in subKeyOpened.GetSubKeyNames())
                        {
                            TreeNode subSubNode = new TreeNode() { Name = "key", Text = subSubKey };
                            treeView.FindNodeByName(treeView_registryKeys.Nodes[0], subKey).Nodes.Add(subSubNode);

                            RegistryKey subSubKeyOpened = key.OpenSubKey(subKey + @"\" + subSubKey);

                            foreach (String subSubSubKey in subSubKeyOpened.GetSubKeyNames())
                            {
                                TreeNode subSubSubNode = new TreeNode() { Name = "key", Text = subSubSubKey };
                                treeView.FindNodeByName(treeView_registryKeys.Nodes[0], subSubKey).Nodes.Add(subSubSubNode);

                                RegistryKey subSubSubKeyOpened = key.OpenSubKey(subKey + @"\" + subSubKey + @"\" + subSubSubKey);

                                foreach (String subSubSubSubKey in subSubSubKeyOpened.GetSubKeyNames())
                                {
                                    TreeNode subSubSubSubNode = new TreeNode() { Name = "key", Text = subSubSubSubKey };
                                    treeView.FindNodeByName(treeView_registryKeys.Nodes[0], subSubSubKey).Nodes.Add(subSubSubSubNode);

                                    RegistryKey subSubSubSubKeyOpened = key.OpenSubKey(subKey + @"\" + subSubKey + @"\" + subSubSubKey + @"\" + subSubSubSubKey);

                                    foreach (String subSubSubSubSubKey in subSubSubSubKeyOpened.GetSubKeyNames())
                                    {
                                        TreeNode subSubSubSubSubNode = new TreeNode() { Name = "key", Text = subSubSubSubKey };
                                        treeView.FindNodeByName(treeView_registryKeys.Nodes[0], subSubSubSubKey).Nodes.Add(subSubSubSubSubNode);

                                        // here it's possible to add more nested levels
                                    }

                                    key.Close();

                                    break;
                                }

                                key.Close();

                                break;
                            }

                            key.Close();
                        }

                        key.Close();
                    }
                    catch { }
                }
            }

        }

        ArrayList path = new ArrayList();
        String textbox_path_str;

        private void treeView_registryKeys_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // showing selected key path

            TreeNode tempNode = treeView_registryKeys.SelectedNode;

            path.Clear();

            for (; ; )
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
                textbox_path_str += tn + @"\";
            }

            textBox_path.Text = textbox_path_str;

            // showing name, type and value of selected key


        }
    }
}
