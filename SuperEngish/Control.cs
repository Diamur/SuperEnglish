using System;
using SuperEngish.BL;
using System.Drawing;

namespace SuperEngish
{

public class Control{
   
	readonly IMainForm _view;
    readonly ILogic _logic;
    readonly IMessageService _messageService;
    readonly IVariableGlobal _variableGlobal;
 

// собственные поля для многократного использования в этом классе 
        public Control( IMainForm view, ILogic logic, IMessageService messageService, IVariableGlobal variableGlobal)
        {
            _view = view;
            _logic = logic;
            _messageService = messageService;
            _variableGlobal = variableGlobal;
        //События которые нужно залить слить обсчитать

        // _view.FileOPenClick += new EventHandler(_view_FileOPenClick); 
        _view.E_Button_selectDirWordsPathClick += _view_E_Button_selectDirWordsPathClick;
        _view.E_Button_selectFileWordsPathClick += _view_E_Button_selectFileWordsPathClick;
        
        _view.E_Button_selectDirFotoPathClick += _view_E_Button_selectDirFotoPathClick;
        _view.E_Button_selectFileFotoPathClick += _view_E_Button_selectFileFotoPathClick;
        _view.E_Label_v1Click += _view_E_Label_v1Click;
        _view.E_Timer_varTick += _view_E_Timer_varTick;
        _view.E_Timer_startTick += _view_E_Timer_startTick;
        _view.E_Label_v2Click += _view_E_Label_v2Click;
        _view.E_Button_startClick += _view_E_Button_startClick;
        _view.E_Button_pausaClick += _view_E_Button_pausaClick;
        _view.E_Button_restartClick += _view_E_Button_restartClick;
        _view.E_Button_testStartClick += _view_E_Button_testStartClick;
        _view.E_Button_testVarClick += _view_E_Button_testVarClick;
        _view.E_Label_unknownClick += _view_E_Label_unknownClick;
        _view.E_Button_levelClick += _view_E_Button_levelClick;
        _view.E_Timer_timeTick += _view_E_Timer_timeTick;
        _view.OnProgressBarTime+= _view_OnProgressBarTime;
        _view.E_Form_Closed+= _view_E_Form_Closed;
        //_view.E_ProgressBar_timeClientSizeChanged += _view_E_ProgressBar_timeClientSizeChanged;
        
        _variableGlobal.ValueChangedSecLevel+= _variableGlobal_ValueChangedSecLevel;
        _variableGlobal.OnFlagStart+= _variableGlobal_OnFlagStart;
        _variableGlobal.OnRemoveIndexAllWords+= _variableGlobal_OnRemoveIndexAllWords;
        _variableGlobal.OnAddIndexErrorWords+= _variableGlobal_OnAddIndexErrorWords;

        // Задание параметров формы при первоначальном запуске программы
        }

		void _view_E_Form_Closed(object sender, EventArgs e)
		{
			//_messageService.ShowMessage("Ура Заработало");
			_view.TimerLevelEnable=true ;		
		}
		void _view_OnProgressBarTime(object sender, EventArgs e)
		{
			_view.Index=_variableGlobal.SecLevel.ToString();
			if(_variableGlobal.SecLevel ==1) NextStep();
			//if(_view.ProgressBarTime==100) NextStep();
		}
        // Cобыитие на изменение количество ошибок
		void _variableGlobal_OnAddIndexErrorWords(object sender, EventArgs e)
		{
			//Установка следующего шага
			if (_variableGlobal.CountIndexAllWords !=0)
			_variableGlobal.CountVisible= ++_variableGlobal.CountVisible;
			if(_variableGlobal.MaxError!=0 && _view.SetTimerStartEnable )
				if(_variableGlobal.CountErrorWords == _variableGlobal.MaxError){
				_view.TimerLevelEnable=false;
				_view.SetTimerStartEnable=false;
				_messageService.ShowExclamation("Ай..ай..ай!" + Environment.NewLine
				                                +"Слишком много ошибок!"  + Environment.NewLine
				                                + "Попробуйте еще разок)");
				                                //Stop();
				                                Start();
				                                Restart();
				                               // Start();
				                                //Start();
				                                
				                                
			}
					
		}
		// Cобыитие на изменение количество верных
		void _variableGlobal_OnRemoveIndexAllWords(object sender, EventArgs e)
		{
			//Установка следующего шага
			if (_variableGlobal.CountIndexAllWords !=0)
			_variableGlobal.CountVisible= ++_variableGlobal.CountVisible;
		}

