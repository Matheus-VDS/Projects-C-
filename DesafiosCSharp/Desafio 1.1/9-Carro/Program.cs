//Autor: Matheus Vieira de Souza

using System;
using System.Collections.Generic;

public class Motor
{
    public double Cilindrada { get; private set; }

    public Motor(double cilindrada)
    {
        if (cilindrada <= 0)
            throw new ArgumentException("A cilindrada deve ser maior que zero.");
        Cilindrada = cilindrada;
    }
}

public class Carro
{
    public string Placa { get; }
    public string Modelo { get; }
    public Motor Motor { get; private set; }
    private static List<Motor> motoresInstalados = new List<Motor>();

    public Carro(string placa, string modelo, Motor motor)
    {
        if (string.IsNullOrEmpty(placa))
            throw new ArgumentException("A placa é obrigatória.");
        if (string.IsNullOrEmpty(modelo))
            throw new ArgumentException("O modelo é obrigatório.");
        if (motor == null)
            throw new ArgumentNullException(nameof(motor), "O carro deve ter um motor.");

        if (MotorInstaladoEmOutroCarro(motor))
            throw new InvalidOperationException("O motor já está instalado em outro carro.");

        Placa = placa;
        Modelo = modelo;
        Motor = motor;
        motoresInstalados.Add(motor);
    }

    public void TrocarMotor(Motor novoMotor)
    {
        if (novoMotor == null)
            throw new ArgumentNullException(nameof(novoMotor), "O novo motor não pode ser nulo.");
        if (Motor == novoMotor)
            throw new InvalidOperationException("O motor já está instalado neste carro.");

        if (MotorInstaladoEmOutroCarro(novoMotor))
            throw new InvalidOperationException("O motor já está instalado em outro carro.");

        motoresInstalados.Remove(Motor);
        Motor = novoMotor;
        motoresInstalados.Add(novoMotor);
    }

    public double CalcularVelocidadeMaxima()
    {
        if (Motor.Cilindrada <= 1.0)
            return 140;
        else if (Motor.Cilindrada <= 1.6)
            return 160;
        else if (Motor.Cilindrada <= 2.0)
            return 180;
        else
            return 220;
    }

    private bool MotorInstaladoEmOutroCarro(Motor motor)
    {
        return motoresInstalados.Contains(motor);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Digite a cilindrada do motor: ");
            double cilindrada = double.Parse(Console.ReadLine());
            Motor motor = new Motor(cilindrada);

            Console.Write("Digite a placa do carro: ");
            string placa = Console.ReadLine();

            Console.Write("Digite o modelo do carro: ");
            string modelo = Console.ReadLine();

            Carro carro = new Carro(placa, modelo, motor);

            Console.WriteLine($"\nCarro: {carro.Modelo}, Placa: {carro.Placa}");
            Console.WriteLine($"Cilindrada do Motor: {motor.Cilindrada}");
            Console.WriteLine($"Velocidade Máxima: {carro.CalcularVelocidadeMaxima()} km/h");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
