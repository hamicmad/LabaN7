using System.Text.RegularExpressions;

var vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'y' };
var alphabet = Enumerable.Range(65, 26).Select(x => (char)x).ToArray();
string fullStr1;
string[] fullStr2;
using (var sr = new StreamReader("test.txt"))
{
    fullStr1 = sr.ReadToEnd();
    fullStr2 = fullStr1.Split('.');
}
using (var sr = new StreamReader("test.txt"))
{
    // 1. Написать программу, которая считывает из текстового файла три предложения и выводит их в обратном порядке.
    string[] str = new string[3];
    for (int i = 0; i < 3; i++)
    {
        str[i] = sr.ReadLine();
    }
    for (int i = str.Length - 1; i >= 0; i--)
    {
        Console.WriteLine(str[i]);
    }
}

// 2.Написать программу, которая считывает текст из текстового файла  и выводит на экран только предложения,
//содержащие введенное с клавиатуры слово.

var inputStr = Console.ReadLine();
foreach (var sent in fullStr2)
    if (sent.ToUpper().Contains(inputStr.ToUpper()))
        Console.WriteLine(sent);

// 3. При помощи регулярных выражений найти все числа из текстового файла и вывести их на экран
var res2 = Regex.Matches(fullStr1, @"\d");
if (res2.Count > 0)
    foreach (Match m in res2)
        Console.Write(m.Value + " ");
Console.WriteLine();



// 4.Написать программу, которая считывает английский текст из текстового файла
// и выводит на экран слова, начинающиеся с гласных букв.
var res3 = fullStr1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < res3.Length; i++)
{
    if (vowels.Contains(char.ToLower(res3[i][0])))
    {
        Console.WriteLine(res3[i]);
    }
}

// 5.Написать программу, которая считывает текст из текстового файла и
// выводит на экран только предложения, не содержащие запятых.
foreach (var sent in fullStr2)
    if (!sent.Contains(','))
        Console.WriteLine(sent);

// 6. Написать программу, которая считывает текст из текстового файла и выводит его на экран,
// меняя местами каждые два соседних слова.
var str6 = fullStr2[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
var extraStr = string.Empty;
for (int i = 0; i < str6.Length - 1; i += 2)
{
    extraStr = str6[i];
    str6[i] = str6[i + 1];
    str6[i + 1] = extraStr;
}
Console.WriteLine(" Task 6" + string.Join(' ', str6));

// 7.Написать программу, которая считывает текст из текстового файла
// и определяет, сколько в нем слов, состоящих не более чем из четырех букв.
Console.WriteLine(str6.Where(x => x.Length <= 4).Count());

// 8.Написать программу, которая считывает текст из текстового файла
// и выводит на экран только цитаты, то есть предложения, заключенные в кавычки.
var res8 = Regex.Matches(fullStr1, @"(?<="").+?(?="")");
foreach (Match m in res8)
    Console.WriteLine(m);

// 9. Написать программу, которая считывает английский текст из текстового файла
// и выводит его на экран, замени впрописной каждую первую букву слов, начинающихся с гласной буквы.
var str9 = fullStr1.Split(new [] {' ', '\n'}, StringSplitOptions.RemoveEmptyEntries).
            Select(w => w).
            Where(ch => alphabet.Contains(char.ToUpper(ch[0]))).
            Select(ch => vowels.Contains(ch[0]) && char.IsLower(ch[0]) ? string.Concat(char.ToUpper(ch[0]),ch[1..^0]) : ch);
Console.WriteLine("task 9");
Console.WriteLine(string.Join(' ',str9));


// 10.Написать программу, которая считывает текст из текстового файла и выводит его на экран, заменив цифры от 0 до 9 словами
// ≪ноль≫, ≪один≫, ≪девять≫, начиная каждое предложение с новой строки.
var dict = new Dictionary<char, string>()
{
        { '0', "ноль" },
        { '1', "один" },
        { '2', "два" },
        { '3', "три" },
        { '4', "четыре" },
        { '5', "пять" },
        { '6', "шесть" },
        { '7', "семь" },
        { '8', "восемь" },
        { '9', "девять" },
        { '.', ".\n" },
        { '?', "?\n" },
        { '!', "!\n" }
};

Console.WriteLine(String.Concat(fullStr1.ToCharArray().Select(ch => dict.ContainsKey(ch) ? dict[ch] : ch.ToString())));

// 11.Написать программу, которая считывает текст из текстового файла, находит самое длинное слово
// и определяет, сколько раз оно встретилось в тексте.

var res11 = fullStr2[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
var extrWrd = string.Empty;
for(int i = 0; i<res11.Length; i++)
    if (res11[i].Length > extrWrd.Length)
    {
        extrWrd = res11[i];
    }
Console.WriteLine($"Slovo {extrWrd},kolvo {res11.Where(x => x == extrWrd).Count()}");
        





