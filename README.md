# Faculdade de Informática e Administração Paulista - FIAP/SP  
**Referência:** Global Solution - 2025/1º Semestre  - [EVENTOS EXTREMOS]

**Alunos:**  
- Guilherme Gonçalves - RM558475  
- Thiago Mendes - RM555352  
- Vinicius Banciela - RM558117  

**Turma:** 2TDSPW  

---

## 📚 KAOW API - Documentação Oficial

Esta é a API RESTful central para o gerenciamento de recursos e informações em situações de emergência e desastres, parte integrante da Global Solution do 1º Semestre de 2025.

---

## 🚀 Visão Geral

**Tecnologias:**  
C#, .NET 8, ASP.NET Core, Entity Framework Core, PostgreSQL, Docker, Docker Compose, Azure, Swagger.

**Funcionalidades:**  
- Cadastro e gerenciamento de Instituições (organizações de resposta, governamentais, ONGs, etc.).  
- Cadastro e gerenciamento de Eventos Extremos (desastres naturais, acidentes, emergências de saúde pública).  
- Cadastro e gerenciamento de Bases de Emergência (locais de abrigo, hospitais de campanha, pontos de apoio logístico).  
- Gestão de relacionamentos opcionais entre Instituições, Eventos Extremos e Bases de Emergência, permitindo flexibilidade na modelagem de cenários reais.  
- Operações completas de CRUD (Criação, Leitura, Atualização, Exclusão) para todas as entidades principais.  

---

## 📖 Introdução e Descrição/Desenvolvimento do Projeto

O projeto KAOW API nasce no contexto da Global Solution do 1º Semestre de 2025, com o objetivo primordial de oferecer uma solução robusta e flexível para o mapeamento e gestão de recursos e atores envolvidos em cenários de emergência e desastres. Inspirados pela necessidade de agilidade e precisão na resposta a crises, esta API foi concebida para integrar e organizar informações cruciais de Instituições, Eventos Extremos e Bases de Emergência.

Adotando uma abordagem modular e utilizando tecnologias modernas como C#, o framework ASP.NET Core e o banco de dados PostgreSQL, a API foi desenhada para ser escalável e de fácil manutenção. Um dos pilares do design da KAOW API é a opcionalidade dos relacionamentos entre as entidades. Isso significa que, por exemplo, um Evento Extremo pode ser cadastrado sem estar imediatamente vinculado a uma Instituição ou a uma Base de Emergência específica (o que é válido para as 3 entidades), permitindo que os dados sejam inseridos de forma incremental e adaptável à fluidez das situações de campo.

A API implementa 6 tipos distintos de relacionamentos opcionais que, combinados com as 3 entidades principais (Instituição, Evento Extremo e Base de Emergência), formam um total de 12 cenários de relacionamento abrangentes. Estes cenários garantem a flexibilidade necessária para modelar diversas situações de emergência no mundo real:

---

## 🔗 Cenários de Relacionamento Detalhados:

1. **Instituição sem relacionamento:**  
   Uma instituição pode ser cadastrada e existir de forma independente, sem vínculos iniciais com bases ou eventos.

2. **Instituição com relacionamento APENAS com Base de Emergência (1:N):**  
   Uma instituição pode ser responsável por uma ou mais bases de emergência. A base, por sua vez, está vinculada a apenas uma instituição.

3. **Instituição com relacionamento APENAS com Evento Extremo (N:M):**  
   Uma instituição pode participar de um ou mais eventos extremos, e um evento extremo pode ter a colaboração de várias instituições.

4. **Instituição com AMBOS os relacionamentos (1:N com Base E N:M com Evento):**  
   Uma instituição pode gerenciar suas próprias bases de emergência e, simultaneamente, participar de múltiplos eventos extremos.

5. **Evento Extremo sem relacionamento:**  
   Um evento extremo pode ser registrado independentemente, sem ter bases de emergência dedicadas ou instituições formalmente associadas inicialmente.

6. **Evento Extremo com relacionamento APENAS com Instituição (N:M):**  
   Um evento extremo pode ter a colaboração de uma ou mais instituições, e uma instituição pode participar de múltiplos eventos.

7. **Evento Extremo com relacionamento APENAS com Base de Emergência (1:N):**  
   Um evento extremo pode ter uma ou mais bases de emergência criadas ou designadas especificamente para apoiar suas operações. Cada base, neste contexto, estaria vinculada unicamente a este evento.

