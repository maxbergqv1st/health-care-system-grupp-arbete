namespace App;

public enum AdminPermission //enum-lista för vad för adminfunctions som kommer att användas 
{
  None,
  ManagePermissions,
  AssignRegions,
  HandleRegistrations,
  AddLocations, //tanke att man ska kunna lägga till flera regioner eller sjukhus, tex Halmstad sjukhus
  CreatePersonellAccounts, //göra accounts för doctor
  ViewPermissionsList, //se men inte röra
}

class Admin : IUser
{

  public string FirstName { get; set; } //ska vara tomt namn för admin, måste ha ett namn för att hantera data till users.txt.
  public string LastName { get; set; } //ska också vara tom
  public string Username { get; set; }
  public string _password { get; set; }
  public Region UserStatus { get; set; }


  public List<AdminPermission> permissions = new(); //en lista som håller permissions
  public Admin(string firstname, string lastname, string username, string password, Region region)
  {
    FirstName = firstname;
    LastName = lastname;
    Username = username;
    _password = password;
    UserStatus = region;
  }

  public bool TryLogin(string username, string password) //Metod för att använda Account till IUsern loggin.
  {
    return username == Username && password == _password; //Skickar username och password till metoden. Returnar true eller false.
  }

  public bool HasPermission(AdminPermission permission) // en bool som håller vem som har permissions
  {
    return permissions.Contains(permission);
  }

  public void GrantPermission(AdminPermission permission) //en void man kan kalla på för att godkänna permissions
  {
    if (!permissions.Contains(permission))
      permissions.Add(permission);
  }

  public void RevokePermission(AdminPermission permission) //en void man kan kalla på för att neka permissions
  {
    permissions.Remove(permission);
  }

  public List<AdminPermission> GetAdminPermissions()//en lista för just adminpermissions
  {
    return permissions;
  }

}

/*
    As an admin with sufficient permissions, I need to be able to give admins the permission to handle the permission system, in fine granularity. 

    As an admin with sufficient permissions, I need to be able to assign admins to certain regions. 

    As an admin with sufficient permissions, I need to be able to give admins the permission to handle registrations. 

    As an admin with sufficient permissions, I need to be able to give admins the permission to add locations. 

    As an admin with sufficient permissions, I need to be able to give admins the permission to create accounts for personnel. 

    As an admin with sufficient permissions, I need to be able to give admins the permission to view a list of who has permission to what. 

    As an admin with sufficient permissions, I need to be able to add locations. 

    As an admin with sufficient permissions, I need to be able to accept user registration as patients. 

    As an admin with sufficient permissions, I need to be able to deny user registration as patients. 

    As an admin with sufficient permissions, I need to be able to create accounts for personnel. 

    As an admin with sufficient permissions, I need to be able to view a list of who has permission to what. 
    */