namespace B05ASPC20_session.Models
{
    public class Cart
    {
        public string Name { get; set; }
        public int Qty { get; set; }
    }

    public class SHoppingCart
    {
        public List<Cart> CartItems = new List<Cart>();


        public void AddToCart(string name, int qty)
        {
            //var ifxist= CartItems.Any(p=>p.Product.Id==product.Id);
            var ifexist = CartItems.FirstOrDefault(p => p.Name == name);
            if (ifexist != null)
            {
                ifexist.Qty += qty;
            }
            else
            {
                CartItems.Add(new Cart { Name = name, Qty = qty });
            }
           

        }
    }
}
