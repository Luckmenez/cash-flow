namespace CashFlow.Exception.ExpeptionBase;

public class ErrorOrValidateException : CashFlowException
{
    public List<string> Errors { get; set; }
    public ErrorOrValidateException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}