namespace MagicHamster.GrocerySamurai.PresentationLayer
{
    using JetBrains.Annotations;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
    [UsedImplicitly]
    public class Program
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        [UsedImplicitly]
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
