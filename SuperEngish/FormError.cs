/*
 * Создано в SharpDevelop.
 * Пользователь: Денис
 * Дата: 24.09.2018
 * Время: 15:48
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuperEngish
{
	/// <summary>
	/// Description of FormError.
	/// </summary>
	public partial class FormError : Form, IFormError
	{
		public FormError()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		//int sec=300;
		int sec=300;
		#region IFormError implementation


		//public int er_pb_Size_Height { get {return er_pictureBox_foto.Size.Height ;	}	set {er_pictureBox_foto.Size.Height =value ;	}}
		//public int er_pb_Size_Widh { get {return er_pictureBox_foto.Size.Width  ;	}	set {er_pictureBox_foto.Size.Width  =value ;	}}

		#endregion

		void E_button_closeClick(object sender, EventArgs e)
		{
			Close();
		}

		#region IFormError implementation

//
//		public event EventHandler E_Close;
//
//		public void OnE_Close()
//		{
//			Close();
//			if (E_Close!= null) E_Close(this, EventArgs.Empty);
//		}
//	

		#endregion

		void Timer1Tick(object sender, EventArgs e)
		{
			if(sec!=0) {
				
				e_button_close.Enabled=false;
				e_button_close.Visible=false;
				//e_button_close.Text=sec.ToString();
				//progressBar1.Value=100;
				progressBar1.Value=(int)(100*(double)sec/300);
				sec--;
			}
			else{
				//OnE_Close();
				Close();
				e_button_close.Enabled=true;
				progressBar1.Visible=false;
				e_button_close.Visible=true;
			}
			
		}
	}
	
	public interface IFormError
	{
//		event EventHandler E_Close;
	//	int er_pb_Size_Height{set;get;}
	//	int er_pb_Size_Widh{set;get;}
		
	}
}
