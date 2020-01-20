docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=SqlServer2017!' -p 1433:1433 -v /home/gcoppini/Projetos/sqlserver2017:/var/opt/mssql -d microsoft/mssql-server-linux:2017-latest
