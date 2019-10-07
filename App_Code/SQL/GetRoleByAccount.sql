SELECT     RoleUserMapping.userID, Member.name, RoleUserMapping.roleID, Role.roleName, Member.account
FROM         Member INNER JOIN
                      RoleUserMapping ON Member.id = RoleUserMapping.userID INNER JOIN
                      Role ON RoleUserMapping.roleID = Role.id
where Member.account=@account