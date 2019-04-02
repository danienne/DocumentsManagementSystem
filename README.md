# DocumentsManagementSystem
Como rodar a aplicação<br><br>
	
Requisitos<br>
	⦁	Visual Studio 2017<br>
	⦁	 node.js<br>
	⦁	angular cli<br>
	⦁	SQL SERVER management tool<br>
	⦁	Conexão a internet para o Materialize.css funcionar<br>
	
Passo-a-Passo<br>
1.	Na sua ferramente de SQL SERVER criar uma base de dados chamada "DocumentManagementSystemDB" e criar um usuário "sa" com a senha "123456" e atribuir "db_owner" para o banco de dados criado.
2.	Abrir a solution "DocumentManagementSystem.sln" no Visual Studio.
3.	Abrir o arquivo "Web.config" dentro do projeto "DocumentManagementSystem.WebApi"
4.	Clicar com o botão direito na solution e clicar em "Restore Nuget Packages".
5.	Alterar a connectionString colocando o "Data Source" correto de sua máquina.
6.	Abrir o "Package Manager Console", selecionar o Default project "DocumentManagementSystem.Repository" e executar a seguinte linha de comando, "Update-Database".
7.	Abrir a pasta "DocumentManagementSystem\DocumentManagementSystem.WebApi\ClientApp\document-management-system\src\app", clicar com o botão direito segurando a tecla shift, clicar na opção "Abrir janela do PowerShell aqui".
8.	Após o PowerShell carregar, digitar a seguinte linha de comando : "npm start"
9.	Iniciar a aplicação no Visual Studio, ela deverá abrir no seu navegador padrão, caso o localhost não seja o seguinte "localhost:65161" favor seguir a próxima instrução, caso contrário pular para instrução 9.
10.	Abrir o documento DocumentManagementSystem.WebApi\ClientApp\document-management-system\src\environments\environment.ts" e alterar a configuração "apiUrl" para o localhost que apareceu no seu navegador ao iniciar a aplicação web api.
11.	Ir para o localhost:4200.
	
Para rodar os testes unitários, basta executar no visual studio através da opção na barra superior, "Test > Run > All Tests".
Para verificação dos logs criados entrar na seguinte pasta, "DocumentManagementSystem\DocumentManagementSystem.WebApi\LogBackUp".<br>
Isso é tudo :)
