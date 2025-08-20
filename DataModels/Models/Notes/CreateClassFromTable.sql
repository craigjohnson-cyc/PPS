declare @TableName sysname = 'clientDetails'
declare @Result varchar(max) = 'public class ' + @TableName + '
{'

select @Result = @Result + '
    public ' + ColumnType + NullableSign + ' ' + ColumnName + ' { get; set; } = ' + DefaultValue
from
(
    select 
        replace(col.name, ' ', '_') ColumnName,
        column_id ColumnId,
        case typ.name 
            when 'bigint' then 'long'
            when 'binary' then 'byte[]'
            when 'bit' then 'bool'
            when 'char' then 'string'
            when 'date' then 'DateTime'
            when 'datetime' then 'DateTime'
            when 'datetime2' then 'DateTime'
            when 'datetimeoffset' then 'DateTimeOffset'
            when 'decimal' then 'decimal'
            when 'float' then 'double'
            when 'image' then 'byte[]'
            when 'int' then 'int'
            when 'money' then 'decimal'
            when 'nchar' then 'string'
            when 'ntext' then 'string'
            when 'numeric' then 'decimal'
            when 'nvarchar' then 'string'
            when 'real' then 'float'
            when 'smalldatetime' then 'DateTime'
            when 'smallint' then 'short'
            when 'smallmoney' then 'decimal'
            when 'text' then 'string'
            when 'time' then 'TimeSpan'
            when 'timestamp' then 'long'
            when 'tinyint' then 'byte'
            when 'uniqueidentifier' then 'Guid'
            when 'varbinary' then 'byte[]'
            when 'varchar' then 'string'
            else 'UNKNOWN_' + typ.name
        end ColumnType,
        case 
            when col.is_nullable = 1 and typ.name in ('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier') 
            then '?' 
            else '' 
        end NullableSign,

        replace(col.name, ' ', '_') ColumnName2,
        column_id ColumnId2,
        case typ.name 
            when 'bigint' then ' 0;'
            when 'binary' then 'byte[]'
            when 'bit' then ' false;'
            when 'char' then ' string.Empty;'
            when 'date' then ' DateTime.Now;'
            when 'datetime' then ' DateTime.Now;'
            when 'datetime2' then ' DateTime.Now;'
            when 'datetimeoffset' then 'DateTimeOffset'
            when 'decimal' then ' 0;'
            when 'float' then ' 0;'
            when 'image' then 'byte[]'
            when 'int' then ' 0;'
            when 'money' then ' 0;'
            when 'nchar' then ' string.Empty;'
            when 'ntext' then ' string.Empty;'
            when 'numeric' then ' 0;'
            when 'nvarchar' then ' string.Empty;'
            when 'real' then ' 0;'
            when 'smalldatetime' then ' DateTime.Now'
            when 'smallint' then ' 0;'
            when 'smallmoney' then ' 0;'
            when 'text' then ' string.Empty;'
            when 'time' then 'TimeSpan'
            when 'timestamp' then 'long'
            when 'tinyint' then ' 0;'
            when 'uniqueidentifier' then ' 0;'
            when 'varbinary' then 'byte[]'
            when 'varchar' then ' string.Empty;'
            else 'UNKNOWN_' + typ.name
        end DefaultValue
    from sys.columns col
        join sys.types typ on
            col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id
    where object_id = object_id(@TableName)
) t
order by ColumnId

set @Result = @Result  + '
}'

print @Result