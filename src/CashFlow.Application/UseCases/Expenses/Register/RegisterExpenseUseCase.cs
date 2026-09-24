using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExpeptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = new Expense
        {
            Description = request.Description,
            Date = request.Date,
            Amount = request.Amount,
            Title = request.Title,
            Type = (Domain.Enums.PaymentType)request.Type,
        };

        return new ResponseRegisterExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var ErrorList = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOrValidateException(errorMessages: ErrorList);
        }
    }
}
