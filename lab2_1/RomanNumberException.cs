namespace lab2
{
    public class RomanNumberException : Exception
    {
        public RomanNumberException() { }
        public RomanNumberException(string text) : base(text) { }
        public RomanNumberException(string text, RomanNumberException inner) : base(text, inner) { }
        protected RomanNumberException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}