using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Transporter_Berkut.Model
{
   static class СonveyorChecker
   {
        public static bool ChangePartStatus(List<Detail> details, int ID)
        {
            details[ID].Success = true;
            Console.WriteLine(string.Format("Для детали  c ID = {0} | Деталь = '{1}' | Производитель = '{2}' | Успешность выполнения = '{3}'. Конвейер исправлен.",ID.ToString(),details[ID].Type_Detail, details[ID].PartName, details[ID].Success));
            return true;
        }
    }
}