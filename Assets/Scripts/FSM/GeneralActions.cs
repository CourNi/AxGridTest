using AxGrid;
using System.Linq;

public static class GeneralActions
{
    public static void ChangeLocationState(string location)
    {
        string currentLocation = Settings.Model.GetString("State");
        Settings.Model.Set($"Btn{currentLocation}Enable", true);
        Settings.Model.Set($"Btn{location}Enable", false);
        Settings.Model.Set("State", location);
    }

    public static string GetNextCollection(string currentCollection)
    {
        string targetCollection = Settings.Model.GetList<string>("CollectionList").SkipWhile(i => i != currentCollection).Skip(1).FirstOrDefault();
        if (targetCollection == null) targetCollection = Settings.Model.GetList<string>("CollectionList")[0];
        return targetCollection;
    }
}
