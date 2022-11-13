using WindowsFirewallHelper;
using WindowsFirewallHelper.FirewallRules;

DateTime timeNow = DateTime.Now;
Console.WriteLine($"{timeNow} Renewer started");

while (true)
{
    var rule = new FirewallWASRule(
            "SteamFamilySharingRenewer",
            @"C:\program files (x86)\steam\steam.exe",
            FirewallAction.Block,
            FirewallDirection.Outbound,
            FirewallProfiles.Domain | FirewallProfiles.Private | FirewallProfiles.Public
        );
    FirewallWAS.Instance.Rules.Add(rule);
    Console.WriteLine($"{timeNow} Renewing...");
    var myRule = FirewallManager.Instance.Rules.FirstOrDefault(r => r.Name == "SteamFamilySharingRenewer");
    Thread.Sleep(500);
    FirewallManager.Instance.Rules.Remove(myRule);
    Console.WriteLine($"{timeNow} Successful renewal");
    for (double i = 0; i < 4.5; i=i+1.5)
    {
        Console.WriteLine($"{timeNow} {4.5 - i} minutes till next renewal");
        Thread.Sleep(90000);
    }
}
