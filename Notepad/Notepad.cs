using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
	public partial class Notepad : Form
	{
		FileOperation fileOperations;
		public Notepad()
		{
			InitializeComponent();
			fileOperations = new FileOperation();
			fileOperations.NewFile();
			this.Text = fileOperations.Filename;
		}

		private void newFileMenu_Click(object sender, EventArgs e)
		{
			if (fileOperations.IsSaved)
			{
				fileOperations.NewFile();
				txtArea.Text = "";
				UpdateTextBox();
			}
			else
			{
				DialogResult result = MessageBox.Show("Do you want save file?", "Notepad", MessageBoxButtons.YesNoCancel);
				if (result == DialogResult.Yes)
				{
					if (fileOperations.Filename.Contains("Untitled"))
					{
						SaveFileDialog newFileSave = new SaveFileDialog();
						newFileSave.Filter = "Text(*.txt) | *.txt";
						if (newFileSave.ShowDialog() == DialogResult.OK)
						{
							fileOperations.SaveFile(newFileSave.FileName, txtArea.Lines);
							UpdateTextBox();
						}
						else
						{
							fileOperations.SaveFile(fileOperations.Filename, txtArea.Lines);
							UpdateTextBox();
						}
					}
				}
				else if (result == DialogResult.No)
				{
					txtArea.Text = "";
					fileOperations.NewFile();
					UpdateTextBox();
				}
			}

		}

		private void UpdateTextBox()
		{
			this.Text = !fileOperations.IsSaved ? fileOperations.Filename + "*" : fileOperations.Filename;
		}

		private void txtArea_TextChanged(object sender, EventArgs e)
		{
			fileOperations.IsSaved = false;
			UpdateTextBox();
		}

		private void openFileMenu_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Filter = "Text(*.txt) | *.txt";
			openFile.InitialDirectory = "D:";
			openFile.Title = "Open File";
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				txtArea.TextChanged -= txtArea_TextChanged;
				txtArea.Text = fileOperations.OpenFile(openFile.FileName);
				txtArea.TextChanged += txtArea_TextChanged;
				UpdateTextBox();
			}
		}

		private void exitFileMenu_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
