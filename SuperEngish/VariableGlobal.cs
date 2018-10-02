
using System;
using System.Collections.Generic;

namespace SuperEngish
{
	public interface IVariableGlobal
	{
		//ПОЛЯ
		//Уровень сложности
		int Level{get;set;}
		int levelMultiplier{get;set;}
		
		//Массив словаря
		string[][] ReadStroka{get;set;}
		
		int CountReadWords{get;}
		int CountLeanWords{get;}
		int CountErrorWords{get;}
		int CountAllWords{get;}
		
		//Флаги старта
		bool FlagStart{get;set;}
		bool FlagPausa{get;set;}
		
		//секунды
		int SecVar {get;set;}
		int SecStart {get;set;}
		int MinStart {get;set;}
		int SecLevel {get;set;}
		int MaxSecLevel{get;set;}
		int MaxError {get;set;}
		string LevelText {get;set;}
		
		
		string CurrentVariant{get;set;}
		string NoCurrentVariant{get;set;}
		
		//
		int CurrentNumVar {get;set;}
		int CurrentIndex {get;set;}
		int LastIndex{get;set;}
		
		//кол-во показанных слов
		int CountVisible {get;set;}
		
		//Шаг
		int Step{get;set;}
		
		//Список индексов всех слов
		List<int> IndexAllWords{ set;}
		//Количество непоказанных слов
		int CountIndexAllWords {get;}
		//удаляем прочитанный индекс из общего списка
		void RemoveIndexAllWords(int index);
		//берем текущий индекс из общего списока для чтения
		int GetIndexAllWords(int index);
		//добавляем индексы в общий список
		void AddIndexAllWords(int item);
		
		/*
		List<int> indexAllWords = new List<int>();
		List<int> indexReadyWords = new List<int>();
		List<int> indexLeanWords = new List<int>();
		List<int> indexErrorWords = new List<int>();
		 */
		//Очистка списков
		void ClearIndexAllWords();
		void ClearIndexReadyWords();
		void ClearIndexLeanWords();
		void ClearIndexErrorWords();
		
		//Список показанных слов
		void AddIndexReadyWords(int index);
		int GetIndexReadyWords(int index);
		
		//Список ошибочных слов
		void AddIndexErrorWords(int index);
		int GetIndexErrorWords(int index);
		
		//Список выученных слов
		void AddIndexLeanWords(int index);
		int GetIndexLeanWords(int index);
		
		event EventHandler ValueChangedSecLevel;
		event EventHandler OnFlagStart;
		event EventHandler OnRemoveIndexAllWords;
		event EventHandler OnAddIndexErrorWords;
	}

	public class VariableGlobal:  IVariableGlobal
	{
		#region Возможности 
				//Tuple <int,string,string,string,bool> dict = new Tuple<int, string, string, string, bool>(,,,,);
		//List<Tuple<int,string,string,string,bool>> dict = new List<Tuple<int, string, string, string, bool>>();
		#endregion
		int _maxSecLevel=0;
		int _maxError=0;
		
		int level=0;
		int _levelMultiplier = 57;
		int _secVar=0;
		
		int _secStart=0;
		int _minStart=0;
		string _levelText="легкий";
		
		int _secLevel=0;
		
		string[][] _readStroka ;
		int _step =0;
		// 
		string _currentVariant;
		string _noCurrentVariant;
		int _currentNumVar;
		int _currentIndex=0;
		int _lastIndex=0;
		
		//Флаги старта
		bool _startFalg =false;
		bool _pausaFlag =false;
		
		//Количество показанных
		int _countVisible=0;			
		
		//полный словарь
		List<int> indexAllWords = new List<int>();		
		//прочитанные
		List<int> indexReadyWords = new List<int>();
		//выученные
		List<int> indexLeanWords = new List<int>();
		//ошибки
		List<int> indexErrorWords = new List<int>();

		//События 
		public event EventHandler OnFlagStart;
		public event EventHandler ValueChangedSecLevel;
		public event EventHandler OnRemoveIndexAllWords;
		public event EventHandler OnAddIndexErrorWords;
//--------------------------------------------------
		public int levelMultiplier { get {return _levelMultiplier;	}	set {_levelMultiplier=value;	}	}

		
		public string LevelText {get {return _levelText;} set {_levelText=value;} }
		public int MaxSecLevel {get {return _maxSecLevel;} set {_maxSecLevel=value;}	}
		public int MaxError { get {return _maxError ;}	set {_maxError =value;}	}
		public int SecLevel { get {return _secLevel;}	set {if(_secLevel!=value) {_secLevel=value;  
					if (ValueChangedSecLevel!= null)
						ValueChangedSecLevel(this, EventArgs.Empty);}}	}
		public int Level { get {return level ;} set {level=value;}}
		
