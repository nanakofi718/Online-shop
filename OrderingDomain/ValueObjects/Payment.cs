

namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

        protected Payment() 
        { 
        }

        private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymenMethod) 
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CVV = cvv;
            PaymentMethod = paymenMethod;
        }

        public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymenMethod) 
        {
            cvv = cvv?.Trim();
            ArgumentException.ThrowIfNullOrEmpty(cardName);
            ArgumentException.ThrowIfNullOrEmpty(cardNumber);
            ArgumentException.ThrowIfNullOrEmpty(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

            return new Payment (cardName, cardNumber, expiration, cvv, paymenMethod);
        }
    }
}
