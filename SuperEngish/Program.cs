using System;
using System.Windows.Forms;
using SuperEngish.BL;

namespace SuperEngish
{

	internal sealed class Program
	{

		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//собственный код------------------------------------

            MainForm form = new MainForm ();
            Logic logic = new Logic();
            MessageService     messageService= new MessageService();
            VariableGlobal variableGlobal = new VariableGlobal();
            Control control = new Control(form,logic,messageService, variableGlobal);
            
            Application.Run(form);
 //----------------------------------------------------
		}
		
	}
}
