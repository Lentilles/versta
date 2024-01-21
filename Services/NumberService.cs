using versta24.Data;

namespace versta24.Services
{
    public class NumberService
    {
        private uint LastNumber;
        private string YearOfLastNumber;

        public NumberService(IServiceScopeFactory scopeFactory) 
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<VerstaDbContext>();

                var LastRecord = dbContext.Orders
                    .Where(record => record.Year == DateTime.Now.Year.ToString())
                    .OrderByDescending(record => record.Created).FirstOrDefault();
                if(LastRecord is null)
                {
                    LastNumber = 0;
                    YearOfLastNumber = DateTime.Now.Year.ToString();
                }
                else
                {
                    LastNumber = LastRecord.Number;
                    YearOfLastNumber = LastRecord.Year;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> Actual numbered sequence </returns>
        public uint GetNumber()
        {
            string currentYear = DateTime.Now.Year.ToString();
            if(currentYear != YearOfLastNumber)
            {
                LastNumber = 0;
                YearOfLastNumber = DateTime.Now.Year.ToString();
            }

            LastNumber++;
            return LastNumber;
        }
    }
}
