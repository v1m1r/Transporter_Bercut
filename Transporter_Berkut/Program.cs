using System;
using System.Collections.Generic;
using Transporter_Berkut.Model;
using Transporter_Berkut.Details;
using System.Threading;
using Transporter_Berkut.Helper;

namespace Transporter_Bercut
{
    class Program
    {
        public static bool СonveyorOn_Off { get; set; } = false;//Статус конвейера
        public static bool MainСonveyor { get; set; } = true;
        public static bool InteriorСonveyor { get; set; } = true;
        static void Main(string[] args)
        {
            DetailsMain executeMech = null;
            DetailsInterior detailsInterior = null;
            int Main_ID = 0;
            int Interior_ID = 0;
            string Type_Detail = string.Empty;
            string Part_name = string.Empty;
            List<Detail> InteriorDet = null;

            List<Detail> MainDetail = CreateMainDetails();
            InteriorDet = CreateInteriorDet();

            //Участок по сборке автомобиля
            executeMech = new DetailsMain(MainDetail, "ИМ создание автомобиля");
            СonveyorOn_Off = true;//Конвейер запущен
            MainСonveyor = true;
            if (executeMech.Creation(out Main_ID, out Type_Detail, out Part_name) == false)
            {
                СonveyorOn_Off = false;
                MainСonveyor = false;
                if (СonveyorMenu.StatusСonveyor(Main_ID, Type_Detail, MainDetail))
                {
                    Thread.Sleep(6000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Запускаю ИМ создание автомобиля");
                    Console.ResetColor();

                    СonveyorOn_Off = true;
                    Console.WriteLine("ИМ запустился => " + СonveyorOn_Off);
                }
            }
            else
            {
                detailsInterior = new DetailsInterior(InteriorDet);
                InteriorСonveyor = true;
                if (detailsInterior.Creation(out Interior_ID, out Type_Detail, out Part_name) == false)
                {
                    СonveyorOn_Off = false;
                    InteriorСonveyor = false;
                    if (СonveyorMenu.StatusСonveyor(Interior_ID, Type_Detail, InteriorDet))
                    {
                        Thread.Sleep(6000);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Запускаю ИМ создание интерьера");
                        Console.ResetColor();

                        СonveyorOn_Off = true;
                        Console.WriteLine("ИМ запустился " + СonveyorOn_Off);
                    }
                }
            }

            if (СonveyorOn_Off == true)
            {
                if (MainСonveyor == false)
                {
                    Console.WriteLine(string.Format("Продолжаю работу конвейера, после ошибки детали => '{0}' производитель = {1}, которая вызвала остановку ИМ",Type_Detail, Part_name));
                    var header = String.Format("|{0,10}|{1,20}|{2,30}|", "Деталь", "Производитель", "Отметка ИМ");
                    Console.WriteLine(header);
                    foreach (var m_detail in MainDetail)
                    {
                        if (m_detail.PartName != Part_name)
                        {
                            Console.WriteLine(string.Format("|{0,10}|{1,20}|{2,30}|", m_detail.Type_Detail, m_detail.PartName, m_detail.Success));
                        }
                    }
                    if (InteriorСonveyor == true)
                    {
                        detailsInterior = new DetailsInterior(InteriorDet);
                        detailsInterior.Creation(out Interior_ID, out Type_Detail, out Part_name);
                    }
                }

                if (InteriorСonveyor == false)
                {
                    Console.WriteLine(string.Format("Продолжаю работу конвейера, после ошибки детали => '{0}' производитель = {1}, которая вызвала остановку ИМ", Type_Detail, Part_name));
                    var header = String.Format("|{0,10}|{1,20}|{2,30}|", "Деталь", "Производитель", "Отметка ИМ");
                    Console.WriteLine(header);
                    foreach (var t in InteriorDet)
                    {
                        if (t.PartName != Part_name)
                        {
                            Console.WriteLine(string.Format("|{0,10}|{1,20}|{2,30}|", t.Type_Detail, t.PartName, t.Success));
                        }
                    }
                }

                Console.WriteLine("Ошибки на конвейере исправлены, для запуска потока нажмите 'Enter'");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    while (true)
                    {
                        executeMech.Creation(out Main_ID, out Type_Detail, out Part_name);
                        detailsInterior.Creation(out Interior_ID, out Type_Detail, out Part_name);
                        Thread.Sleep(3000);
                    }
                }
            }
            Console.ReadLine();
        }

        static List<Detail> CreateMainDetails()
        {
            List<Detail> MainDetail = new List<Detail>
            {
                new Body() {Type_Detail="Кузов",PartName = "Cедан", Success = true },
                new CarTires() {Type_Detail="Шины", PartName = "Bridgestone", Success = true },
                new Engine() {Type_Detail="Мотор", PartName = "VZX640", Success = true },
                new Painting() {Type_Detail="Красный", PartName = "Яркий помидор", Success = true },

                new Body() {Type_Detail="Кузов",PartName = "Кабриолет", Success = true },
                new CarTires() {Type_Detail="Шины", PartName = "Michelin", Success = true },
                new Engine() {Type_Detail="Мотор", PartName = "CDR340", Success = true },
                new Painting() {Type_Detail="Желтый", PartName = "Сияющий лимон", Success = true }
            };

            return MainDetail;
        }

        static List<Detail> CreateInteriorDet()
        {
            List<Detail> InteriorDet = new List<Detail>
            {
               new Body() {Type_Detail="Руль",PartName = "Momo", Success = true },
               new CarTires() {Type_Detail="Диски", PartName = "TURANZA", Success = false },
               new Engine() {Type_Detail="Oil", PartName = "SHELL", Success = true },

               new Body() {Type_Detail="Руль",PartName = "Nardi", Success = true },
               new CarTires() {Type_Detail="Диски", PartName = "BBS", Success = true },
               new Engine() {Type_Detail="Oil", PartName = "Liqui Moly", Success = true }

            };

            return InteriorDet;
        }
    }
}
