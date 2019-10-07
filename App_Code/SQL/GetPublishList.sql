WITH ModulePublishData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY ModulePublish.initDate desc) AS RowNumber
,ModulePublish.id, ModulePublish.version, ModulePublish.moduleID, ModulePublish.OrgID, ModulePublish.classID, ModulePublish.title, ModulePublish.picUrl, 
                      ModulePublish.fileUrl, ModulePublish.linkUrl, ModulePublish.linkTarget, ModulePublish.linkText, ModulePublish.shortDescription, ModulePublish.poster, 
                      ModulePublish.posterUnit, ModulePublish.updater, ModulePublish.updaterUnit, ModulePublish.initDate, ModulePublish.lastupdated, ModulePublish.startDate, 
                      ModulePublish.endDate, ModulePublish.counts, ModulePublish.listNum, ModulePublish.enable, ModulePublish.beSelect, ModulePublish.status, 
                      ModuleClass.className, UnitName.title AS OrgNames,
					  (select top 1 picUrl from ModulePictures where publishID=ModulePublish.id order by listNum) as Top1Pic
FROM         UnitName RIGHT OUTER JOIN
                      ModulePublish ON UnitName.id = ModulePublish.OrgID LEFT OUTER JOIN
                      ModuleClass ON ModulePublish.classID = ModuleClass.id
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from ModulePublishData WHERE RowNumber >=@start  and RowNumber <=@end
