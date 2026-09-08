using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.CommonTestUtilities.Requests;
using Shouldly;

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
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Error_Title_Empty()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RegisterExpenseRegisterValidatorBuilder().Build();
        request.Title = string.Empty;
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();
    }
}