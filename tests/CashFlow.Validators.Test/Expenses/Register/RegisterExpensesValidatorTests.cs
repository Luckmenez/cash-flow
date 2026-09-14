using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.CommonTestUtilities.Requests;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
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

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Error_Title_Empty(string? title)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RegisterExpenseRegisterValidatorBuilder().Build();
        request.Title = title!;
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldHaveSingleItem();
        result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.TITLE_REQUIRED);
    }

    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RegisterExpenseRegisterValidatorBuilder().Build();
        request.Date = DateTime.UtcNow.AddDays(1);
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldHaveSingleItem();
        result
            .Errors[0]
            .ErrorMessage.ShouldBe(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE);
    }

    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RegisterExpenseRegisterValidatorBuilder().Build();
        request.Type = (PaymentType)700;
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldHaveSingleItem();
        result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Error_Amount_Invalid(decimal amount)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RegisterExpenseRegisterValidatorBuilder().Build();
        request.Amount = amount;
        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.ShouldBeFalse();

        result.Errors.ShouldHaveSingleItem();
        result.Errors[0].ErrorMessage.ShouldBe(
            ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO
        );
    }
}
