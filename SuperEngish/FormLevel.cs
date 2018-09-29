/*
 * Создано в SharpDevelop.
 * Пользователь: Денис
 * Дата: 25.09.2018
 * Время: 19:52
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuperEngish
{
	/// <summary>
	/// Description of FormLevel.
	/// </summary>
	public partial class FormLevel : Form
	{
		public FormLevel()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
