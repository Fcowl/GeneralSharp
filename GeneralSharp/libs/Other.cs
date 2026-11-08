using System.Security.Principal;

namespace GeneralSharp.libs;
public class Func
{
    public static bool IsAdmin()
    {
        using WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);

    }
}