namespace CashFlow.Validators.Test.Expenses.Register;

public class RegisterExpenseRegisterValidatorBuilder
{
    public RegisterExpenseValidator Build()
    {
        var faker = new Faker();

        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(x => x.Title, f => f.Commerce.CompanyName())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Date, f => f.Date.Past())
            .RuleFor(x => x.Amount, f => f.Random.Decimal(min: 1, max: 1000))
            .RuleFor(x => x.Type, f => f.PickRandom<CashFlow.Communication.Enums.PaymentType>());

    }
}