		//-------------------------- Флаг Старта---------------------------
		void _variableGlobal_OnFlagStart(object sender, EventArgs e)
		{
			_view.TimerLevelEnable= _variableGlobal.FlagStart;
			_view.SetTimerStartEnable= _variableGlobal.FlagStart;
							
		}
		//======================================================================
        #region Выбор папок
        // папка для словаря
		void _view_E_Button_selectDirWordsPathClick(object sender, EventArgs e)
		{
			_view.DirWordsPath = _view.GetDirWordsPath ;
		}		
		// файл для словаря
		void _view_E_Button_selectFileWordsPathClick(object sender, EventArgs e)
		{
			
			_view.FileWordPath = _view.GetFileWordsPath ;
			_view.DirWordsPath =  _logic.GetDirPathFromFileName( _view.FileWordPath);;
			
			//очищаем таблицу
			_view.dataGridView1RowsClear();
			
			//создаем массив всех слов
			_variableGlobal.ReadStroka=_logic.AddReadStroka(_logic.GetFileReadAllLines(_view.FileWordPath));
			
			//изменяемый список индексов всех слов
			LoadIndexAllWords();
			
			//загружаем таблицу массивом всех слов			
			_view.addGrids(_variableGlobal.ReadStroka);
			
		}
		
		//изменяемый список индексов всех слов
		void LoadIndexAllWords(){			
			try {				
			_variableGlobal.IndexAllWords = new System.Collections.Generic.List<int>(_logic.ArrToArr( _variableGlobal.ReadStroka.Length));
			} catch (Exception) {				
				_messageService.ShowExclamation("Нет загруженных справочников!");
			}
		}
		
		// папка для фото
		void _view_E_Button_selectDirFotoPathClick(object sender, EventArgs e)
		{
			_view.DirFotoPath= _view.GetDirFotoPath;
		}
		// файл для фото
		void _view_E_Button_selectFileFotoPathClick(object sender, EventArgs e)
		{
			_view.FileFotoPath = _view.GetFileFotoPath;
			_view.DirFotoPath=_logic.GetDirPathFromFileName( _view.FileFotoPath);
		}

		void _view_E_Button_testVarClick(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			
		}
		void _view_E_Button_testStartClick(object sender, EventArgs e)
		{
			//Берем 0 индекс слова из словара
			_variableGlobal.LastIndex=0;
			//высвечиваем на дисплее 0 индекс
			//Если не  - Игнор
		}

		#endregion 
		

	#region работа с вариантами	
	
			
		//Установка цвета варианта
		void SetColorVariant(int var, Color color){
			if(var == 3){
				_view.SetColorUnknow = color;
				return ;
			}
			if(var==1){
				_view.SetColorV1= color; //Color.LightGreen ;
			}else{
				_view.SetColorV2= color ;//Color.LightGreen ;
			}			
		}
		
