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
            Console.WriteLine("*=======MENU=======*");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. Product Category");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                while (true)
                {
                    foreach (var p in products)
                        Console.WriteLine($"{p.Id}. {p.Name} - {p.Price} (Stock: {p.Stock})");

                    Console.Write("Enter product ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Product selected = products[id - 1];

                    Console.Write("Quantity: ");
                    int qty = int.Parse(Console.ReadLine());

                    if (qty <= selected.Stock)
                    {
                        cart[cartCount++] = new CartItem { Product = selected, Quantity = qty };
                        selected.Stock -= qty;
                        total += selected.Price * qty;

                        Console.WriteLine("Item Added!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough stock");
                    }

                    
                    string ans;
                    while (true)
                    {
                        Console.Write("Add another item? (Y/N): ");
                        ans = Console.ReadLine().ToUpper();

                        if (ans == "Y" || ans == "N")
                            break;

                        Console.WriteLine("Invalid input. Please enter Y or N only.");
                    }

                    if (ans == "N")
                        break;
                }
            }


            else if (choice == 2)
            {
                Console.Write("Search product name: ");
                string key = Console.ReadLine().ToLower();

                bool found = false;

                foreach (var p in products)
                {
                    if (p.Name.ToLower().Contains(key))
                    {
                        Console.WriteLine($"{p.Name} - PHP {p.Price} (Stock: {p.Stock})");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No product found.");
                }
            }


            else if (choice == 3)
            {
                Console.Write("Product Category: ");
                string cat = Console.ReadLine();

                foreach (var p in products)
                    if (p.Category.ToLower() == cat.ToLower())
                        Console.WriteLine(p.Name);
            }

            else if (choice == 4)
            {
                while (true)
                {
                    Console.WriteLine("+=======CART MENU=======+");
                    Console.WriteLine("1. View Cart");
                    Console.WriteLine("2. Remove Item");
                    Console.WriteLine("3. Update Quantity");
                    Console.WriteLine("4. Clear Cart");
                    Console.WriteLine("5. Checkout");
                    Console.WriteLine("6. Back");

                    Console.Write("Enter Choice: ");
                    int cartChoice = int.Parse(Console.ReadLine());

                    if (cartChoice == 1)
                    {
                        Console.WriteLine("+=======CART=======+");
                        for (int i = 0; i < cartCount; i++)
                        {
                            Console.WriteLine($"{i + 1}. (ID:{cart[i].Product.Id}) {cart[i].Product.Name} x{cart[i].Quantity}");
                        }

                        if (cartCount == 0)
                            Console.WriteLine("Cart is empty");
                    }

                    else if (cartChoice == 2)
                    {
                        Console.Write("Enter item number to remove: ");
                        int index = int.Parse(Console.ReadLine()) - 1;

                        if (index >= 0 && index < cartCount)
                        {
                            cart[index].Product.Stock += cart[index].Quantity;
                            total -= cart[index].Product.Price * cart[index].Quantity;

                            cart[index] = cart[cartCount - 1];
                            cartCount--;

                            Console.WriteLine("Item removed");
                        }
                        else
                        {
                            Console.WriteLine("Invalid item");
                        }
                    }

                    else if (cartChoice == 3)
                    {
                        Console.Write("Enter Product ID to update: ");
                        int productId = int.Parse(Console.ReadLine());

                        bool found = false;

                        for (int i = 0; i < cartCount; i++)
                        {
                            if (cart[i].Product.Id == productId)
                            {
                                Console.Write("Enter new quantity: ");
                                int newQty = int.Parse(Console.ReadLine());

                                int oldQty = cart[i].Quantity;
                                int diff = newQty - oldQty;

                                if (diff > 0 && diff > cart[i].Product.Stock)
                                {
                                    Console.WriteLine("Not enough stock");
                                }
                                else
                                {
                                    cart[i].Product.Stock -= diff;
                                    cart[i].Quantity = newQty;
                                    total += cart[i].Product.Price * diff;

                                    Console.WriteLine("Quantity updated!");
                                }

                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Item not found in cart");
                        }
                    }

                    else if (cartChoice == 4)
                    {

                        for (int i = 0; i < cartCount; i++)
                        {
                            cart[i].Product.Stock += cart[i].Quantity;
                        }

                        cartCount = 0;
                        total = 0;

                        Console.WriteLine("Cart cleared");
                    }

                    else if (cartChoice == 5)
                    {
                        double discount = 0;
                        if (total >= 5000)
                            discount = total * 0.10;

                        double finalTotal = total - discount;

                        Console.WriteLine("Final Total: " + finalTotal);

                        double payment;
                        while (true)
                        {
                            Console.Write("Enter payment: ");
                            payment = double.Parse(Console.ReadLine());

                            if (payment >= finalTotal)
                                break;

                            Console.WriteLine("Insufficient payment.");
                        }

                        double change = payment - finalTotal;

                        Console.WriteLine("+====RECEIPT====+");
                        Console.WriteLine("Date: " + DateTime.Now);
                        Console.WriteLine("Total: " + total);
                        Console.WriteLine("Discount: " + discount);
                        Console.WriteLine("Final: " + finalTotal);
                        Console.WriteLine("Payment: " + payment);
                        Console.WriteLine("Change: " + change);

                        Console.WriteLine("\nLOW STOCK ALERT:");
                        foreach (var p in products)
                            if (p.Stock <= 5)
                                Console.WriteLine(p.Name + " low stock: " + p.Stock);

                        cartCount = 0;
                        total = 0;

                        break;
                    }

                    else if (cartChoice == 6)
                    {
                        break;
                    }
                }
            }
        }
    }
}
        
      
    