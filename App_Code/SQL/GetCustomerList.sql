WITH CustomerData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT   ROW_NUMBER() OVER(ORDER BY initDate Desc) AS RowNumber
,*
FROM         Customer
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from CustomerData WHERE RowNumber >=@start  and RowNumber <=@end
