using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Newtonsoft.Json;

/// <summary>
/// Person 的摘要描述
/// </summary>
[JsonObject(MemberSerialization.OptIn)]
public class SPerson
{
    private string _Account;
    [JsonProperty]
    public string account
    {
        get
        {
            return _Account;
        }
        set
        {
            _Account = value;
        }
    }
    
    private string _Name;
    [JsonProperty]
    public string name
    {
        get
        {
            return _Name;
        }
        set
        {
            _Name = value;
        }
    }

    private string _Id;
    [JsonProperty]
    public string id
    {
        get
        {
            return _Id;
        }
        set
        {
            _Id = value;
        }
    }

    private string _Organization;
    [JsonProperty]
    public string Organization
    {
        get
        {
            return _Organization;
        }
        set
        {
            _Organization = value;
        }
    }

    private string _Permission;
    [JsonProperty]
    public string Permission
    {
        get
        {
            return _Permission;
        }
        set
        {
            _Permission = value;
        }
    }

    private string _Email;
    [JsonProperty]
    public string email
    {
        get
        {
            return _Email;
        }
        set
        {
            _Email = value;
        }
    }

    private string _Gender;
    [JsonProperty]
    public string gender
    {
        get
        {
            return _Gender;
        }
        set
        {
            _Gender = value;
        }
    }

    private string _CellPhone;
    [JsonProperty]
    public string cellPhone
    {
        get
        {
            return _CellPhone;
        }
        set
        {
            _CellPhone = value;
        }
    }

}

public class Person
{
    private string _Account;

    public string account
    {
        get
        {
            return _Account;
        }
    }
    
    private string _Name;
    public string name
    {
        get
        {
            return _Name;
        }
    }

    private string _Id;
    public string id
    {
        get
        {
            return _Id;
        }
    }

    private string _Organization;
    public string organization
    {
        get
        {
            return _Organization;
        }
    }

    private string _Permission;
    public string permission
    {
        get
        {
            return _Permission;
        }
    }

    private string _Email;
    public string email
    {
        get
        {
            return _Email;
        }
    }

    private string _Gender;
    public string gender
    {
        get
        {
            return _Gender;
        }
    }

    private string _CellPhone;
    public string cellPhone
    {
        get
        {
            return _CellPhone;
        }
    }

    public Person()
    {
        //取得UserData
        string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
        SPerson Myperson = JsonConvert.DeserializeObject<SPerson>(strUserData);
        _Account = Myperson.account;
        _Email = Myperson.email;
        _Name = Myperson.name;
        _Id = Myperson.id;
        _Organization = Myperson.Organization;
        _Permission = Myperson.Permission;
        _Gender = Myperson.gender;
        _CellPhone = Myperson.cellPhone;

    }
    DataLayer dl=new DataLayer();

    public bool IsAdmin()
    {
        bool result = false;
        DataTable dtRoles = dl.GetRoleByAccount(_Account);
        DataRow[] dataRows = dtRoles.Select("roleID=1");
        if(dataRows.Length>0)
        {
            result=true;
        }
        return result;
    }
}