using System;
// Интерфейс для всех
public interface IVehicle
{
    void Drive();
    void Refuel();
}

// Класс Автомобиль
public class Car : IVehicle
{
    private string Brand; 
    private string Model; 
    private string FuelType;

    public Car(string brand, string model, string fuelType)
    {
        Brand = brand;
        Model = model;
        FuelType = fuelType;
    }

    //Drive
    public void Drive()
    {
        Console.WriteLine($"Автомобиль {Brand} {Model} едет.");
    }

    //Refuel
    public void Refuel()
    {
        Console.WriteLine($"Автомобиль {Brand} {Model} заправляется {FuelType}.");
    }
}



// Класс Мотоцикл
public class Motorcycle : IVehicle
{
    private string Type;      
    private int EngineCapacity;

    public Motorcycle(string type, int engineCapacity)
    {
        Type = type;
        EngineCapacity = engineCapacity;
    }

    public void Drive()
    {
        Console.WriteLine($"{Type} мотоцикл с двигателем {EngineCapacity} куб.см едет.");
    }

    public void Refuel()
    {
        Console.WriteLine($"{Type} мотоцикл с двигателем {EngineCapacity} куб.см заправляется.");
    }
}



// Класс Грузовик
public class Truck : IVehicle
{
    private int LoadCapacity;
    private int Axles;

    public Truck(int loadCapacity, int axles)
    {
        LoadCapacity = loadCapacity;
        Axles = axles;
    }

    public void Drive()
    {
        Console.WriteLine($"Грузовик с {Axles} осями и грузоподъемностью {LoadCapacity} кг едет.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Грузовик с {Axles} осями заправляется.");
    }
}


// Создания транспортного средства
public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}



// Создания автомобиля
public class CarFactory : VehicleFactory
{
    private string Brand;
    private string Model;
    private string FuelType;

    public CarFactory(string brand, string model, string fuelType)
    {
        Brand = brand;
        Model = model;
        FuelType = fuelType;
    }

    public override IVehicle CreateVehicle()
    {
        return new Car(Brand, Model, FuelType);
    }
}



// Создания мотоцикла
public class MotorcycleFactory : VehicleFactory
{
    private string Type;
    private int EngineCapacity;

    public MotorcycleFactory(string type, int engineCapacity)
    {
        Type = type;
        EngineCapacity = engineCapacity;
    }

    public override IVehicle CreateVehicle()
    {
        return new Motorcycle(Type, EngineCapacity);
    }
}


// Создания грузовика
public class TruckFactory : VehicleFactory
{
    private int LoadCapacity;
    private int Axles;

    public TruckFactory(int loadCapacity, int axles)
    {
        LoadCapacity = loadCapacity;
        Axles = axles;
    }

    public override IVehicle CreateVehicle()
    {
        return new Truck(LoadCapacity, Axles);
    }
}



public class VehicleCreationSystem
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип транспорта: 1 - Автомобиль, 2 - Мотоцикл, 3 - Грузовик");
        string choice = Console.ReadLine();

        VehicleFactory factory = null;

        switch (choice)
        {
            case "1":
                Console.WriteLine("Введите марку автомобиля:");
                string carBrand = Console.ReadLine();
                Console.WriteLine("Введите модель автомобиля:");
                string carModel = Console.ReadLine();
                Console.WriteLine("Введите тип топлива:");
                string carFuel = Console.ReadLine();
                factory = new CarFactory(carBrand, carModel, carFuel);
                break;

            case "2":
                Console.WriteLine("Введите тип мотоцикла (спортивный, туристический):");
                string motoType = Console.ReadLine();
                Console.WriteLine("Введите объем двигателя (в куб.см):");
                int motoEngine = int.Parse(Console.ReadLine());
                factory = new MotorcycleFactory(motoType, motoEngine);
                break;

            case "3":
                Console.WriteLine("Введите грузоподъемность грузовика (в кг):");
                int truckLoad = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите количество осей грузовика:");
                int truckAxles = int.Parse(Console.ReadLine());
                factory = new TruckFactory(truckLoad, truckAxles);
                break;

            default:
                Console.WriteLine("Неправильный выбор.");
                return;
        }

        IVehicle vehicle = factory.CreateVehicle();
        
        vehicle.Drive();
        vehicle.Refuel();
    }
}