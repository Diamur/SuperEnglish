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
		int sec=0;
		#region IFormError implementation


		//public int er_pb_Size_Height { get {return er_pictureBox_foto.Size.Height ;	}	set {er_pictureBox_foto.Size.Height =value ;	}}
		//public int er_pb_Size_Widh { get {return er_pictureBox_foto.Size.Width  ;	}	set {er_pictureBox_foto.Size.Width  =value ;	}}

		#endregion

		void E_button_closeClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			if(sec<301) {
				e_button_close.Enabled=false;
				e_button_close.Visible=false;
				//e_button_close.Text=sec.ToString();
				progressBar1.Value=(int)(100*(double)sec/300);
				
			}
			else{
				this.Close();
				e_button_close.Enabled=true;
				progressBar1.Visible=false;
				e_button_close.Visible=true;
			}
			sec++;
		}
	}
	
	public interface IFormError
	{
	//	int er_pb_Size_Height{set;get;}
	//	int er_pb_Size_Widh{set;get;}
		
	}
}
