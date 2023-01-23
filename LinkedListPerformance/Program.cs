using System.Diagnostics;

namespace LinkedListPerformance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\SkillFactory\\module3\\CompareLists\\Text1.txt";
            string text = File.ReadAllText(path);

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //Делим полученный массив слов на трети и получаем индексы первой и второй третей.
            int indexOfFirstThird = words.Length / 3;
            int indexOfSecondThird = (int)((int)words.Length - 0.6 * (int)words.Length);

            LinkedList<string> linkedList = new LinkedList<string>();
            LinkedListNode<string> node;

            //Формируем Linked List из первой и последней трети
            for (int i = 0; i < indexOfFirstThird; i++)
            {
                linkedList.AddLast(words[i]);
            }
            for (int i = indexOfSecondThird; i < words.Length; i++)
            {
                linkedList.AddLast(words[i]);
            }

            //// Запустим таймер и вставляем элементы после первого элемнта связного списка
            var watch = Stopwatch.StartNew();

            // определяем узел примерно посередине массива 
            var insertNode = linkedList.Find("Барон");

            //вставлем элементы примерно посередине связанного списка
            for (int i = indexOfFirstThird; i < indexOfSecondThird; i++)
            {
                linkedList.AddAfter(insertNode, words[i]);
            }

            Console.WriteLine($"Вставка в LinkedList<string>: {watch.Elapsed.TotalMilliseconds} мс");
        }
    }
}