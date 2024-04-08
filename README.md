# Projeto To Do AM4

Esse projeto é um desafio onde desenvolvi um To Do simplificado

## O que foi utilizado no backend?

- .Net(C#)
- Entity Framework
- SqlServer

## Sobre a API

- A API de Lista de Tarefas é uma aplicação escalável projetada para gerenciar tarefas de forma eficiente. Ela segue as melhores práticas de desenvolvimento, incluindo conceitos fundamentais de DDD, DTO, Interfaces, Repositórios, padrões de design e código limpo para garantir uma arquitetura sólida e de fácil manutenção.

## Pacotes usados Backend

- Microsoft.EntityFrameworkCore 6.0.28
- Microsoft.EntityFrameworkCore.SqlServer 6.0.28
- Microsoft.EntityFrameworkCore.Tools 6.0.28
- AutoMapper 13.0.1

## O que foi utilizado no Frontend?

- Html
- JavaScript
- JQuery
- BootStrap

## Extensões usadas Frontend

- Code Time
- Live Server

## Como rodar o projeto?

Ao abrir o código, é importante mudar o link da ConnectionString do banco da dados que está localizado na "appsettings.json" na camada da API

Após isso crie um banco de dados através da migration usando o comando abaixo no Package-Manager:

```
  Update-Database
```

A porta da API é 7226

Após criar o banco, basta executar o projeto da API(Am4ToDo.Api) e em seguida o projeto que está consumindo a ela(AM4.Desafios).

## Documentação da API

#### Retorna todos as tarefas

```http
  GET api/TaskToDo
```

#### Retorna uma tarefa

```http
  GET /api/TaskToDo/${id}
```

| Parâmetro   | Tipo     | Descrição                                         |
| :---------- | :------- | :------------------------------------------------ |
| `id`        | `int`    | **Obrigatório**. O ID da tarefa que você quer.    |

#### Adiciona uma tarefa

```http
  POST /api/TaskToDo

```

| Parâmetro   | Tipo     | Descrição                                                                                             |
| :---------- | :------- | :-----------------------------------------                                                            |
| `name`      | `string` | **Obrigatório**. É preciso passar no Body.                                                            |
| `taskState` | `enum` | **Obrigatório**. Envie no body "0" caso precise criar como a fazer e "1" caso precise criar como feita. |

#### Altera uma tarefa

```http
  PUT /api/TaskToDo

```

| Parâmetro   | Tipo     | Descrição                                                                             |
| :---------- | :------- | :---------------------------------------------------------------------------------    |
| `id`        | `int`    | **Obrigatório**. É preciso passar no Body.                                            |
| `name`      | `string` | **Opcional**. É preciso passar no Body caso queira alterar.                           |
| `taskState` | `enum`   | **Opcional**. É preciso passar no Body caso queira alterar(0 = a fazer | 1 = Feito).  |

#### Deletar uma tarefa

```http
  DELETE /api/TaskToDo/{id}

```

| Parâmetro | Tipo  | Descrição                                     |
| :-------- | :---- | :-------------------------------------------- |
| `id`      | `int` | **Obrigatório**. É preciso passar no na rota. |

---

## Funcionalidades

- Criar: Tarefas
- Adicionar: Tarefas
- Editar: Tarefas
- Remover: Tarefas


## 🔗 Links

[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://github.com/gabrielbritog)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/gabriel-caetano-a06880140/)


