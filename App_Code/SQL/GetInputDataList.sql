WITH IInputData AS
(
/*--order by 請在程式覆蓋 ORDER BY InputData.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY InputData.initDate desc) AS RowNumber
,InputData.*
FROM         InputData 
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from IInputData WHERE RowNumber >=@start  and RowNumber <=@end