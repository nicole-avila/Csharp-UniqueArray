// Array Exercise: 
//Create a console application that prompts the user to input a series of numbers separated by spaces.
//The program should then convert these inputs into an array and find the first unique (non-repeated) number in the array

using System;
using System.Runtime.CompilerServices;

bool runningProgram = true;

while (runningProgram)
{
    Console.WriteLine("Var god och skriv in några siffror efter varandra här nedan. Glöm inte mellansslag efter varje önskad siffra ");

    int[] userInputNumbers = GetAndShowUserInputNumbers();

    FindAndShowTheUniqueNumber(userInputNumbers);

    runningProgram = EndRunningProgram(runningProgram);
}



static int[] GetAndShowUserInputNumbers()
{
    Console.Write("Skriv in dina siffror här: ");

    //string number = int.TryParse(Console.ReadLine());


    ///GÖR en felhantering här .. ifall användaren skriver oglitig inmatning. 
 
    string[] numbersInThisLine = Console.ReadLine()!.Split(' ');

    int[] userInputNumbers = Array.ConvertAll(numbersInThisLine, int.Parse);

    



    foreach (int userInputNumber in userInputNumbers)
    {
        Console.WriteLine(userInputNumber);
    }

    return userInputNumbers;
}

static void FindAndShowTheUniqueNumber(int[] userInputNumbers)
{
     //Group sammlar alla siffron från arreyen och Grupperar dom / eller plockar ut dom  - Where = filterar ut alla värden som har 1 värde, värde = 1.. allatså siffror som är enkla, 1 2 5 6 och inte dubbla siffror 
     // Select = så då tar den det värdet och First() = det första i hela den arreyen som har värden med ett värde.

    // OrderByDescending (x => x.Key) i fallande eller stigande orddning.. Sortera en lista i stigande eller fallande ordning.  
    int firstUniqueNumber = userInputNumbers.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).FirstOrDefault();  // FirstOrDefult == om den inte hittar någiot (ett unikt nummer) så visar den Ingenting, alltså 0.  default värde i int-dataTyp blir 0 ! 

    Console.WriteLine($"ditt unika nummer: {firstUniqueNumber}");

    //int firstUniqueNumber = userInputNumbers.Length;

    //for (int i = 0; i < firstUniqueNumber; i++)
    //{
    //    bool isDublicate = false;
    //    for (int j = 0; j < i; j++)
    //    {
    //        if (userInputNumbers[i] == userInputNumbers[j]) 
    //        { 
    //            isDublicate |= true;
    //            break;
    //        }
    //    }
    //    if (!isDublicate)
    //    {
    //        Console.WriteLine($"Här är ditt unika nummer: {userInputNumbers[i]}");
    //    }
    //}
}

static bool EndRunningProgram(bool runningProgram)
{
    Console.WriteLine("Vill du avsuta programmet? ja/nej");

    string quitProgram = Console.ReadLine()!.ToLower();

    if (quitProgram == "ja")
    {
        runningProgram = false;
    }

    return runningProgram;

    /*
 n: Denna variabel representerar varje element i numbers matrisen när FirstOrDefault metoden itererar över den. I detta sammanhang representerar n ett specifikt tal i matrisen.
x: Denna variabel representerar varje element i numbers matrisen när Count metoden itererar över den för att räkna 
antalet förekomster av det aktuella talet n. I detta sammanhang representerar x ett specifikt tal i matrisen.
 */
}

//int firstUniqueNumber = userInputNumbers.FirstOrDefault(n => userInputNumbers.Count(x => x == n) == 1);

//if (firstUniqueNumber != 0)
//{
//    Console.WriteLine($"Ditt första unika nummer är: {firstUniqueNumber}"); // //om firtsUniqueNumber är null eller inte. Om den är null har inget unkt tal hittat. Om den INTE är null, har ett unikt tal hittats.
//}
//else
//{
//    Console.WriteLine("Det finns inget unkit nummer att visa.");
//}