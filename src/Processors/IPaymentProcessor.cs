using DesignPatternChallenge.Enums;
using DesignPatternChallenge.Requests;
using DesignPatternChallenge.Responses;

namespace DesignPatternChallenge;

public interface IPaymentProcessor
{
    PaymentResult ProcessPayment(PaymentRequest request);
    bool RefundPayment(string transactionId, decimal amount);
    PaymentStatus CheckStatus(string transactionId);
}
