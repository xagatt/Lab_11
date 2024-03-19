﻿using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_10
{
    public class GeneralizedCollection<T> where T : Auto
    {
        public Stack<T> autos = new Stack<T>();
        Random random = new Random();

        public void AddAuto(T auto)
        {
            autos.Push(auto);
        }

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
                switch (answ)
                {
                    case "1":
                        {
                            Passenger light = new Passenger();
                            light.Init();
                            autos.Push(light as T);
                            isGenerated = true;
                            break;
                        }
                    case "2":
                        {
                            Truck heavy = new Truck();
                            heavy.Init();
                            autos.Push(heavy as T);
                            isGenerated = true;
                            break;
                        }
                    case "3":
                        {
                            OffRoad offroad = new OffRoad();
                            offroad.Init();
                            autos.Push(offroad as T);
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
                int a = random.Next(0, 3);
                if (a == 0)
                {
                    Passenger light = new Passenger();
                    light.RandomInit();
                    autos.Push(light as T);
                }
                else if (a == 1)
                {
                    Truck heavy = new Truck();
                    heavy.RandomInit();
                    autos.Push(heavy as T);
                }
                else if (a == 2)
                {
                    OffRoad offRoad = new OffRoad();
                    offRoad.RandomInit();
                    autos.Push(offRoad as T);
                }
            }
        }

        public void RemoveAuto()
        {
            if (autos.Count > 0)
            {
                autos.Pop();
            }
            else
            {
                Console.WriteLine("Ошибка: Коллекция пустая.");
            }
        }

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

        public int ReturnCountOfLights()
        {
            int count = 0;
            foreach (var light in autos)
            {
                if (light.GetType() == typeof(Passenger))
                {
                    count++;
                }
            }
            return count;
        }

        public void PrintOnlyHeavyCars()
        {
            int count = 0;
            foreach (var heavy in autos)
            {
                if (heavy.GetType() == typeof(Truck))
                {
                    count++;
                    heavy.Show();
                }
            }
            if (count == 0)
            {
                Console.WriteLine("В коллекции нет грузовых машин");
            }
        }

        public bool CheckIsOffRoad()
        {
            if (autos.Peek().GetType() == typeof(OffRoad))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public object Clone()
        {
            GeneralizedCollection<T> clonedCollection = new GeneralizedCollection<T>();
            foreach (var auto in autos)
            {
                T newAuto = auto;
                clonedCollection.AddAuto(newAuto);
            }
            return clonedCollection;
        }

        public void SortByYear()
        {
            List<T> temp = autos.ToList();
            temp.Sort((a1, a2) => a1.Year.CompareTo(a2.Year));
            autos = new Stack<T>(temp);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GeneralizedCollection<T> otherCollection = (GeneralizedCollection<T>)obj;
            if (autos.Count != otherCollection.autos.Count)
                return false;

            var enumerator1 = autos.GetEnumerator();
            var enumerator2 = otherCollection.autos.GetEnumerator();

            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                if (!enumerator1.Current.Equals(enumerator2.Current))
                    return false;
            }

            return true;
        }
    }
}
