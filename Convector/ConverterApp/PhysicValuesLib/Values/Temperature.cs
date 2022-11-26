using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicValuesLib.Values
{
    internal class Temperature : IValue
    {
        private double Value { get; set; }
        private string? From { get; set; }
        private string? To { get; set; }

        private string _valueName = "Температура";

        private List<string> _measureList = new List<string>()
    {
        "Градус Фаренгейта",
        "Градус Цельсия",
        "Кельвины"
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
                case "Градус Цельсия":
                    break;
                case "Градус Фаренгейта":
                    Value = Value * 1.8 + 32;
                    break;
                case "Кельвины":
                    Value += 273.15;
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
                case "Градус Цельсия":
                    break;
                case "Градус Фаренгейта":
                    Value = (Value - 32) / 1.8;
                    break;
                case "Кельвины":
                    Value -= 273.15;
                        break;
            }
        }

        public string GetValueName()
        {
            return _valueName;
        }
    }
}
