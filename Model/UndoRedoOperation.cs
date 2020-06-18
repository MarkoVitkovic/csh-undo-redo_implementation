using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class UndoRedoOperation
	{
		//constructor
		public UndoRedoOperation()
		{
			UndoStack = new Stack<string>();
			RedoStack = new Stack<string>();
		}
		//clear redo stack
		public void ClearRedo()
		{ 
			RedoStack.Clear();
		}
		//add items in undo stack
		public void AddToUndo(string i)
		{
			UndoStack.Push(i);
		}
		//pop items from undo stack and push in redo
		public string Undo()
		{
			string i = UndoStack.Pop();
			RedoStack.Push(i);
			return UndoStack.First();
		}
		public string Redo()
		{
			// if redo stack is empty, then we dont have something to return
			if (RedoStack.Count == 0)
				return UndoStack.First();
			string i = RedoStack.Pop();
			UndoStack.Push(i);
			return UndoStack.First();
		}
		//check if we can undo, if is undo stack greater then 1 we can
		public bool CanUndo()
		{
			return UndoStack.Count > 1;
		}
		//check if we can redo, if is redo stack greater then 0 we can
		public bool CanRedo()
		{
			return RedoStack.Count > 0;
		}
		public List<string> UndoItems()
		{
			return UndoStack.ToList();
		}
		public List<string> RedoItems()
		{
			return RedoStack.ToList();
		}


		private Stack<string> UndoStack;
		private Stack<string> RedoStack;
	}
}
