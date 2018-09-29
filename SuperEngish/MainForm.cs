using System;
using System.Net;

//using System.Collections.Generic;
using System.Drawing;
//using System.Net;
//using System.Threading;
//using System.Web;
using System.Windows.Forms;
using System.IO;
//using NAudio.Wave;




namespace SuperEngish
{    


    public partial class MainForm : Form , IMainForm 
    {
        public MainForm()
        {
            InitializeComponent();
            
            // Генерация событий на форме, если с формы не заданы автоматом
            // Слить, залить, вычислить
            // События внутри формы без выхода наружи(Задать)
            SetSize();
            label_w.Visible = false;
            label_tr.Visible= false;
            label_v1.Visible=false;
            label_v2.Visible=false;
            button_pausa.Enabled=false;
            label_unknown.Visible=false;
           
        }
        public FormError fe;
        FormLevel flevel;
	#region IMainForm implementation поля и события
		public event EventHandler E_Button_selectDirWordsPathClick;
		public event EventHandler E_Button_selectFileWordsPathClick;		
		public event EventHandler E_Button_selectDirFotoPathClick;
		public event EventHandler E_Button_selectFileFotoPathClick;		
		public event EventHandler E_Label_v1Click;		
		public event EventHandler E_Timer_varTick;
		public event EventHandler E_Label_v2Click;
		public event EventHandler E_Button_startClick;
		public event EventHandler E_Timer_startTick;
		public event EventHandler E_Button_pausaClick;
		public event EventHandler E_Button_restartClick;
		public event EventHandler E_Button_testStartClick;
		public event EventHandler E_Button_testVarClick;
		public event EventHandler E_Label_unknownClick;
		public event EventHandler E_Button_levelClick;
		public event EventHandler E_Timer_timeTick;
		public event EventHandler E_ProgressBar_timeClientSizeChanged;
		
		public int ProgressBarTimeMaxValue {get { return progressBar_time.Maximum;}	set {progressBar_time.Maximum=value	;}
		}
		public string LevelText { get {return label_level.Text  ;} set {label_level.Text =value;} }
		public bool TimerLevelEnable {get {return timer_time.Enabled;} set {timer_time.Enabled=value;}	}
		public bool ProgressBarTimeEnable {	get {return progressBar_time.Enabled ;} set { progressBar_time.Enabled=value;}	}
		public int ProgressBarTime { get { return progressBar_time.Value; }	set { progressBar_time.Value=value ; } }
		public bool Label_unknown_Visible {set { label_unknown.Visible=value;} }
		public bool ChekTranslate {get {return checkBox_transl.Checked  ;} set { checkBox_transl.Checked=value;} }

		public bool ChekFoto {get { return checkBox_foto.Checked;} set {checkBox_foto.Checked=value	;}	}

		public string Rezult {get {return textBox_Rezult.Text ;} set {textBox_Rezult.Text=value;}}

		public string Index {set {label_index.Text =value;}}
		public string CountVisible {set {label_countVisible.Text=value;}}
		
		//------Тестовые поля--------
		public string Tb_nextIndex {set {textBox_nextIndex.Text=value;}	get{return textBox_nextIndex.Text ;}}
		public string Tb_index 	{set  {textBox_SP_index.Text=value; }	}
		public string Tb_all 	{ set {textBox_SP_all.Text=value; }	}

		public string CountResidul {set {label_countResidual.Text=value;}}     
		//Видимость текста
		public bool LabelWordEnable {			set {label_w.Visible=value;}		}
		public bool LabelTransEnable {			set {label_tr.Visible=value;}		}
		public bool LabelVar1Enable {			set {label_v1.Visible=value;}		}
		public bool LabelVar2Enable {			set {label_v2.Visible=value;}		}
		public bool ButtonPausaEnable {			set {button_pausa.Enabled=value;}		}		
		//тестовое поле
		public string TestText {set { label_test.Text =value ;	}}
		
		public string ButtonStartText {			get { return button_start.Text ;}			set { button_start.Text=value;}		}
		//Вывод данных внизу панели
		public string CountWords {			set {label_countWords.Text =value;}		}
		public string CountCurrent {			set {label_countCurrent.Text=value;}		}
		public string CountError {			set {label_countError.Text=value;}		}
		public string CountRead {			set {label_countVisible.Text=value;}		}
		public int ProgressBarCountLean {			set {ProgressBar_countLean.Value=value;}		}
		public string Time {			set {label_time.Text=value;}		}		
		