		//Вывод результат
		void OutResult(string result){
			if (result == "верно") {
				_view.Rezult = 	(_variableGlobal.CountVisible) + "  " 
							  	+ _variableGlobal.ReadStroka[ _variableGlobal.CurrentIndex][0] + "\t"  
					    		+"верно" + Environment.NewLine + _view.Rezult  ;		
			}
			if (result == "не верно"){
				_view.Rezult = 	(_variableGlobal.CountVisible) + "  "
							+ _variableGlobal.ReadStroka[ _variableGlobal.CurrentIndex][0] + "\t"							
							+ "не верно" 
							+ "(" + _variableGlobal.NoCurrentVariant +")--->" + "\t" 
							+ _variableGlobal.ReadStroka[_variableGlobal.LastIndex][2] 
							+ Environment.NewLine + _view.Rezult;				
			}
			
			if (result == "не знаю"){
				_view.Rezult = 	(_variableGlobal.CountVisible) + "  "
							+ _variableGlobal.ReadStroka[ _variableGlobal.CurrentIndex][0] + "\t"							
							+ "не знаю" 
							+ " --->" + "\t" 
							+ _variableGlobal.ReadStroka[_variableGlobal.LastIndex][2] 
							+ Environment.NewLine + _view.Rezult;				
			}			
		}		
		
		//Обработка варианта
		void LogicaVar(int var){
			// Если НеЗНаю
			if(var ==3){				
			//Вывод результата
			OutResult("не знаю");
				SetColorVariant(3, Color.Red);
				_view.SetTimerVarEnable= true ;
				_view.TimerLevelEnable=false;
			return;
			}
			//Если верно
			if(_variableGlobal.CurrentNumVar==var){				
				//Вывод результата 
				OutResult("верно");
				
				SetColorVariant(var, Color.LightGreen);
				_view.SetTimerVarEnable= true ;				
				_variableGlobal.AddIndexLeanWords(_variableGlobal.CurrentIndex);
				_variableGlobal.RemoveIndexAllWords(_variableGlobal.CurrentIndex); // удаляем из списка показа
				
			// Последний индекс списка
			_variableGlobal.LastIndex = _logic.GetStartIndex(_variableGlobal.CountIndexAllWords,  _variableGlobal.LastIndex) ;
			
			}else {
				// если неверно
			//Вывод результата
			OutResult("не верно");
				SetColorVariant(var, Color.Red);
				_view.SetTimerVarEnable= true ;
				_variableGlobal.AddIndexErrorWords(_variableGlobal.CurrentIndex);					
			// Последний индекс списка индексов
			_variableGlobal.LastIndex = _logic.GetNextIndex(_variableGlobal.CountIndexAllWords,  _variableGlobal.LastIndex) ;
			}
			
			//-----------------------------------------------------------------
			_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;
		}

		void _view_E_Label_unknownClick(object sender, EventArgs e)
		{
			if(_variableGlobal.FlagPausa) return;
			
			_view.TimerLevelEnable=false;
			_view.ShowFormError(_variableGlobal.ReadStroka[_variableGlobal.CurrentIndex][0],_variableGlobal.ReadStroka[_variableGlobal.CurrentIndex][1],_variableGlobal.ReadStroka[_variableGlobal.CurrentIndex][2]);			
			//-------------------------------------------------------------
			//_variableGlobal.SecLevel= _variableGlobal.MaxSecLevel*100;
			//_view.TimerLevelEnable=true;
		}
		//Тестовые выводы
		void TestOut(){
			//============================ВЫВОД ТЕСТВОЙ ИНФОРМАЦИИ ==================================
			// --вывод всех слов и индексов----
			string  str ="";
	
			for (int i = 0; i < _variableGlobal.ReadStroka.Length ; i++) {
				str = str + i + "\t" + _variableGlobal.ReadStroka[i][0] + Environment.NewLine;
			}
			
			_view.Tb_all = str;
			
			//---вывод изменяемый  список индексов ---
			str ="";
			for (int i = 0; i < _variableGlobal.CountIndexAllWords ; i++) {
				
				try {
			//		_messageService.ShowExclamation("str = str +i + \"\\t\"+ _variableGlobal.GetIndexAllWords(i)  + Environment.NewLine;");
					str = str +i + "\t"+ _variableGlobal.GetIndexAllWords(i)  + Environment.NewLine;
				} catch (Exception) {
					
					_messageService.ShowExclamation("str = str +i + \"\\t\"+ _variableGlobal.GetIndexAllWords(i)  + Environment.NewLine;");
				}
			}
			_view.Tb_index= str;
			
			
			//--вывод текущих индексов для показа
			
				try {
				if(_variableGlobal.CountIndexAllWords !=0)
					_view.Tb_nextIndex =  _variableGlobal.CurrentIndex+"\t" +  _variableGlobal.ReadStroka[_variableGlobal.CurrentIndex][0] + "\t" + _variableGlobal.LastIndex +"\t" + _variableGlobal.GetIndexAllWords( _variableGlobal.LastIndex) + Environment.NewLine +_view.Tb_nextIndex ;
				
					
			} catch (Exception) {
				_messageService.ShowExclamation("//--вывод текущих индексов для показа "+ _variableGlobal.LastIndex ) ;
				
			}
			//===========================================================================================================
			
		}
		
