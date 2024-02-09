using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transporter_Berkut.Model;

namespace Transporter_Berkut.Details
{
    //Покраска
    public class Painting : Detail
    {
        public override string Type_Detail { get; set; }
        public override string PartName { get; set; }
        public override bool Success { get; set; }

        public override void InstallSuccess()
        {
            Console.WriteLine(string.Format("Название ='{0}' | Цвет покраски = '{1}' | Успешность выполнения = '{2}'", Type_Detail, PartName, Success));
        }
    }
}
