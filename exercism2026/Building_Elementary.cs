namespace Building_Elementary
{
    using System;

    public class RemoteControlCar
    {
        private int batteryPercentage = 100;
        private int distanceDrivenInMeters = 0;
        private string[] sponsors = Array.Empty<string>();
        private int highestSerialNum = 0;

        public static RemoteControlCar Buy()
        {
            return new RemoteControlCar();
        }

        public void Drive()
        {
            if (batteryPercentage > 0)
            {
                batteryPercentage -= 10;
                distanceDrivenInMeters += 2;
            }
        }

        // Tarea 1: Recibir uno o más patrocinadores con params
        public void SetSponsors(params string[] sponsors)
        {
            this.sponsors = sponsors;
        }

        public string DisplaySponsor(int sponsorNum)
        {
            return sponsors[sponsorNum];
        }

        // Tarea 2: Obtener la telemetría usando ref y out
        public bool GetTelemetryData(ref int serialNum, out int batteryPercentage, out int distanceDrivenInMeters)
        {
            if (serialNum < highestSerialNum)
            {
                serialNum = highestSerialNum;
                batteryPercentage = -1;
                distanceDrivenInMeters = -1;
                return false;
            }

            highestSerialNum = serialNum;
            batteryPercentage = this.batteryPercentage;
            distanceDrivenInMeters = this.distanceDrivenInMeters;
            return true;
        }
    }

    public class TelemetryClient
    {
        private readonly RemoteControlCar car;

        public TelemetryClient(RemoteControlCar car)
        {
            this.car = car;
        }

        // Tarea 3: Calcular el consumo de batería por metro
        public string GetBatteryUsagePerMeter(int serialNum)
        {
            bool success = car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters);

            if (!success || distanceDrivenInMeters <= 0)
            {
                return "no data";
            }

            int usagePerMeter = (100 - batteryPercentage) / distanceDrivenInMeters;
            return $"usage-per-meter={usagePerMeter}";
        }
    }
}