		void Winner(){
			if(_variableGlobal.CountIndexAllWords==0) {	
				Display();
				_variableGlobal.FlagStart=false;
				_messageService.ShowMessage("Поздравляем!"
                                            + Environment.NewLine
                                            +"Все слова выучены!" 
                                            + Environment.NewLine
                                            +"Количество правильных слов - " + _variableGlobal.CountAllWords 
                                            + Environment.NewLine
                                            + "Сделано ошибок - " + _variableGlobal.CountErrorWords 
                                            + Environment.NewLine
                                            + "Всего показов - " + _variableGlobal.CountVisible
                                           ); 
					Stop();  
					return ;
			}
			//_view.ProgressBarTimeEnable=false;
			//_view.TimerLevelEnable=false;
			//_view.SetTimerStartEnable=false;
			
		
		}
		
		// Нажатие Варианта 1  
		void _view_E_Label_v1Click(object sender, EventArgs e)
		{
			//
			if(_variableGlobal.FlagPausa) return;
			// обработка варианта
			LogicaVar(1);
			//			
			Cycles();
			//Сообщение
			Winner();		
			//
			TestOut();
			//Установка следующего индекса для показа слова		
		if(_variableGlobal.CountIndexAllWords!=0) 				
			_variableGlobal.CurrentIndex= _variableGlobal.GetIndexAllWords(_variableGlobal.LastIndex);		
			
		}
		
		// Нажатие Варианта 2
		void _view_E_Label_v2Click(object sender, EventArgs e)
		{
			// Флаг пауза		
			if(_variableGlobal.FlagPausa) return;
			// обработка варианта
			LogicaVar(2);
			//Тестовая информация
			Cycles();
			//Сообщение
			//if(_variableGlobal.CountIndexAllWords==0) { Stop();	_messageService.ShowMessage("Поздравляем!"+ Environment.NewLine  +"Все слова выучены!"); return ;}
			Winner();
			
			TestOut();
			
			//Установка следующего индекса для показа слова	
		if(_variableGlobal.CountIndexAllWords!=0) 		
			_variableGlobal.CurrentIndex= _variableGlobal.GetIndexAllWords(_variableGlobal.LastIndex);				
		}		
	
		// таймер вариантов
		void _view_E_Timer_varTick(object sender, EventArgs e)
		{	
			_variableGlobal.SecVar =++_variableGlobal.SecVar;
			
			//вывод тестовых секунда
			_view.SetLabel_testText= _variableGlobal.SecVar.ToString();
			
			//на 4 секунды окрашивается кнопка в красный цвет
			if(_logic.isSecVar(_variableGlobal.SecVar )){
				_view.SetColorV1= Color.WhiteSmoke;
				_view.SetColorV2= Color.WhiteSmoke;
				_view.SetColorUnknow=Color.MistyRose;
				_view.SetTimerVarEnable= false ;
				_variableGlobal.SecVar = 0;
				if(_variableGlobal.CountIndexAllWords!=0)
					_view.TimerLevelEnable=true;	
				//_variableGlobal.SetSecVar(0);
			}			
		}
#endregion	
//		void SetProgressBarTimeZero(){
//			_variableGlobal.SecLevel=0;
//		//	SetProgressBarTime(0);
//			_view.TimerLevelEnable=true ;
//		}

