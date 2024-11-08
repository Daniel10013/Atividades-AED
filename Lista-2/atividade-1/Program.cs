using System;

class Program{
    static void Main(string[] args)
    {
        int qntdOfCountrys;
        int.TryParse(Console.ReadLine(), out qntdOfCountrys);
        string[] countryList = new string[qntdOfCountrys];
        for(int i = 0; i < qntdOfCountrys; i++){
            countryList[i] = Console.ReadLine();
        }

        countryList = OrderListByGold(countryList, 1);
        countryList = OrderOtherValues(countryList, 2);  
        countryList = OrderOtherValues(countryList, 3);
        countryList = OrderByCountryName(countryList);
        foreach(string country in countryList){
            Console.WriteLine(country);
        }
    }

    static string[] OrderListByGold(string[] countryList, int indexToGetValue){
        for(int i = 0; i < countryList.Length; i++){
            int medalValue = GetNumberFromString(countryList[i], indexToGetValue); 
            
            for(int j = 0; j < countryList.Length; j++){
                int medalValueCompare = GetNumberFromString(countryList[j], indexToGetValue); 

                string temp;
                if(medalValue > medalValueCompare){
                    temp = countryList[i];
                    countryList[i] = countryList[j];
                    countryList[j] = temp;
                }
            }
        }
        return countryList;
    }

    static string[] OrderOtherValues(string[] countryList, int indexToOrder){
        for(int i = 0; i < countryList.Length - 1; i++){
            int valueBefore = GetNumberFromString(countryList[i], indexToOrder - 1 ); 
            int valueBeforeCompare = GetNumberFromString(countryList[i + 1], indexToOrder - 1);  

            if(i + 1 != countryList.Length && valueBefore == valueBeforeCompare){

                int medalValue = GetNumberFromString(countryList[i], indexToOrder); 
                int medalValueCompare = GetNumberFromString(countryList[i + 1], indexToOrder); 
                if(medalValue < medalValueCompare){
                    string temp;
                    temp = countryList[i];
                    countryList[i] = countryList[i + 1];
                    countryList[i + 1] = temp;
                }
            }
        }
        return countryList;
    }

    static string[] OrderByCountryName(string[] countryList){
          for(int i = 0; i < countryList.Length - 1; i++){
            int bronzeNumber = GetNumberFromString(countryList[i], 3); 
            int bronzeNumberCompare = GetNumberFromString(countryList[i + 1], 3);  

            if(i + 1 != countryList.Length && bronzeNumber == bronzeNumberCompare){
                int compareResult = CompareWords(countryList[i], countryList[i + 1]);
                if(compareResult > 1){ 
                    string temp;
                    temp = countryList[i];
                    countryList[i] = countryList[i + 1];
                    countryList[i + 1] = temp;
                }
            }
        }
        return countryList;
    }

    static int GetNumberFromString(string text, int indexToReturn){
        string[] splitedText = text.Split(" ");

        bool isNumeric = int.TryParse(splitedText[indexToReturn], out _);
        if(isNumeric == true){
            return int.Parse(splitedText[indexToReturn]);
        }

        return -1;
    }

    static int CompareWords(string word1, string word2)
    {
        int resultado = string.Compare(word1, word2, StringComparison.OrdinalIgnoreCase);
        return resultado;
    }
}
