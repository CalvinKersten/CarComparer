using System.ComponentModel.DataAnnotations;
using VehicleComparerDAL;
using VehicleComparerModel;
using VehicleComparerService;
namespace VehicleComparer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            VehicleDao vehicleDao = new VehicleDao();
            vehicleDao.Display();
            ReadAction();
        }
        void ReadAction()
        {
            while (true)
            {
                Console.Write("Add vehicle (Press: A) | Remove vehicle (Press: D): ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "A")
                {
                    AddVehicle();
                }
                else if (input.ToUpper() == "D")
                {
                    RemoveVehicle();
                }
                else
                {
                    Console.WriteLine($"'{input}' is not a valid option :(");
                }
            }
        }
        private void AddVehicle()
        {
            VehicleDao vehicleDao = new VehicleDao();

            int id = 1;
            foreach (Vehicle vehicle in  vehicleDao.GetAllVehicles())
            {
                id++;
            }

            Console.Write("Enter vehicle name: ");
            string name = Console.ReadLine();

            Console.Write("Enter vehicle price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter mileage (round numbers): ");
            int mileage = int.Parse(Console.ReadLine());

            Console.Write("Enter register number: ");
            string register = Console.ReadLine();

            Console.Write("Enter tax amount: ");
            double tax = double.Parse(Console.ReadLine());

            Console.Write("Enter insurance amount: ");
            double insurance = double.Parse(Console.ReadLine());

            vehicleDao.Add(id, name, price, mileage, register, tax, insurance);
        }    
        private void RemoveVehicle()
        {
            VehicleDao vehicleDao = new VehicleDao();

            Console.Write("Number of vehicle you wish to remove: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write($"Are you sure you wish to remove vehicle nr. {id}? (Y/N): ");
            string input = Console.ReadLine();

            if ( input == "Y" ) 
            {
                vehicleDao.Delete(id);
            }
            else if (input == "N" )
            {
                return;
            }
            else { return; }
        }
    }
}