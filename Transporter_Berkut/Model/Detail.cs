using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporter_Berkut.Model
{
    //Абстрактная деталь
    //Успех установки
    //Имя
    //Вывод состояния об успешности установки
    public abstract class Detail
    {
        public abstract string Type_Detail {get;set;} //Тип детали
        public abstract string PartName { get; set; } // Название детали
        public abstract bool Success { get; set; } //Состояние сборки
        
        public virtual void InstallSuccess()
        {
            var header = String.Format("|{0,10}|{1,20}|{2,30}|", "Деталь", "Производитель", "Отметка ИМ");
            Console.WriteLine(header);
            Console.WriteLine(string.Format("|{0,10}|{1,20}|{2,30}|", Type_Detail, PartName, Success));
        }
    }
}
