using System.Security.Cryptography.X509Certificates;

namespace App;

public enum AdminPermission
{
  None,
  ManagePermissions,
  AssignRegions,
  HandleRegistrations,
  AddLocations,
  CreatePersonellAccounts,
  ViewPermissionsList,
}

class Admin : IUser
{

  public string FirstName { get; set; } //= ""; //Tomt namn för admin, måste ha ett namn för att hantera data till users.txt.
  public string LastName { get; set; } //= "";
  public string Username { get; set; }
  public string _password { get; set; }
  public Region UserStatus { get; set; }


  public List<AdminPermission> permissions = new();
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

  public bool HasPermission(AdminPermission permission)
  {
    return permissions.Contains(permission);
  }

  public void GrantPermission(AdminPermission permission)
  {
    if (!permissions.Contains(permission))
      permissions.Add(permission);
  }

  public void RevokePermission(AdminPermission permission)
  {
    permissions.Remove(permission);
  }

  public List<AdminPermission> GetAdminPermissions()
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