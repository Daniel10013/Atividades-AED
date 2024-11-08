using System;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    public static Stack capturedPokemons;
    public static Queue pokeBattleQueue;
    public static Queue pokeWaitQueue;
    public static Pokemon[] pokemons;
    
    static void Main()
    {
        capturedPokemons = new Stack();
        pokeBattleQueue = new Queue();
        pokeWaitQueue = new Queue();

        string stringNumberPokemon = Console.ReadLine();
        int numberOfPokemons;
        int.TryParse(stringNumberPokemon, out numberOfPokemons);
        pokemons = new Pokemon[numberOfPokemons];

        for (int i = 0; i < pokemons.Length; i++)
        {
            string pokemonData = Console.ReadLine();
            pokemons[i] = new Pokemon(pokemonData, pokemonData);
        }

        string stringNumberActions = Console.ReadLine();
        int numberOfActions;
        int.TryParse(stringNumberActions, out numberOfActions);
        for (int i = 0; i < numberOfActions; i++)
        {
            string action = Console.ReadLine();
            string[] actionArray = action.Split(" ");
            action = actionArray[0];

            if (action.Contains('C'))
            {
                CapturePokemon(actionArray);
            }
            if (action.Contains('P'))
            {
                PreparePokemon(actionArray[1]);
            }
            if (action.Contains('B'))
            {
                SetToBattle(actionArray[1]);
            }
            if (action.Contains('R'))
            {
                RetrievePokemon(actionArray[1]);
            }
            if (action.Contains('L'))
            {
                ReleasePokemon(actionArray[1]);
            }
        }
    }

    private static void CapturePokemon(string[] actionArray)
    {
        if (actionArray.Length == 2)
        {
            CaptureByName(actionArray[1]);
            return;
        }

        bool Param1IsNumber = int.TryParse(actionArray[1], out _);
        if (Param1IsNumber)
        {
            CaptureByWeight(int.Parse(actionArray[1]), int.Parse(actionArray[2]));
        }
        else
        {
            CaptureByType(actionArray[1], actionArray[2]);
        }
    }

    private static void CaptureByName(string name)
    {
        if (capturedPokemons.ItemExists(name) == true)
        {
            Console.WriteLine(name);
            return;
        }

        string capturedPokemonName = "";
        foreach (Pokemon item in pokemons)
        {
            if (item.name == name)
            {
                capturedPokemonName = item.name;
                capturedPokemons.InsertItem(item);
            }
        }

        Console.WriteLine(capturedPokemonName);
    }

    private static void CaptureByType(string type1, string type2)
    {
        foreach (Pokemon item in pokemons)
        {
            Pokemon pokemonToCapture = null;
            if (item.type1 == type1 && item.type2 == type2)
            {
                pokemonToCapture = item;
            }
            if(pokemonToCapture == null){
                continue;
            }

            string capturedPokemonName = pokemonToCapture.name;
            if (capturedPokemons.ItemExists(capturedPokemonName) == true)
            {
                Console.WriteLine(capturedPokemonName);
                continue;
            }

            capturedPokemons.InsertItem(pokemonToCapture);
            Console.WriteLine(capturedPokemonName);
        }
    }

    private static void CaptureByWeight(int weight1, int weight2)
    {
        foreach (Pokemon item in pokemons)
        {
            Pokemon pokemonToCapture = null;
            double.TryParse(item.weight_kg, NumberStyles.Any, CultureInfo.InvariantCulture, out double pokemonWeight);

            if (pokemonWeight >= (double)weight1 && pokemonWeight <= (double)weight2)
            {
                pokemonToCapture = item;
            }

            if(pokemonToCapture == null){
                continue;
            }

            string capturedPokemonName = pokemonToCapture.name;
            if (capturedPokemons.ItemExists(capturedPokemonName) == true)
            {
                Console.WriteLine(capturedPokemonName);
                continue;
            }

            capturedPokemons.InsertItem(pokemonToCapture);
            Console.WriteLine(capturedPokemonName);
        }
    }

    private static void PreparePokemon(string param)
    {   
        int numberOfPokemons;
        int.TryParse(param, out numberOfPokemons);
        for(int i = 0; i < numberOfPokemons; i++){
            Pokemon pokemonToMove = capturedPokemons.GetItem();
            capturedPokemons.RemoveItem();
            pokeWaitQueue.InsertItem(pokemonToMove);
            Console.WriteLine(pokemonToMove.name);
        }
    }

    private static void SetToBattle(string param)
    {
        int numberOfPokemons;
        int.TryParse(param, out numberOfPokemons);
        for(int i = 0; i < numberOfPokemons; i++){
            Pokemon pokemonToMove = pokeWaitQueue.GetItem();
            pokeWaitQueue.RemoveItem();
            pokeBattleQueue.InsertItem(pokemonToMove);
            pokemonToMove.See();
        }
    }

    private static void RetrievePokemon(string param)
    {
        int numberOfPokemons;
        int.TryParse(param, out numberOfPokemons);
        for(int i = 0; i < numberOfPokemons; i++){
            if(pokeWaitQueue.size != 0){
                Pokemon pokemonToMove = pokeWaitQueue.GetItem();
                pokeWaitQueue.RemoveItem();
                capturedPokemons.InsertItem(pokemonToMove);
                Console.WriteLine(pokemonToMove.name);
            }
        }
    }

    private static void ReleasePokemon(string param)
    {
        int numberOfPokemons;
        int.TryParse(param, out numberOfPokemons);
        for(int i = 0; i < numberOfPokemons; i++){
            if(pokeWaitQueue.size != 0){
                Pokemon pokemonToMove = pokeWaitQueue.GetItem();
                pokeWaitQueue.RemoveItem();
                pokemonToMove.See();
            }
        }
    }
}

