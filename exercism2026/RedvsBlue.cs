namespace RedvsBlue
{
    using System;


    namespace RedRemoteControlCarTeam
    {
        public class RemoteControlCar
        {
            public Motor Motor { get; set; } = new Motor();
            public Telemetry Telemetry { get; set; } = new Telemetry();
        }

        public class Motor { }
        public class Telemetry { }
    }

    namespace BlueRemoteControlCarTeam
    {
        public class RemoteControlCar
        {
            public Motor Motor { get; set; } = new Motor();
            public Telemetry Telemetry { get; set; } = new Telemetry();
        }

        public class Motor { }
        public class Telemetry { }
    }


    namespace CombinedTest
    {
        using Red = RedRemoteControlCarTeam;
        using Blue = BlueRemoteControlCarTeam;

        class Program
        {
            static void Main()
            {
                var redCar = new Red.RemoteControlCar();
                var blueCar = new Blue.RemoteControlCar();

                Console.WriteLine($"Auto rojo creado: {redCar.GetType().FullName}");
                Console.WriteLine($"Auto azul creado: {blueCar.GetType().FullName}");
            }
        }
    }
}
