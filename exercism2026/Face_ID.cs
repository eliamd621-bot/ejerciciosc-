namespace Face_ID
{
    using System;
    using System.Collections.Generic;

    public class FacialFeatures
    {
        public string EyeColor { get; }
        public decimal PhiltrumWidth { get; }

        public FacialFeatures(string eyeColor, decimal philtrumWidth)
        {
            EyeColor = eyeColor;
            PhiltrumWidth = philtrumWidth;
        }

        public override bool Equals(object? obj)
        {
            if (obj is FacialFeatures other)
            {
                return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EyeColor, PhiltrumWidth);
        }
    }

    public class Identity
    {
        public string Email { get; }
        public FacialFeatures FacialFeatures { get; }

        public Identity(string email, FacialFeatures facialFeatures)
        {
            Email = email;
            FacialFeatures = facialFeatures;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Identity other)
            {
                return Email == other.Email && Equals(FacialFeatures, other.FacialFeatures);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, FacialFeatures);
        }
    }

    public class Authenticator
    {
        private readonly HashSet<Identity> _registeredIdentities = new HashSet<Identity>();

        // Tarea 1: Compara si dos rostros son idénticos en sus valores
        public static bool AreSameFace(FacialFeatures face1, FacialFeatures face2)
        {
            return face1.Equals(face2);
        }

        // Tarea 2: Compara si la identidad coincide con la del administrador
        public bool IsAdmin(Identity identity)
        {
            var adminIdentity = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
            return identity.Equals(adminIdentity);
        }

        // Tarea 3: Registra una nueva identidad (HashSet.Add devuelve false si ya existía)
        public bool Register(Identity identity)
        {
            return _registeredIdentities.Add(identity);
        }

        // Tarea 4: Verifica si una identidad está registrada
        public bool IsRegistered(Identity identity)
        {
            return _registeredIdentities.Contains(identity);
        }

        // Tarea 5: Compara si ambas variables apuntan a la misma instancia exacta en memoria
        public static bool AreSameObject(object object1, object object2)
        {
            return ReferenceEquals(object1, object2);
        }
    }
}
