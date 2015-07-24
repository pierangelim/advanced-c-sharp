namespace AnonymousTypes
{
    public class Manufacturer
    {
        private readonly string _name;

        public Manufacturer(string name)
        {
            _name = name;
        }

        public bool Equals(Manufacturer other)
        {
            return string.Equals(_name, other._name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Manufacturer)obj);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        public static bool operator ==(Manufacturer left, Manufacturer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Manufacturer left, Manufacturer right)
        {
            return !Equals(left, right);
        }
    }
}