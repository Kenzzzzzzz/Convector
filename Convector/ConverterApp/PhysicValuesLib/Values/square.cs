using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicValuesLib.Values
{
    internal class square : IValue
    {
        private double Value { get; set; }
        private string? From { get; set; }
        private string? To { get; set; }

        private string _valueName = "Площадь";

        private List<string> _measureList = new List<string>()
    {
        "Квадратный метр",
        "Сотка",
        "Квадратный километр",
        "Гектар"
    };

        /// <summary>
        /// Метод возвращает конвертированное значение
        /// </summary>
        /// <returns></returns>
        public double GetConvertedValue(double value, string from, string to)
        {
            Value = value;
            From = from;
            To = to;

            ToSi();
            ToRequired();
            return Value;
        }

        /// <summary>
        /// Метод возвращает список единиц измерения
        /// </summary>
        /// <returns></returns>
        public List<string> GetMeasureList()
        {
            return _measureList;
        }

        /// <summary>
        /// Метод конвертирует в нужные единицы измерения
        /// </summary>
        public void ToRequired()
        {
            switch (To)
            {
                case "Квадратный метр":
                    break;
                case "Сотка":
                    Value /= 100;
                    break;
                case "Квадратный километр":
                    Value /= 1000000;
                    break;
                case "Гектар":
                    Value /= 10000;
                    break;
            }
        }

        /// <summary>
        /// Метод переводит в систему СИ
        /// </summary>
        public void ToSi()
        {
            switch (From)
            {
                case "Квадратный метр":
                    break;
                case "Сотка":
                    Value *= 1000;
                    break;
                case "Квадратный километр":
                    Value *= 1000000;
                    break;
                case "Гектар":
                    Value *= 10000;
                    break;
            }
        }

        public string GetValueName()
        {
            return _valueName;
        }
    }
}
