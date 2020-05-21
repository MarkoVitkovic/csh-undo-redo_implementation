using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class EditOperation
	{
		//constructor
		public EditOperation()
		{
			data = new UndoRedoOperation();
		}
		
		public string UndoClicked()
		{
			//no require change of text area so it is false, and call undo method on data
			TxtAreaTextChangeRequired = false;
			return data.Undo();
		}

		public string RedoClicked()
		{
			TxtAreaTextChangeRequired = false;
			return data.Redo();
		}
		//call undoredooperation function on data wich we init in constructor
		public void AddUndoRedo(string i)
		{
			data.AddItem(i);
		}
		//call Can undo on data, wich is implemented in UndoRedoOperation
		public bool CanUndo()
		{
			return data.CanUndo();
		}
		
		public bool CanRedo()
		{
			return data.CanRedo();
		}



		private UndoRedoOperation data;
		private bool txtAreaTextChangeRequired = true;

		public bool TxtAreaTextChangeRequired { get => txtAreaTextChangeRequired; set => txtAreaTextChangeRequired = value; }
	}
}
