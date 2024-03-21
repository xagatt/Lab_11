using ClassLibrary;
using System;
using System.Collections.Generic;

namespace Lab_10
{
    public class TestCollections
    {
        // коллекции
        public List<Passenger> collection1;
        public List<string> collection2;
        public Dictionary<Auto, Passenger> collection3;
        public Dictionary<string, Passenger> collection4;

        // конструктор класса
        public TestCollections(int numberOfElements)
        {
            // инициализация коллекций
            collection1 = new List<Passenger>();
            collection2 = new List<string>();
            collection3 = new Dictionary<Auto, Passenger>();
            collection4 = new Dictionary<string, Passenger>();

            for (int i = 0; i < numberOfElements; i++)
            {
                Passenger lightCar = new Passenger();
                lightCar.RandomInit();

                // добавление в коллекции
                collection1.Add(lightCar);
                collection2.Add(lightCar.ToString());
                collection3.Add(lightCar.BaseAutoObject, lightCar);
                collection4.Add(lightCar.BaseAutoObject.ToString(), lightCar);
            }
        }

        // измерение времени поиска элемента в коллекции
        private TimeSpan MeasureSearchTime(Action searchAction)
        {
            int iterations = 10; // итераций для усреднения времени
            TimeSpan totalTime = TimeSpan.Zero;

            for (int i = 0; i < iterations; i++)
            {
                // замер времени
                DateTime startTime = DateTime.Now;

                // поиска
                searchAction();

                // конец замера времени и добавляем к общему времени
                DateTime endTime = DateTime.Now;
                totalTime += endTime - startTime;
            }

            // среднее время поиска
            return TimeSpan.FromTicks(totalTime.Ticks / iterations);
        }

        private void SearchInCollection1(Passenger element)
        {
            collection1.Contains(element);
        }

        private void SearchInCollection2(string element)
        {
            collection2.Contains(element);
        }

        private void SearchInCollection3(Passenger element)
        {
            collection3.ContainsValue(element);
        }

        private void SearchInCollection4(Passenger element)
        {
            collection4.ContainsValue(element);
        }

        public TimeSpan MeasureSearchTimeInCollection1(Passenger element)
        {
            return MeasureSearchTime(() => SearchInCollection1(element));
        }

        public TimeSpan MeasureSearchTimeInCollection2(string element)
        {
            return MeasureSearchTime(() => SearchInCollection2(element));
        }

        public TimeSpan MeasureSearchTimeInCollection3(Passenger element)
        {
            return MeasureSearchTime(() => SearchInCollection3(element));
        }

        public TimeSpan MeasureSearchTimeInCollection4(Passenger element)
        {
            return MeasureSearchTime(() => SearchInCollection4(element));
        }
    }

}
