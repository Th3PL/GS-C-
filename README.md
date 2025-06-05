
# 📦 MedWay — Sistema de Suporte em Situações de Emergência

> Projeto desenvolvido como parte da disciplina de **C# (Global Solution)** na **FIAP - 2025**.

## 🚀 Descrição do Projeto

O **MedWay** é um sistema que simula um aplicativo de suporte à comunidade durante emergências, como quedas de energia e situações de risco. Ele permite que usuários acessem rapidamente:

- 🏥 **Hospitais próximos à sua localização (simulada)**
- 🩺 **Especialidades médicas disponíveis**
- 💡 **Dicas comunitárias de segurança e prevenção**
- 🚑 **Informações emergenciais importantes (Samu, Bombeiros, etc.)**
- 👤 **Visualizar informações do usuário logado (nome, idade, tipo sanguíneo, localização)**

O sistema simula geolocalização aleatória a cada login, alterando os dados apresentados de acordo com a cidade detectada.

---

## 🔧 Funcionalidades

- 🔐 **Login e cadastro de usuários** (validação de duplicidade por e-mail).
- 📍 **Localização aleatória simulada** no momento do login.
- 🏥 **Listagem de hospitais filtrados pela cidade atual.**
- 🩺 **Listagem de especialidades médicas.**
- 💡 **Dicas comunitárias de prevenção.**
- 🚑 **Informações de emergência (Samu, Bombeiros, Defesa Civil).**
- 👤 **Consulta de dados do usuário logado**, incluindo:
  - Nome
  - Idade (calculada automaticamente)
  - Tipo sanguíneo
  - Cidade e Estado (gerados aleatoriamente a cada login)

---

## 🗺️ Localizações Suportadas (Simuladas)

- São Paulo - SP
- Rio de Janeiro - RJ
- Belo Horizonte - MG
- Curitiba - PR
- Porto Alegre - RS
- Salvador - BA
- Recife - PE
- Fortaleza - CE
- Brasília - DF

---

## 🏛️ Estrutura do Projeto

```plaintext
/MedWay
│
├── /Models           → Classes de domínio (Usuario, Hospital, etc.)
├── /Repositories     → Conexão com Banco Oracle
├── /Controllers      → Lógica de controle do sistema
├── Program.cs        → Menu principal (Console)
├── README.md         → Documentação do projeto
└── script.sql        → Scripts SQL para criação das tabelas
```

---

## 💻 Tecnologias Utilizadas

- 🧠 **Linguagem:** C#
- ☁️ **Banco de Dados:** Oracle Database (FIAP)
- 🔗 **Conexão:** Oracle Managed Data Access
- 🖥️ **Interface:** Console Application (.NET)

---

## 🔗 Requisitos para Executar o Projeto

- ✔️ Oracle Database (FIAP ou local)
- ✔️ Visual Studio ou Visual Studio Code
- ✔️ .NET SDK instalado
- ✔️ Pacote NuGet:
  - `Oracle.ManagedDataAccess`

---

## 🗄️ Configuração do Banco de Dados

1. Execute o arquivo **`script.sql`** para criar as tabelas e sequences no banco Oracle.
2. Configure a **string de conexão** no arquivo `UsuarioRepository.cs` e nos outros repositories:

```csharp
private readonly string _connectionString = 
"User Id=SEU_RM;Password=SUA_SENHA;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));";
```

---

## 🚀 Como Executar o Projeto

1. Clone este repositório:
```bash
git clone https://github.com/seu-usuario/MedWay.git
```
2. Abra no Visual Studio ou Visual Studio Code.
3. Restaure os pacotes NuGet (`Oracle.ManagedDataAccess`).
4. Configure sua string de conexão com Oracle.
5. Compile e execute o projeto.

---

## 📸 Demonstração

*(Adicione aqui um print real do console após rodar o projeto)*

---

## 👨‍💻 Desenvolvido por

| Nome          | RM       |
|----------------|----------|
| João Pedro Borsato Cruz | RM550294  |
| Maria Fernanda Vieira de Camargo | RM9796  |
| Pedro Lucas de Andrade Nunes | RM550366  |


