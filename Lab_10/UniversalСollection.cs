﻿using ClassLibrary;
using System;
using System.Collections.Generic;

namespace Lab_10
{
    public class UniversalСollection
    {
        public List<Auto> autos = new List<Auto>();
        Random random = new Random();

        public void AddAuto(Auto auto)
        {
            autos.Add(auto);
        }

        // добавление нового автомобиля
        public void AddNewAuto()
        {
            bool isGenerated = false;
            while (!isGenerated)
            {
                Console.WriteLine("Выберите тип машины:");
                Console.WriteLine("1 - Легковая");
                Console.WriteLine("2 - Грузовая");
                Console.WriteLine("3 - Внедорожник");
                string answ = Console.ReadLine().Trim();
                switch(answ)
                {
                    case "1":
                        {
                            Passenger light = new Passenger();
                            light.Init();
                            autos.Add(light);
                            isGenerated = true;
                            break;
                        }
                    case "2":
                        {
                            Truck heavy = new Truck();
                            heavy.Init();
                            autos.Add(heavy);
                            isGenerated = true;
                            break;
                        }
                    case "3":
                        {
                            OffRoad offroad = new OffRoad();
                            offroad.Init();
                            autos.Add(offroad);
                            isGenerated = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public void GenerateAutos(int count)
        {
            autos.Clear();
            for (int i = 0; i < count; i++)
            {
                int a = random.Next(0, 2);
                if (a == 0)
                {
                    Passenger light = new Passenger();
                    light.RandomInit();
                    autos.Add(light);
                }
                else if(a == 1)
                {
                    Truck heavy = new Truck();
                    heavy.RandomInit();
                    autos.Add(heavy);
                }
                else if(a == 2)
                {
                    OffRoad offRoad = new OffRoad();
                    offRoad.RandomInit();
                    autos.Add(offRoad);
                }
            }
        }

        // удаление автомобиля по индексу
        public void RemoveAuto(int index)
        {
            if (index >= 0 && index < autos.Count)
            {
                autos.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Ошибка: Недопустимый индекс для удаления.");
            }
        }

        // вывод информации о коллекции
        public void PrintCollection()
        {
            Console.WriteLine("Информация о коллекции автомобилей:");
            if (autos.Count > 0)
            {
                foreach (var auto in autos)
                {
                    auto.Show();
                }
            }
            else
            {
                Console.WriteLine("Коллекция пустая");
            }
        }

        // вычисления количества легковых автомобилей
        public int ReturnCountOfLights()
        {
            int count = 0;
            foreach(var light in autos)
            {
                if (light.GetType() == typeof(Passenger))
                {
                    count ++;
                }
            }
            return count;
        }

        // печать грузовых автомобилей
        public void PrintOnlyHeavyCars()
        {
            int count = 0;
            foreach(var heavy in autos)
            {
                if (heavy.GetType() == typeof(Truck))
                {
                    count++;
                    heavy.Show();
                }
            }
            if(count == 0) 
            {
                Console.WriteLine("В коллекции нет грузовых машин");
            }
        }

        // является ли автомобиль внедорожником
        public bool CheckIsOffRoad(int index)
        {
            if (autos[index].GetType() == typeof(OffRoad) && index >= 0 && index < autos.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // клонирование коллекции
        public object Clone()
        {
            UniversalСollection clonedCollection = new UniversalСollection();
            foreach (var auto in autos)
            {
                Auto newAuto = auto;
                clonedCollection.AddAuto(newAuto);
            }
            return clonedCollection;
        }

        // сортировка коллекции по году выпуска
        public void SortByYear()
        {
            autos.Sort((a1, a2) => a1.Year.CompareTo(a2.Year));
        }

        public Auto GetAutoByIndex(int v)
        {
            return autos[v];
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            UniversalСollection otherCollection = (UniversalСollection)obj;
            if (autos.Count != otherCollection.autos.Count)
                return false;

            for (int i = 0; i < autos.Count; i++)
            {
                if (!autos[i].Equals(otherCollection.autos[i]))
                    return false;
            }

            return true;
        }
    }
}
