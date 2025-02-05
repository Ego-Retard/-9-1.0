using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_9_1._0
{
    internal class Discipline
    {
        //1 Поля
        //2 Свойства
        //3 Конструкторы
        //4 Публичные методы
        //5 Приватные методы
        //__________________________________ПОЛЯ______________________________________
        string name; //Название дисциплины по умолчанию private
        int contactHours; //Часы аудиторной работы по умолчанию private
        int selfHours; //Часы самостоятельной работы по умолчанию prvate
        private static int objCount = 0;
        //____________________________________________________________________________
        //__________________________________СВОЙСТВА__________________________________
        public string Name
        {
            get => name;
            set
            {
                if (name == null)
                {
                    name = "Неуказанная дисциплина";
                    throw new Exception("Дисциплина должна иметь название");
                }
            }
        }
        public int ContactHours
        {
            get => contactHours;
            set
            {
                if (value < 0)
                {
                    selfHours = 0;
                    throw new Exception("Часы аудиторной работы не могут быть отрицательными");
                }
                else
                {
                    contactHours = value;
                }
            }
        }
        public int SelfHours
        {
            get => selfHours;
            set
            {
                if (value < 0)
                {
                    selfHours = 0;
                    throw new Exception("Часы самостоятельной работы не могут быть отрицательными");
                }
                else
                {
                    selfHours = value;
                }
            }
        }

        //____________________________________________________________________________
        //__________________________________КОНСТРУКТОРЫ______________________________
        //RКонструктор по умолчанию(конструктор без параметров)
        public Discipline()
        {
            name = "Неуказанная дисциплина";
            contactHours = 0;
            selfHours = 0;
            objCount++;
        }
        //Конструктор с вводом всех параметров
        public Discipline(string name, int contactHours, int selfHours)
        {
            this.name = name;
            this.contactHours = contactHours;
            this.selfHours = selfHours;
            objCount++;
        }
        //_____________________________________________________________________________
        //________________________________МЕТОДЫ_______________________________________
        //Метод класса для вычисления зачетных единиц
        public int CalcCreditUnit()
        {
            return (ContactHours + SelfHours) / 38;
        }
        //Статистический метод для вычисления зачетных единиц
        public static int CalcCreditUnitStatic(Discipline dis)
        {
            return (dis.ContactHours + dis.SelfHours) / 38;
        }
        //Метод для демонстрации информации о дисциплине
        public string GetDisciplineInfo()
        {
            return ($"Название дисциплины: {Name}, Часы аудиторной работы: {ContactHours}, Часы самостоятельной работы: {SelfHours}");
        }
        //Метод для демонстрации количества обьектов
        public static int GetObjCount()
        {
            return objCount;
        }
        //








        //_____________________________________________________________________________
        //Вывод в консоль дисциплины и часов
        //public void Show()
        //{
        //    Console.WriteLine($"Дисциплина:{name}, аудиторныые часы:{contactHours}, самостоятельная работа {selfHours}");
        //}
        //public static void CreditUnit()
        //{
        //    return (contactHours +)
        //}
        //static int 
        //static
    }
}