8. **Evento Extremo com AMBOS os relacionamentos (1:N com Base E N:M com Instituição):**  
   Um evento extremo pode contar com o apoio de bases de emergência dedicadas e, ao mesmo tempo, ser atendido por diversas instituições.

9. **Base de Emergência sem relacionamento:**  
   Uma base de emergência pode ser cadastrada como um recurso geral, sem ser diretamente atribuída a uma instituição específica ou a um evento extremo imediato.

10. **Base de Emergência com relacionamento APENAS com Instituição (N:1):**  
    Uma base de emergência pode ser operada ou gerenciada por uma única instituição, mas não necessariamente vinculada a um evento extremo específico.

11. **Base de Emergência com relacionamento APENAS com Evento Extremo (N:1):**  
    Uma base de emergência pode ser designada para dar suporte exclusivo a um evento extremo específico, sem que uma instituição a gerencie diretamente no sistema (embora possa haver uma entidade operando-a na vida real).

12. **Base de Emergência com AMBOS os relacionamentos (N:1 com Instituição E N:1 com Evento):**  
    Uma base de emergência pode ser gerenciada por uma instituição específica e, ao mesmo tempo, estar dedicada a um evento extremo particular.

---

A API oferece um conjunto abrangente de endpoints RESTful que permitem desde a criação de registros detalhados até a atualização e exclusão, além de consultas para recuperar dados específicos e suas respectivas vinculações. A documentação completa da API é disponibilizada via Swagger, proporcionando uma interface intuitiva para exploração e testes.

Todas as rotas da KAOW API são intencionalmente configuradas como públicas. Esta decisão de design visa permitir que a sociedade como um todo, incluindo cidadãos, voluntários e outras entidades, possa manipular e acessar os dados de forma flexível e dinâmica. Este modelo promove a colaboração e a rápida disseminação de informações em contextos de emergência, onde a agilidade no acesso aos dados é crucial para uma resposta eficiente.

A arquitetura foi pensada para garantir a manutenibilidade, clareza e eficiência do código, facilitando futuras expansões do projeto. Para a implantação, a API é conteinerizada utilizando Docker e Docker Compose, e pode ser facilmente orquestrada em ambientes de nuvem, como o Azure, garantindo alta disponibilidade e escalabilidade.

---

## 🚀 Guia de Instalação e Execução

Este guia assume que você possui as ferramentas básicas de desenvolvimento Docker e Git instaladas.

### 📦 Pré-requisitos

- Docker (que inclui Docker Engine e Docker Compose) instalado e rodando.  
- Git instalado na máquina.  
- Acesso ao terminal ou shell para execução dos comandos.  
- (Opcional) Visual Studio, Visual Studio Code, Rider ou outro editor para abrir o projeto (necessário apenas para desenvolvimento local, não para execução via Docker).

---

### 📥 Clone o repositório

```bash
git clone https://github.com/vinibanciela/KAOW-API-dotNet.git
```
## Acesse a pasta

```bash
cd KAOW-API-dotNet
```

---

### 🐳 Configuração e Execução dos Containers

O projeto utiliza Docker Compose para orquestrar o serviço da API e o banco de dados PostgreSQL.

**Construa as imagens Docker e inicie os serviços:**  
Na raiz do projeto (onde o arquivo `docker-compose.yml` está localizado), execute:

```bash
docker-compose up --build -d
```

Este comando irá construir as imagens Docker para a API e o PostgreSQL (se ainda não existirem) e iniciará os containers em segundo plano.

**Verifique se os containers estão rodando:**

```bash
docker ps
```

Você deverá ver containers para a `kaow-api` e `postgres` (ou nomes semelhantes, dependendo da sua configuração).

**Acompanhe os logs dos containers (opcional):**

```bash
docker-compose logs -f
```

Pressione `Ctrl+C` para sair do acompanhamento de logs.

**A API estará acessível em:**  
📍 http://localhost:8080 (ou na porta configurada no `docker-compose.yml`).

---

## 📂 Estrutura de Endpoints

### 📘 Documentação Interativa

