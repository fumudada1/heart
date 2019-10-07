SELECT     RoleUserMapping.id, Role.roleName, Member.account, Member.name, UnitName.title AS Organization
FROM         RoleUserMapping INNER JOIN
                      Member ON RoleUserMapping.userID = Member.id INNER JOIN
                      Role ON RoleUserMapping.roleID = Role.id LEFT OUTER JOIN
                      UnitName ON Member.OrganizationID = UnitName.id
where RoleUserMapping.roleID=@roleID