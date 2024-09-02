using System;
using System.Collections.Generic;

Car car1 = new Car { Name = "Mercedes", MaxMph = 180, Horsepower = 500, Price = 80000 };
Car car2 = new Car { Name = "BMW", MaxMph = 160, Horsepower = 400, Price = 60000 };

int comparisonResult = car1.CompareTo(car2);

bool areEqual = car1.Equals(car2);

Car clonedCar = (Car)car1.Clone();

CarComparer comparer = new CarComparer(SortCar.Price);
int priceComparisonResult = comparer.Compare(car1, car2);


public class Car : IComparable<Car>, IEquatable<Car>, ICloneable
{
    public string Name { get; set; }
    public int MaxMph { get; set; }
    public int Horsepower { get; set; }
    public decimal Price { get; set; }

    public int CompareTo(Car other)
    {
        if (other == null)
        {
            return -1;
        }

        return Horsepower.CompareTo(other.Horsepower);
    }

    public object Clone()
    {
        return new Car
        {
            Name = this.Name,
            MaxMph = this.MaxMph,
            Horsepower = this.Horsepower,
            Price = this.Price
        };
    }

    public bool Equals(Car other)
    {
        if (other == null)
        {
            return false;
        }

        return string.Equals(Name, other.Name) &&
           MaxMph == other.MaxMph &&
           Horsepower == other.Horsepower &&
           Price == other.Price;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Car);
    }
}

public enum SortCar
{
    Name,
    MaxMph,
    Horsepower,
    Price
}

public class CarComparer : IComparer<Car>
{
    private readonly SortCar _compareby;

    public CarComparer(SortCar compareby)
    {
        _compareby = compareby;
    }

    public int Compare(Car x, Car y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        switch (_compareby)
        {
            case SortCar.Name:
                return x.Name.CompareTo(y.Name);

            case SortCar.MaxMph:
                return x.MaxMph.CompareTo(y.MaxMph);

            case SortCar.Horsepower:
                return x.Horsepower.CompareTo(y.Horsepower);

            case SortCar.Price:
                return x.Price.CompareTo(y.Price);

            default:
                return 0;
        }
    }


}

