create procedure checkUsersCredentials
(
 @Username nvarchar(50),
 @Password nvarchar(50)
)
as 
Begin
Declare @IsCredentialsCorrect bit
set @IsCredentialsCorrect = 0

if Exists (select '#' from Users where UserName=@Username and Password=@Password

select @IsCredentialsCorrect

end
