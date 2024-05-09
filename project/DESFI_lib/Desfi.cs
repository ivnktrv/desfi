using System.Globalization;

namespace DESFI_lib;

public class Desfi
{
    private const char NULL_BYTE = '\x00';

    public void destroy(string file, bool writeNullBytes = false, bool passes = false,
        bool randBytes = false, bool pasOneRandByte = false, bool dod = false)
    {
        try
        {
            using BinaryWriter br = new(File.Open(file, FileMode.Open));

            if (writeNullBytes)
            {
                Console.WriteLine("[i] Запись NULL байтов");
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    br.Write(NULL_BYTE);
                }
                Console.WriteLine("[+] Сделано");
                br.Close();
                File.Delete(file);
                Console.WriteLine($"\n[+] Файл удалён: {file}");
            }
            if (passes)
            {
                Console.Write("Сколько будет проходов?: ");
                int countPasses = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (!randBytes)
                {
                    for (int i = 0; i < countPasses; i++)
                    {
                        Console.Write($"Введите HEX значение для {i + 1} прохода: ");
                        int getHex = int.Parse(Console.ReadLine(), NumberStyles.HexNumber);
                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            br.Write(getHex);
                        }
                        br.BaseStream.Position = 0;
                    }
                }
                else if (randBytes)
                {
                    for (int i = 0; i < countPasses; i++)
                    {
                        if (!pasOneRandByte)
                        {
                            while (br.BaseStream.Position != br.BaseStream.Length)
                            {
                                br.Write(new Random().Next(0, 255));
                            }
                        }
                        else
                        {
                            int rChar = new Random().Next(0, 255);
                            while (br.BaseStream.Position != br.BaseStream.Length)
                            {
                                br.Write(rChar);
                            }
                        }
                        br.BaseStream.Position = 0;
                        Console.WriteLine($"[i] Проход {i + 1} завершён");
                    }
                    Console.Write("\n[?] Перезаписать содержимое NULL байтами? [y/n]: ");
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Y || key.Key == ConsoleKey.Enter)
                    {
                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            br.Write(NULL_BYTE);
                        }
                        Console.WriteLine("\n[i] Добавление NULL байтов завершено");
                    }
                    else
                    {
                        Console.WriteLine("\n[-] Отмена");
                    }
                }
                br.Close();
                File.Delete(file);
                Console.WriteLine($"\n[+] Файл удалён: {file}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("[-] Файл не найден");
        }
    }
}
