namespace Lekce13
{
    public class Calculator
    {
        private readonly IDatabase _database;

        public Calculator(IDatabase database)
        {
            _database = database;
        }

        public int Calculate()
        {
            int data = _database.GetData();
            return data * 2;
        }

        public int Calculate(string userName)
        {
            int data = _database.GetUserData(userName);
            return data * 2;
        }
    }
}
