﻿using System;
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
        _view.E_RadioButton_level1CheckedChanged+= _view_E_RadioButton_level1CheckedChanged;
        _view.E_RadioButton_level2CheckedChanged+= _view_E_RadioButton_level2CheckedChanged;
        _view.E_RadioButton_level3CheckedChanged+= _view_E_RadioButton_level3CheckedChanged;
        _view.E_RadioButton_level4CheckedChanged+= _view_E_RadioButton_level4CheckedChanged;
        _view.E_Button_settingStartClick+= _view_E_Button_settingStartClick;
        _view.E_Button_saveClick+= _view_E_Button_saveClick;
        _view.E_Button_loadClick+= _view_E_Button_loadClick;
        _view.E_ListView1SelectedIndexChanged+= _view_E_ListView1SelectedIndexChanged;
        _view.OnFileWordPath+= _view_OnFileWordPath;
        _view.OnFileFotoPath+= _view_OnFileFotoPath;
        _view.RadioButtonDialogLevel1Cheked+= _view_RadioButtonDialogLevel1Cheked;
      _view.RadioButtonDialogLevel2Cheked+= _view_RadioButtonDialogLevel2Cheked;
      _view.RadioButtonDialogLevel3Cheked+= _view_RadioButtonDialogLevel3Cheked;
      _view.RadioButtonDialogLevel4Cheked+= _view_RadioButtonDialogLevel4Cheked;
        //_view.Onlabel_level+= _view_Onlabel_level;
        //_view.E_ProgressBar_timeClientSizeChanged += _view_E_ProgressBar_timeClientSizeChanged;
        
        _variableGlobal.ValueChangedSecLevel+= _variableGlobal_ValueChangedSecLevel;
        _variableGlobal.OnFlagStart+= _variableGlobal_OnFlagStart;
        _variableGlobal.OnRemoveIndexAllWords+= _variableGlobal_OnRemoveIndexAllWords;
        _variableGlobal.OnAddIndexErrorWords+= _variableGlobal_OnAddIndexErrorWords;
        _variableGlobal.OnLevel+= _variableGlobal_OnLevel;
        _variableGlobal.On_CountVisible+= _variableGlobal_On_CountVisible;
        _variableGlobal.On_ReadStroka+= _variableGlobal_On_ReadStroka;
        _variableGlobal.OnClearIndexErrorWords+= _variableGlobal_OnClearIndexErrorWords;
        _variableGlobal.OnClearIndexAllWords+= _variableGlobal_OnClearIndexAllWords;
        _variableGlobal.OnindexAllWords+= _variableGlobal_OnindexAllWords;
        _variableGlobal.OnAddIndexAllWords+= _variableGlobal_OnAddIndexAllWords;
        _variableGlobal.OnAddIndexLeanWords+= _variableGlobal_OnAddIndexLeanWords;
        _variableGlobal.OnClearIndexLeanWords+= _variableGlobal_OnClearIndexLeanWords;

        // Задание параметров формы при первоначальном запуске программы
        }

		void _view_RadioButtonDialogLevel1Cheked(object sender, EventArgs e)
		{
			_view.RadioButton_level1=true;
		}

		void _view_RadioButtonDialogLevel2Cheked(object sender, EventArgs e)
		{
			_view.RadioButton_level2=true;
		}

		void _view_RadioButtonDialogLevel3Cheked(object sender, EventArgs e)
		{
			_view.RadioButton_level3=true;
		}

		void _view_RadioButtonDialogLevel4Cheked(object sender, EventArgs e)
		{
			_view.RadioButton_level4=true;
		}

      #region (((((((((((((((((((((((((((---НАСТРОЙКИ---)))))))))))))))))))))))))))
		//Загрузка настроек
		void _view_E_Button_loadClick(object sender, EventArgs e)
		{
			//Относительный путь
		   string pathFoto = Environment.CurrentDirectory + @"\foto\f0000.jpg";
		   string pathWord = Environment.CurrentDirectory + @"\words\words.txt";
			
		  // _view.FileWordPath = SettingsSE.Default.dictFilePath;
		  _view.FileFotoPath= pathFoto ;
		  _view.FileWordPath = pathWord ;			 
		}
		//Сохранение настроек
		void _view_E_Button_saveClick(object sender, EventArgs e)
		{
			SettingsSE.Default.dictFilePath= _view.FileWordPath;
			SettingsSE.Default.Save();
		}
		#endregion
		void _view_E_Button_settingStartClick(object sender, EventArgs e)
		{
			_view.TabControl1SelectedIndex=1;
			Start();
		}

        //==========УРОВНИ=========================================================
		void _view_E_RadioButton_level4CheckedChanged(object sender, EventArgs e)
		{
			_variableGlobal.Level=3;
			//Установка максимального значения секунда для прогрессбара уровня
			_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;
			//Установка видимости прогрессбара
			_view.ProgreesBarTimeVisible=true;
			SetLevelSetting();
		}
		void _view_E_RadioButton_level3CheckedChanged(object sender, EventArgs e)
		{
			_variableGlobal.Level=2;
			//Установка максимального значения секунда для прогрессбара уровня
			_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;
			//Установка видимости прогрессбара
			_view.ProgreesBarTimeVisible=true;
			SetLevelSetting();
		}
		void _view_E_RadioButton_level2CheckedChanged(object sender, EventArgs e)
		{
			_variableGlobal.Level=1;
			//Установка максимального значения секунда для прогрессбара уровня
			_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;
			//Установка видимости прогрессбара
			_view.ProgreesBarTimeVisible=true;
			SetLevelSetting();
		}
		void _view_E_RadioButton_level1CheckedChanged(object sender, EventArgs e)
		{
			_variableGlobal.Level=0;
			//Установка максимального значения секунда для прогрессбара уровня
			_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;
			//Установка видимости прогрессбара
			_view.ProgreesBarTimeVisible=true;
			SetLevelSetting();
		}
		 //==========УРОВНИ=========================================================
		void _view_E_Form_Closed(object sender, EventArgs e)
		{
			//_messageService.ShowMessage("Ура Заработало");
			_view.TimerLevelEnable=true ;		
		}
		//Значение прогрессБара в цифре внизу на панел
		void _view_OnProgressBarTime(object sender, EventArgs e)
		{
			//_view.Index=_variableGlobal.SecLevel.ToString();
			
			
			//if(_variableGlobal.SecLevel ==1) NextStep();
			//if(_view.ProgressBarTime==100) NextStep();
		}
		
		//Очистка списка ошибок
		void _variableGlobal_OnClearIndexErrorWords(object sender, EventArgs e)
		{
			//Ошибок
			_view.CountError=_variableGlobal.CountErrorWords.ToString();			
		}		

		//-------------------------- Флаг Старта---------------------------
		void _variableGlobal_OnFlagStart(object sender, EventArgs e)
		{
			_view.TimerLevelEnable= _variableGlobal.FlagStart;
			_view.SetTimerStartEnable= _variableGlobal.FlagStart;
							
		}
		//======================================================================
		#region (((((((((((((((((((____Выбор папок______)))))))))))))))))))
		//если изменилось значение поля ссылки файла
			void _view_OnFileWordPath(object sender, EventArgs e)
		{
			try {
				_view.DirWordsPath =  _logic.GetDirPathFromFileName( _view.FileWordPath);
			
			//очищаем таблицу
			_view.dataGridView1RowsClear();
			
			//создаем массив всех слов
			_variableGlobal.ReadStroka=_logic.AddReadStroka(_logic.GetFileReadAllLines(_view.FileWordPath));
			
			//изменяемый список индексов всех слов
			LoadIndexAllWords();
			
			//загружаем таблицу массивом всех слов			
			_view.addGrids(_variableGlobal.ReadStroka);
			} catch (Exception) {
				
				;
			}
		}
			
         // При выборе из листвьювер
		void _view_E_ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			//создаем массив всех слов
			if(_view.GetItemListView() != "")
			_variableGlobal.ReadStroka=_logic.AddReadStroka(_logic.GetFileReadAllLines(_view.DirWordsPath + _view.GetItemListView() ));
			else return;
			
			//Очищаем список
			_variableGlobal.ClearIndexAllWords();
			//очищаем таблицу
			_view.dataGridView1RowsClear();
			
			
			//изменяемый список индексов всех слов
			LoadIndexAllWords();
			
			//загружаем таблицу массивом всех слов			
			_view.addGrids(_variableGlobal.ReadStroka);
			
		
		}
		void _view_OnFileFotoPath(object sender, EventArgs e)
		{
			try {
				_view.DirFotoPath=  _logic.GetDirPathFromFileName( _view.FileFotoPath);
			} catch (Exception) {
				
				;
			}
		}

        // папка для словаря
		void _view_E_Button_selectDirWordsPathClick(object sender, EventArgs e)
		{
			_view.DirWordsPath = _view.GetDirWordsPath ;
		}		
		// файл для словаря
		void _view_E_Button_selectFileWordsPathClick(object sender, EventArgs e)
		{
			
			_view.FileWordPath = _view.GetFileWordsPath ;
			if(_view.FileWordPath !=""){
				
			
			_view.DirWordsPath =  _logic.GetDirPathFromFileName( _view.FileWordPath);
			
			//Очищаем список
			_variableGlobal.ClearIndexAllWords();
			//очищаем таблицу
			_view.dataGridView1RowsClear();			
			//создаем массив всех слов
			_variableGlobal.ReadStroka=_logic.AddReadStroka(_logic.GetFileReadAllLines(_view.FileWordPath));			
			//изменяемый список индексов всех слов
			LoadIndexAllWords();			
			//загружаем таблицу массивом всех слов			
			_view.addGrids(_variableGlobal.ReadStroka);
			}			
			//Загрузка списка файлов
			_view.SetListFilesListView(_view.DirWordsPath);
			
			
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
			if(_view.FileFotoPath !="")
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
		
	#region(((((((((((((((((((____ОБРАБОТКА ВАРИАНТОВ)))))))))))))))))))
			
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
		
		//Нажатие кнопки "НЕ ЗНАЮ"
		void _view_E_Label_unknownClick(object sender, EventArgs e)
		{
			if(_variableGlobal.FlagPausa) return;
			
			_view.TimerLevelEnable=false;
			_view.ShowFormError(_variableGlobal.ReadStroka[_variableGlobal.CurrentIndex][0],_variableGlobal.ReadStroka[_variableGlobal.CurrentIndex][1],_variableGlobal.ReadStroka[_variableGlobal.CurrentIndex][2]);			
			//-------------------------------------------------------------
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
		
		// Нажатие Варианта 1  
		void _view_E_Label_v1Click(object sender, EventArgs e)
		{
			//
			if(_variableGlobal.FlagPausa) return;
			// обработка варианта
			LogicaVar(1);
			//			
			//Cycles();
			StepLogika();
			//Сообщение
	
			//
			TestOut();
			//Установка следующего индекса для показа слова		
//		if(_variableGlobal.CountIndexAllWords!=0) 				
//			_variableGlobal.CurrentIndex= _variableGlobal.GetIndexAllWords(_variableGlobal.LastIndex);		
			
		}
		
		// Нажатие Варианта 2
		void _view_E_Label_v2Click(object sender, EventArgs e)
		{
			// Флаг пауза		
			if(_variableGlobal.FlagPausa) return;
			// обработка варианта
			LogicaVar(2);
			//Тестовая информация
			//Cycles();
			StepLogika();
			//Сообщение			
			TestOut();
			
			//Установка следующего индекса для показа слова	
//			if(_variableGlobal.CountIndexAllWords!=0) 		
//				_variableGlobal.CurrentIndex= _variableGlobal.GetIndexAllWords(_variableGlobal.LastIndex);				
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
				_logic.PlayTak();
				OutResult("верно");				
				SetColorVariant(var, Color.LightGreen);
				_view.SetTimerVarEnable= true ;				
				_variableGlobal.AddIndexLeanWords(_variableGlobal.CurrentIndex);
				_variableGlobal.RemoveIndexAllWords(_variableGlobal.CurrentIndex); // удаляем из списка показа
				
			// Последний индекс списка
			//_variableGlobal.LastIndex = _logic.GetStartIndex(_variableGlobal.CountIndexAllWords,  _variableGlobal.LastIndex) ;
			
			}else {
				// если неверно
			//Вывод результата
				_logic.PlayError();
				OutResult("не верно");
				SetColorVariant(var, Color.Red);
				_view.SetTimerVarEnable= true ;
				_variableGlobal.AddIndexErrorWords(_variableGlobal.CurrentIndex);					
			// Последний индекс списка индексов
			//_variableGlobal.LastIndex = _logic.GetNextIndex(_variableGlobal.CountIndexAllWords,  _variableGlobal.LastIndex) ;
			}
			
			//-----------------------------------------------------------------
			_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;
		}
		
		
		void  StepLogika()
		{				
//			//Запоминание индекс правильного ответа		
//			if(_variableGlobal.CountIndexAllWords!=0)
//				_variableGlobal.CurrentIndex =_variableGlobal.GetIndexAllWords( _variableGlobal.LastIndex) ;
//			else {	
//				VisibleText(false);					
//			}
			
			//======================
			
			//Заполнение
			//Слова
//			_view.SetWord = _variableGlobal.ReadStroka[nextIndex][0];			
//			//Транслита				
//			_view.SetTranslate = _variableGlobal.ReadStroka[nextIndex][1];
//			// Запоминание правильного варианта
//			_variableGlobal.CurrentVariant =_variableGlobal.ReadStroka[nextIndex][2];
//			// Запоминание Неправильного слова
//			_variableGlobal.NoCurrentVariant = _variableGlobal.ReadStroka[_logic.GetIndexNoCurrentWord(_variableGlobal.ReadStroka , nextIndex)][2];
			//==========================
			
			//Заполнение
			FillLabelsForms(_variableGlobal.CurrentIndex);			
				
			//Выравнивание текста
			_view.SetSize();
			
			//Добавление индекса прочитанного слова
			_variableGlobal.AddIndexReadyWords(_variableGlobal.CurrentIndex);				
		}
		
		// Cобыитие на изменение количество верных
		void _variableGlobal_OnRemoveIndexAllWords(object sender, EventArgs e)
		{
						
			//Прогресс Бар
			_view.ProgressBarCountLean = _logic.Procent( _variableGlobal.ReadStroka.Length, (_variableGlobal.ReadStroka.Length - _variableGlobal.CountIndexAllWords));
			
			//Осталось
			_view.CountResidul= _variableGlobal.CountIndexAllWords.ToString();
			
			//Установка следующего шага
			if (_variableGlobal.CountIndexAllWords !=0){
				_variableGlobal.CountVisible= ++_variableGlobal.CountVisible;
				// Последний индекс списка
				_variableGlobal.LastIndex = _logic.GetStartIndex(_variableGlobal.CountIndexAllWords,  _variableGlobal.LastIndex) ;
				//Запоминание индекс правильного ответа	
				_variableGlobal.CurrentIndex =_variableGlobal.GetIndexAllWords( _variableGlobal.LastIndex) ;				
			}
			
			else{
				_variableGlobal.FlagStart=false;
				//_logic.PlayRating(0);
				_logic.PlayRating(_logic.GetRating(_variableGlobal.Level, _variableGlobal.CountAllWords,_variableGlobal.CountErrorWords));
				_messageService.ShowMessage("Поздравляем!"
                                            + Environment.NewLine
                                            +"Все слова выучены!" 
                                            + Environment.NewLine
                                            +"Количество правильных слов - " + _variableGlobal.CountAllWords 
                                            + Environment.NewLine
                                            + "Сделано ошибок - " + _variableGlobal.CountErrorWords 
                                            + Environment.NewLine
                                            + "Всего показов - " + _variableGlobal.CountVisible
                                            + Environment.NewLine
                                            + "Оценка - " + _logic.GetOcenka(_logic.GetRating(_variableGlobal.Level, _variableGlobal.CountAllWords,_variableGlobal.CountErrorWords))
                                           ); 
					Stop();  
					return ;
			}
			
		}
		
		 // Cобыитие на изменение количество ошибок
		void _variableGlobal_OnAddIndexErrorWords(object sender, EventArgs e)
		{
			//Ошибок
			_view.CountError=_variableGlobal.CountErrorWords.ToString();
			
			//Проверка достижения лимита ошибок
			if(_variableGlobal.CountErrorWords == _variableGlobal.MaxError){
				StopError();
				Restart();
			}
			//Установка следующего показа
			else if (_variableGlobal.CountIndexAllWords !=0){
				_variableGlobal.CountVisible= ++_variableGlobal.CountVisible;
				// Последний индекс списка
				_variableGlobal.LastIndex = _logic.GetNextIndex(_variableGlobal.CountIndexAllWords,  _variableGlobal.LastIndex);
				//Запоминание индекс правильного ответа	
				_variableGlobal.CurrentIndex =_variableGlobal.GetIndexAllWords( _variableGlobal.LastIndex) ;	
			}			
					
		}
		
		//Событие изменения значения секунд Уровня сложности			
		void _variableGlobal_ValueChangedSecLevel(object sender, EventArgs e)
		{
			//Отображение на дисплеее секунд
			_view.Index=_variableGlobal.SecLevel.ToString();
			
			//if(_variableGlobal.SecLevel ==0 )
				//NextStep();
				if( _variableGlobal.SecLevel < _view.ProgressBarTimeMaxValue /2 ){
					_view.LabelVar2Visible=true;
					_view.LabelVar1Enable= false;
					
				}else {
					_view.LabelVar1Enable= true;
					_view.LabelVar2Visible=false;
					
				}
				
			
			if(_variableGlobal.SecLevel ==0) {
				_logic.PlayTime();
			     NextStep();
			}
			if(_variableGlobal.SecLevel <=0 ){
					_variableGlobal.SecLevel=_variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;					
			}
			_view.ProgressBarTime = _variableGlobal.SecLevel;
		}
				
			//Следующий шаг
		void NextStep(){
			
			// Флаг пауза		
			if(_variableGlobal.FlagPausa) return;
			
			OutResult("не знаю");
			// обработка варианта
			_variableGlobal.AddIndexErrorWords(_variableGlobal.CurrentIndex);					
			// Последний индекс списка индексов
			//_variableGlobal.LastIndex = _logic.GetNextIndex(_variableGlobal.CountIndexAllWords,  _variableGlobal.LastIndex) ;
			//Установка картинки если путь задан
			if(_view.ChekFoto)
			_view.SetBackgroundImage(_view.DirFotoPath + "f"+_logic.RandNum(0,50) +".jpg");
			
			StepLogika();
			//Cycles();
			//Сообщение
				
			//Установка следующего индекса для показа слова	
		//	if (_variableGlobal.CountIndexAllWords!=0)
		//	_variableGlobal.CurrentIndex= _variableGlobal.GetIndexAllWords(_variableGlobal.LastIndex);				
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
			}			
		}
	#endregion		

		// Установка и вывод минут и секунд
		void setTime(){
		// Установка минут и секунд
			_variableGlobal.SecStart = _logic.SetSecTime(_variableGlobal.SecStart);	
			_variableGlobal.MinStart= _logic.SetMinTime(_variableGlobal.SecStart,_variableGlobal.MinStart);
		//Вывод времени 
			_view.Time = _logic.timeDisplay(_variableGlobal.SecStart, _variableGlobal.MinStart);
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
		
         //СОБЫТИЯ НА ДИСПЛЕЙ
		void _variableGlobal_On_CountVisible(object sender, EventArgs e)
		{
			//Показано
			_view.CountVisible = _variableGlobal.CountVisible.ToString();
						
		}

		void _variableGlobal_On_ReadStroka(object sender, EventArgs e)
		{
			//Прогресс Бар
			_view.ProgressBarCountLean = _logic.Procent( _variableGlobal.ReadStroka.Length, (_variableGlobal.ReadStroka.Length - _variableGlobal.CountIndexAllWords));
			
			//Всего слов
			_view.CountWords = _variableGlobal.ReadStroka.Length.ToString();			
		}

		void _variableGlobal_OnClearIndexAllWords(object sender, EventArgs e)
		{
			//Прогресс Бар
			_view.ProgressBarCountLean = _logic.Procent( _variableGlobal.ReadStroka.Length, (_variableGlobal.ReadStroka.Length - _variableGlobal.CountIndexAllWords));
			
			//Осталось
			_view.CountResidul = _variableGlobal.CountIndexAllWords.ToString();
		}

		void _variableGlobal_OnindexAllWords(object sender, EventArgs e)
		{
			//Прогресс Бар
			_view.ProgressBarCountLean = _logic.Procent(_variableGlobal.ReadStroka.Length, (_variableGlobal.ReadStroka.Length - _variableGlobal.CountIndexAllWords));
			
			//Осталось
			_view.CountResidul = _variableGlobal.CountIndexAllWords.ToString();
		}

		void _variableGlobal_OnAddIndexAllWords(object sender, EventArgs e)
		{
			//Прогресс Бар
			_view.ProgressBarCountLean = _logic.Procent(_variableGlobal.ReadStroka.Length, (_variableGlobal.ReadStroka.Length - _variableGlobal.CountIndexAllWords));
			
			//Осталось
			_view.CountResidul = _variableGlobal.CountIndexAllWords.ToString();			
			
		}

		void _variableGlobal_OnAddIndexLeanWords(object sender, EventArgs e)
		{
			//Верно
			_view.CountCurrent = _variableGlobal.CountLeanWords.ToString();	
		}

		void _variableGlobal_OnClearIndexLeanWords(object sender, EventArgs e)
		{
			//Верно
			_view.CountCurrent = _variableGlobal.CountLeanWords.ToString();		
		}
		
		//Таймер уровень сложности
		void _view_E_Timer_timeTick(object sender, EventArgs e)
		{
			if(_variableGlobal.MaxSecLevel ==0) return ;			
			_variableGlobal.SecLevel=_variableGlobal.SecLevel-1;					
		}
		
		void VisibleText(bool b){
			_view.LabelWordEnable=b;
			if(!_view.ChekTranslate) _view.LabelTransEnable = false;
			else _view.LabelTransEnable=b;
			if(!b){
			_view.LabelVar1Visible=b;
			_view.LabelVar2Visible=b;
			}
			else _view.LabelVar1Visible=b;
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
			//Видимость слов
			VisibleText(false);
			//Видимость прогрессбара
			_view.ProgreesBarTimeVisible=false;
			//Текст кнопки
			_view.ButtonStartText="Старт";			
		}
		//Стоп-ошибка
		void StopError(){
			//Установка флага включения кнопки старт
			_variableGlobal.FlagStart = false ;			
			//Видимость
			VisibleText(false);		
			_logic.PlayError();
			_logic.PlayRating(_logic.GetRating(_variableGlobal.Level, _variableGlobal.CountAllWords,_variableGlobal.CountErrorWords));
			_messageService.ShowExclamation("Ай..ай..ай!" + Environment.NewLine
				                                +"Слишком много ошибок для этого режима!"  + Environment.NewLine
				                                + "Попробуйте еще разок(:");			
		}
		//стоп
		void Stop(){
			//Установка флага включения кнопки старт
			_variableGlobal.FlagStart = false ;			
			Restart();		
		}
		
		// Проверка включения легкого уровня сложности
		bool  isLevel(){
			if(_variableGlobal.Level==0)	return false;
			return true;
		}		

		void _variableGlobal_OnLevel(object sender, EventArgs e)
		{
			switch (_variableGlobal.Level) {
				case 0: 
					_view.LevelText = "легкий";
					break;
				case 1:	
					_view.LevelText = "средний";
					break;
				case 2:
					_view.LevelText = "сложный";
					break;
				case 3:
					_view.LevelText = "Экстремальный";
					break;
				default: 
					_view.LevelText = "легкий";
					break;						
						
			};
		}
		
		void SetLevelSetting()
		{			
			
			if (_variableGlobal.Level == 0) {
				_variableGlobal.MaxSecLevel = 0;
				_variableGlobal.MaxError = 0;
				_variableGlobal.LevelText = "легкий";
				_view.ProgreesBarTimeVisible = false;
			}
			
			if (_variableGlobal.Level == 1) {
				_variableGlobal.MaxSecLevel = 10;
				_variableGlobal.MaxError = 10;
				_variableGlobal.LevelText = "средний";
				_view.ProgressBarTimeMaxValue = 10 * _variableGlobal.levelMultiplier;
				_variableGlobal.SecLevel = 10 * _variableGlobal.levelMultiplier;
			}
			
			if (_variableGlobal.Level == 2) {
				_variableGlobal.MaxSecLevel = 5;
				_variableGlobal.MaxError = 3;
				_variableGlobal.LevelText = "сложный";
				_view.ProgressBarTimeMaxValue = 5 * _variableGlobal.levelMultiplier;
				_variableGlobal.SecLevel = 5 * _variableGlobal.levelMultiplier;
			}
			
			if (_variableGlobal.Level == 3) {
				_variableGlobal.MaxSecLevel = 3;
				_variableGlobal.MaxError = 1;
				_variableGlobal.LevelText = "Экстремальный";
				_view.ProgressBarTimeMaxValue = 3 * _variableGlobal.levelMultiplier;
				_variableGlobal.SecLevel = 3 * _variableGlobal.levelMultiplier;
			}				
		}
			
		void Start(){			
				//Установка флага включения кнопки старт
			_variableGlobal.FlagStart = _logic.FlagOnOff(_variableGlobal.FlagStart);					
			
				// Если флаг включен
			if (_variableGlobal.FlagStart) {
				_variableGlobal.CountVisible = 1;			
				_view.ProgreesBarTimeVisible = true;
				//Установки уровня сложности
				SetLevelSetting();				
				//Запуск таймера сложности
				if (isLevel())
					_view.TimerLevelEnable = true;					
				//Текст кнопки
				_view.ButtonStartText = "Стоп";
				_view.ButtonPausaEnable = true;
				//изменяемый список индексов всех слов
				LoadIndexAllWords();
				//Вывод информации
				StepLogika();
				//Видимость
				VisibleText(true);
				
				//Display();
				//Установка картинки если путь задан
				if (_view.ChekFoto)
					_view.SetBackgroundImage(_view.DirFotoPath + "f" + _logic.RandNum(0, 50) +".jpg");
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
			_variableGlobal.Level =	_view.Level(_variableGlobal.Level);
			//Установка максимального значения секунда для прогрессбара уровня
			_variableGlobal.SecLevel = _variableGlobal.MaxSecLevel * _variableGlobal.levelMultiplier;
			//Установка видимости прогрессбара
			_view.ProgreesBarTimeVisible = true;
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
	
		}
    }
}