		// Установка и вывод минут и секунд
		void setTime(){
		// Установка минут и секунд
			_variableGlobal.SecStart = _logic.SetSecTime(_variableGlobal.SecStart);	
			_variableGlobal.MinStart= _logic.SetMinTime(_variableGlobal.SecStart,_variableGlobal.MinStart);
		//Вывод времени 
			_view.Time = _logic.timeDisplay(_variableGlobal.SecStart, _variableGlobal.MinStart);

			//таймер сложности
//			if(_variableGlobal.SecLevel==1 && _view.ProgressBarTime== _variableGlobal.MaxSecLevel * 100){
//				SetProgressBarTime(0);
//				NextStep();
//				_view.TimerLevelEnable=true ;
//			}
				
		}

		//Событие изменения значения секунд Уровня сложности			
		void _variableGlobal_ValueChangedSecLevel(object sender, EventArgs e)
		{
			//if(_variableGlobal.SecLevel ==0 ) 
				//NextStep();
			if(_variableGlobal.SecLevel <=0 ){
					_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;					
			}
			_view.ProgressBarTime = _variableGlobal.SecLevel;
		}
		
		//Запуск времени таймер старта
		void _view_E_Timer_startTick(object sender, EventArgs e)
		{			
			//Отсчет времени
			setTime();							
		}		
		
		//Заполнение
		void FillLabelsForms(int nextIndex){
			
			//Заполнение
				//Слова
			_view.SetWord = _variableGlobal.ReadStroka[nextIndex][0];			
				//Транслита				
			_view.SetTranslate = _variableGlobal.ReadStroka[nextIndex][1];
			// Запоминание правильного варианта
			_variableGlobal.CurrentVariant =_variableGlobal.ReadStroka[nextIndex][2];
			// Запоминание Неправильного слова
			_variableGlobal.NoCurrentVariant = _variableGlobal.ReadStroka[_logic.GetIndexNoCurrentWord(_variableGlobal.ReadStroka , nextIndex)][2];
		
			if(_logic.RandNum(0,2)==1){
				// Распределение вариантов
				_variableGlobal.CurrentNumVar = 1;
				_view.SetVar1 = _variableGlobal.CurrentVariant;
				_view.SetVar2= _variableGlobal.NoCurrentVariant;
				
			} else {
				// Распределение вариантов
				_variableGlobal.CurrentNumVar = 2;
				_view.SetVar2=_variableGlobal.CurrentVariant;
				_view.SetVar1=_variableGlobal.NoCurrentVariant;
			}						
			//Сделать видимыми лейблы
			
			//Установка фона			
		}
		
		//Вывод информацию внизу панели
		void Display(){			
			//Показано
			//_view.CountRead = _variableGlobal.Step.ToString();
			_view.CountVisible = _variableGlobal.CountVisible.ToString();
						
			//Всего слов
			_view.CountWords = _variableGlobal.ReadStroka.Length.ToString();
				
			//Ошибок
			_view.CountError=_variableGlobal.CountErrorWords.ToString();
			
			//Осталось
			_view.CountResidul= _variableGlobal.CountIndexAllWords.ToString();
			
			//Верно
			_view.CountCurrent = _variableGlobal.CountLeanWords.ToString();		
						
			//Прогресс Бар
			_view.ProgressBarCountLean = _logic.Procent( _variableGlobal.ReadStroka.Length, (_variableGlobal.ReadStroka.Length - _variableGlobal.CountIndexAllWords));
			
			//Текущий индекс
//			if(_variableGlobal.CountIndexAllWords!=0)_view.Index= _variableGlobal.CurrentIndex.ToString();
//			else _view.Index="-";
			_view.Index=_variableGlobal.SecLevel.ToString();
				
			//Время независимое
			//_view.Time = _logic.timeDisplay(_variableGlobal.SecStart, _variableGlobal.MinStart);			
		}
		
