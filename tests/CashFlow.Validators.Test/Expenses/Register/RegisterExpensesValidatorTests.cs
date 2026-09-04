using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpensesValidatorTests
{
    [Fact]
    public void Success()
    {
        //arrange
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJson
        {
            Description = "Test",
            Date = DateTime.Now.AddDays(-1),
            Title = "Test",
            Amount = 100,
            Type = CashFlow.Communication.Enums.PaymentType.Cash
        };
        //act
        var result = validator.Validate(request);

        //assert
        Assert.True(result.IsValid);

    }
}