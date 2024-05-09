using DESFI_lib;

namespace desfi;

internal class Program
{
    static void Main(string[] args)
    {
        
        printLogo();

        Console.Write("Укажите файл: ");
        string? file = Console.ReadLine();

        Desfi d = new();
        
        Console.Write("""

            ### ЧТО ЗАПИСАТЬ В ФАЙЛ ###

            0 - Записать NULL байты
            1 - Выбрать образец прохода
            2 - Записать рандомные байты
            3 - Для каждого прохода выбрать рандомный байт
            
            -> 
            """);
        
        ConsoleKeyInfo key = Console.ReadKey();

        Console.WriteLine("\n");
        if (key.Key == ConsoleKey.NumPad0 || key.Key == ConsoleKey.D0)
        {
            d.destroy(file, writeNullBytes: true);
        }
        else if (key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1)
        {
            d.destroy(file, passes: true, randBytes: false);
        }
        else if (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2)
        {
            d.destroy(file, passes: true, randBytes: true);
        }
        else if (key.Key == ConsoleKey.NumPad3 || key.Key == ConsoleKey.D3)
        {
            d.destroy(file, passes: true, randBytes: true, pasOneRandByte: true);
        }
        else if (key.Key == ConsoleKey.H)
        {
            Console.WriteLine("""
                ### ПРИНЦИП РАБОТЫ МЕТОДОВ УДАЛЕНИЯ ###

                file.txt
                ----------------------------
                HELLO WORLD

                ______________________________________________________
                |0:                                                  |
                |       - ЗАПИСЫВАЮТСЯ NULL БАЙТЫ                    |
                |                                                    |
                |       file.txt                                     |
                |       ----------------------------                 |
                |       00 00 00 00 00 00 00 00 00 00                |
                |       00                                           |
                |____________________________________________________|
                |1:                                                  |
                |       - УКАЗЫВАЕТЕ КОЛ-ВО ПРОХОДОВ                 |
                |                                                    |
                |       ЦИКЛ:                                        |
                |           - ВЫБИРАЕТЕ HEX ЗНАЧЕНИЕ (НАПРИМЕР AB)   |
                |                                                    |
                |           file.txt                                 |
                |           ----------------------------             |
                |           AB AB AB AB AB AB AB AB AB AB            |
                |           AB                                       |
                |____________________________________________________|
                |2:                                                  |
                |    ЦИКЛ:                                           |
                |        - ЗАПИСЫВАЮТСЯ РАНДОМНЫЕ БАЙТЫ              |
                |                                                    |
                |       file.txt                                     |
                |       ----------------------------                 |
                |       10 AB FF AA CA 1E D5 F0 1D 21                |
                |       15                                           |
                |____________________________________________________|
                |3:                                                  |
                |   - ВЫБИРАЕТСЯ РАНДОМНЫЙ БАЙТ (НАПРИМЕР FF)        |
                |                                                    |
                |   ЦИКЛ:                                            |
                |                                                    |
                |       file.txt                                     |
                |       ----------------------------                 |
                |       FF FF FF FF FF FF FF FF FF FF                |
                |       FF                                           |
                |____________________________________________________|
                """);
            Console.ReadKey();
        }
        Console.ReadKey();
    }
    
    private static void printLogo()
    {
        Console.WriteLine("""
                _____     _____   ____   ____   ____   *
                |    \    |    \ /  . \ / __|  / ___| ___  DESTROY
              __|____|__  |  | | |  __/ \__ \  | |__  | |  THE FILE
              |________|  |  | | | |       \ \ |  __| | |  FOREVER
                 |  /|    |    | | |__  ___/ / | |    | |
                |/ |  \   |____/ \____| |___/  |_|    |_|  v1.0
              
            """);
    }
}