		//Следующий шаг
		void NextStep(){
			
			// Флаг пауза		
			if(_variableGlobal.FlagPausa) return;
			OutResult("не знаю");
			// обработка варианта
			_variableGlobal.AddIndexErrorWords(_variableGlobal.CurrentIndex);					
			// Последний индекс списка индексов
			_variableGlobal.LastIndex = _logic.GetNextIndex(_variableGlobal.CountIndexAllWords,  _variableGlobal.LastIndex) ;
			//
			
			Cycles();
			//Сообщение
				
			//Установка следующего индекса для показа слова	
			if (_variableGlobal.CountIndexAllWords!=0)
			_variableGlobal.CurrentIndex= _variableGlobal.GetIndexAllWords(_variableGlobal.LastIndex);				
		}
		
//		void SetProgressBarTime(int value){
//			_view.ProgressBarTime = value;
//		}	
		
		//Таймер уровень сложности
		void _view_E_Timer_timeTick(object sender, EventArgs e)
		{
			if(_variableGlobal.MaxSecLevel ==0) return ;
			
			_variableGlobal.SecLevel=--_variableGlobal.SecLevel;
					
		}
		
		//Циклы работ
		void Cycles(){
			//Отработка основного списка
			if(StepLogika()) return ;
			//Отработка ошибочного списка
			
			//Вывод результата по окончании тестировании		
			}
			
		bool  StepLogika()
		{				
			//Запоминание индекс правильного ответа		
			if(_variableGlobal.CountIndexAllWords!=0)
				_variableGlobal.CurrentIndex =_variableGlobal.GetIndexAllWords( _variableGlobal.LastIndex) ;
			else {
				VisibleText(false);
				return false ;
			}
			//Заполнение
			FillLabelsForms(_variableGlobal.CurrentIndex);			
				
			//Выравнивание текста
			_view.SetSize();
			
			//Добавление индекса прочитанного слова
			_variableGlobal.AddIndexReadyWords(_variableGlobal.CurrentIndex);
			
			//Вывод данных на нижнюю панель
			 Display();
			
			//Установка следующего шага
			//_variableGlobal.CountVisible= ++_variableGlobal.CountVisible;
			
			//_variableGlobal.Step= _logic.NextStep(_variableGlobal.Step);
			return true;
		}

		void VisibleText(bool b){
			_view.LabelWordEnable=b;
			if(!_view.ChekTranslate) _view.LabelTransEnable = false;
			else _view.LabelTransEnable=b;			
			_view.LabelVar1Enable=b;
			_view.LabelVar2Enable=b;
			_view.Label_unknown_Visible=b;
		}
		
		// ------Кн. Рестарт--------------
		void _view_E_Button_restartClick(object sender, EventArgs e)
		{
			Restart();
		}	
		
		void Restart(){
			// -----Обнуление переменных-------------			
			_variableGlobal.SecVar=0;
			_variableGlobal.SecStart=0;
			_variableGlobal.MinStart=0;
			_variableGlobal.Step=0;
			_variableGlobal.CurrentIndex=0;
			_variableGlobal.LastIndex=0;
			_variableGlobal.FlagStart=false;
			_variableGlobal.FlagPausa=false;
			_variableGlobal.CountVisible=0; 
			
			//---очистка списка---------------------
			_variableGlobal.ClearIndexErrorWords();
			_variableGlobal.ClearIndexLeanWords();
			_variableGlobal.ClearIndexReadyWords();
			_variableGlobal.IndexAllWords = new System.Collections.Generic.List<int>(_logic.ArrToArr( _variableGlobal.ReadStroka.Length));
			//_variableGlobal.ClearIndexAllWords();
			//	Очистка всех форм
			_view.Tb_all = "";
			_view.Tb_index= "";
			_view.Tb_nextIndex ="";
			_view.Rezult="";
			Display();			
		}
		
