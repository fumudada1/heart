WITH IOutputDate AS
(
/*--order by 請在程式覆蓋 ORDER BY OutputDate.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY OutputDate.initDate desc) AS RowNumber
,OutputDate.*
FROM         OutputDate 
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from IOutputDate WHERE RowNumber >=@start  and RowNumber <=@end