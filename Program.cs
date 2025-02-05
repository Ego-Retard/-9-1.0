using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_9_1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Discipline d1 = new Discipline();
            Discipline d2 = new Discipline("Математический анализ",30,45);
            Discipline d3 = new Discipline("Математический анализ", 30, 46);
            Console.WriteLine("Работа класса Discipline");
            Console.WriteLine("Конструктор без параметров");
            Console.WriteLine(d1.GetDisciplineInfo());
            Console.WriteLine("Конструктор с параметрами (Математический анализ,30, 45)");
            Console.WriteLine(d2.GetDisciplineInfo());
            Console.WriteLine($"Количество созданных в программе объектов {Discipline.GetObjCount()}");
            Console.WriteLine($"(Нестатический метод) метод класса для вычисления зачётных единиц");
            Console.WriteLine($"Зачётные единицы: {d2.CalcCreditUnit()}");
            Console.WriteLine($"(Статический метод) для вычисления зачётных единиц");
            Console.WriteLine($"Зачётные единицы: {Discipline.CalcCreditUnitStatic(d3)}");
            //    Discipline d1 = new Discipline();
            //    Discipline d2 = new Discipline("rerehepf", 43, 34);
            //    Console.WriteLine(d2);
        }
    }
}
