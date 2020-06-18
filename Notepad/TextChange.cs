using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
	public class TextChange : RichTextBox
	{
		protected override void OnTextChanged(EventArgs e)
		{
			if (enableTextChangeEvent == false)
				return;
			base.OnTextChanged(e);
		}
		public void SetText(string text)
		{
			enableTextChangeEvent = false;
			Text = text;
			enableTextChangeEvent = true;
		}
		private bool enableTextChangeEvent = true;
	}
}
