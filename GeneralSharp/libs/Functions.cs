using System.Runtime.InteropServices;

namespace GeneralSharp.libs;

public static class WinTweaks
{
    // Импортируем функцию поиска окна по названию
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    // Импортируем функцию перевода окна на передний план
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    // Импортируем функцию для проверки, свернуто ли окно
    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);

    // Импортируем функцию изменения состояния отображения окна
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    // Константа для восстановления окна в нормальный режим
    private const int SW_RESTORE = 9;

    /// <summary>
    /// Активирует окно по его точному названию (заголовку)
    /// </summary>
    /// <param name="windowTitle">Точный заголовок окна (например, "Калькулятор" или "Блокнот")</param>
    /// <returns>True, если окно найдено и успешно активировано; иначе False</returns>
    public static bool ActivateWindowByTitle(string windowTitle)
    {
        // 1. Ищем дескриптор окна (HWND) по его названию
        // Передаем null в качестве имени класса, чтобы искать только по имени заголовка
        IntPtr hWnd = FindWindow(null, windowTitle);

        // Если окно не найдено, возвращаем false
        if (hWnd == IntPtr.Zero) return false;
        
        // 2. Если окно свернуто (iconic), восстанавливаем его
        if (IsIconic(hWnd)) ShowWindow(hWnd, SW_RESTORE);
        
        // 3. Выводим окно на передний план и передаем фокус
        return SetForegroundWindow(hWnd);
    }
}

