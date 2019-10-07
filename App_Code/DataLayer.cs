using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Text;


/// <summary>
/// DataLayer 的摘要描述
/// </summary>
public class DataLayer
{
    readonly SqlConnection _connection;

    #region "建構子"
    /// <summary>
    /// 建構子，預設使用web.config裡連線字串名稱為ConnectionString
    /// </summary>
    public DataLayer()
    {
        _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    }
    /// <summary>
    /// 建構子，傳入SqlConnection物件
    /// </summary>
    /// <param name="conn">傳入SqlConnection物件</param>
    public DataLayer(SqlConnection conn)
    {
        _connection = conn;
    }
    /// <summary>
    /// 建構子，傳入連線字串
    /// </summary>
    /// <param name="connectionString"></param>
    public DataLayer(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }
    #endregion

    #region "登入"
    /// <summary>
    /// 登入
    /// </summary>
    /// <param name="account">帳號</param>
    /// <param name="password">密碼</param>
    /// <returns></returns>
    public DataRow Login(string account, string password)
    {
        password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/Login.sql"));

        //實做連線和命令字串
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@account", SqlDbType.NVarChar, 50);
        sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar, 50);
        sqlCommand.Parameters["@account"].Value = account;
        sqlCommand.Parameters["@password"].Value = password;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));

        return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

    }
    #endregion

    #region "會員登入"
    /// <summary>
    /// 會員登入
    /// </summary>
    /// <param name="username">帳號</param>
    /// <param name="password">密碼</param>
    /// <returns></returns>
    public DataRow CLogin(string username, string password)
    {
        password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/CLogin.sql"));

        //實做連線和命令字串
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar, 50);
        sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar, 50);
        sqlCommand.Parameters["@username"].Value = username;
        sqlCommand.Parameters["@password"].Value = password;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));

        return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

    }
    #endregion


    #region "後台動態發布系統列表"

    /// <summary>
    /// 後台動態發布系統列表
    /// </summary>
    /// <param name="moduleId">moduleID</param>
    /// <param name="orgId">機關編號</param>
    /// <param name="pClassId">第一層編號</param>
    /// <param name="title">標題關鍵字</param>
    /// <param name="sortMethed">排序方式</param>
    /// <param name="litimDate">是否顯示開始時間與結束時間</param>
    /// <param name="pageSize">一頁幾筆</param>
    /// <param name="currentPage">第幾頁</param>
    /// <returns>DataTable</returns>
    public DataTable GetPublishList(string moduleId, string orgId, string pClassId, string title, string poster, SortMethed sortMethed, bool litimDate, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetPublishList.sql"));
        if (litimDate) //顯示開始時間與結束時間
        {
            commandString = commandString.Replace("where 1=1", "where 1=1 AND (GetDate() Between startDate AND DATEADD(DAY,1,endDate))");
        }
        if (sortMethed == SortMethed.OrderBylistNum) //排序方式
        {
            commandString = commandString.Replace("ORDER BY ModulePublish.initDate desc", "ORDER BY ModulePublish.listNum asc");
        }
        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(moduleId))
        {
            searchString += " and  ModulePublish.moduleID=@moduleID ";
        }
        if (!string.IsNullOrEmpty(orgId))
        {
            searchString += " and  CHARINDEX(@orgID,ModulePublish.OrgID)<>0 ";
        }
        if (!string.IsNullOrEmpty(pClassId))
        {
            searchString += " and  ModulePublish.classID=@pClassID ";
        }
        if (!string.IsNullOrEmpty(title))
        {
            searchString += " and (ModulePublish.[title] LIKE '%' + @title + '%') "; ;
        }
        if (!string.IsNullOrEmpty(poster))
        {
            searchString += " and  ModulePublish.poster=@poster ";
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleId;
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;
        sqlCommand.Parameters.Add("@orgID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@orgID"].Value = orgId;
        sqlCommand.Parameters.Add("@pclassID", SqlDbType.NVarChar, 10);
        sqlCommand.Parameters["@pclassID"].Value = pClassId;
        sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar);
        sqlCommand.Parameters["@title"].Value = title;
        sqlCommand.Parameters.Add("@poster", SqlDbType.NVarChar);
        sqlCommand.Parameters["@poster"].Value = poster;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetPublishListCount(string moduleId, string orgId, string pClassId, string title, string poster, SortMethed sortMethed, bool litimDate)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetPublishListCount.sql"));
        if (litimDate) //顯示開始時間與結束時間
        {
            commandString = commandString.Replace("where 1=1", "where 1=1 AND (GetDate() Between startDate AND DATEADD(DAY,1,endDate))");
        }
        if (sortMethed == SortMethed.OrderBylistNum) //排序方式
        {
            commandString = commandString.Replace("ORDER BY ModulePublish.initDate desc", "ORDER BY ModulePublish.listNum asc");
        }

        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(moduleId))
        {
            searchString += " and  ModulePublish.moduleID=@moduleID ";
        }
        if (!string.IsNullOrEmpty(orgId))
        {
            searchString += " and  CHARINDEX(@orgID,ModulePublish.OrgID)<>0 ";
        }
        if (!string.IsNullOrEmpty(pClassId))
        {
            searchString += " and  ModulePublish.classID=@pClassID ";
        }
        if (!string.IsNullOrEmpty(title))
        {
            searchString += " and ([title] LIKE '%' + @title + '%') "; ;
        }
        if (!string.IsNullOrEmpty(poster))
        {
            searchString += " and  ModulePublish.poster=@poster ";
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleId;
        sqlCommand.Parameters.Add("@orgID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@orgID"].Value = orgId;
        sqlCommand.Parameters.Add("@pclassID", SqlDbType.NVarChar, 10);
        sqlCommand.Parameters["@pclassID"].Value = pClassId;
        sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar);
        sqlCommand.Parameters["@title"].Value = title;
        sqlCommand.Parameters.Add("@poster", SqlDbType.NVarChar);
        sqlCommand.Parameters["@poster"].Value = poster;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }

    public enum SortMethed
    {
        OrderByInitDate,
        OrderBylistNum,
        OrderByCounts
    }

    #endregion

    #region " 取得單獨設定權限的人與角色列表，不含屬於角色的人"
    /// <summary>
    /// 取得單獨設定權限的人與角色列表，不含屬於角色的人
    /// </summary>
    /// <returns>取得單獨設定權限的人與角色列表</returns>
    public DataTable GetPermissionList()
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetAccountAndRoleList.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //sqlCommand.Parameters.Add("@organization", SqlDbType.NVarChar, 10);
        //sqlCommand.Parameters["@organization"].Value = organization;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得所屬群組列表"
    /// <summary>
    /// 取得所屬群組列表
    /// </summary>
    /// <returns>取得單獨設定權限的人與角色列表</returns>
    public DataTable GetRoleMapAccount(string RoleID)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetRoleMapAccount.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@roleID", SqlDbType.Int);
        sqlCommand.Parameters["@roleID"].Value = RoleID;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得屬於哪一些群組"
    /// <summary>
    /// 取得所屬群組列表
    /// </summary>
    /// <returns>取得單獨設定權限的人與角色列表</returns>
    public DataTable GetRoleByAccount(string account)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetRoleByAccount.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@account", SqlDbType.NVarChar);
        sqlCommand.Parameters["@account"].Value = account;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得挑群組人員資料"
    /// <summary>
    /// 取得所屬群組列表
    /// </summary>
    /// <returns>取得單獨設定權限的人與角色列表</returns>
    public DataTable GetSelectRoleUser(string RoleID)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetSelectRoleUser.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@roleID", SqlDbType.Int);
        sqlCommand.Parameters["@roleID"].Value = RoleID;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得權限字串"
    /// <summary>
    /// 取得權限字串
    /// </summary>
    /// <param name="userID">userID</param>
    /// <returns>string</returns>
    public string GetPermissionStringByID(string userID)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetPermissionStringByID.SQL"));
        //搜尋字串
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@userID", SqlDbType.Int);
        sqlCommand.Parameters["@userID"].Value = userID;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        StringBuilder PermissionString = new StringBuilder();
        //找出不重覆權限加入PermissionString
        foreach (DataRow row in dataTable.Rows)
        {
            string[] arrTemp = row["permission"].ToString().Split(',');
            foreach (string perm in arrTemp)
            {
                if (PermissionString.ToString().IndexOf(perm) == -1)
                {
                    PermissionString.Append(perm + ",");
                }
            }
        }


        return PermissionString.ToString();
    }
    #endregion

    #region "動態消息點閱數+1"
    public void ModulePublish_UpdateCountsPlus(string ID)
    {
        SqlCommand myCommand = new SqlCommand("ModulePublish_UpdateCountsPlus", _connection);
        //宣告命令型態為StoredProcedure
        myCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter parameterUserName = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
        parameterUserName.Value = ID;
        myCommand.Parameters.Add(parameterUserName);
        _connection.Open();
        myCommand.ExecuteNonQuery();
        _connection.Close();




    }
    #endregion

    #region "產品點閱數+1"
    public void Products_UpdateCountsPlus(string ID)
    {
        SqlCommand myCommand = new SqlCommand("Products_UpdateCountsPlus", _connection);
        //宣告命令型態為StoredProcedure
        myCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter parameterUserName = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
        parameterUserName.Value = ID;
        myCommand.Parameters.Add(parameterUserName);
        _connection.Open();
        myCommand.ExecuteNonQuery();
        _connection.Close();




    }
    #endregion

    #region "取得客戶列表"
    public DataTable GetCustomerList(string search, string roleType, int pageSize, int currentPage)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetCustomerList.sql"));
        //搜尋字串
        string searchString = "and Enable=1";

        if (!string.IsNullOrEmpty(search))
        {
            searchString += " and ([name]+[city] LIKE '%' + @search + '%') "; ;
        }

        if (roleType != "-1")
        {
            searchString += " and roleType = @roleType ";
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);

        //處理參數

        sqlCommand.Parameters.Add("@search", SqlDbType.NVarChar);
        sqlCommand.Parameters["@search"].Value = search;
        sqlCommand.Parameters.Add("@roleType", SqlDbType.NVarChar);
        sqlCommand.Parameters["@roleType"].Value = roleType;

        //分頁用
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    public int GetCustomerListCount(string search, string roleType)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetCustomerListCount.sql"));


        //搜尋字串
        string searchString = "and Enable=1";

        if (!string.IsNullOrEmpty(search))
        {
            searchString += " and ([name]+[city] LIKE '%' + @search + '%') "; ;
        }
        if (roleType != "-1")
        {
            searchString += " and roleType = @roleType ";
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);

        //處理參數
        sqlCommand.Parameters.Add("@search", SqlDbType.NVarChar);
        sqlCommand.Parameters["@search"].Value = search;
        sqlCommand.Parameters.Add("@roleType", SqlDbType.NVarChar);
        sqlCommand.Parameters["@roleType"].Value = roleType;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }
    #endregion


    #region "取得類別列表"
    public DataTable GetClassList(string moduleID, string search, int pageSize, int currentPage)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetClassList.sql"));
        //搜尋字串
        string searchString = "and eable = 1";

        if (moduleID != "-1")
        {
            searchString += " and moduleID = @moduleID ";
        }
        if (!string.IsNullOrEmpty(search))
        {
            searchString += " and ([className] LIKE '%' + @search + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);

        //處理參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleID;

        sqlCommand.Parameters.Add("@search", SqlDbType.NVarChar);
        sqlCommand.Parameters["@search"].Value = search;


        //分頁用
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    public int GetClassListCount(string moduleID, string search)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetClassListCount.sql"));


        //搜尋字串
        string searchString = "and eable = 1";

        if (moduleID != "-1")
        {
            searchString += " and moduleID = @moduleID ";
        }

        if (!string.IsNullOrEmpty(search))
        {
            searchString += " and ([className] LIKE '%' + @search + '%') "; ;
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);

        //處理參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleID;

        sqlCommand.Parameters.Add("@search", SqlDbType.NVarChar);
        sqlCommand.Parameters["@search"].Value = search;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }
    #endregion


    #region "產品發布系統列表"

    /// <summary>
    /// 後台動態發布系統列表
    /// </summary>
    /// <param name="moduleId">moduleID</param>
    /// <param name="orgId">機關編號</param>
    /// <param name="pClassId">第一層編號</param>
    /// <param name="title">標題關鍵字</param>
    /// <param name="sortMethed">排序方式</param>
    /// <param name="litimDate">是否顯示開始時間與結束時間</param>
    /// <param name="pageSize">一頁幾筆</param>
    /// <param name="currentPage">第幾頁</param>
    /// <returns>DataTable</returns>
    public DataTable GetMasterProductsList(string moduleId, string classID, string subject, bool IsShowEnable, SortMethed sortMethed, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetMasterProductsList.sql"));
        if (IsShowEnable) //顯示只顯示上架產品
        {
            commandString = commandString.Replace("where 1=1", "where 1=1 AND Products.enable=1");
        }
        if (sortMethed == SortMethed.OrderByCounts) //排序方式
        {
            commandString = commandString.Replace("ORDER BY Products.initDate desc", "ORDER BY Products.counts desc");
        }
       
        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(moduleId))
        {
            searchString += " and  Products.moduleID=@moduleID ";
        }

        if (!string.IsNullOrEmpty(classID))
        {
            searchString += " and  Products.classID=@classID ";
        }
        if (!string.IsNullOrEmpty(subject))
        {
            searchString += " and (Products.[subject] LIKE '%' + @subject + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleId;
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;

        sqlCommand.Parameters.Add("@classID", SqlDbType.NVarChar, 10);
        sqlCommand.Parameters["@classID"].Value = classID;
        sqlCommand.Parameters.Add("@subject", SqlDbType.NVarChar);
        sqlCommand.Parameters["@subject"].Value = subject;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetMasterProductsCount(string moduleId, string classID, string subject, bool IsShowEnable)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetMasterProductsCount.sql"));
        if (IsShowEnable) //顯示只顯示上架產品
        {
            commandString = commandString.Replace("where 1=1", "where 1=1 AND Products.enable=1");
        }

        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(moduleId))
        {
            searchString += " and  Products.moduleID=@moduleID ";
        }

        if (!string.IsNullOrEmpty(classID))
        {
            searchString += " and  Products.classID=@classID ";
        }
        if (!string.IsNullOrEmpty(subject))
        {
            searchString += " and (Products.[subject] LIKE '%' + @subject + '%') "; ;
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleId;
        sqlCommand.Parameters.Add("@classID", SqlDbType.NVarChar, 10);
        sqlCommand.Parameters["@classID"].Value = classID;
        sqlCommand.Parameters.Add("@subject", SqlDbType.NVarChar);
        sqlCommand.Parameters["@subject"].Value = subject;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }

    

    #endregion

    #region "訂單列表"

    /// <summary>
    /// 訂單列表
    /// </summary>
    /// <param name="moduleId">moduleID</param>
    /// <param name="orgId">機關編號</param>
    /// <param name="pClassId">第一層編號</param>
    /// <param name="title">標題關鍵字</param>
    /// <param name="sortMethed">排序方式</param>
    /// <param name="litimDate">是否顯示開始時間與結束時間</param>
    /// <param name="pageSize">一頁幾筆</param>
    /// <param name="currentPage">第幾頁</param>
    /// <returns>DataTable</returns>
    public DataTable GetOrderList(string moduleId, string id, string orderProcess, string orderUserName, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetOrderList.sql"));
      

        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(moduleId))
        {
            searchString += " and moduleID=@moduleID ";
        }

        if (orderProcess != "全部")
        {
            searchString += " and  orderProcess=@orderProcess ";
        }
        if (!string.IsNullOrEmpty(id))
        {
            searchString += " and  id=@id ";
        }
        if (!string.IsNullOrEmpty(orderUserName))
        {
            searchString += " and (orderUserName LIKE '%' + @orderUserName + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleId;
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;

        sqlCommand.Parameters.Add("@orderProcess", SqlDbType.NVarChar, 10);
        sqlCommand.Parameters["@orderProcess"].Value = orderProcess;

        sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@id"].Value = id.Trim('0');

        sqlCommand.Parameters.Add("@orderUserName", SqlDbType.NVarChar);
        sqlCommand.Parameters["@orderUserName"].Value = orderUserName;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetOrderCount(string moduleId, string id, string orderProcess, string orderUserName)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetOrderCount.sql"));
       

        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(moduleId))
        {
            searchString += " and moduleID=@moduleID ";
        }

        if (orderProcess != "全部")
        {
            searchString += " and  orderProcess=@orderProcess ";
        }
        if (!string.IsNullOrEmpty(id))
        {
            searchString += " and  id=@id ";
        }
        if (!string.IsNullOrEmpty(orderUserName))
        {
            searchString += " and (orderUserName LIKE '%' + @orderUserName + '%') "; ;
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleId;

        sqlCommand.Parameters.Add("@orderProcess", SqlDbType.NVarChar, 10);
        sqlCommand.Parameters["@orderProcess"].Value = orderProcess;

        sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@id"].Value = id.Trim('0');

        sqlCommand.Parameters.Add("@orderUserName", SqlDbType.NVarChar);
        sqlCommand.Parameters["@orderUserName"].Value = orderUserName;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }



    #endregion

    #region "後台聯絡我們回覆系統"

    /// <summary>
    /// 後台聯絡我們回覆系統
    /// </summary>
    /// <param name="isReply">是否回覆</param>
    /// <param name="pageSize">一頁幾筆</param>
    /// <param name="currentPage">第幾頁</param>
    /// <returns>DataTable</returns>
    public DataTable GetContactList(string isReply, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetContactList.sql"));

        //搜尋字串
        string searchString = "";

        if (isReply != "-1")
        {
            searchString += " and isReply = @isReply ";
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@isReply", SqlDbType.NVarChar);
        sqlCommand.Parameters["@isReply"].Value = isReply;
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetContactListCount(string isReply)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetContactListCount.sql"));


        //搜尋字串
        string searchString = "";
        if (isReply != "-1")
        {
            searchString += " and isReply = @isReply ";
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@isReply", SqlDbType.NVarChar);
        sqlCommand.Parameters["@isReply"].Value = isReply;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }


    #endregion

    #region "收入資料系統"

    /// <summary>
    /// 收入資料系統
    /// </summary>
    /// <param name="enable">是否回覆</param>
    /// <param name="strOrderBy"> </param>
    /// <param name="pageSize">一頁幾筆</param>
    /// <param name="currentPage">第幾頁</param>
    /// <param name="customerId">客戶ID </param>
    /// <param name="startDate">開始日期 </param>
    /// <param name="endDate">結束日期 </param>
    /// <returns>DataTable</returns>
    public DataTable GetInputDataList(string enable, string customerId,string startDate, string endDate, string strOrderBy, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetInputDataList.sql"));

        //搜尋字串
        string searchString = "";

        if (enable != "")
        {
            searchString += " and enable = @enable ";
        }
        if (customerId != "")
        {
            searchString += " and customerID = @customerID ";
        }
        if(strOrderBy!="")
        {
            commandString = commandString.Replace("ORDER BY InputData.initDate desc", strOrderBy);
        }

        if ((!string.IsNullOrEmpty(startDate)) && (!string.IsNullOrEmpty(endDate)))
        {
            searchString += " and (payDate between @startDate and @endDate)";
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@enable", SqlDbType.NVarChar);
        sqlCommand.Parameters["@enable"].Value = enable;
        sqlCommand.Parameters.Add("@customerID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@customerID"].Value = customerId;
        sqlCommand.Parameters.Add("@startDate", SqlDbType.NVarChar, 20);
        sqlCommand.Parameters.Add("@endDate", SqlDbType.NVarChar, 20);
        sqlCommand.Parameters["@startDate"].Value = startDate;
        sqlCommand.Parameters["@endDate"].Value = endDate;

        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetInputDataListCount(string enable, string customerId,string startDate, string endDate)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetInputDataListCount.sql"));


        //搜尋字串
        string searchString = "";
        if (enable != "")
        {
            searchString += " and enable = @enable ";
        }
        if (customerId != "")
        {
            searchString += " and customerID = @customerID ";
        }
        if ((!string.IsNullOrEmpty(startDate)) && (!string.IsNullOrEmpty(endDate)))
        {
            searchString += " and (payDate between @startDate and @endDate)";
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@enable", SqlDbType.NVarChar);
        sqlCommand.Parameters["@enable"].Value = enable;
        sqlCommand.Parameters.Add("@customerID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@customerID"].Value = customerId;
        sqlCommand.Parameters.Add("@startDate", SqlDbType.NVarChar, 20);
        sqlCommand.Parameters.Add("@endDate", SqlDbType.NVarChar, 20);
        sqlCommand.Parameters["@startDate"].Value = startDate;
        sqlCommand.Parameters["@endDate"].Value = endDate;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }


    #endregion

    #region "活動支出系統"

    /// <summary>
    /// 活動支出系統
    /// </summary>
    /// <param name="enable">是否回覆</param>
    /// <param name="pageSize">一頁幾筆</param>
    /// <param name="currentPage">第幾頁</param>
    /// <returns>DataTable</returns>
    public DataTable GetOutputDateList(string subject, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetOutputDateList.sql"));

        //搜尋字串
        string searchString = "";

        if (!string.IsNullOrEmpty(subject))
        {
            searchString += " and (subject LIKE '%' + @title + '%') "; ;
        }

      

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@subject", SqlDbType.NVarChar);
        sqlCommand.Parameters["@subject"].Value = subject;
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetOutputDateListCount(string subject)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetOutputDateListCount.sql"));


        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(subject))
        {
            searchString += " and (subject LIKE '%' + @title + '%') "; ;
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@subject", SqlDbType.NVarChar);
        sqlCommand.Parameters["@subject"].Value = subject;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }


    #endregion

    #region "活動支出系統"

    /// <summary>
    /// 活動支出系統
    /// </summary>
    /// <param name="enable">是否回覆</param>
    /// <param name="pageSize">一頁幾筆</param>
    /// <param name="currentPage">第幾頁</param>
    /// <returns>DataTable</returns>
    public DataRow GetInOutcoco()
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetInOutcoco.sql"));

       
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
      
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
    }


    #endregion

}