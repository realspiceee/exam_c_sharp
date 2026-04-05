using System;

class Thermostat
{
    private double temperature;

    public event EventHandler<double> TemperatureChanged;
    public event EventHandler<double> OverheatWarning;

    public double Temperature
    {
        get { return temperature; }
        set
        {
            temperature = value;
            TemperatureChanged?.Invoke(this, temperature);
            if (temperature > 100)
                OverheatWarning?.Invoke(this, temperature);
        }
    }
}

class TemperatureMonitor
{
    public void Subscribe(Thermostat t)
    {
        t.TemperatureChanged += OnTemperatureChanged;
        t.OverheatWarning += OnOverheat;
    }

    void OnTemperatureChanged(object sender, double temp)
    {
        Console.WriteLine("Температура изменилась: " + temp + "°C");
    }

    void OnOverheat(object sender, double temp)
    {
        Console.WriteLine("ПЕРЕГРЕВ! Температура: " + temp + "°C");
    }
}

class Program
{
    static void Main()
    {
        Thermostat thermostat = new Thermostat();
        TemperatureMonitor monitor = new TemperatureMonitor();
        monitor.Subscribe(thermostat);

        thermostat.Temperature = 36.6;
        thermostat.Temperature = 75.0;
        thermostat.Temperature = 105.0;
        thermostat.Temperature = 98.0;
    }
}