		//стоп
		void Stop(){
			//Установка флага включения кнопки старт
			_variableGlobal.FlagStart = false ;			
			Restart();
			//Запуск Timer_start
			//_view.SetTimerStartEnable =false  ;
			//Таймер сложности
			//_view.TimerLevelEnable=false;
			_view.ProgressBarTime =0;
			//
			//Видимость
			VisibleText(false);
			_view.ButtonPausaEnable=false;				
			//Текст кнопки
			_view.ButtonStartText="Старт";
			//
			Display();			
		}
		
		// Проверка включения легкого уровня сложности
		bool  isLevel(){
			if(_variableGlobal.Level==0)	return false;
			return true;
		}
		
		void SetLevelSetting(){
			_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;
			_view.ProgreesBarTimeVisible=true;
			if(_variableGlobal.Level==0){
				_variableGlobal.MaxSecLevel=0;
				_variableGlobal.MaxError=0;
				_variableGlobal.LevelText="легкий";
				_view.ProgreesBarTimeVisible=false;
			}
			
			if(_variableGlobal.Level==1){
				_variableGlobal.MaxSecLevel=10;
				_variableGlobal.MaxError=10;
				_variableGlobal.LevelText="средний";
				_view.ProgressBarTimeMaxValue=10*_variableGlobal.levelMultiplier;
				_variableGlobal.SecLevel=10*_variableGlobal.levelMultiplier;
			}
			
			if(_variableGlobal.Level==2){
				_variableGlobal.MaxSecLevel=5;
				_variableGlobal.MaxError=3;
				_variableGlobal.LevelText="сложный";
				_view.ProgressBarTimeMaxValue=5*_variableGlobal.levelMultiplier;
				_variableGlobal.SecLevel=5*_variableGlobal.levelMultiplier;
			}
			
			if(_variableGlobal.Level==3){
				_variableGlobal.MaxSecLevel=3;
				_variableGlobal.MaxError=1;
				_variableGlobal.LevelText="Экстремальный";
				_view.ProgressBarTimeMaxValue=3*_variableGlobal.levelMultiplier;
				_variableGlobal.SecLevel=3*_variableGlobal.levelMultiplier;
			}
				
		}
			
		void Start(){
			
				//Установка флага включения кнопки старт
			_variableGlobal.FlagStart = _logic.FlagOnOff(_variableGlobal.FlagStart);					
			
			// Если флаг включен
			if(_variableGlobal.FlagStart){
				_variableGlobal.CountVisible=1;
				//Установки уровня сложности
				SetLevelSetting();
				
				//Запуск таймера сложности
				if(isLevel()) _view.TimerLevelEnable=true;
				
				//Текст кнопки
				_view.ButtonStartText="Стоп";
				_view.ButtonPausaEnable=true;
				//изменяемый список индексов всех слов
				LoadIndexAllWords();
				//Вывод информации
				StepLogika();
				//Видимость
				VisibleText(true);	
				Display();
			}			
			// Если флаг выклчен
			else{
				//Видимость
				Stop();
				
			}			
		}	
		//Уровень сложности
		void _view_E_Button_levelClick(object sender, EventArgs e)
		{
		// Restart();
		_variableGlobal.Level =	_view.Level( _variableGlobal.Level);
		//_view.Rezult= _variableGlobal.Level.ToString();
		SetLevelSetting();
		_view.LevelText= _variableGlobal.LevelText;
		}

				
			
		//----------Кн.Старт-------------------
		void _view_E_Button_startClick(object sender, EventArgs e)
		{
			Start();
		}		
		
		void _view_E_Button_pausaClick(object sender, EventArgs e)
		{
			//Установка флага включения кнопки старт
			_variableGlobal.FlagPausa  = _logic.FlagOnOff(_variableGlobal.FlagPausa);			
			
			//Запуск Timer_start
			//_view.SetTimerStartEnable=!_variableGlobal.FlagPausa;				
			
			
		}
    }
}
