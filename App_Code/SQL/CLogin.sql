/* 登入用，輸入帳號密碼回傳 使用者單位 個人資料與權限等資料 */
SELECT     *
FROM         Customer
WHERE     (username = @username) AND (password = @password)

/*--where begin --*/

/*--where End--*/

/*--order by begin--*/

/*--order by begin--*/