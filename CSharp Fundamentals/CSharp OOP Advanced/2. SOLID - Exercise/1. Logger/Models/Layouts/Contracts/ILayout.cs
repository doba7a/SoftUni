using Logger.Models.Errors.Contracts;

namespace Logger.Models.Layouts.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}
