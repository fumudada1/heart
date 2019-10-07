SELECT    count(*)
FROM         Products INNER JOIN
                      ModuleClass ON Products.classID = ModuleClass.id INNER JOIN
                      Masters ON ModuleClass.masterID = Masters.id
where 1=1

/*--where begin --*/

/*--where End--*/