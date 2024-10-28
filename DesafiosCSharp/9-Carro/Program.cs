using System;

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

        // Construtor para inicializar o carro
        public Carro(string placa, string modelo, Motor motor)
        {
            if (string.IsNullOrEmpty(placa))
                throw new ArgumentException("A placa é obrigatória.");
            if (string.IsNullOrEmpty(modelo))
                throw new ArgumentException("O modelo é obrigatório.");
            if (motor == null)
                throw new ArgumentNullException(nameof(motor), "O carro deve ter um motor.");

            Placa = placa;
            Modelo = modelo;
            Motor = motor;
        }

        // Método para trocar o motor do carro
        public void TrocarMotor(Motor novoMotor)
        {
            if (novoMotor == null)
                throw new ArgumentNullException(nameof(novoMotor), "O novo motor não pode ser nulo.");
            if (Motor == novoMotor)
                throw new InvalidOperationException("O motor já está instalado neste carro.");

            // Verifica se o novo motor já está instalado em outro carro
            if (MotorInstaladoEmOutroCarro(novoMotor))
                throw new InvalidOperationException("O motor já está instalado em outro carro.");

            Motor = novoMotor;
        }

        // Método para calcular a velocidade máxima do carro
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

        // Método para verificar se o motor está instalado em outro carro (simulação)
        private bool MotorInstaladoEmOutroCarro(Motor motor)
        {
            // Aqui você pode implementar a lógica para verificar se o motor está em outro carro
            // Para simplificar, vamos assumir que não existe essa verificação, pois não temos controle de outros carros neste contexto.
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Criando um motor
            Motor motor1 = new Motor(1.6);

            // Criando um carro com o motor
            Carro carro1 = new Carro("ABC-1234", "Fusca", motor1);

            // Exibindo informações do carro
            Console.WriteLine($"Carro: {carro1.Modelo}, Placa: {carro1.Placa}");
            Console.WriteLine($"Cilindrada do Motor: {motor1.Cilindrada}");
            Console.WriteLine($"Velocidade Máxima: {carro1.CalcularVelocidadeMaxima()} km/h");

            // Criando um novo motor
            Motor motor2 = new Motor(2.0);
            carro1.TrocarMotor(motor2);

            Console.WriteLine($"Novo motor instalado.");
            Console.WriteLine($"Cilindrada do Novo Motor: {motor2.Cilindrada}");
            Console.WriteLine($"Nova Velocidade Máxima: {carro1.CalcularVelocidadeMaxima()} km/h");
        }
    }
