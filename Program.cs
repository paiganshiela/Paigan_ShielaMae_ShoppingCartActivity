using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;
    public string Category;
}

class CartItem
{
    public Product Product;
    public int Quantity;
}

class Program
{
    static void Main()
    {

        Product[] products = new Product[10];

        products[0] = new Product { Id = 1, Name = "Lipstick", Price = 500, Stock = 20, Category = "Lip" };
        products[1] = new Product { Id = 2, Name = "Foundation", Price = 1500, Stock = 10, Category = "Face" };
        products[2] = new Product { Id = 3, Name = "Eyeshadow", Price = 2000, Stock = 30, Category = "Eye" };
        products[3] = new Product { Id = 4, Name = "Mascara", Price = 400, Stock = 20, Category = "Eye" };
        products[4] = new Product { Id = 5, Name = "Contour", Price = 150, Stock = 10, Category = "Face" };
        products[5] = new Product { Id = 6, Name = "Eyeliner", Price = 210, Stock = 30, Category = "Eye" };
        products[6] = new Product { Id = 7, Name = "Lipline", Price = 100, Stock = 20, Category = "Lip" };
        products[7] = new Product { Id = 8, Name = "Highlighter", Price = 160, Stock = 10, Category = "Face" };
        products[8] = new Product { Id = 9, Name = "Blush on", Price = 200, Stock = 30, Category = "Face" };
        products[9] = new Product { Id = 10, Name = "Pressed Powder", Price = 600, Stock = 20, Category = "Face" };

        CartItem[] cart = new CartItem[10];
        int cartCount = 0;

        double total = 0;

        while (true)
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Search");
                Console.WriteLine("3. Product Category");
                Console.WriteLine("4. View Cart");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("6. Exit");

                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());

            }
        }
    }
}