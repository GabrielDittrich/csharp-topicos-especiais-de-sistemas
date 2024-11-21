# CSharp - Tópicos Especiais de Sistemas

Este repositório contém os projetos desenvolvidos na disciplina **Tópicos Especiais de Sistemas**, que combina tecnologias modernas para o desenvolvimento de aplicações web full stack.

## 🛠️ Tecnologias Utilizadas

### Backend:
- **C#**: Linguagem de programação utilizada para desenvolver a API.
- **Entity Framework**: Framework ORM para interação com o banco de dados.
- **Swagger**: Ferramenta para documentação e teste da API.
- **MySQL**: Banco de dados utilizado para armazenar informações.

### Frontend:
- **React**: Biblioteca JavaScript para criação de interfaces dinâmicas.
- **Axios**: Cliente HTTP utilizado para consumir a API.

## 🔧 Estrutura do Projeto

### Backend
O backend foi desenvolvido com C# e utiliza o Entity Framework para abstração de banco de dados. A documentação da API pode ser acessada via Swagger.

### Frontend
O frontend foi desenvolvido em React, com Axios para realizar requisições HTTP ao backend. 

### Banco de Dados
O banco de dados foi modelado no **MySQL**, seguindo boas práticas de normalização para garantir eficiência no armazenamento e recuperação dos dados.

## 🚀 Como Executar o Projeto

### Pré-requisitos
Certifique-se de ter as seguintes ferramentas instaladas:
- **Node.js** (para rodar o React)
- **.NET SDK** (para rodar a API)
- **MySQL** (para o banco de dados)

### Passos
1. Clone este repositório:
   git clone https://github.com/seu-usuario/csharp-topicos-especiais-de-sistemas.git
2. Configure o banco de dados no MySQL e atualize as strings de conexão no backend.
3. Navegue até a pasta do backend e rode a API: </br>
 - cd backend </br>
 - dotnet run
4. Navegue até a pasta do frontend e inicie o React <br>
- cd frontend
- npm install
- npm start
5. Acesse a aplicação no navegador:
- Frontend: http://localhost:3000
- Swagger: http://localhost:5000/swagger
