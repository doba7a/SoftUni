using StorageMaster.Core;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using System;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
