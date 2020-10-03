# FPF
Projeto para ser avaliado pela equipe técnica 

Pré-requisitos:
Visual Studio 2017 +
Banco de Dados Oracle (Fiz aqui no Oracle Database 18c Express Edition) Disponível em : https://download.oracle.com/otn/nt/oracle18c/180000/OracleXE184_Win64.zip
ODT for VS2019 Disponível em : https://download.oracle.com/otn/other/ole-oo4o/ODTforVS2019_193100.zip


Passos para execução do projeto:

1- Baixar o projeto no endereço : https://github.com/felipe-nascimento-homework/FPF.git

2- Com o usuário SYSTEM do banco de dados, criar o usuário FPF.

             CREATE USER FPF IDENTIFIED BY 123;
             GRANT CREATE SESSION TO FPF;
             ALTER USER FPF quota 100M on USERS;

3 - Abrir a pasta VagaFPF e iniciar o projeto pelo arquivo VagaFPF.sln

4 - Checar se o Nuget baixou as dependências do projeto.
- EntityFramework v6.4.4
- Oracle.ManagedDataAcess v19.9.0
- Oracle.ManagedDataAccess.EntityFramework by Oracle v1.6.0

5 - Ir no arquivo Web.config e atualizar o login e a senha caso necessário.
procurar a tag string de conexão do banco de dados.
Colocar no campo "User Id=" O login com previlegios para criar tabelas e executar procedimentos.
No campo "Password" colocar as senha.
No campo "Data Source=localhost/XEPDB1:1521" colocar o nome da instância do banco instalado em sua maquina no caso do Oracle Database 18c Express Edition o nome da instância do banco é : XEPDB1
Salve as alterações.

Exemplo :

  <connectionStrings>
    <add name="OracleDbContext" providerName="Oracle.ManagedDataAccess.Client" connectionString="User Id=SYSTEM;Password=123;Data Source=localhost/XEPDB1:1521/;PERSIST SECURITY INFO=True;USER ID=SYSTEM" />
  </connectionStrings>


6 - Vá na pasta Migration do projeto e verifique se o arquivo 202010020228217_Criacao_do_banco.cs existe no projeto.
6.1 - Caso não exista execute o passo 7 com o comando no prompt "Add-Migration Criacao_do_banco"

7 - Vá em Tools -> Nuget Package Manager -> Package Manager Console o sistema irá abrir um terminal do Nuget.
7.1 - Execute o comando no prompt do Nuget "Update-Database" 

8 -  Verifique se o banco foi criado e se existes as tabelas no usuario FPF.
  - employee
  - rule
  
9 - casos as tabelas existam build e execute o projeto no visual studio.


Observações:
Não e necessário script do DDL do banco de dados para criar as tabelas.
O Projeto usa o conceito de Code Fist EntityFramework e o migration cria os scripts das alterações.







