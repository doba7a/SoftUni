public interface IBrowsable
{
    bool ValidUrl(string url);

    string VisitingSite(string url);
}
