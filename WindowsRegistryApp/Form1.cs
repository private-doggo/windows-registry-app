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
using static WindowsRegistryApp.Reg;

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

			updateRegKeys();

		}

		public void updateRegKeys()
		{
			//listView_regParData.Items.Clear();
			treeView_registryKeys.Nodes.Clear();

			// parsing registry keys & filling treeView with 'em

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

				Data.regKeysList.Add(key);
			}

			treeView.FindNodeByName(treeView_registryKeys.Nodes[0], "Computer").Expand();

			foreach (RegistryKey key in regKeyArray)
			{
				foreach (string subKey in key.GetSubKeyNames())
				{
					TreeNode subNode = new TreeNode() { Name = "key", Text = subKey };
					treeView.FindNodeByName(treeView_registryKeys.Nodes[0], key.ToString()).Nodes.Add(subNode);

					try
					{
						RegistryKey subKeyOpened = key.OpenSubKey(subKey);

						Data.regKeysList.Add(subKeyOpened);

						foreach (string subSubKey in subKeyOpened.GetSubKeyNames())
						{
							TreeNode subSubNode = new TreeNode() { Name = "key", Text = subSubKey };
							treeView.FindNodeByName(treeView_registryKeys.Nodes[0], subKey).Nodes.Add(subSubNode);

							RegistryKey subSubKeyOpened = subKeyOpened.OpenSubKey(subSubKey);

							Data.regKeysList.Add(subSubKeyOpened);

							foreach (string subSubSubKey in subSubKeyOpened.GetSubKeyNames())
							{
								TreeNode subSubSubNode = new TreeNode() { Name = "key", Text = subSubSubKey };
								treeView.FindNodeByName(treeView_registryKeys.Nodes[0], subSubKey).Nodes.Add(subSubSubNode);

								RegistryKey subSubSubKeyOpened = subSubKeyOpened.OpenSubKey(subSubSubKey);

								Data.regKeysList.Add(subSubSubKeyOpened);

								/*
								foreach (string subSubSubSubKey in subSubSubKeyOpened.GetSubKeyNames())
								{
									TreeNode subSubSubSubNode = new TreeNode() { Name = "key", Text = subSubSubSubKey };
									treeView.FindNodeByName(treeView_registryKeys.Nodes[0], subSubSubKey).Nodes.Add(subSubSubSubNode);

									RegistryKey subSubSubSubKeyOpened = subSubSubKeyOpened.OpenSubKey(subSubSubSubKey);

									foreach (string subSubSubSubSubKey in subSubSubSubKeyOpened.GetSubKeyNames())
									{
										TreeNode subSubSubSubSubNode = new TreeNode() { Name = "key", Text = subSubSubSubKey };
										treeView.FindNodeByName(treeView_registryKeys.Nodes[0], subSubSubSubKey).Nodes.Add(subSubSubSubSubNode);

										// here it's possible to add more nested levels
									}

									key.Close();
								}

								key.Close();*/
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
		string textbox_path_str;

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

			foreach (string tn in path)
			{
				textbox_path_str += tn + @"\";
			}

			textBox_path.Text = textbox_path_str;

			// showing name, type and value of selected key

			listView_regParData.Items.Clear();
			RegistryValueKind parType;
			object parValue;
			String parValueString;

			RegistryKey currentRegKey = Reg.GetRegistryKeyByName(treeView_registryKeys.SelectedNode.Text, Data.regKeysList);

			if (currentRegKey != null)
			{
				try
				{
					foreach (string parName in currentRegKey.GetValueNames().OrderBy(x => x))
					{
						parValue = currentRegKey.GetValue(parName);
						parType = currentRegKey.GetValueKind(parName);

						parValueString = (parType == RegistryValueKind.DWord) ? $"0x{((int)parValue).ToString("X2").ToLower().PadLeft(8, '0')} ({(uint)(int)parValue})" : parValue.ToString();

						var parData = new string[] { parName, ((RegistryValueKindNative)parType).ToString(), parValueString};

						var lvi = new ListViewItem(parData);
						listView_regParData.Items.Add(lvi);
					}
				}
				catch { }
			}

		}

		private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView_registryKeys.SelectedNode;

			RegistryKey currentRegKey = Reg.GetRegistryKeyByName(selectedNode.Text, Data.regKeysList);

			if (currentRegKey != null)
			{
				sectionCreationForm sectionCreation = new sectionCreationForm();

				sectionCreation.ShowDialog();

				try
				{
					RegistryKey newRegKey = currentRegKey.CreateSubKey(Data.newRegKeyName);

					selectedNode.Nodes.Add(Data.newRegKeyName);
				}
				catch
				{
					MessageBox.Show("Can't be proceed");
				}
				// добавить еще тип ключа (в виде дропбокса) и значение

			}
			else
			{
				MessageBox.Show("It's not possible to create new sections here");
			}
		}

		private void updateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			updateRegKeys();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RegistryKey currentRegKey = Reg.GetRegistryKeyByName(treeView_registryKeys.SelectedNode.Text, Data.regKeysList);

			if (currentRegKey != null)
			{
				// удаление параметра
				/*currentRegKey.DeleteValue("key1", false); // in case key doesn't exit an exeption won't appear
				currentRegKey.Close();*/
				try
				{
					RegistryKey currentRegKeyParent = Reg.GetRegistryKeyByName(treeView_registryKeys.SelectedNode.Parent.Text, Data.regKeysList);

					currentRegKey.Close();
					currentRegKeyParent.DeleteSubKeyTree(treeView_registryKeys.SelectedNode.Text);

					treeView_registryKeys.Nodes.Remove(treeView_registryKeys.SelectedNode);
				}
				catch { }
			}
			else
			{
				MessageBox.Show("It's not possible to delete this key");
			}
		}

		private void parameterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Data.selectedNode = treeView_registryKeys.SelectedNode;

			RegistryKey currentRegKey = Reg.GetRegistryKeyByName(Data.selectedNode.Text, Data.regKeysList);

			if (currentRegKey != null)
			{
			   parCreationForm parCreation = new parCreationForm();

				 parCreation.ShowDialog();		
			}
			else
			{
				MessageBox.Show("It's not possible to create new parameters here");
			}
		}

		/*private void textBox_path_KeyPress(object sender, EventArgs e)
		{
			string new_path = textBox_path.Text;

			string[] new_path_arr = new string[10];

			new_path_arr = new_path.Split('\\');

			foreach (string str in new_path_arr)
			{
				MessageBox.Show(str);
			}
		}*/
	}
}
