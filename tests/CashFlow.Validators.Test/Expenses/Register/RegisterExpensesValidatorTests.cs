using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.CommonTestUtilities.Requests;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpensesValidatorTests
{
    [Fact]
    public void Success()
    {
        //arrange
        var validator = new RegisterExpenseValidator();
        var request = new RegisterExpenseRegisterValidatorBuilder().Build();
        //act
        var result = validator.Validate(request);

        //assert
        Assert.True(result.IsValid);

    }
}