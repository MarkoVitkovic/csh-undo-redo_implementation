using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FileOperation
    {
		private string filename;
		private bool isSaved;

		public string Filename { get => filename; set => filename = value; }
		public bool IsSaved { get => isSaved; set => isSaved = value; }

		public void NewFile()
		{
			this.Filename = "Untitled.txt";
			this.IsSaved = true;
		}

		public void SaveFile(string fileName, string[] lines)
		{

		}
	}
}
