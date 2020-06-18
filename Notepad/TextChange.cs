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
		public override void txtArea_TextChanged(object sender, EventArgs e)
		{
			if (enableTextChangeEvent)
				return;
			base.txtArea_TextChanged();
		}
		private void SetText()
		{
			enableTextChangeEvent = false;
		}
		private bool enableTextChangeEvent = true;
	}
}
