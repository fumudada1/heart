SELECT         Role.Permission
FROM             RoleUserMapping INNER JOIN
                          Role ON RoleUserMapping.RoleID = Role.ID
--WHERE         (RoleUserMapping.userID = '48d7041a-4f4b-421b-9ec7-db982593ddf5')
WHERE         (RoleUserMapping.userID = @userID)
union all
Select  Permission
FROM Member
--WHERE         (RoleUserMapping.userID = '48d7041a-4f4b-421b-9ec7-db982593ddf5')
Where id=@userID