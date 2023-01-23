using System.Diagnostics;

namespace ListPerformance
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

            List<string> lst = new List<string>();

            //Формируем List из первой и последней трети
            for (int i = 0; i < indexOfFirstThird; i++)
            {
                lst.Add(words[i]);
            }
            for (int i = indexOfSecondThird; i < words.Length; i++)
            {
                lst.Add(words[i]);
            }
            //// Запустим таймер и вствляем элементы после первой трети списка
            var watch = Stopwatch.StartNew();
            for (int i = indexOfFirstThird; i < indexOfSecondThird; i++)
            {
                lst.Insert(i, words[i]);
            }

            Console.WriteLine($"Вставка в List<string>: {watch.Elapsed.TotalMilliseconds} мс");
        }
    }
}