Disponível em (se der erro ao clicar, copie e cole o link, e atualize a aba):  
🔗 [http://4.201.169.45:8080/swagger/index.html](http://4.201.169.45:8080/swagger/index.html)

---

### 🏛️ Instituição

| Método  | Rota                      | Descrição                                  | Respostas HTTP                          |
|---------|---------------------------|--------------------------------------------|-----------------------------------------|
| POST    | /api/Instituicao          | Cria uma nova instituição.                 | 201 Created, 400 Bad Request             |
| GET     | /api/Instituicao          | Lista todas as instituições.               | 200 OK                                  |
| GET     | /api/Instituicao/{id}     | Retorna detalhes de uma instituição por ID.| 200 OK, 404 Not Found                    |
| PUT     | /api/Instituicao/{id}     | Atualiza uma instituição existente por ID. | 204 No Content, 400 Bad Request, 404 Not Found |
| DELETE  | /api/Instituicao/{id}     | Exclui uma instituição por ID.             | 204 No Content, 404 Not Found            |

---

### 🌪️ Evento Extremo

| Método  | Rota                          | Descrição                                                     | Respostas HTTP                          |
|---------|-------------------------------|---------------------------------------------------------------|-----------------------------------------|
| POST    | /api/EventoExtremo            | Cria um novo evento extremo.                                  | 201 Created, 400 Bad Request             |
| GET     | /api/EventoExtremo            | Lista todos os eventos extremos.                              | 200 OK                                  |
| GET     | /api/EventoExtremo/{id}       | Retorna os dados detalhados do evento extremo.                | 200 OK, 404 Not Found                    |
| PUT     | /api/EventoExtremo/{id}       | Atualiza os dados do evento extremo.                          | 204 No Content, 400 Bad Request, 404 Not Found |
| DELETE  | /api/EventoExtremo/{id}       | Remove um evento extremo.                                     | 204 No Content, 404 Not Found            |

---

### 🏥 Base de Emergência

| Método  | Rota                            | Descrição                                                                        | Respostas HTTP                          |
|---------|---------------------------------|----------------------------------------------------------------------------------|-----------------------------------------|
| POST    | /api/BaseEmergencia             | Adiciona uma nova base de emergência no sistema.                                | 201 Created, 400 Bad Request             |
| GET     | /api/BaseEmergencia             | Retorna todas as bases de emergência cadastradas (sem dados relacionados).      | 200 OK                                  |
| GET     | /api/BaseEmergencia/{id}        | Retorna os dados detalhados da base, com instituição e evento relacionados.     | 200 OK, 404 Not Found                    |
| PUT     | /api/BaseEmergencia/{id}        | Atualiza os dados da base de emergência.                                        | 204 No Content, 400 Bad Request, 404 Not Found |
| DELETE  | /api/BaseEmergencia/{id}        | Remove uma base de emergência.                                                  | 204 No Content, 404 Not Found            |

---

### 🔗 Relacionamentos (EventoInstituicao)

| Método  | Rota                                                                            | Descrição                                                  | Respostas HTTP                          |
|---------|----------------------------------------------------------------------------------|------------------------------------------------------------|-----------------------------------------|
| POST    | /api/EventoInstituicao                                                          | Cria vínculo entre EventoExtremo e Instituição.            | 201 Created, 400 Bad Request             |
| GET     | /api/EventoInstituicao                                                          | Lista todos os vínculos Evento-Inst.                       | 200 OK                                  |
| GET     | /api/EventoInstituicao/evento/{eventoId}/instituicao/{instituicaoId}            | Busca vínculo específico.                                  | 200 OK, 404 Not Found                    |
| DELETE  | /api/EventoInstituicao/evento/{eventoId}/instituicao/{instituicaoId}            | Remove vínculo específico.                                 | 204 No Content, 404 Not Found            |

---

## 📝 Observações

- ✅ **201 Created**: Entidade criada com sucesso.  
- ✅ **204 No Content**: Atualização/remoção bem-sucedida, sem conteúdo retornado.  
- ⚠️ **400 Bad Request**: Erro de validação ou solicitação malformada.  
- ❌ **404 Not Found**: Entidade ou vínculo não encontrado.  

---

---

## 🧪 Testes com Instruções de Acesso e Exemplos

Para demonstrar os 12 cenários de relacionamentos e a funcionalidade completa da KAOW API, siga as instruções abaixo. Os IDs das entidades serão gerados sequencialmente, começando por 1 para a primeira entidade de cada tipo criada.

### Instruções de Acesso:

1. Certifique-se de que os containers da API e do banco de dados estão em execução (via `docker-compose up -d`).
2. Utilize uma ferramenta como Postman ou o próprio Swagger UI para enviar as requisições HTTP.
3. Após cada requisição POST de entidade principal (`Instituicao`, `EventoExtremo`, `BaseEmergencia`), anote o ID retornado na resposta `201 Created`. Estes IDs serão usados nas requisições subsequentes.

---

📌 **Dúvidas, bugs ou sugestões:** use o sistema de issues do GitHub no repositório  
📁 Repositório: [https://github.com/vinibanciela/KAOW-API-dotNet](https://github.com/vinibanciela/KAOW-API-dotNet)

--- 

### ⚠️ Observação Importante:

Todos os exemplos JSON abaixo foram testados e documentados em vídeo, validando a funcionalidade da API. No entanto, como o repositório é público e o link da API com o Swagger pode ser utilizado por diversos usuários (incluindo os professores avaliadores), é crucial que, após realizar os testes, o ambiente seja limpo e reiniciado.

Se um professor testar e a base de dados já contiver registros anteriores, a sequência dos IDs pode ser afetada. Para garantir que os exemplos funcionem conforme o esperado, especialmente os POSTs de relacionamento e os PUTs que dependem de IDs específicos (os demais POST´s poderiam funcionar), a base de dados deve estar limpa.

### 🔄 Resetar o Banco para testes limpos:

```bash
# 1. Conecte-se via SSH:
ssh kaowadmin@4.201.169.45
# senha: SenhaForteAqui123!

# 2. Acesse o diretório do projeto:
cd KAOW-API-dotNet

# 3. Pare todos os containers em execução:
docker stop $(docker ps -q)

# 4. Remova todos os containers:
docker rm $(docker ps -aq)

# 5. Remova o volume do banco de dados:
docker volume rm kaow-api-dotnet_postgres-data

# 6. Verifique se containers e volumes foram removidos:
docker ps
docker volume ls

# 7. Suba novamente os containers e reconstrua:
docker compose up -d --build
```

> Isso garante que os IDs comecem novamente a partir de 1 para facilitar os testes dos 12 cenários abaixo.

---

## 🧬 Demonstração dos 12 Cenários de Relacionamento

Os JSONs e requisições completas estão estruturadas na ordem:

- **Cenários 1 a 4**: Instituição  
- **Cenários 5 a 8**: Evento Extremo  
- **Cenários 9 a 12**: Base de Emergência  

Para visualizar os exemplos JSON de cada cenário com endpoints e ID esperados, acesse a continuação do documento original (README), pois eles estão todos detalhados e organizados.

> Todos os exemplos foram testados e validados. É recomendado resetar o banco antes para que os IDs retornem a partir de 1.

---

## 🔁 Demonstração dos 12 Cenários de Relacionamento (JSONs de Requisição)

---

### #Instituição - Cenários 1 a 4

---

#### **1. Cenário: Instituição sem relacionamento**

Ação: Criar uma nova Instituição. (Esta será a Instituição de ID 1).

**POST** http://4.201.169.45:8080/api/Instituicao  
**JSON:**
```json
{
  "nome": "Centro de Pesquisas Climáticas",
  "tipo": "Acadêmica",
  "email": "contato@cpc.edu.br",
  "cnpj": "98765432000150",
  "telefone": "(21) 2345-6789",
  "endereco": "Rua do Conhecimento, 50 - Rio de Janeiro/RJ",
  "descricao": "Focada em estudos e previsões climáticas, sem envolvimento direto em emergências."
}
```
**ID Esperado:** 1  
**Verificação:**  
GET http://4.201.169.45:8080/api/Instituicao/1 (verifique `basesEmergencia` e `eventosExtremos` como listas vazias)

---

#### **2. Cenário: Instituição com relacionamento APENAS com BaseEmergencia (1:N)**

Ação: Criar uma nova Instituição (ID 2) e uma nova Base de Emergência (ID 1). Depois, vincular a Base (ID 1) a essa Instituição (ID 2).

**POST** http://4.201.169.45:8080/api/Instituicao  
**JSON:**
```json
{
  "nome": "Agência de Resposta Rápida",
  "tipo": "Governamental",
  "email": "contato@arr.gov.br",
  "cnpj": "23456789000123",
  "telefone": "(31) 3210-9876",
  "endereco": "Av. da Ação, 200 - Belo Horizonte/MG",
  "descricao": "Especializada em primeira resposta e coordenação de abrigos."
}
```
**ID Esperado:** 2  

**POST** http://4.201.169.45:8080/api/BaseEmergencia  
**JSON:**
```json
{
  "localizacao": "Abrigo Comunitário - MG",
  "email": "abrigo.mg@arr.gov.br",
  "telefone": "(31) 98765-4321",
  "descricao": "Abrigo temporário para desabrigados de eventos locais.",
  "tipo": "Abrigo"
}
```
**ID Esperado:** 1  

**PUT** http://4.201.169.45:8080/api/BaseEmergencia/1  
**JSON:**
```json
{
  "id": 1,
  "localizacao": "Abrigo Comunitário - MG",
  "email": "abrigo.mg@arr.gov.br",
  "telefone": "(31) 98765-4321",
  "descricao": "Abrigo temporário para desabrigados de eventos locais, gerenciado pela ARR.",
  "tipo": "Abrigo",
  "instituicaoId": 2,
  "eventoExtremoId": null
}
```
**Verificação:**  
GET http://4.201.169.45:8080/api/Instituicao/2 (verifique `basesEmergencia` preenchido)

---

#### **3. Cenário: Instituição com relacionamento APENAS com EventoExtremo (N:M)**

Ação: Criar uma nova Instituição (ID 3) e um novo Evento Extremo (ID 1). Depois, criar o vínculo N:M entre eles.

**POST** http://4.201.169.45:8080/api/Instituicao  
**JSON:**
```json
{
  "nome": "Equipe de Apoio Voluntário",
  "tipo": "ONG",
  "email": "contato@eav.org",
  "cnpj": "34567890000145",
  "telefone": "(81) 99999-1234",
  "endereco": "Rua da Solidariedade, 30 - Recife/PE",
  "descricao": "Grupo de voluntários para assistência em desastres."
}
```
**ID Esperado:** 3  

**POST** http://4.201.169.45:8080/api/EventoExtremo  
**JSON:**
```json
{
  "descricao": "Inundação repentina em área costeira",
  "data": "2025-07-10T08:00:00.000Z",
  "tipo": "Desastre Natural",
  "local": "Litoral de Pernambuco"
}
```
**ID Esperado:** 1  

**POST** http://4.201.169.45:8080/api/EventoInstituicao  
**JSON:**
```json
{
  "eventoExtremoId": 1,
  "instituicaoId": 3
}
```
**Verificação:**  
GET http://4.201.169.45:8080/api/Instituicao/3 (verifique `eventosExtremos` preenchido)

---

#### **4. Cenário: Instituição com AMBOS os relacionamentos (1:N com Base E N:M com Evento)**

Ação: Criar uma nova Instituição (ID 4), uma nova Base de Emergência (ID 2) e um novo Evento Extremo (ID 2). Em seguida, vincular a Base (ID 2) à Instituição (ID 4) e criar o vínculo N:M com o Evento (ID 2).

**POST** http://4.201.169.45:8080/api/Instituicao  
**JSON:**
```json
{
  "nome": "Força Nacional de Resposta",
  "tipo": "Federal",
  "email": "contato@fnr.gov.br",
  "cnpj": "45678901000178",
  "telefone": "(61) 5555-4444",
  "endereco": "QG Nacional, s/n - Brasília/DF",
  "descricao": "Unidade especializada em grandes desastres nacionais."
}
```
**ID Esperado:** 4  

**POST** http://4.201.169.45:8080/api/BaseEmergencia  
**JSON:**
```json
{
  "localizacao": "Base Logística Central - DF",
  "email": "base.central@fnr.gov.br",
  "telefone": "(61) 98765-1234",
  "descricao": "Ponto estratégico para distribuição de recursos em nível nacional.",
  "tipo": "Central Logística"
}
```
**ID Esperado:** 2  

**POST** http://4.201.169.45:8080/api/EventoExtremo  
**JSON:**
```json
{
  "descricao": "Terremoto de média intensidade",
  "data": "2025-08-01T22:45:00.000Z",
  "tipo": "Desastre Natural",
  "local": "Região Amazônica - Manaus/AM"
}
```
**ID Esperado:** 2  

**PUT** http://4.201.169.45:8080/api/BaseEmergencia/2  
**JSON:**
```json
{
  "id": 2,
  "localizacao": "Base Logística Central - DF",
  "email": "base.central@fnr.gov.br",
  "telefone": "(61) 98765-1234",
  "descricao": "Ponto estratégico para distribuição de recursos, gerenciado pela FNR.",
  "tipo": "Central Logística",
  "instituicaoId": 4,
  "eventoExtremoId": null
}
```

**POST** http://4.201.169.45:8080/api/EventoInstituicao  
**JSON:**
```json
{
  "eventoExtremoId": 2,
  "instituicaoId": 4
}
```

**Verificação:**  
GET http://4.201.169.45:8080/api/Instituicao/4 (verifique `basesEmergencia` e `eventosExtremos` preenchidos)

---
### #EventoExtremo - Cenários 5 a 8

---

#### **5. Cenário: Evento Extremo sem relacionamento**

Ação: Criar um novo Evento Extremo (ID 3).

**POST** http://4.201.169.45:8080/api/EventoExtremo  
**JSON:**
```json
{
  "descricao": "Onda de calor persistente",
  "data": "2025-07-15T15:00:00.000Z",
  "tipo": "Climático",
  "local": "Interior de São Paulo"
}
```
**ID Esperado:** 3  
**Verificação:**  
GET http://4.201.169.45:8080/api/EventoExtremo/3 (verifique `basesEmergencia: []` e `instituicoes: []`)

---

#### **6. Cenário: Evento Extremo com relacionamento APENAS com Instituição (N:M)**

Ação: Criar um novo Evento Extremo (ID 4) e uma nova Instituição (ID 5). Depois, criar o vínculo N:M entre eles.

**POST** http://4.201.169.45:8080/api/EventoExtremo  
**JSON:**
```json
{
  "descricao": "Vazamento de produto químico",
  "data": "2025-09-05T11:00:00.000Z",
  "tipo": "Acidente Industrial",
  "local": "Polo Industrial de Camaçari/BA"
}
```
**ID Esperado:** 4  

**POST** http://4.201.169.45:8080/api/Instituicao  
**JSON:**
```json
{
  "nome": "Serviço de Atendimento Químico",
  "tipo": "Privada",
  "email": "contato@saq.com.br",
  "cnpj": "56789012000189",
  "telefone": "(71) 7777-8888",
  "endereco": "Av. Empresas, 1000 - Camaçari/BA",
  "descricao": "Especializada em resposta a vazamentos e contaminações químicas."
}
```
**ID Esperado:** 5  

**POST** http://4.201.169.45:8080/api/EventoInstituicao  
**JSON:**
```json
{
  "eventoExtremoId": 4,
  "instituicaoId": 5
}
```
**Verificação:**  
GET http://4.201.169.45:8080/api/EventoExtremo/4 (verifique `instituicoes` preenchido)

---

#### **7. Cenário: Evento Extremo com relacionamento APENAS com BaseEmergencia (1:N)**

Ação: Criar um novo Evento Extremo (ID 5) e uma nova Base de Emergência (ID 3). Depois, vincular a Base (ID 3) a esse Evento (ID 5).

**POST** http://4.201.169.45:8080/api/EventoExtremo  
**JSON:**
```json
{
  "descricao": "Deslizamento de terra em área de risco",
  "data": "2025-10-20T06:30:00.000Z",
  "tipo": "Desastre Natural",
  "local": "Serra Fluminense - Petrópolis/RJ"
}
```
**ID Esperado:** 5  

**POST** http://4.201.169.45:8080/api/BaseEmergencia  
**JSON:**
```json
{
  "localizacao": "Centro de Triagem - Petrópolis",
  "email": "triagem.petropolis@email.com",
  "telefone": "(24) 91234-5678",
  "descricao": "Ponto de triagem e encaminhamento de vítimas de deslizamentos.",
  "tipo": "Centro de Triagem"
}
```
**ID Esperado:** 3  

**PUT** http://4.201.169.45:8080/api/BaseEmergencia/3  
**JSON:**
```json
{
  "id": 3,
  "localizacao": "Centro de Triagem - Petrópolis",
  "email": "triagem.petropolis@email.com",
  "telefone": "(24) 91234-5678",
  "descricao": "Ponto de triagem e encaminhamento de vítimas de deslizamentos, dedicado a este epidemia.",
  "tipo": "Centro de Triagem",
  "instituicaoId": null,
  "eventoExtremoId": 5
}
```
**Verificação:**  
GET http://4.201.169.45:8080/api/EventoExtremo/5 (verifique `basesEmergencia` preenchido)

---

#### **8. Cenário: Evento Extremo com AMBOS os relacionamentos (1:N com Base E N:M com Instituição)**

Ação: Criar um novo Evento Extremo (ID 6), uma nova Instituição (ID 6) e uma nova Base de Emergência (ID 4). Vincular a Base (ID 4) ao Evento (ID 6), e criar o vínculo N:M com a Instituição (ID 6).

**POST** http://4.201.169.45:8080/api/EventoExtremo  
**JSON:**
```json
{
  "descricao": "Epidemia de doença infecciosa",
  "data": "2025-11-01T09:00:00.000Z",
  "tipo": "Saúde Pública",
  "local": "Várias cidades do Nordeste"
}
```
**ID Esperado:** 6  

**POST** http://4.201.169.45:8080/api/Instituicao  
**JSON:**
```json
{
  "nome": "Organização Médicos Sem Fronteiras Brasil",
  "tipo": "ONG Internacional",
  "email": "contato.br@msf.org",
  "cnpj": "67890123000190",
  "telefone": "(11) 1234-5678",
  "endereco": "Av. da Saúde, 10 - São Paulo/SP",
  "descricao": "Atuação humanitária em crises médicas e epidemias."
}
```
**ID Esperado:** 6  

**POST** http://4.201.169.45:8080/api/BaseEmergencia  
**JSON:**
```json
{
  "localizacao": "Hospital de Campanha - Nordeste",
  "email": "hospital.camp@msf.org",
  "telefone": "(85) 99876-5432",
  "descricao": "Estrutura médica temporária para tratamento de pacientes.",
  "tipo": "Hospital de Campanha"
}
```
**ID Esperado:** 4  

**PUT** http://4.201.169.45:8080/api/BaseEmergencia/4  
**JSON:**
```json
{
  "id": 4,
  "localizacao": "Hospital de Campanha - Nordeste",
  "email": "hospital.camp@msf.org",
  "telefone": "(85) 99876-5432",
  "descricao": "Estrutura médica temporária para tratamento de pacientes, dedicada a esta epidemia.",
  "tipo": "Hospital de Campanha",
  "instituicaoId": null,
  "eventoExtremoId": 6
}
```

**POST** http://4.201.169.45:8080/api/EventoInstituicao  
**JSON:**
```json
{
  "eventoExtremoId": 6,
  "instituicaoId": 6
}
```

**Verificação:**  
GET http://4.201.169.45:8080/api/EventoExtremo/6 (verifique `basesEmergencia` e `instituicoes` preenchidos)

---
### #BaseEmergencia - Cenários 9 a 12

---

#### **9. Cenário: Base de Emergência sem relacionamento**

Ação: Criar uma nova Base de Emergência (ID 5).

**POST** http://4.201.169.45:8080/api/BaseEmergencia  
**JSON:**
```json
{
  "localizacao": "Ginásio Municipal - Sem Vínculo",
  "email": "ginasio.municipal@email.com",
  "telefone": "(19) 3210-5678",
  "descricao": "Espaço de apoio genérico para qualquer eventualidade.",
  "tipo": "Espaço Comunitário"
}
```

**ID Esperado:** 5  
**Verificação:**  
GET http://4.201.169.45:8080/api/BaseEmergencia/5 (verifique `instituicaoNome` e `eventoExtremoTipo` vazios)

---

#### **10. Cenário: Base de Emergência com relacionamento APENAS com Instituição (N:1)**

Ação: Criar uma nova Base de Emergência (ID 6) e uma nova Instituição (ID 7). Vincular a Base (ID 6) à Instituição (ID 7).

**POST** http://4.201.169.45:8080/api/BaseEmergencia  
**JSON:**
```json
{
  "localizacao": "Central de Suprimentos - Sul",
  "email": "suprimentos.sul@email.com",
  "telefone": "(51) 98765-1111",
  "descricao": "Ponto de coleta e distribuição de suprimentos.",
  "tipo": "Depósito"
}
```

**ID Esperado:** 6  

**POST** http://4.201.169.45:8080/api/Instituicao  
**JSON:**
```json
{
  "nome": "Logística Humanitária Sul",
  "tipo": "ONG",
  "email": "contato@lhs.org.br",
  "cnpj": "78901234000101",
  "telefone": "(51) 3333-2222",
  "endereco": "Rua do Depósito, 1 - Porto Alegre/RS",
  "descricao": "Focada em logística e distribuição de ajuda humanitária."
}
```

**ID Esperado:** 7  

**PUT** http://4.201.169.45:8080/api/BaseEmergencia/6  
**JSON:**
```json
{
  "id": 6,
  "localizacao": "Central de Suprimentos - Sul",
  "email": "suprimentos.sul@email.com",
  "telefone": "(51) 98765-1111",
  "descricao": "Ponto de coleta e distribuição de suprimentos, gerenciado pela LHS.",
  "tipo": "Depósito",
  "instituicaoId": 7,
  "eventoExtremoId": null
}
```

**Verificação:**  
GET http://4.201.169.45:8080/api/BaseEmergencia/6 (verifique `instituicaoNome` preenchido)

---

#### **11. Cenário: Base de Emergência com relacionamento APENAS com Evento Extremo (N:1)**

Ação: Criar uma nova Base de Emergência (ID 7) e um novo Evento Extremo (ID 7). Vincular a Base (ID 7) ao Evento (ID 7).

**POST** http://4.201.169.45:8080/api/BaseEmergencia  
**JSON:**
```json
{
  "localizacao": "Escola Municipal João Pedro - Destinada",
  "email": "escola.jp@email.com",
  "telefone": "(88) 99988-7766",
  "descricao": "Ponto de evacuação e abrigo para evento específico.",
  "tipo": "Ponto de Evacuação"
}
```

**ID Esperado:** 7  

**POST** http://4.201.169.45:8080/api/EventoExtremo  
**JSON:**
```json
{
  "descricao": "Vendaval e queda de árvores",
  "data": "2025-12-05T13:00:00.000Z",
  "tipo": "Fenômeno Natural",
  "local": "Cidade de Juazeiro do Norte/CE"
}
```

**ID Esperado:** 7  

**PUT** http://4.201.169.45:8080/api/BaseEmergencia/7  
**JSON:**
```json
{
  "id": 7,
  "localizacao": "Escola Municipal João Pedro - Destinada",
  "email": "escola.jp@email.com",
  "telefone": "(88) 99988-7766",
  "descricao": "Ponto de evacuação e abrigo para evento específico de vendaval.",
  "tipo": "Ponto de Evacuação",
  "instituicaoId": null,
  "eventoExtremoId": 7
}
```

**Verificação:**  
GET http://4.201.169.45:8080/api/BaseEmergencia/7 (verifique `eventoExtremoTipo` preenchido)

---

#### **12. Cenário: Base de Emergência com AMBOS os relacionamentos (N:1 com Instituição E N:1 com Evento)**

Ação: Criar uma nova Instituição (ID 8), um novo Evento Extremo (ID 8) e uma nova Base de Emergência (ID 8), já incluindo os IDs em sua criação.

**POST** http://4.201.169.45:8080/api/Instituicao  
**JSON:**
```json
{
  "nome": "Cruz Vermelha Brasileira - Filial SP",
  "tipo": "ONG",
  "email": "contato.sp@cvb.org.br",
  "cnpj": "12345678000102",
  "telefone": "(11) 5555-1234",
  "endereco": "Av. Brasil, 500 - São Paulo/SP",
  "descricao": "Atuação humanitária em saúde, desastres e desenvolvimento comunitário."
}
```

**ID Esperado:** 8  

**POST** http://4.201.169.45:8080/api/EventoExtremo  
**JSON:**
```json
{
  "descricao": "Colapso de estrutura em construção",
  "data": "2026-01-10T10:00:00.000Z",
  "tipo": "Acidente Estrutural",
  "local": "Zona Leste - São Paulo/SP"
}
```

**ID Esperado:** 8  

**POST** http://4.201.169.45:8080/api/BaseEmergencia  
**JSON:**
```json
{
  "localizacao": "Posto Avançado - Leste",
  "email": "posto.leste@cvb.org.br",
  "telefone": "(11) 99876-0000",
  "descricao": "Ponto de atendimento e suporte inicial, gerenciado pela CVB e dedicado ao colapso.",
  "tipo": "Posto Médico Avançado",
  "instituicaoId": 8,
  "eventoExtremoId": 8
}
```

**ID Esperado:** 8  

**Verificação:**  
GET http://4.201.169.45:8080/api/BaseEmergencia/8 (verifique `instituicaoNome` e `eventoExtremoTipo` preenchidos)

---


