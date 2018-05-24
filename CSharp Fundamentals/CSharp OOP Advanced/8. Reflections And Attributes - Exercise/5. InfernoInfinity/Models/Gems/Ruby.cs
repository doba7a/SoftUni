public class Ruby : Gem
{
    private const int RUBY_STRENGTH = 7;
    private const int RUBY_AGILITY = 2;
    private const int RUBY_VITALITY = 5;

    public Ruby(Clarity clarity) 
        :base(clarity, RUBY_STRENGTH, RUBY_AGILITY, RUBY_VITALITY)
    {
    }
}

