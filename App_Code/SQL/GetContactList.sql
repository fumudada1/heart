WITH ContactData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY Contact.initDate desc) AS RowNumber
,Contact.*
FROM         Contact 
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from ContactData WHERE RowNumber >=@start  and RowNumber <=@end