		//--------------------------------------------------------------------- 
		public int LastIndex {get {return _lastIndex ;} set { _lastIndex=value;}}
		//--------------------------------------------------------------------- 
		public List<int> IndexAllWords { set { indexAllWords = new List<int>(value);} }
		//--------------------------------------------------------------------- 
		public int CurrentIndex { get { return _currentIndex ;} set { _currentIndex = value;} }
		//--------------------------------------------------------------------- 
		public int CurrentNumVar { get {return _currentNumVar;}	set { _currentNumVar=value;} }
		//--------------------------------------------------------------------- 
		public bool FlagPausa {	get { return  _pausaFlag ;}	set {_pausaFlag=value;} }		
		//--------------------------------------------------------------------- 
		public int CountVisible { get {return _countVisible;} set {_countVisible = value;}	}
		//--------------------------------------------------------------------- 
		public bool FlagStart {	get {return _startFalg;} set {_startFalg= value; if (OnFlagStart!= null) OnFlagStart(this, EventArgs.Empty);} }		
		//------Количество всего загруженных слов
		public int CountReadStroka { get {return _readStroka.Length ;} }
		//------Количество слов в справочнике
		public int CountAllWords {	get {return _readStroka.Length ;} }
		//------Количество оставшихся слов для показа 
		public int CountIndexAllWords {	get {return indexAllWords.Count ;}}		
		// ----------Количество выученых слов
		public int CountLeanWords {	get { return indexLeanWords.Count;} }
		// ---------Количество показанных слов
		public int CountReadWords {	get { return indexReadyWords.Count;	} }
		// --------------Количество ошибочных слов
		public int CountErrorWords { get { return indexErrorWords.Count; } }		
		// -------------Правильный ответ
		public string CurrentVariant {	get {return _currentVariant	;}	set { _currentVariant = value;}	}
		// --------------Неправильный ответ
		public string NoCurrentVariant { get { return _noCurrentVariant;} set { _noCurrentVariant = value;}	}
		//секунды Старта
		public int SecStart { get { return _secStart;} set{_secStart=value;} }
		//--------------------------------------------------------------------- 
		public int MinStart { get { return _minStart ;}	set { _minStart=value;} }
		//--------------------------------------------------------------------- 
		public int SecVar {	get { return _secVar;}	set {_secVar=value;} }		
		// ------------------массив словаряy---------------------------------
		public string[][] ReadStroka { get { return _readStroka;} set { _readStroka = value; } }
		// ------------------Очистка списка---------------------------------
		public void ClearIndexAllWords()		{indexAllWords.Clear();		}
		// ------------------Очистка списка---------------------------------
		public void ClearIndexReadyWords()		{indexReadyWords.Clear();		}
		// ------------------Очистка списка---------------------------------
		public void ClearIndexLeanWords()		{indexLeanWords.Clear();		}
		// ------------------Очистка списка---------------------------------
		public void ClearIndexErrorWords()		{indexErrorWords.Clear();		}
		// ------------------удаление индекса из списка---------------------------------
		public void RemoveIndexAllWords(int index) { indexAllWords.Remove(index); if (OnRemoveIndexAllWords!= null) OnRemoveIndexAllWords(this, EventArgs.Empty);}
		// ------------------взять индекс из списка остатка---------------------------------
		public int GetIndexAllWords(int index)	{ return indexAllWords[index];}
		//--------------------------------------------------------------------- 		
		public void AddIndexAllWords(int item)	{ indexAllWords.Add(item);}			
		//----Cписок индексов прочитанных слов-----------------------
		public void AddIndexReadyWords(int index){ indexReadyWords.Add(index); }
		//--------------------------------------------------------------------- 
		public int GetIndexReadyWords(int index) { return indexReadyWords[index];}		
		//--Список индексов ошибочных слов -----------------------------
		public void AddIndexErrorWords(int index) { indexErrorWords.Add(index); if (OnAddIndexErrorWords!= null) OnAddIndexErrorWords(this, EventArgs.Empty);}
		//--------------------------------------------------------------------- 
		public int GetIndexErrorWords(int index) {	return indexErrorWords[index];}		
		//--Список индексов выученных слов -----------------------------
		public void AddIndexLeanWords(int index) {	indexLeanWords.Add(index);}
		//--------------------------------------------------------------------- 
		public int GetIndexLeanWords(int index)	{	return indexLeanWords[index];}		
		//--------------Шаг, индекс текущей позиции слова------------------------
		public int Step {	get { return _step;	}	set{_step=value;}	}

		
    }
}
