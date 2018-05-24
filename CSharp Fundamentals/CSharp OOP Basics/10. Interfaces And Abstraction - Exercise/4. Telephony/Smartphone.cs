using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    public string CallingNumber(string number)
    {
        return $"Calling... {number}";
    }

    public bool ValidNumber(string number)
    {
        if (number.All(x => char.IsDigit(x)))
        {
            return true;
        }

        return false;
    }

    public bool ValidUrl(string url)
    {
        if (url.Any(x => char.IsDigit(x)))
        {
            return false;
        }

        return true;
    }

    public string VisitingSite(string url)
    {
        return $"Browsing: {url}!";
    }
}