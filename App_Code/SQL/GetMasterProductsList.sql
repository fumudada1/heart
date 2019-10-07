WITH MasterProductsData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY Products.initDate desc) AS RowNumber
,ModuleClass.className, Masters.cName, Products.*
FROM         Products INNER JOIN
                      ModuleClass ON Products.classID = ModuleClass.id INNER JOIN
                      Masters ON ModuleClass.masterID = Masters.id
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from MasterProductsData WHERE RowNumber >=@start  and RowNumber <=@end