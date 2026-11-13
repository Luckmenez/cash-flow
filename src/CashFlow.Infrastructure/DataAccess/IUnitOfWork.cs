namespace CashFlow.Infrastructure.DataAccess;

public interface IUnitOfWork
{
    Task Commit();
}
