create database API_TasK_dec28

use API_TasK_dec28
create table crud
(
id int primary key identity(1,1),
state varchar(100),
city varchar(100),
pincode varchar(100)
)


go
create procedure sp_fetch
as begin 
select * from crud end


go
create procedure sp_insert
( @state varchar(100),
@city varchar(100),
@pincode varchar(100) ) 
as begin 
insert into crud values (@state,@city,@pincode ) end 

exec sp_insert 'Karnataka','mysore ','645435' 

go
create procedure sp_update
( @id int,
@state varchar(100),
@city varchar(100),
@pincode varchar(100) ) 
as begin 
update crud set state=@state,city=@city,pincode=@pincode where id=@id  end 


go
create procedure sp_delete
( @id int )
as begin 
delete from crud where id=@id end 


go
create procedure sp_search 
( @searchdata varchar(100) ) 
as begin
select * from crud where state like '%' + @searchdata + '%' or city like '%' + @searchdata + '%' or pincode like '%' + @searchdata + '%' or id like '%' + @searchdata + '%' end 
go
create procedure sp_fetch_id 
(@id int )
as begin 
select * from crud where id=@id end 

