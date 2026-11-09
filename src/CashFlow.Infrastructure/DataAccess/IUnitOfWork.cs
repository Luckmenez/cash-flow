namespace CashFlow.Infrastructure.DataAccess;

public interface IUnitOfWork
{
    void Commit();
}