class Pokemon
{
    public string id { get; set; } public string generation { get; set; } public string name { get; set; } public string description { get; set; }
    public string type1 { get; set; } public string type2 { get; set; } public string weight_kg { get; set; } public string height_m { get; set; }
    public string capture_rate { get; set; } public string is_legendary { get; set; } public string capture_date { get; set; } public string abilities { get; set; }
    public string original_string{get; set;}

    public Pokemon(string pokemonData, string original)
    {
        string[] splitedData;
        string abilitiesSubString, dataWithoutAbility;
        int positionToSplit = FindPositionToSplitByDate(pokemonData);

        splitedData = pokemonData.Split(";");

        if (positionToSplit != -1)
        {
            dataWithoutAbility = pokemonData.Substring(0, positionToSplit + 1);
            abilitiesSubString = pokemonData.Substring(positionToSplit + 2);
            splitedData = this.GetPokemonDataWithAbilities(dataWithoutAbility, abilitiesSubString);
        }

        this.SetAttributes(splitedData, original);
    }

    public void See()
    {
        Console.WriteLine(original_string);
    }

    void SetAttributes(string[] pokemonData, string originalString)
    {
        string[] attributesList = {"id", "generation", "name", "description", "type1", "type2", "weight_kg", "height_m", "capture_rate", "is_legendary", "capture_date", "abilities"};
        
        int i = 0;
        foreach (string atribute in attributesList)
        {  
            bool isType = ValidateType(pokemonData[i]);
            PropertyInfo propertyInfo = GetType().GetProperty(atribute);
            if (isType == true && atribute.Contains("type"))
            {
                propertyInfo.SetValue(this, pokemonData[i]);
                i++;
                continue;
            }else if(isType == false && atribute.Contains("type")){
                propertyInfo.SetValue(this, "");
                continue;
            }
            
            propertyInfo.SetValue(this, pokemonData[i]);
            i++;
        }

        original_string = originalString;
    }

    static bool ValidateType(string typeToValidate)
    {
        string allTypes = "normal fire water electric grass ice fighting poison ground flying psychic bug rock ghost dragon dark steel fairy";
        return allTypes.Contains(typeToValidate);
    }

    static int FindPositionToSplitByDate(string pokemonData)
    {
        string pattern = @"\b(\d{2}/\d{2}/\d{4})\b";
        Match match = Regex.Match(pokemonData, pattern);
        if (match.Success)
        {
            return match.Index + match.Length - 1;
        }
        return -1;
    }

    string[] GetPokemonDataWithAbilities(string dataFirst, string dataSecond)
    {
        string[] splitedFirstData, dataToReturn, secondData;
        splitedFirstData = dataFirst.Split(";");
        secondData = new string[1];
        secondData[0] = dataSecond;

        dataToReturn = new string[splitedFirstData.Length + secondData.Length];
        splitedFirstData.CopyTo(dataToReturn, 0);
        secondData.CopyTo(dataToReturn, splitedFirstData.Length);
        return dataToReturn;
    }
}

class Stack
{
    public int size;
    public Node firstItem;

    public void InsertItem(Pokemon value)
    {
        Node node = firstItem;
        size++;

        if (node == null)
        {
            firstItem = new Node(value, null);
            return;
        }

        while (node.nextItem != null)
        {
            node = node.nextItem;
        }
        node.nextItem = new Node(value, null);
    }

    public void RemoveItem()
    {
        Node node = firstItem;
        size--;

        while (node.nextItem.nextItem != null)
        {
            node = node.nextItem;
        }

        node.nextItem = null;
    }

    public Pokemon GetItem()
    {
        Node node = firstItem;

        while (node.nextItem != null)
        {
            node = node.nextItem;
        }

        return node.itemValue;
    }

    public bool ItemExists(string itemValue){
        Node node = firstItem;
        if(firstItem == null){
            return false;
        }

        while (node.nextItem != null)
        {
            node = node.nextItem;
        }

        if (node.itemValue.name == itemValue)
        {
            return true;
        }

        return false;
    }
}

class Queue
{
    public int size;
    public Node firstItem;

    public void InsertItem(Pokemon value)
    {
        Node node = firstItem;
        size++;

        if (node == null)
        {
            firstItem = new Node(value, null);
            return;
        }

        while (node.nextItem != null)
        {
            node = node.nextItem;
        }
        node.nextItem = new Node(value, null);
    }

    public void RemoveItem()
    {
        Node tmp = firstItem;
        this.firstItem = tmp.nextItem;
        size--;
    }

    public Pokemon GetItem()
    { 
        return firstItem.itemValue;
    }

    
    public bool ItemExists(string itemValue){
        Node node = firstItem;
        if(firstItem == null){
            return false;
        }

        while (node.nextItem != null)
        {
            node = node.nextItem;
        }

        if (node.itemValue.name == itemValue)
        {
            return true;
        }

        return false;
    }
}

class Node
{
    public Pokemon itemValue;
    public Node nextItem;

    public Node(Pokemon itemValue, Node nextItem)
    {
        this.itemValue = itemValue;
        this.nextItem = nextItem;
    }
}