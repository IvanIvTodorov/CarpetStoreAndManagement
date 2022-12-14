namespace CarpetStoreAndManagement.ViewModels.OrderViewModels
{
    public class MyOrdersViewModel
    {
        public int OrderId { get; set; }
        public List<string> ProductName { get; set; }

        public List<string> ProductType { get; set; }

        public List<string> ProductColors { get; set; }

        public List<int> ProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCompleted { get; set; }
    }
}