		public string DirWordsPath {			get {return textBox_dirWordsPath.Text;	}			set {textBox_dirWordsPath.Text = value;	}		}
		
		public string FileWordPath {			get {return textBox_fileWordsPath.Text;	}			set {textBox_fileWordsPath.Text =value;	}		}
		
		public string GetDirWordsPath {	get {OpenFileDialog dlg = new OpenFileDialog(); if(dlg.ShowDialog() == DialogResult.OK) return Path.GetDirectoryName(dlg.FileName)+@"\"; return "";} }
				
		public string GetFileWordsPath { get { OpenFileDialog dlg = new OpenFileDialog(); if(dlg.ShowDialog() == DialogResult.OK) return dlg.FileName; return "";}	}
		
		public string DirFotoPath {	get { return textBox_dirFotoPath.Text ;} set {textBox_dirFotoPath.Text = value;} }
		public string FileFotoPath { get {return textBox_fileFotoPath.Text ;} set {textBox_fileFotoPath.Text = value;} }
		public string GetDirFotoPath { get {OpenFileDialog dlg = new OpenFileDialog(); if(dlg.ShowDialog() == DialogResult.OK) return Path.GetDirectoryName(dlg.FileName)+@"\";	return "";}	}
		public string GetFileFotoPath {	get {OpenFileDialog dlg = new OpenFileDialog(); if(dlg.ShowDialog() == DialogResult.OK)	return dlg.FileName; return "";} }
		
		public Color SetColorV1 { set {label_v1.BackColor= value;}	}
		
		public Color SetColorV2 {set {label_v2.BackColor= value;} }

		public Color SetColorUnknow { set {label_unknown.BackColor =value;} }
		//--------------Вставка слов-----------------------------------
		public string SetWord 		{ set { label_w.Text=value;} 	}
		//--------------Вставка слов-----------------------------------
		public string SetTranslate 	{ set { label_tr.Text =value;} }
		//--------------Вставка слов-----------------------------------
		public string SetVar1 		{ set { label_v1.Text=value;} get {return  label_v1.Text;} 	}
		//--------------Вставка слов-----------------------------------
		public string SetVar2 		{ set {label_v2.Text=value;} get {return  label_v2.Text;}}
		
		//----------таймер варианта------------------------------------
		public bool SetTimerVarEnable { set {timer_var.Enabled = value;} }
		//--------------------------------------------------------------
		public bool SetTimerStartEnable { set {timer_start.Enabled = value;} }
		//--------------------------------------------------------------
		public string SetLabel_testText { set { label_test.Text = value;}	}
		
#endregion


	
	#region Работа с таблицами
	
		public void addGrids(string[][] allStroka){				
				foreach (var stroka in allStroka) { addGridParam(stroka); }
			}
	
		public void addGridParam(string[] readStroka){
			DataGridView Grid= dataGridView1;
		//пока столбцов не будет достаточное количество добавляем их
		while (readStroka.Length > Grid.ColumnCount)
		{
		//если колонок нехватает добавляем их пока их будет хватать
		Grid.Columns.Add("", "");
		}
		//заполняем строку
		Grid.Rows.Add(readStroka);
	}	
	
		public void dataGridView1RowsClear()
		{
			dataGridView1.Rows.Clear();
		}

	#endregion		
	
	#region Размеры лейблов
				void  SetLabelCenter(Label l, int w ){
				//Центр Окна
				int c_win = (int)(w/2);				
				
				// Ширина/2 слова			
				//int wid2_w =(int)(l.Size.Width/2);
				int wid2_w =(int)(l.PreferredWidth/2);
				
				// Лок.Х слова
				Point loc = l.Location;
		   		loc.X=(int)(c_win - wid2_w);
		   		
		   		//loc.Y
		   		loc.Y=l.Location.Y;
				
		   		// установка координат
		   		l.Location = loc;			
			}
	
			void  SetSizeLabel(Label l, int  k1, int  k2, int  k3, int w, int h, int dwid=0 ){
				//высота
				int h10_win =(int)(h*((double)(k2)/100));				
				//Центр Окна
				int c_win = (int)(w/2);				
				//Ширина слова
				int wid_w = (int)(w*((double)(k1)/100));				
				// Подбор размера шрифта
				int rsz=10;
				
				l.Font = new Font("Arial",rsz , l.Font.Style );
				
				//while ( l.Size.Width < wid_w && l.Size.Height < h10_win) {
				while ( l.PreferredWidth < wid_w && l.PreferredHeight  < h10_win) {
					l.Font = new Font("Arial",rsz , l.Font.Style );
					rsz++;
				}
				
				// Ширина/2 слова			
				//int wid2_w =(int)(l.Size.Width/2);
				int wid2_w =(int)(l.PreferredWidth/2);
				
				// Лок.Х слова
				Point loc = l.Location;
		   		loc.X=(int)(c_win - wid2_w + dwid);
		   		
		   		//loc.Y
		   		loc.Y=(int)(h/k3);
				
		   		// установка координат
		   		l.Location = loc;			
			}
			
			void  SetSizeLabel_tr(Label l, int  k1, int  k2, int  k3, int w, int h,Label wrd,Label otv, int dwid=0 ){
				//высота
				int h10_win =(int)(h*((double)(k2)/100));
				
				//Центр Окна
				int c_win = (int)(w/2);
				
				//Ширина слова
				int wid_w = (int)(w*((double)(k1)/100));
				
				// Подбор размера шрифта
				int rsz=10;
				l.Font = new Font("Arial",rsz , l.Font.Style );
				
				//while ( l.Size.Width < wid_w && l.Size.Height < h10_win) {
				while ( l.PreferredWidth < wid_w && l.PreferredHeight < h10_win) {
					l.Font = new Font("Arial",rsz , l.Font.Style );
					rsz++;
				}
				
				// Ширина/2 слова			
			//	int wid2_w =(int)(l.Size.Width/2);
			//	int wid2_h =(int)(l.Size.Height /2);
				int wid2_w =(int)(l.PreferredWidth/2);
				int wid2_h =(int)(l.PreferredHeight /2);
				
				// Лок.Х слова
				Point loc = l.Location;
		   		loc.X=(int)(c_win - wid2_w + dwid);
		   		
		   		//loc.Y		   		
//		   		int w_y = label_w.Location.Y;
//		   		int w_h = label_w.Size.Height;
		   		int w_y = wrd.Location.Y;
		   		int w_h = wrd.Size.Height;
		   		
//		   		int v1_y = label_v1.Location.Y;
//		   		int v1_h = label_v1.Size.Height;
		   		int v1_y = otv.Location.Y;
		   		int v1_h = otv.Size.Height;
		   		
		   		int y = w_y + w_h + ((int)((double)(v1_y - (w_y + w_h))/2) - wid2_h);
		   		
		   		loc.Y = y;	   		
				
		   		// установка координат
		   		l.Location = loc;			
			}
					
			public void SetSize(){			
		    SetSizeLabel(label_w, 86, 24, 22,pictureBox1.Size.Width,pictureBox1.Size.Height);
		   	SetSizeLabel(label_v1, 73, 10, 2, (int)((double)(pictureBox1.Size.Width)/2),pictureBox1.Size.Height);
		  	SetSizeLabel(label_v2, 73, 10, 2, (int)((double)(pictureBox1.Size.Width)/2),pictureBox1.Size.Height,(int)((double)(pictureBox1.Size.Width)/2));
		  	SetSizeLabel_tr(label_tr,73, 14,3,pictureBox1.Size.Width,pictureBox1.Size.Height,label_w ,label_v1);
		  	SetLabelCenter(label_unknown, pictureBox1.Size.Width );
		  	
			}
	#endregion		

	
		
 #region IMainForm event проброс для управляющего кода -- if (FileOPenClick !=null) FileOPenClick(this, EventArgs.Empty ); --
		// Настройки пути Словарь
		void Button_selectDirWordsPathClick(object sender, EventArgs e)
		{
			if ( E_Button_selectDirWordsPathClick!=null) E_Button_selectDirWordsPathClick(this, EventArgs.Empty );
			
		}		
		void Button_selectFileWordsPathClick(object sender, EventArgs e)
		{
		    if ( E_Button_selectFileWordsPathClick!=null) E_Button_selectFileWordsPathClick(this, EventArgs.Empty );
		}
		
		// Настройка пути Фото
		void Button_selectDirFotoPathClick(object sender, EventArgs e)
		{
			if ( E_Button_selectDirFotoPathClick!=null) E_Button_selectDirFotoPathClick(this, EventArgs.Empty );
	
		}		
		void Button_selectFileFotoPathClick(object sender, EventArgs e)
		{
			if ( E_Button_selectFileFotoPathClick!=null) E_Button_selectFileFotoPathClick(this, EventArgs.Empty );
	
		}
		
		//АВторазмер
		void MainFormResize(object sender, EventArgs e)
		{	
			SetSize();
		}
		
		//Нажатие вариантов	и таймер их	
		void Label_v1Click(object sender, EventArgs e)
		{    			
			if ( E_Label_v1Click !=null) E_Label_v1Click(this, EventArgs.Empty );
		}		
		void Label_v2Click(object sender, EventArgs e)
		{
			if ( E_Label_v2Click !=null) E_Label_v2Click(this, EventArgs.Empty );	
		}		
		void Timer_varTick(object sender, EventArgs e)
		{			
			if ( E_Timer_varTick !=null) E_Timer_varTick(this, EventArgs.Empty );	
		}		
		
		//Старт, стоп и таймер их
		void Button_startClick(object sender, EventArgs e)
		{
			if ( E_Button_startClick !=null) E_Button_startClick(this, EventArgs.Empty );
	
		}		
		void Timer_startTick(object sender, EventArgs e)
		{
			if ( E_Timer_startTick !=null) E_Timer_startTick(this, EventArgs.Empty );
	
		}

		
 #endregion		
 
		//============ ТЕСТОВЫЕ КНОПКИ =================================
		void Button1Click(object sender, EventArgs e)
		{
#region Загрузка картинки
//		try {
//				Bitmap b =  new Bitmap(textBox_fileFotoPath.Text);
//			pictureBox1.BackgroundImage = b;
//			pictureBox1.BackgroundImageLayout = ImageLayout.Stretch ;
//				
//			} catch (Exception ) {
//				
//				MessageService m = new MessageService();
//			    m.ShowExclamation("Не заданы пути к файлам!");
//			}
//
#endregion
		//fm = new Form();
		
	//	FormErro
	//	fm.Size.Height= new Size();
//		fm.Size.Width=500;
//		fm.Name="Tecт форма";
//		fm.Size = new Size(1050, 561);
//		fm.TopMost=true;
//
//		Button b_close; 
//		b_close = new System.Windows.Forms.Button();
//		fm.Controls.Add(b_close);
//		
//		b_close.Location = new System.Drawing.Point(584, 17);
//			b_close.Name = "button_selectFileFotoPath";
//			b_close.Size = new System.Drawing.Size(28, 23);
//			b_close.TabIndex = 2;
//			b_close.Text = "Закрыть";
//			b_close.UseVisualStyleBackColor = true;
//			b_close.Click += new System.EventHandler(B_CloseClick);
//		
//		fm.Show();	
	//	ShowFormError("Hello", "хело", "Привет");
	
		//string result = translate("привет", "ru", "en");
 
//HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
//doc2.LoadHtml(result);
//HtmlNodeCollection translateNode = doc2.DocumentNode.SelectNodes("//span[@id='result_box']");
//if (translateNode.Count != 0)
//{
//     ResultRichTextBox.Text = translateNode[0].InnerText;
//     HtmlNode add = doc2.DocumentNode.SelectSingleNode("//div[@class='gt-cd-c']");
//     if (add != null)
//     {
//          ResultRichTextBox.AppendText("\n-------------");
//     }
//}
//else
//{
//    ResultRichTextBox.Text = "Проблема с переводом";
//}

			flevel = new FormLevel();
			
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;
			flevel.Location = new System.Drawing.Point((int)((double)width/2), (int)((double)height/2));

			//Location loc= p;
			
			
			//flevel.Location = loc;
			
			
			flevel.ShowDialog();
			if(flevel.radioButton_level1.Checked) textBox_Rezult.Text="Легкий";
			if(flevel.radioButton_level2.Checked) textBox_Rezult.Text="Средний";
			if(flevel.radioButton_level3.Checked) textBox_Rezult.Text="Сложный";
			if(flevel.radioButton_level4.Checked) textBox_Rezult.Text="Экстремельный";

		}
		
		public int Level(){
				flevel = new FormLevel();
			
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;
			flevel.Location = new System.Drawing.Point((int)((double)width/2), (int)((double)height/2));

			//Location loc= p;
			
			
			//flevel.Location = loc;
			
			
			flevel.ShowDialog();
			if(flevel.radioButton_level1.Checked) return 0;// textBox_Rezult.Text="Легкий";
			if(flevel.radioButton_level2.Checked) return 1;// textBox_Rezult.Text="Средний";
			if(flevel.radioButton_level3.Checked) return 2;//textBox_Rezult.Text="Сложный";
			if(flevel.radioButton_level4.Checked) return 3;//textBox_Rezult.Text="Экстремельный";
			return 0;
		}
		
		//===========================================================
		
		public string TranslateText(string input, string languagePair)
			{
			    string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
			    WebClient webClient = new WebClient();
			    webClient.Encoding = System.Text.Encoding.UTF8;
			    string result = webClient.DownloadString(url);
			    result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
			    result = result.Substring(result.IndexOf(">") + 1);
			    result = result.Substring(0, result.IndexOf("</span>"));
			    return result.Trim();
			}
		
		public string translate(string word, string SL, string DL)
        {
            var cookies = new CookieContainer();
            string result;
            ServicePointManager.Expect100Continue = false;
            var request = (HttpWebRequest)WebRequest.Create("http://translate.google.ru/?sl=" + SL + "&tl=" + DL +  "&q=" + word);
            request.CookieContainer = cookies;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";
 
            using (var requestStream = request.GetRequestStream())
 
            using (var responseStream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                result = reader.ReadToEnd();
            }
 
            return result;
		}
		
		//===========================================================
		
		
		public void ShowFormError(string word, string translate, string otvet){
			fe = new FormError();
			fe.WindowState = FormWindowState.Maximized;
			//
			//System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height;
			//Слово
			Label er_label_word =new Label() ;
			er_label_word.Name="l_word";
			er_label_word.TabIndex = 2;
			er_label_word.Text = word;
			er_label_word.AutoSize=true;
		//	SetSizeLabel(er_label_word, 86, 24, 22,fe.Size.Width,fe.Size.Height);
			SetSizeLabel(er_label_word, 86, 24, 22,Screen.PrimaryScreen.Bounds.Size.Width,Screen.PrimaryScreen.Bounds.Size.Height);
			
			fe.Controls.Add(er_label_word);
			
			//Ответ			
			Label er_label_otvet =new Label() ;
			er_label_otvet.Name="l_otvet";
			er_label_otvet.TabIndex = 2;
			er_label_otvet.Text = otvet;
			er_label_otvet.AutoSize=true;
			//SetSizeLabel(er_label_otvet, 73, 10, 2,fe.Size.Width,fe.Size.Height);
			SetSizeLabel(er_label_otvet, 73, 10, 2,Screen.PrimaryScreen.Bounds.Size.Width,Screen.PrimaryScreen.Bounds.Size.Height);
			
			fe.Controls.Add(er_label_otvet);
			
			//Транслейт
			Label er_label_tr =new Label() ;
			er_label_tr.Name="l_tr";
			er_label_tr.TabIndex = 2;
			er_label_tr.Text = translate;
			er_label_tr.ForeColor=Color.Gray;
			er_label_tr.AutoSize=true;
			//SetSizeLabel(er_label_tr,73, 14,3,fe.Size.Width,fe.Size.Height);
			SetSizeLabel_tr(er_label_tr,73, 14,2,Screen.PrimaryScreen.Bounds.Size.Width,Screen.PrimaryScreen.Bounds.Size.Height,er_label_word,er_label_otvet);
			fe.Controls.Add(er_label_tr);
			
			fe.Show();	
		}

		void B_CloseClick(object sender, EventArgs e)
		{
			;
		}
		
		void Button2Click(object sender, EventArgs e)
		{		
		
			
		}
		//============ ТЕСТОВЫЕ КНОПКИ =================================	
		void Button_pausaClick(object sender, EventArgs e)
		{
			if ( E_Button_pausaClick !=null) E_Button_pausaClick(this, EventArgs.Empty );
	
		}
		//Рестарт
		void Button_restartClick(object sender, EventArgs e)
		{
			if ( E_Button_restartClick !=null) E_Button_restartClick(this, EventArgs.Empty );
		}
		
		void Button_testStartClick(object sender, EventArgs e)
		{
			if ( E_Button_testStartClick !=null) E_Button_testStartClick(this, EventArgs.Empty );
		}
		
		void Button_testVarClick(object sender, EventArgs e)
		{
			if ( E_Button_testVarClick !=null) E_Button_testVarClick(this, EventArgs.Empty );
		}
		
		
		void Label_unknownClick(object sender, EventArgs e)
		{
			if ( E_Label_unknownClick !=null) E_Label_unknownClick(this, EventArgs.Empty );
		}
		
		void Button_levelClick(object sender, EventArgs e)
		{
		if ( E_Button_levelClick !=null) E_Button_levelClick(this, EventArgs.Empty );
		}
		
		//Время для уровня сложности
		void Timer_timeTick(object sender, EventArgs e)
		{
		if ( E_Timer_timeTick !=null) E_Timer_timeTick(this, EventArgs.Empty );
		}
		
		void ProgressBar_timeClientSizeChanged(object sender, EventArgs e)
		{
			if ( E_ProgressBar_timeClientSizeChanged !=null) E_ProgressBar_timeClientSizeChanged(this, EventArgs.Empty );
		}
	

    }
    
    //Интерфейс
    public interface IMainForm
    {
    	//Прогресс бар
    	int ProgressBarTime{ get; set;}
    	bool  ProgressBarTimeEnable { get; set;}
    	bool TimerLevelEnable  { get; set;}
    	int ProgressBarTimeMaxValue  { get; set;}
    	//Тестовые поля
    	string Tb_all{set;}
    	string Tb_index{set;}
    	string Tb_nextIndex{set;get;}
    	//тестовое поле на форме
        string TestText {set;}
        bool ChekTranslate{get;set;}
        bool ChekFoto{get;set;}
    	
        //Поля для управляющего кода
        // пути  словаря
        string DirWordsPath {get ;set;}
        string FileWordPath {get ;set;}
        string GetDirWordsPath {get ;}
        string GetFileWordsPath {get ;}
        
        
        //видимость текста
        bool LabelWordEnable {set;}
        bool LabelTransEnable {set;}
        bool LabelVar1Enable {set;}
        bool LabelVar2Enable {set;}
        bool ButtonPausaEnable {set;}
        bool Label_unknown_Visible  {set;}
        
        //Текст кнопки старт
        string ButtonStartText {get ;set;}
        
        //Вывод данных внизу панели
        string CountVisible{set;}
        string CountWords{set;}
        string CountResidul{set;}
        string CountCurrent{set;}
        string CountError{set;}
        string CountRead{set;}
        int ProgressBarCountLean{set;}
        string Time{set;}
        string Index{set;}
        string LevelText{get;set;}
        
        //вставляем слова
        string SetWord{set;}
        string SetTranslate{set;}
        string SetVar1{set;}
        string SetVar2{set;}
        
        Color  SetColorV1 {set;}
        Color SetColorV2{set;}
        Color SetColorUnknow {set;}
        
        bool SetTimerVarEnable{set;}
        bool SetTimerStartEnable{set;}
        string SetLabel_testText{set;}
        
        // пути фото
        string DirFotoPath {get ;set;}
        string FileFotoPath {get ;set;}
        string GetDirFotoPath {get ;}
        string GetFileFotoPath {get ;}
        
        // Результат
        string Rezult{get;set;}
        
        //Методы для управляющего кода для действий над формой
        void addGrids(string[][] allStroka);
        void SetSize();
        void dataGridView1RowsClear();
        void ShowFormError(string word, string translate, string otvet);
        int Level();
        
        //События для управляющего кода  
        event EventHandler E_Button_selectDirWordsPathClick;
        event EventHandler E_Button_selectFileWordsPathClick;
        event EventHandler E_Button_selectDirFotoPathClick;
        event EventHandler E_Button_selectFileFotoPathClick;
        event EventHandler E_Label_v1Click;
        event EventHandler E_Timer_varTick;
        event EventHandler E_Timer_startTick;
        event EventHandler E_Label_v2Click;
        event EventHandler E_Button_startClick;
        event EventHandler E_Button_pausaClick;
        event EventHandler E_Button_restartClick;
        event EventHandler E_Button_testStartClick;
        event EventHandler E_Button_testVarClick;
        event EventHandler E_Label_unknownClick;
        event EventHandler E_Button_levelClick;
        event EventHandler E_Timer_timeTick;
        event EventHandler E_ProgressBar_timeClientSizeChanged;
       
        
    }
}
