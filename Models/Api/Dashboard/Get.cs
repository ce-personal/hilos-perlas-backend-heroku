namespace Nothing.Models.Api.Dashboard
{
    public class GetInformationByBudget
    {
        public int NumberOfSales { get; set; }
        public string? Income { get; set; }
        public string? Profits { get; set; }
        public string? Losses { get; set;  }
    }

    public class GetInfoByOrderInWeek
    {
        public string Name { get; set; }
        public decimal Porcentage { get; set; }
        public int Cantidad { get; set; }
        public int CantidadTotal { get; set; }
    }
}
