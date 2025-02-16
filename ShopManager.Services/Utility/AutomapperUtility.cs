using AutoMapper;
using System.Reflection;

namespace ShopManager.Services.Utility
{
    public class AutomapperUtility
    {
        public static Type[] GetAllAutomapperProfiles()
        {
            var parentProfile = typeof(Profile);
            var assembly = Assembly.GetExecutingAssembly();

            return assembly.GetTypes()
                           .Where(x => x.IsSubclassOf(parentProfile))
                           .ToArray();
        }
    }
}
