namespace SoftJail.DataProcessor.ExportDto
{
    public class ExpPrisonerByCellDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public ExpOfficerByCellDto[] Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }
}
