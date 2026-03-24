using DesignPatternChallenge.Enums;
using DesignPatternChallenge.Requests;
using DesignPatternChallenge.Responses;

namespace DesignPatternChallenge.Adapters;

public class PaymentAdapter : IPaymentProcessor
{
    private readonly LegacyPaymentSystem _legacyPaymentSystem;

    public PaymentAdapter(LegacyPaymentSystem legacyPaymentSystem)
    {
        _legacyPaymentSystem = legacyPaymentSystem;
    }

    public PaymentStatus CheckStatus(string transactionId)
    {
        var transactionStatus = _legacyPaymentSystem.QueryTransactionStatus(transactionId);

        var paymentStatuses = Enum.GetValues<PaymentStatus>();

        return paymentStatuses.First(x => x.ToString().Equals(transactionStatus, StringComparison.OrdinalIgnoreCase));
    }

    public PaymentResult ProcessPayment(PaymentRequest request)
    {
        try
        {
            var response = _legacyPaymentSystem.AuthorizeTransaction(request.CreditCardNumber, 
                                                                     Int32.Parse(request.Cvv), 
                                                                     request.ExpirationDate.Month,
                                                                     request.ExpirationDate.Year,
                                                                     (double)request.Amount,
                                                                     request.Description);

            return new PaymentResult
            {
                Success = true,
                TransactionId = response.TransactionRef,
                Message = response.ResponseMessage
            };                      
        }
        catch (Exception ex)
        {
            return new PaymentResult
            {
                Success = false,
                Message = ex.Message
            };
        }                                  
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
       return  _legacyPaymentSystem.ReverseTransaction(transactionId, (double)amount);
    }
}
