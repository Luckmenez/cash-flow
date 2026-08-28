using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisterExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("Title is required");
        }
        if (request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }
        var dateCompare = DateTime.Compare(request.Date, DateTime.Now);
        if (dateCompare > 0)
        {
            throw new ArgumentException("Date cannot be in the future");
        }
        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.Type);
        if (!paymentTypeIsValid)
        {
            throw new ArgumentException("Invalid payment type");
        }
    }
}
