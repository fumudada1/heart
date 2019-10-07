
SELECT    count(*)
FROM          ModuleClass RIGHT OUTER JOIN
                      ModulePublish ON ModuleClass.id = ModulePublish.classID
--where 1=1 and  CHARINDEX('383132600C',ModulePublish.OrgID)<>0 and classID like 'C01%' and classID='C0101' and title like '%最新%'
where 1=1

/*--where begin --*/

/*--where End--*/