namespace Remote_Control
{
    using System;

    public class RemoteControlCar
    {
        private string currentSponsor = "";
        private string speed = "";

        public string CurrentSponsor => currentSponsor;
        public TelemetryTelemetry Telemetry { get; }

        public RemoteControlCar()
        {
            Telemetry = new TelemetryTelemetry(this);
        }

        public string GetSpeed() => speed;

        // Tarea 4: El enum SpeedUnits no se puede usar fuera de RemoteControlCar
        private enum SpeedUnits
        {
            MetersPerSecond,
            CentimetersPerSecond
        }

        // Tarea 3: El struct Speed no se puede usar fuera de RemoteControlCar
        private struct Speed
        {
            public int Amount { get; }
            public SpeedUnits Units { get; }

            public Speed(int amount, SpeedUnits units)
            {
                Amount = amount;
                Units = units;
            }

            public override string ToString()
            {
                string unitText = Units switch
                {
                    SpeedUnits.MetersPerSecond => "meters per second",
                    SpeedUnits.CentimetersPerSecond => "centimeters per second",
                    _ => ""
                };
                return $"{Amount} {unitText}";
            }
        }

        // Tareas 1 y 2: Clase Telemetry accesible solo mediante la propiedad car.Telemetry
        public class TelemetryTelemetry
        {
            private readonly RemoteControlCar _car;

            internal TelemetryTelemetry(RemoteControlCar car)
            {
                _car = car;
            }

            public void Calibrate()
            {
            }

            public bool SelfTest()
            {
                return true;
            }

            public void ShowSponsor(string sponsorName)
            {
                _car.currentSponsor = sponsorName;
            }

            public void SetSpeed(int speedAmount, string minOrMax)
            {
                SpeedUnits units = minOrMax switch
                {
                    "mps" => SpeedUnits.MetersPerSecond,
                    "cps" => SpeedUnits.CentimetersPerSecond,
                    _ => SpeedUnits.MetersPerSecond
                };

                var speedStruct = new Speed(speedAmount, units);
                _car.speed = speedStruct.ToString();
            }
        }
    }
}