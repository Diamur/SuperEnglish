using System;
using System.IO;
//using System.Text;
using System.Collections.Generic;
//using System.Media;


namespace SuperEngish.BL
{

  public interface ILogic
    {
	string GetDirPathFromFileName(string fileName);
	bool isSecVar(int s);
	string[] GetFileReadAllLines(string defoultPath) ;
	string[][] AddReadStroka(string[] stroka);
	int TimePlus(int sec);
	int NextStep(int step);
	string timeDisplay(int s, int m);
	int Procent(int full , int part);
	void Plus(int dig);
	 int SetMinTime(int sec, int min);
 	int SetSecTime(int sec);
 	bool FlagOnOff(bool flag);
 	int GetIndexNoCurrentWord(string[][] readStroka, int indexCurrent);
 	List<int> ListIndex(int[] input);
 	//
 	int RandNum(int min,int max);
 	int[] ArrToArr(int countArr);
 	int GetNextIndex(int countArr, int lastIndex); 	
 	int GetStartIndex(int countArr, int lastIndex);
 	void PlayError();
 	void PlayTime();
 	void PlayRating(int rating);
 	void PlayTak();
 	int GetRating(int level, int countAllWord,  int countError);
 	int GetOcenka(int rating);
    }
    

  
  public class Logic: ILogic  
  {	
  		MyMedia _myMedia= new MyMedia();
  		//((((((((((((((((----------Файлы---------------)))))))))))))))))
  		//Открыть путь каталога
//  		public string GetPathDir(){
//  			
//  		}
    		  		
  		//((((((((((((((((----------Воспроизведение  звука---------********-*-*-*-*09975
  		public void PlayError(){
  			//MyMedia _myMedia= new MyMedia();
  			_myMedia.Error( RandNum(1,13));
  		}
  		
  		public void PlayTime(){
  			//MyMedia _myMedia= new MyMedia();
  			_myMedia.Time ( RandNum(1,5));
  		}
  		
  		public void PlayRating(int rating){
  			//MyMedia _myMedia= new MyMedia();
  			_myMedia.Rating(rating);
  		}
  		
  		public void PlayTak(){
  			//MyMedia _myMedia= new MyMedia();
  			_myMedia.Tak();
  		}
  		
  		
  		//((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
  		//Расчет оценки
  		public int GetOcenka(int rating){
  			switch (rating ) {
  					case 2: return 5;
  					case 1: return 4;
  					case 0: return 2; 			 					
  			}
  			return 2;
  		}
  		
  		//Расчет рейтинга
  		public int GetRating(int level, int countAllWord,  int countError){
  			switch (level) {
  					case 0:{
  						if(countError==0) return 2;
  						if(	100*(double)countError/(double)countAllWord < 33) return 1;
  						if(100*(double)countError/(double)countAllWord > 33) return 0;
  					}; break;
  					case 1:{
  						if(countError==0) return 2;
  						if(	countError < 4) return 1;
  						if(countError > 4) return 0;
  					}; break;
  					case 2:{
  						if(countError==0) return 2;
  						if(	countError==1) return 1;
  						if(countError>1) return 0;
  					}; break;
  					case 3:{
  						if(countError==0) return 2;
  						if(	countError==1) return 0;  						
  					}  	; break;
  			}
  			return 2;
  		}
  		
  		//Взять следующий индекс
  		public int GetNextIndex(int countArr, int lastIndex){  
				if(lastIndex ==countArr-1) return 0;
  			return ++lastIndex;  			
  		}
  		
  		public int GetStartIndex(int countArr, int lastIndex){  
				if(lastIndex ==countArr) return 0;
  			return lastIndex;  			
  		}
  		  	
		//Массив из массива
	  	public int[] ArrToArr(int countArr){
	  	
		int[] arr = new int[countArr];
			
	  	for (int i = 0; i < countArr; i++) {
			arr[i]=i;
	  	}
		return arr;
	  }
	  	
