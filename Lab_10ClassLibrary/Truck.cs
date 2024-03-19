using System;

namespace ClassLibrary
{
    public class Truck : Auto, IInit
    {
        //Грузовой автомобиль: грузоподъёмность.
        private int liftingCapacity;

        public int LiftingCapacity
        {
            get { return liftingCapacity; }
            set
            {
                if (value > 0)
                    liftingCapacity = value;
                else
                    throw new Exception("Грузоподъемность не может быть отрицательной.");

            }
        }

        public Truck() : base()
        {
            liftingCapacity = 0;
        }

        public Truck(string brand, int year, string color, int cost, int clearance) : base(brand, year, color, cost, clearance)
        {
            this.liftingCapacity = liftingCapacity;
        }

        public override void Show()
        {
            Console.WriteLine("Truck");

            base.Show();

            Console.WriteLine($"Грузоподъемность: {liftingCapacity}");
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Грузоподъемность: ");
            liftingCapacity = int.Parse(Console.ReadLine());

        }

        public override void RandomInit()
        {
            base.RandomInit();

            liftingCapacity = rnd.Next(800, 4000);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Truck otherTruck = (Truck)obj;
            return liftingCapacity == otherTruck.liftingCapacity;
        }


        public int HeavyCarsCount { get; set; }

        public override object Clone()
        {
            Truck clone = (Truck)base.Clone();
            clone.HeavyCarsCount = HeavyCarsCount;
            return clone;
        }
    }
}
