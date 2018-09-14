using System;

public class UnlockedWeaponQuerry
{
    
    public const string INSERT_SQL = "INSERT INTO alarm (memo, ringtoneId, hour, minute, activated, DayOfWeek) VALUES(?, ?, ?, ?, ?, ?)";

    public const string SELECT_ALL_SQL = "SELECT FK_UnlockedWeaponBlueprint_Id, Name FROM UnlockedWaeponBlueprint INNER JOIN AllWeaponBlueprint ON FK_UnlockedWeaponBlueprint_Id = ";

    public const string SELECT_ALARM_SQL = "SELECT id, memo, ringtoneId, hour, minute, activated, DayOfWeek FROM alarm WHERE id=?";
                  
    public const string DELETE_ALARM_SQL = "DELETE FROM alarm WHERE id=?";
    public const string CLEAR_ALARM_SQL = "DELETE FROM alarm";
                  
    public const string UPDATE_ALARM_SQL = "UPDATE alarm SET memo=?, ringtoneId=?, hour=?, minute=?, activated=?, DayOfWeek=? WHERE id=?";


    private UnlockedWeaponQuerry()
    {
        //Private constructor to prevent instantiation
    }
}