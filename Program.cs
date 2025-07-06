// See https://aka.ms/new-console-template for more information

    using InventorySystem.Models;
    using InventorySystem.Repositories;
    using InventorySystem.Services;
    using InventorySystem.Utils;

    //Server: mysql所在伺服器位置 (local host or ip xxx.xxx.xxx.xxx)
    //Port: mysql端口(預設3306)
    //Database: inventory_db(CREATE DATABASE inventory_db;)
    //uid: mysql使用者名稱
    //pwd: mysql使用者密碼
    const string MYSQL_CONNECTION_STRING = "Server=localhost;Port=3306;Database=inventory_db;uid=root;Pwd=235235jASON;"; //MySqlProductRepository productRepository = new MySqlProductRepository(MYSQL_CONNECTION_STRING);
    
    //小明注入 打掃阿姨1 (mysql實作)
    MySqlProductRepository productRepo = new MySqlProductRepository(MYSQL_CONNECTION_STRING);
    InventoryService inventoryService = new InventoryService(productRepo);

    
    //通知功能相關
    //使用EmailNotifier
    EmailNotifier  emailNotifier = new EmailNotifier();
    NotificationService emailService = new NotificationService(emailNotifier);
    //SmsNotifier
    SmsNotifier smsNotifier = new SmsNotifier();
    NotificationService smsService = new NotificationService(smsNotifier);
    
    
    //小明注入 打掃阿姨2 (mongo實作)

    
    
    
    RunMenu();

void RunMenu()
{
    while (true)
    {
        DisplayMenu();
        string input = Console.ReadLine();
        switch (input) 
        {
            case "1": GetAllProducts();
                break;
            case "2": SearchProduct();
                break;
            case "3": AddProduct();
                break;
            case "0": 
                Console.WriteLine("Goodbye !");
                return;
        }
    }
}

void DisplayMenu()
{
    Console.WriteLine("Welcome to the inventory system!");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. 查看所有產品");
    Console.WriteLine("2. 查詢產品");
    Console.WriteLine("3. 新增產品");
    Console.WriteLine("0. 離開");
}

void GetAllProducts()
{
    Console.WriteLine("\n--- 所有產品列表 ---");
    var products = inventoryService.GetAllProducts();
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("ID | Name | Price | Quantity | Status");
    Console.WriteLine("-----------------------------------------------");
    foreach (var product in products)
    { 
        Console.WriteLine(product);
    }
    Console.WriteLine("-----------------------------------------------");
    
    User user = Auth.
    emailService.NotifyUser("Jason", "查詢已完成");
}

void SearchProduct()
{
    Console.WriteLine("輸入欲查詢的產品編號");
    int input = ReadIntLine(1);
    var product = productRepo.GetProductById(input);
    // string input = Console.ReadLine();
    // var product = productRepository.GetProductById(ReadInt(input));
    if (product != null)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("ID | Name | Price | Quantity | Status");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine(product);
        Console.WriteLine("-----------------------------------------------");
    }
}

void AddProduct()
{
    Console.WriteLine("輸入產品名稱：");
    string name = Console.ReadLine();
    Console.WriteLine("輸入產品價格：");
    decimal price = ReadDecimalLine();
    Console.WriteLine("輸入產品數量：");
    int quantity = ReadIntLine();
    productRepo.AddProduct(name, price, quantity);
    smsService.NotifyUser("john", "新增產品成功");
}
    
int ReadInt(string input)
{
    try
    {
        return Convert.ToInt32(input);
    }
    catch (FormatException e)
    {
        Console.WriteLine("請輸入有效數字。");
        return 0;
    }
}

int ReadIntLine(int defaultValue = 0)
{
    while (true)
    {
        
        String input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) && defaultValue != 0)
        {
            return defaultValue;
        }
        //string parsing to int 
        if (int.TryParse(input,out int value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("請輸入有效數字。");
        }
    }
}

decimal ReadDecimalLine(decimal defaultValue = 0.0m)
{
    while (true)
    {
        
        String input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) && defaultValue != 0.0m)
        {
            return defaultValue;
        }
        //string parsing to int 
        if (decimal.TryParse(input,out decimal value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("請輸入有效數字。");
        }
    }
}





    // Product testProduct = new Product(1, "testProduct", 100.0m, 5);
    // testProduct.Quantity = 15;
    // testProduct.UpdateStatus();
    // Console.WriteLine(testProduct.ToString());

    // List<Animal> animals = new List<Animal>();
    // animals.Add(new Cat("OBOB"));
    // animals.Add(new Dog("DD"));
    // // animals.Add(new Animal("bird"));
    // foreach (Animal animal in animals)
    // {
    //     animal.MakeSound();
    // }
    //
    //
    // void ConsoleReadLine()
    // {
    //     //Scanner sc =new Scanner();
    //     // sc.nextLine()
    //     Console.Write("請輸入你的名字：  ");
    //     string userName = Console.ReadLine();
    //     Console.WriteLine($"哈囉,{userName}!");
    //     Console.Write("請輸入您的年齡：  ");
    //     string intputAge = Console.ReadLine();
    //
    //     if (int.TryParse(intputAge, out int age))
    //     {
    //         Console.WriteLine($"你的年齡為{age}!");
    //     }
    //     else
    //     {
    //         Console.WriteLine("年齡輸入錯誤");
    //     }
    // }
    //
    //
    //
    //
    // void IFElse(string day)
    // {
    //     if (day == "Monday" || day == "Tuesday")
    //     {
    //         Console.WriteLine("工作日");
    //     }
    //     else if (day == "Saturday" || day == "Sunday")
    //     {
    //         Console.WriteLine("週末");
    //     }
    //     else
    //     {
    //         Console.WriteLine("未知日期");
    //     }
    // }
    //
    //
    //
    // void flag(bool b)
    // {
    //     /*version 1
    //     if (b)
    //     {
    //         Console.WriteLine("條件為真");
    //     }
    //     else
    //     {
    //         Console.WriteLine("條件為假");
    //     }*/
    //     
    //     /* version 2
    //     string msg;
    //     if (b)
    //     {
    //         msg = "條件為真";
    //     }
    //     else
    //     {
    //         msg = "條件為假";
    //     } */
    //     
    //     // version 3 (三元運算子)
    //     //string msg = b ? "<條件為真>" : "<條件為假>";
    //     //Console.WriteLine(msg);
    //     
    // }
    //
    // static void SwitchCase(string dayOfWeek)
    // {
    //     switch (dayOfWeek)
    //     {
    //         case "Monday":
    //         case "Tuesday":
    //             Console.WriteLine("工作日"); 
    //             break;
    //         case "Sunday":
    //         case "Saturday": 
    //             Console.WriteLine("ˋ週末");
    //             break; 
    //         default:
    //             Console.WriteLine("未知日期");
    //             break;
    //     }
    //     
    //     
    //     
    //     
    //     
    // }
    //
    // static void test()
    // {
    //     var str = "test";
    //     Console.WriteLine("這是一行文字，會自動換行。"); //System.out.print()
    //     Console.Write("這是一行文字，");
    //     Console.Write("不會自動換行。");//System.out.print()
    //     Console.WriteLine("\n換行了。"); // 可以用 \n 強制換行
    //     Console.Write($"測試文字{str}");
    // }
    