SELECT     Member.id, Member.account, Member.name, Member.email, Member.permission, UnitName.title AS Organization
FROM         Member LEFT OUTER JOIN
                      UnitName ON Member.OrganizationID = UnitName.id
WHERE     (Member.id NOT IN
                          (SELECT     userID
                            FROM          RoleUserMapping
                            WHERE      (roleID = @roleID)))