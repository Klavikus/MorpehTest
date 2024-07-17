namespace GameCore.Controllers.Services
{
    public class ProgressRepository
    {
        private readonly PlayerCurrency _currency;
        private readonly PlayerLevel _level;

        public ProgressRepository(int initialCurrency, int initialLevel)
        {
            _currency = new PlayerCurrency(initialCurrency);
            _level = new PlayerLevel(initialLevel);
        }

        public PlayerCurrency GetPlayerCurrency() =>
            _currency;

        public PlayerLevel GetPlayerLevel() =>
            _level;
    }

    public class PlayerLevel
    {
        public PlayerLevel(int initialLevel)
        {
        }
    }

    public class PlayerCurrency
    {
        public PlayerCurrency(int initialCurrency)
        {
        }
    }
}