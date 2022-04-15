using AxGrid;

public static class GeneralActions
{
    public static void ChangeLocationState(string location)
    {
        string currentLocation = Settings.Model.GetString("State");
        Settings.Model.Set($"Btn{currentLocation}Enable", true);
        Settings.Model.Set($"Btn{location}Enable", false);
        Settings.Model.Set("State", location);
    }
}
