using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private const string EndCommand = "END";

        private StorageMaster storageMaster;
        private StringBuilder sb;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
            this.sb = new StringBuilder();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (!input.Equals(EndCommand))
            {
                try
                {
                    this.ProcessCommand(input);
                }
                catch (InvalidOperationException ioe)
                {
                    sb.AppendLine("Error: " + ioe.Message);
                }

                input = Console.ReadLine();
            }

            sb.AppendLine(this.storageMaster.GetSummary());
            Console.WriteLine(this.sb.ToString().Trim());
        }

        private void ProcessCommand(string input)
        {
            string[] inputData = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = inputData[0];

            switch (command)
            {
                case "AddProduct":
                    string productType = inputData[1];
                    double productPrice = double.Parse(inputData[2]);

                    sb.AppendLine(this.storageMaster.AddProduct(productType, productPrice));
                    break;
                case "RegisterStorage":
                    string storageTypeToRegister = inputData[1];
                    string storageNameToRegister = inputData[2];

                    sb.AppendLine(this.storageMaster.RegisterStorage(storageTypeToRegister, storageNameToRegister));
                    break;
                case "SelectVehicle":
                    string storageNameToGetVehicle = inputData[1];
                    int garageSlotToGetVehicle = int.Parse(inputData[2]);

                    sb.AppendLine(this.storageMaster.SelectVehicle(storageNameToGetVehicle, garageSlotToGetVehicle));
                    break;
                case "LoadVehicle":
                    List<string> productNames = inputData.Skip(1).ToList();

                    sb.AppendLine(this.storageMaster.LoadVehicle(productNames));
                    break;
                case "SendVehicleTo":
                    string sourceName = inputData[1];
                    int sourceGarageSlot = int.Parse(inputData[2]);
                    string destinationName = inputData[3];

                    sb.AppendLine(this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
                    break;
                case "UnloadVehicle":
                    string storageName = inputData[1];
                    int garageSlot = int.Parse(inputData[2]);

                    sb.AppendLine(this.storageMaster.UnloadVehicle(storageName, garageSlot));
                    break;
                case "GetStorageStatus":
                    string storageNameForStatus = inputData[1];

                    sb.AppendLine(this.storageMaster.GetStorageStatus(storageNameForStatus));
                    break;
                default:
                    break;
            }
        }
    }
}
