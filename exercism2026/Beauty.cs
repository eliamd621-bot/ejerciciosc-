namespace Beauty
{
    using System;

    namespace BookingUpBeauty
    {
        public static class Appointment
        {
            // Tarea 1: Convertir un texto a DateTime
            public static DateTime Schedule(string appointmentDateDescription)
            {
                return DateTime.Parse(appointmentDateDescription);
            }

            // Tarea 2: Verificar si la fecha de la cita ya pasó
            public static bool HasPassed(DateTime appointmentDate)
            {
                return appointmentDate < DateTime.Now;
            }

            // Tarea 3: Verificar si la cita es por la tarde (>= 12:00 y < 18:00)
            public static bool IsAfternoonAppointment(DateTime appointmentDate)
            {
                return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;
            }

            // Tarea 4: Devolver la descripción formateada de la cita
            public static string Description(DateTime appointmentDate)
            {
                return $"You have an appointment on {appointmentDate}.";
            }

            // Tarea 5: Devolver la fecha del aniversario de este año (15 de Septiembre a las 00:00:00)
            public static DateTime AnniversaryDate()
            {
                return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // 1. Probar Schedule()
                DateTime fechaPrueba = Appointment.Schedule("7/25/2026 13:45:00");
                Console.WriteLine($"Cita programada: {fechaPrueba}");

                // 2. Probar HasPassed()
                bool yaPaso = Appointment.HasPassed(new DateTime(1999, 12, 31, 9, 0, 0));
                Console.WriteLine($"¿La fecha de 1999 ya pasó?: {yaPaso}");

                // 3. Probar IsAfternoonAppointment()
                bool esTarde = Appointment.IsAfternoonAppointment(new DateTime(2026, 3, 29, 15, 0, 0));
                Console.WriteLine($"¿Es cita por la tarde (15:00)?: {esTarde}");

                // 4. Probar Description()
                string descripcion = Appointment.Description(new DateTime(2026, 3, 29, 15, 0, 0));
                Console.WriteLine($"Descripción: {descripcion}");

                // 5. Probar AnniversaryDate()
                DateTime aniversario = Appointment.AnniversaryDate();
                Console.WriteLine($"Fecha de aniversario de este año: {aniversario}");
            }
        }
    }
}