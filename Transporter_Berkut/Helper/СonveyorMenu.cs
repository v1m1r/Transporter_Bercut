using System;
using System.Collections.Generic;
using Transporter_Berkut.Model;
using System.Threading;

namespace Transporter_Berkut.Helper
{
    public static class СonveyorMenu
    {
        public static bool StatusСonveyor(int ID, string Type, List<Detail> details)
        {
            int Get_Detail_ID = 0;
            Console.WriteLine(new string('*', 50));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Внимание!!! Warning!!! Achtung!!!");
            Console.ResetColor();
            Console.WriteLine(new string('*', 50));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format("Конвейер остановлен для принятия решения оператором. Ошибка с деталью '{0}' | ID детали = '{1}'", Type, ID));
            Console.ResetColor();
            Console.Write("Исправьте ситуацию и введите ID детали для перезапуска конвейера => ");
            Get_Detail_ID = Convert.ToInt32(Console.ReadLine());
            if (СonveyorChecker.ChangePartStatus(details, Get_Detail_ID))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Пришла команда перезапуска конвейера.......");
                Thread.Sleep(3);
                Console.ResetColor();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}