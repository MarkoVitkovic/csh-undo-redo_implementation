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
		EditOperation editOperations;
		

		public Notepad()
		{
			InitializeComponent();
			fileOperations = new FileOperation();
			editOperations = new EditOperation();
			fileOperations.NewFile();
			this.Text = fileOperations.Filename;
			editOperations.AddUndoRedo(txtArea.Text);

		}

		private void newFileMenu_Click(object sender, EventArgs e)
		{
			//Check if file is saved?
			if (fileOperations.IsSaved)
			{
				fileOperations.NewFile();
				txtArea.Text = "";
				UpdateTextBox();
			}
			else
			{
				//throw dialog box and ask if you want save?
				DialogResult result = MessageBox.Show("Do you want save file?", "Notepad", MessageBoxButtons.YesNoCancel);
				//if you click yes, open save dialog and ask you for name and to choose format, you only have one
				if (result == DialogResult.Yes)
				{
					if (fileOperations.Filename.Contains("Untitled"))
					{
						SaveFileDialog newFileSave = new SaveFileDialog();
						newFileSave.Filter = "Text(*.txt) | *.txt"; //format, txt file
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
				//open new file without saving
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
			undoEditMenu.Enabled = editOperations.CanUndo() ? true : false;
			redoEditMenu.Enabled = editOperations.CanRedo() ? true : false; 
		}

		private void txtArea_TextChanged(object sender, EventArgs e)
		{
			fileOperations.IsSaved = false;
			editOperations.AddUndoRedo(txtArea.Text);
			UpdateTextBox();
		}

		private void openFileMenu_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog(); //dialog
			openFile.Filter = "Text(*.txt) | *.txt"; //format
			openFile.Title = "Open File"; //dialog name
			//if click on ok, file is open
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				
				txtArea.Text = fileOperations.OpenFile(openFile.FileName);
				UpdateTextBox();
			}
		}

		private void exitFileMenu_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		//with this we enable items in edit only if is there on txtarea some text or in clipboard 
		private void editMenu_Click(object sender, EventArgs e)
		{
			cutEditMenu.Enabled = txtArea.SelectedText.Length > 0 ? true : false;
			copyEditMenu.Enabled = txtArea.SelectedText.Length > 0 ? true : false;
			pasteEditMenu.Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
		}

		private void editMenu_MouseEnter(object sender, EventArgs e)
		{
			editMenu_Click(sender, e);
		}
	
		private void cutEditMenu_Click(object sender, EventArgs e)
		{
			txtArea.Cut();
			pasteEditMenu.Enabled = true;
		}

		private void copyEditMenu_Click(object sender, EventArgs e)
		{
			txtArea.Copy();
			pasteEditMenu.Enabled = true;
		}

		private void pasteEditMenu_Click(object sender, EventArgs e)
		{
			//check if there any txt in clipboard
			if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
				txtArea.Paste();

		}

		private void deleteEditMenu_Click(object sender, EventArgs e)
		{
			//remove selected text, remove(start, end)
			txtArea.Text = txtArea.Text.Remove(txtArea.SelectionStart, txtArea.SelectionLength);
		}

		private void undoEditMenu_Click(object sender, EventArgs e)
		{
			txtArea.Text = editOperations.UndoClicked();
			UpdateTextBox();
		}

		private void redoEditMenu_Click(object sender, EventArgs e)
		{
			txtArea.Text = editOperations.RedoClicked();
			UpdateTextBox();
		}
	}
}
