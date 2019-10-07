SELECT     id, account, name, email, Organization, 0 AS type
FROM         Member
union all                    
Select convert(nvarchar(10),id),'角色',roleName,'',description,1
FROM Role