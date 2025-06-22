using System;

public class FinancialForecaster
{
    
    public double CalculateFutureValue(double currentValue, double growthRate, int periods)
    {
        
        if (periods == 0)
            return currentValue;
        
        
        double nextValue = currentValue * (1 + growthRate);
        return CalculateFutureValue(nextValue, growthRate, periods - 1);
    }
}

class Program
{
    static void Main()
    {
        FinancialForecaster forecaster = new FinancialForecaster();
        
        
        double result = forecaster.CalculateFutureValue(1000, 0.05, 3);
        Console.WriteLine($"Future value: ${result:F2}"); 
    }
}
