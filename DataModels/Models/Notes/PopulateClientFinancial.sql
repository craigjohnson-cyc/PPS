insert into dbo.clientFinancial (id,AccountNumber, Balance, BankName, CoSigner, Statement, AccountType, ClientKey)
select 1,chkacct1, chkbal1, chkbank1,chkcosign1,chkstmt1,'Checking', Client_key from [Learn1].[dbo].[clients] where client_key = 1
go
insert into dbo.clientFinancial (id,AccountNumber, Balance, BankName, CoSigner, Statement, AccountType, ClientKey)
select 2,chkacct2, chkbal2, chkbank2,chkcosign2,chkstmt2,'Checking', Client_key from [Learn1].[dbo].[clients] where client_key = 1
go
insert into dbo.clientFinancial (id,AccountNumber, Balance, BankName, CoSigner, Statement, AccountType, ClientKey)
select 3,chkacct3, chkbal3, chkbank3,chkcosign3,chkstmt3,'Checking', Client_key from [Learn1].[dbo].[clients] where client_key = 1
go
insert into dbo.clientFinancial (id,AccountNumber, Balance, BankName, CoSigner, Statement, AccountType, ClientKey)
select 4,svaccct1, svbal1, svbank1,svcosign1,svstmt1,'Savings', Client_key from [Learn1].[dbo].[clients] where client_key = 1
go
insert into dbo.clientFinancial (id,AccountNumber, Balance, BankName, CoSigner, Statement, AccountType, ClientKey)
select 5,svaccct2, svbal2, svbank2,svcosign2,svstmt2,'Savings', Client_key from [Learn1].[dbo].[clients] where client_key = 1
go
insert into dbo.clientFinancial (id,AccountNumber, Balance, BankName, CoSigner, Statement, AccountType, ClientKey)
select 6,svaccct3, svbal3, svbank3,svcosign3,svstmt3,'Savings', Client_key from [Learn1].[dbo].[clients] where client_key = 1
go