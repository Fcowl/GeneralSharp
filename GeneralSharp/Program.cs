using GeneralSharp.libs;

class Program {
    static void Main(string[] args)
    {
        bool admin = Func.IsAdmin();
        if (admin)
        {
            bool result = WinTweaks.ActivateWindowByTitle("Honkai: Star Rail");
            Console.WriteLine($"Окно активировано: {result}");
        }
        else Console.WriteLine("Запустите от администратора ");
        
    }
}