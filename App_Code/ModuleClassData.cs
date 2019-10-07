using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using TIN;

/// <summary>
/// ModuleClass 的摘要描述
/// </summary>
public class ModuleClassData
{
	static public string[] GetClassNames(int classId)
	{
        EasyDataProvide ModuleClass = new EasyDataProvide("ModuleClass");
        DataTable dtClass = ModuleClass.GetAllData();
        string[] classNames = new string[3];
       
        DataView dv3 = new DataView(dtClass);
        dv3.RowFilter = "id=" + classId;

        if (dv3.Count > 0)
        {
            classNames[2] = dv3[0]["className"].ToString();
            DataView dv2 = new DataView(dtClass);
            dv2.RowFilter = "id=" + dv3[0]["parentID"].ToString();
            if (dv2.Count > 0)
            {
                classNames[1] = dv2[0]["className"].ToString();
                DataView dv1 = new DataView(dtClass);
                dv1.RowFilter = "id=" + dv2[0]["parentID"].ToString();
                if (dv1.Count > 0)
                {

                    classNames[0]=dv1[0]["className"].ToString();
                }
            }

            

        }

	    return classNames;

	}

    static public string[] GetClassValue(int classId)
    {
        EasyDataProvide ModuleClass = new EasyDataProvide("ModuleClass");
        DataTable dtClass = ModuleClass.GetAllData();
        string[] classValues = new string[3];

        DataView dv3 = new DataView(dtClass);
        dv3.RowFilter = "id=" + classId;

        if (dv3.Count > 0)
        {
            classValues[2] = dv3[0]["id"].ToString();
            DataView dv2 = new DataView(dtClass);
            dv2.RowFilter = "id=" + dv3[0]["parentID"].ToString();
            if (dv2.Count > 0)
            {
                classValues[1] = dv2[0]["id"].ToString();
                DataView dv1 = new DataView(dtClass);
                dv1.RowFilter = "id=" + dv2[0]["parentID"].ToString();
                if (dv1.Count > 0)
                {

                    classValues[0] = dv1[0]["id"].ToString();
                }
            }



        }

        return classValues;

    }
}