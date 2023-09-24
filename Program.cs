using System;
using System.IO;
using System.Linq;

class Ar
{
    private int[] a;

    public int N => a.Length;
    public int S => a.Where(x => x % 2 != 0).Sum();

    public Ar(int a, int b)
    {
        this.a = Enumerable.Range(a, b - a + 1).ToArray();
    }

    public Ar(string fileName)
    {
        
        try
        {
            this.a = File.ReadAllText(fileName).Split().Select(int.Parse).ToArray();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Помилка: Файл не знайдено.");
            this.a = new int[0]; // Якщо файл не знайдено, ініціалізуємо пустий масив.
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Некоректний формат даних у файлі.");
            this.a = new int[0]; // Якщо в файлі некоректний формат даних, ініціалізуємо пустий масив.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            this.a = new int[0]; // Інші помилки, ініціалізуємо пустий масив.
        }
    }

    public void Print() => Console.WriteLine(string.Join(" ", a));

    public int P() => Array.FindIndex(a, x => x % 10 == 5);

    public int Sum(int i1, int i2) => a.Skip(i1).Take(i2 - i1 + 1).Sum();
}

class Program
{
    
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Оберіть конструктор (1 або 2):");
        int constructorChoice = int.Parse(Console.ReadLine());

        Ar arrayObj;

        if (constructorChoice == 1)
        {
            Console.Write("Введіть a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введіть b: ");
            int b = int.Parse(Console.ReadLine());
            arrayObj = new Ar(a, b);
        }
        else if (constructorChoice == 2)
        {
            Console.Write("Введіть ім'я файлу: ");
            string fileName = Console.ReadLine();
            arrayObj = new Ar(fileName);
        }
        else
        {
            Console.WriteLine("Неправильний вибір конструктора.");
            return;
        }

        arrayObj.Print();
        Console.WriteLine($"Сума непарних елементів: {arrayObj.S}");

        int index = arrayObj.P();
        if (index != -1)
        {
            Console.WriteLine($"Індекс першого елемента, який закінчується на 5: {index}");
            int sumRight = arrayObj.Sum(index + 1, arrayObj.N - 1);
            Console.WriteLine($"Сума елементів правіше: {sumRight}");
        }
        else
        {
            Console.WriteLine("Елемент, який закінчується на 5, не знайдено.");
        }
    }
}
