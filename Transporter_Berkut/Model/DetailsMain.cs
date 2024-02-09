using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporter_Berkut.Model
{
    //Основная линия ИМ
    public class DetailsMain
    {
        public List<Detail> details;
        public DetailsMain(List<Detail> det, string MechanismName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("----{0}----", MechanismName));
            Console.ResetColor();
            
            details = det;
            Console.WriteLine(string.Format("***Поступило деталей для создания = '{0}' ***", details.Count.ToString()));
        }

        public bool Creation(out int ID,out string TypeDetail,out string PartName)
        {
            foreach (var CheckDetail in details)
            {
                if (CheckDetail.Success != false)
                {
                    
                    CheckDetail.InstallSuccess();
                }
                else if (CheckDetail.Success == false)
                {
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine(string.Format((string.Format("Возникла ошибка! Остановку конвейера вызвала Деталь = '{0}' | Название = '{1}' Время остановки | {2}", CheckDetail.Type_Detail,CheckDetail.PartName,DateTime.Now.ToString()))));
                   Console.ResetColor();
                   ID = details.IndexOf(CheckDetail);
                   TypeDetail =details[ID].Type_Detail;
                    PartName = details[ID].PartName;
                   return false;
                }
            }
            ID = -1;
            TypeDetail = "";
            PartName = "";
            return true;
        }

    }
}
