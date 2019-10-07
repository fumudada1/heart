using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_PermissionUserControl : System.Web.UI.UserControl
{

    /// <summary>
    /// 取得或設定TreeView 裡設定的權限
    /// </summary>
    public string permissionString
    {
        get
        {
            //取得權限字串
            //string _permissionString = TreeView1.CheckedNodes.Cast<TreeNode>().Where(node => node.Checked).Aggregate("", (current, node) => current + (node.Value + ","));
            string _permissionString = "";
            foreach (TreeNode node in TreeView1.CheckedNodes)
            {
                if(node.Checked)
                {
                    _permissionString += node.Value+",";
                }
            }

            //去除最後一個逗號
            _permissionString = _permissionString.Trim(',');

            return _permissionString;
        }
        set
        {
            if (TreeView1.CheckedNodes.Count == 0)
            {
                XmlDataSource1.XPath = "/menu/Modules";
                TreeView1.DataSourceID = "XmlDataSource1";
                TreeView1.DataBind();


            }
            

            foreach (TreeNode node in TreeView1.Nodes)
            {
                //跑遞迴
                setTreeValue(node, value);
            }

            

        }
    }



    #region "遞迴走訪TreeView 如果有權限，打勾"
    /// <summary>
    /// 遞迴走訪TreeView 如果有權限，打勾
    /// </summary>
    /// <param name="node">TreeNode</param>
    /// <param name="value">權限字串</param>
    static void setTreeValue(TreeNode node, string value)
    {
        if (node.ShowCheckBox == true && value.IndexOf(node.Value) != -1)
        {
            node.Checked = true;
        }
        if (node.ChildNodes.Count == 0)
        {
            return;
        }
        else
        {
            foreach (TreeNode cnode in node.ChildNodes)
            {
                setTreeValue(cnode, value);
            }
        }


    }
    #endregion


    protected void TreeView1_DataBound(object sender, EventArgs e)
    {
        foreach(TreeNode node in TreeView1.Nodes)
        {
            if(node.ChildNodes.Count!=0)
            {
                node.ShowCheckBox = false;
                node.ExpandAll();
            }
        }
       
    }

    protected void btnOpen_Click(object sender, EventArgs e)
    {
        TreeView1.ExpandAll();
    }
    protected void btnClose_Click1(object sender, EventArgs e)
    {
        TreeView1.CollapseAll();
    }
}