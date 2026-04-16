using System;


class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int Stock;

    public void Display()
    {
        Console.WriteLine(Id + ". " + Name + ":" + Price + " (Stock: " + Stock + ")");
    }
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

        products[0] = new Product { Id = 1, Name = "Lipstick", Price = 500, Stock = 20 };
        products[1] = new Product { Id = 2, Name = "Foundation", Price = 1500, Stock = 10 };
        products[2] = new Product { Id = 3, Name = "Eyeshadow", Price = 2000, Stock = 30 };
        products[3] = new Product { Id = 4, Name = "Mascara", Price = 400, Stock = 20 };
        products[4] = new Product { Id = 5, Name = "Contour", Price = 150, Stock = 10 };
        products[5] = new Product { Id = 6, Name = "Eyeliner", Price = 210, Stock = 30 };
        products[6] = new Product { Id = 7, Name = "Lipline", Price = 100, Stock = 20 };
        products[7] = new Product { Id = 8, Name = "Highlighter", Price = 160, Stock = 10 };
        products[8] = new Product { Id = 9, Name = "Blush on", Price = 200, Stock = 30 };
        products[9] = new Product { Id = 10, Name = "Pressed Powder", Price = 600, Stock = 20 };


        CartItem[] cart = new CartItem[10];
        int cartCount = 0;

        double total = 0;

        while (true)
        {
            Console.WriteLine("+=== MENU ===+");
            for (int i = 0; i < products.Length; i++)
            {
                products[i].Display();
            }
            Console.WriteLine("11. Exit");
            Console.WriteLine();

            Console.Write("Enter product number: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            if (choice == 11)
            {
                break;
            }

            if (choice < 1 || choice > products.Length)
            {
                Console.WriteLine("Invalid product");
                continue;
            }

            Product selected = products[choice - 1];

            if (selected.Stock == 0)
            {
                Console.WriteLine("Out of stock");
                continue;
            }

            Console.Write("Enter quantity: ");
            int qty;

            if (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity");
                continue;
            }

            if (qty > selected.Stock)
            {
                Console.WriteLine("Not enough stock");
                continue;
            }

            double itemTotal = selected.Price * qty;
            total += itemTotal;
            selected.Stock -= qty;

            cart[cartCount] = new CartItem
            {
                Product = selected,
                Quantity = qty
            };

            cartCount++;

            Console.WriteLine("Added to cart!");
            Console.WriteLine("Subtotal: " + itemTotal);

            Console.Write("Add more? (N/Y): ");
            string ans = Console.ReadLine();
            Console.WriteLine();

            if (ans.ToUpper() == "N")
                break;
        }
        {
            Console.WriteLine();
        }

        Console.WriteLine("+==== TOTAL ====+");
        Console.WriteLine("Grand Total: " + total);

        if (total >= 5000)
        {
            double discount = total * 0.10;
            double finalTotal = total - discount;

            Console.WriteLine("Discount: " + discount);
            Console.WriteLine("Final Total: " + finalTotal);
        }
        {
            Console.WriteLine();
        }


        Console.WriteLine("+=== REMAINING STOCK ===+");
        for (int i = 0; i < products.Length; i++)
        {
            Console.WriteLine(products[i].Name + ": " + products[i].Stock);
        }
    }
}