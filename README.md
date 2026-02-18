# 🌐 Exercícios ASP.NET — Portal de Férias

Repositório com exercícios práticos e o projeto final desenvolvidos ao longo do módulo de **ASP.NET**, inserido no curso de **Programador Informático (EFA)** ministrado pelo **CENCAL**.

O módulo abrangeu o desenvolvimento de aplicações web com ASP.NET, incluindo integração com bases de dados, design de interfaces e ferramentas avançadas como Entity Framework e Rich Text Editor.

---

## 🎓 Contexto

| | |
|---|---|
| **Curso** | Programador Informático |
| **Tipo** | Curso EFA (Educação e Formação de Adultos) |
| **Instituição** | CENCAL |
| **Módulo** | Desenvolvimento Web com ASP.NET |
| **Linguagens** | C#, HTML, CSS, JavaScript |

---

## 🛠️ Tecnologias e Ferramentas

- **ASP.NET** — Framework principal de desenvolvimento web
- **Entity Framework (EF)** — ORM para gestão e acesso a bases de dados
- **MySQL Server** — Sistema de gestão de bases de dados relacional
- **Rich Text Editor** — Editor de conteúdo rico integrado nas aplicações
- **Visual Studio** — IDE utilizado
- **HTML / CSS / JavaScript** — Frontend e design das páginas

---

## 📁 Estrutura do Repositório

O repositório está organizado em exercícios progressivos ao longo do módulo, culminando no projeto final **Portal de Férias**:

```
ExerciciosASP.net/
├── ExerciciosASP/          ← Exercícios iniciais
├── Exercicio2ASP/
├── Exercicio3ASP/
├── Exercicio4ASP/
├── Exercicio5ASP/
├── Exercicio5_1ASP/
├── Exercicio6/
├── Exercicio7ASP/
├── Exercicio8ASP/
├── Exercicio9ASP/
├── Exercicio10ASP/
├── Exercicio11ASP/
├── Exercicio12ASP/
├── Exercicio13ASP/
├── Exercicio14ASP/
│
└── PortalFerias/           ⭐ Projeto Final — Teste de Módulo
```

---

## ⭐ Projeto Final — Portal de Férias

O **Portal de Férias** é o projeto de avaliação final do módulo, desenvolvido para consolidar todos os conhecimentos adquiridos ao longo das aulas. Trata-se de uma aplicação web completa que integra:

- Gestão de conteúdos com **Rich Text Editor**
- Ligação e operações CRUD com base de dados **MySQL** via **Entity Framework**
- Design e interface de utilizador com **HTML, CSS e JavaScript**
- Arquitetura **ASP.NET** com separação de responsabilidades

---

## ▶️ Como Executar

### Pré-requisitos

- [Visual Studio](https://visualstudio.microsoft.com/) com suporte a ASP.NET
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) instalado e em execução
- .NET SDK instalado

### Passos

1. Clona o repositório:
   ```bash
   git clone https://github.com/brunomsmcarvalho/ExerciciosASP.net.git
   ```

2. Abre o ficheiro `ExerciciosASP.slnx` no **Visual Studio**.

3. Configura a string de ligação à base de dados no ficheiro `appsettings.json` (ou `web.config`) do projeto pretendido.

4. Aplica as migrações do Entity Framework (se aplicável):
   ```bash
   dotnet ef database update
   ```

5. Seleciona o projeto e executa com `F5` ou **Run**.

---

## 👤 Autor

**Bruno Carvalho**  
Formando no Curso EFA de Programador Informático — CENCAL  
[GitHub](https://github.com/brunomsmcarvalho)

---

> *Repositório de aprendizagem desenvolvido no âmbito da formação profissional.*
