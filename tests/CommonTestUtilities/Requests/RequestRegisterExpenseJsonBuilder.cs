using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CashFlow.CommonTestUtilities.Requests;

public class RegisterExpenseRegisterValidatorBuilder
{
    public RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(x => x.Title, f => f.Company.CompanyName())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Date, f => f.Date.Past())
            .RuleFor(x => x.Amount, f => f.Random.Decimal(min: 1, max: 1000))
            .RuleFor(x => x.Type, f => f.PickRandom<PaymentType>())
            .Generate();
    }
}
