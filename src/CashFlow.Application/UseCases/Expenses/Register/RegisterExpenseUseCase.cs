using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExpeptionBase;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpenseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterExpenseUseCase(IExpenseRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisterExpenseJson> Execute(RequestRegisterExpenseJson request)
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

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return new ResponseRegisterExpenseJson {
            Title = entity.Title
        };
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
