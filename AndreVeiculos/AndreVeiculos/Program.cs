using Controllers;
using Models;

namespace AndreVeiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
                // ** Inserindo Operação **
            //new OperationController().Insert(new List<Operation>() { new Operation() { Description = "Inserção de carro" } });

                // ** Inserindo Carro **
            //MenuInsertCar();

                // ** Inserindo Operação de Carro **
            /*List<Car> cars = new List<Car>();
            cars = new CarController().GetAll();
            List<Operation> operations = new List<Operation>();
            operations = new OperationController().GetAll();
            new CarOperationController().Insert(cars[0], operations[0]);*/

                // ** Listando Operações de Carro **
            /*var List = new CarOperationController().GetAll();
            Console.ReadKey();*/
        }

        static void MenuInsertCar()
        {
            do
            {
                Title(">>>>>Carro<<<<<");
                Console.WriteLine("1 - Inserir Manualmente");
                Console.WriteLine("2 - Gerar Aleatorio");
                Console.WriteLine("0 - Voltar");

                switch (LerInt())
                {
                    case 1:
                        InsertCar();
                        break;
                    case 2:
                        GenerateRandomCar();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (true);
        }

        static void InsertCar()
        {
            CarController carController = new CarController();
            List<Car> cars = new();

            Title(">>>>>Inserir Carro<<<<<");
            Car car = new Car()
            {
                Plate = LerString("Digite a placa do carro:"),
                Name = LerString("Digite o nome do carro:"),
                ModelYear = LerInt("Digite o ano do modelo do carro:"),
                ManufactureYear = LerInt("Digite o ano de fabricação do carro:"),
                Color = LerString("Digite a cor do carro:"),
                Sold = false
            };
            cars.Add(car);

            InsertMessage(carController.Insert(cars));
        }

        static void GenerateRandomCar()
        {
            CarController carController = new CarController();

            Random random = new Random();
            string[] cars = { "Volkswagen Gol", "Fiat Uno", "Chevrolet Onix", "Ford Fiesta", "Renault Sandero", "Hyundai HB20", "Toyota Corolla", "Honda Civic", "Fiat Palio", "Volkswagen Fox", "Chevrolet Corsa", "Ford Ka", "Renault Logan", "Nissan Versa", "Toyota Hilux", "Honda Fit", "Volkswagen Saveiro", "Fiat Strada", "Chevrolet Prisma", "Ford Focus", "Hyundai Creta", "Toyota Etios", "Renault Duster", "Nissan March", "Volkswagen Voyage", "Fiat Siena", "Chevrolet Cruze", "Honda HR-V", "Ford Ranger", "Toyota RAV4", "Volkswagen Polo", "Fiat Argo", "Renault Kwid", "Nissan Kicks", "Hyundai Tucson", "Chevrolet Spin", "Honda City", "Ford Ecosport", "Toyota Yaris", "Volkswagen Jetta", "Fiat Fiorino", "Renault Captur", "Nissan Sentra", "Hyundai i30", "Chevrolet Tracker", "Ford Fusion", "Toyota SW4", "Volkswagen Amarok", "Fiat Toro", "Renault Fluence", "Honda Accord", "Chevrolet Cobalt", "Ford Edge", "Toyota Camry", "Volkswagen Golf", "Fiat Mobi", "Renault Megane", "Nissan Frontier", "Hyundai Santa Fe", "Chevrolet Montana", "Ford Territory", "Toyota Prius", "Volkswagen Up!", "Fiat Grand Siena", "Renault Oroch", "Nissan Tiida", "Hyundai Veloster", "Chevrolet Trailblazer", "Ford Taurus", "Toyota Land Cruiser", "Volkswagen SpaceFox", "Fiat Cronos", "Renault Symbol", "Nissan X-Trail", "Hyundai Elantra", "Chevrolet S10", "Ford Mustang", "Toyota Hilux SW4", "Volkswagen Tiguan", "Fiat Doblo", "Renault Scenic", "Nissan Altima", "Hyundai Genesis", "Chevrolet Camaro", "Ford Explorer", "Toyota Prius C", "Volkswagen Passat", "Fiat 500", "Renault Zoe", "Nissan Murano", "Hyundai Azera", "Chevrolet Equinox", "Ford F-150", "Toyota Avalon", "Volkswagen Virtus", "Fiat 147", "Renault Twingo", "Nissan Maxima", "Hyundai Veracruz", "Chevrolet Blazer" };
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string[] colors = { "preto", "branco", "prata", "cinza", "vermelho", "azul", "verde", "amarelo" };
            int year = random.Next(1980, 2024);

            List<Car> generatedCar = new List<Car>();
            Car car = new Car()
            {
                Plate = $"{letters[new Random().Next(0, letters.Length)]}{letters[random.Next(0, letters.Length)]}{letters[random.Next(0, letters.Length)]}-{random.Next(0, 9999):0000}",
                Name = cars[new Random().Next(0, cars.Length)],
                ManufactureYear = year,
                ModelYear = new Random().Next(year, year + 2),
                Color = colors[new Random().Next(0, colors.Length)],
                Sold = true
            };

            generatedCar.Add(car);

            InsertMessage(carController.Insert(generatedCar));
        }

        static void InsertMessage(bool result)
        {
            Console.WriteLine();
            if (result)
            {
                Console.WriteLine("Carro inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao inserir carro!");
            }
            Console.ReadKey();
        }

        static void Title(string title)
        {
            Console.Clear();
            Console.WriteLine(title);
        }

        static string LerString(string mensagem)
        {
            string result = string.Empty;
            do
            {
                Console.WriteLine(mensagem);
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("\nValor inválido!\n");
                }
            } while (string.IsNullOrEmpty(result));

            return result;
        }

        static string LerString()
        {
            string result = string.Empty;
            do
            {
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("\nValor inválido!\n");
                }
            } while (string.IsNullOrEmpty(result));

            return result;
        }

        static int LerInt(string mensagem)
        {
            int result;
            bool conversao;

            do
            {
                Console.WriteLine(mensagem);
                conversao = int.TryParse(Console.ReadLine(), out result);
                if (!conversao)
                {
                    Console.WriteLine("\nValor inválido!\n");
                }
            } while (!conversao);

            return result;
        }

        static int LerInt()
        {
            int result;
            bool conversao;

            do
            {
                conversao = int.TryParse(Console.ReadLine(), out result);
                if (!conversao)
                {
                    Console.WriteLine("\nValor inválido!\n");
                }
            } while (!conversao);

            return result;
        }   
    }
}
