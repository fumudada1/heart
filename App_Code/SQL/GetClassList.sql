WITH ClassData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

select ROW_NUMBER() OVER(ORDER BY listNum ASC) AS RowNumber,* from dbo.ModuleClass 

where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from ClassData WHERE RowNumber >=@start  and RowNumber <=@end