	  	// Список индексов
	  	public List<int> ListIndex(int[] input){
	  			List<int> t = new List<int>(input);
	  			return t;
	  		}
	  		
        // Поля текущего класса        
        public int RandNum(int min,int max){
        	// создаем экземпляр класса Random для генерирования случайных чисел
		    Random rand = new Random();		   
		      return  rand.Next(min,max);
        }
        
        
        //Взять путь папки из имени
        public string GetDirPathFromFileName(string fileName){
        	return Path.GetDirectoryName(fileName)+@"\";
        }
        
        //Секунды
        //Проверить секунды вариантов
        public bool isSecVar(int s){
        	if (s > 5) return true;
        		return false;
        }
        
        //Процент прогресса
        public int Procent(int full , int part){
        	return (int)(100*(double)part/(double)full);
        }        

         //Взять строки из файла
        public string[] GetFileReadAllLines(string defoultPath){
        	return File.ReadAllLines(defoultPath);        	
        }
        
        //Посчитать кол-во строк в файле
        #region Функция для Перемешивание массива
		static void Shuffle(string[] arr)
		{
		    // создаем экземпляр класса Random для генерирования случайных чисел
		    Random rand = new Random();
		 
		    for (int i = arr.Length - 1; i >= 1; i--)
		    {
		        int j = rand.Next(i + 1);
		 
		        string tmp = arr[j];
		        arr[j] = arr[i];
		        arr[i] = tmp;
		    }
		}
		
		// Перемешивание и добавление массива
		public string[][] AddReadStroka(string[] stroka){
			
			Shuffle(stroka);
        	
        	int countWords = stroka.Length ;        	
        	
        	string[][] _readStroka = new string[countWords][];
			var readWord = new string[4];
        
			for (int i = 0; i < countWords; i++) {
				readWord = stroka[i].Split('\t');
				_readStroka[i]= new string[4]{readWord[0],readWord[1],readWord[2], "0" };
			}
			return _readStroka;
        }
		#endregion
		
		public int NextStep(int step){
			return ++step;			
		}
		
		#region	Время	
       	public int TimePlus(int sec){
			return ++sec;
		}
		
		public void Plus(int dig){
			dig=dig+1;
		}	
		
		//Секундомер
		public string timeDisplay(int s, int m){

			string time_s = "00";
			string time_m = "00";
			string time = "";			
			if(s < 10) 				time_s = "0" + s;			
			if(s > 9 && s <= 59) 	time_s = s.ToString();			
			if(s == 60) 			time_m = "01";			
			if(m > 0 && m < 9) 		time_m="0" + m;			
			if(m >=9)				time_m= m.ToString();				
			return 					time = time_m + ":" + time_s;			
		}
		
		public bool FlagOnOff(bool flag){
			if(!flag) return true ;			
			return false ;
		}
						
		public int SetSecTime(int sec){
			if(sec < 60) sec++;
			else sec =0;
			return sec;
		}
		
		public int SetMinTime(int sec, int min){
			if(sec==60) min++;
			if(min == 60) min=0;
			return min;
		}
		#endregion
		//Поиск неправильного слова близкого по размеру
		public int GetIndexNoCurrentWord(string[][] readStroka, int indexCurrent){
			
			int maxLen =0;
			//int dtLet=0;
			
			//Поиск самого длинного ответа
			for (int k = 0; k < readStroka.Length ; k++) {
				//if(k!=indexCurrent)
					if(readStroka[k][2].Length > maxLen) maxLen = readStroka[k][2].Length;
			}
			
			// Перебор по разнице длин между ответами
			for (int dt = 0; dt < maxLen; dt++) {				
				//Поиск близкого по разнице длин ответов
				for (int i = 0; i < readStroka.Length ; i++) {				
					if(i!=indexCurrent)
						if(Math.Abs(readStroka[i][2].Length - readStroka[indexCurrent][2].Length) == dt) return i;					
				}				
			}
			return indexCurrent;
		}
	
		
    }
	
}
