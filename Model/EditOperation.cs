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
		
		public string CallUndo()
		{
			//no require change of text area so it is false, and call undo method on data
			return data.Undo();
		}

		public string CallRedo()
		{
			return data.Redo();
		}
		//call undoredooperation function on data wich we init in constructor
		public void AddUndo(string i)
		{
			data.AddToUndo(i);
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
		public void ClearRedo()
		{
			data.ClearRedo();
		}



		private UndoRedoOperation data;
		//check if is text is cchangeing if is true, we call method AddUndoRedo, need this, without this undo/redo dosent work
	
	}
}
