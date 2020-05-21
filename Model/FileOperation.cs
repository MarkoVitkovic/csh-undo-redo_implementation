using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FileOperation
    {
		private string filename;
		private bool isSaved;
		private string location;

		public string Filename { get => filename; set => filename = value; }
		public bool IsSaved { get => isSaved; set => isSaved = value; }
		public string Location { get => location; set => location = value; }

		public void NewFile()
		{
			this.Filename = "Untitled.txt";
			this.IsSaved = true;
		}

		public void SaveFile(string fileName, string[] lines)
		{

		}

		public string OpenFile(string location)
		{
			string content;
			this.Location = location;
			Stream stream = File.Open(location, FileMode.Open, FileAccess.ReadWrite);
			using (StreamReader streamReader = new StreamReader(stream))
			{
				content = streamReader.ReadToEnd();
			}
			string filename = Location.Substring(Location.LastIndexOf("\\") + 1);
			this.Filename = filename;
			this.IsSaved = true;
			return content;

		}
	}
}
