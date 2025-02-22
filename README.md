# GerenciamentoProduto

## Perguntas e Respostas

#### Escreva uma query que otimize a seguinte consulta para grandes volumes de dados. Query original: 
``SELECT * FROM Orders 
WHERE OrderDate BETWEEN '2023-01-01' AND '2023-12-31' ORDER BY CustomerID; ``

**Resposta:**

``Select CustomerID, OrderDate where orderDate between '2023-01-01'and '2023-12-31' ORDER BY CustomerID``

#### Qual é a diferença entre INNER JOIN, LEFT JOIN e CROSS JOIN? 

**Inner Join::** Relacionamento de tabelas no qual os dados devem existir em ambas tabelas, por exemplo, tenho duas tabelas; Usuario e Categoria, na tabela de usuario eu tenho o Id como identificador e na tabela Categoria eu tenho a coluna IdUser que é referente ao Id da tabela Usuário, então quando eu faço inner join nessas tabelas os mesmos dados tem que existe em ambas, o id 1 da tabela Usuario tem que ter na colunar Iduser da categoria.

**Left join::** independente se houver mesmo dados em ambas determinada coluna, deve trazer os dados priorizando o dados na tabela do qual foi priorizado(A Esquerda).

**Cross Join::** Praticamente junta todas as tabelas, fazendo uma combinação entre elas

#### Explique a diferença entre os modos de carregamento Lazy, Eager e Explicit no Entity Framework. 
**Eager** = usamos o Include para trazer todos os relacionamentos

**Lazy**= dados do relacionamento é acessado

**Explicit** = dados relacionados não são carregados automaticamente, ele é recomendavel quando voce quer selecionar qual relacionamento quer carregar na entidade.

#### Descreva um cenário onde o uso de AsNoTracking() seria necessário e explique por que.
O uso de AsNoTracking() é essencial para não fazer o rastreamento determinada entidade.

**Cenário:**
Eu tenho as entidade Produto e crio uma variavel para fazer uma determinada consulta(no qual eu não quero fazer mudanças nelas). apenas consulta, porém logo abaixo dessa variável eu chamei outra variável de entidade de Produtos no qual eu quero fazer pequenas modificações, quando eu usar o saveChange, o EF ele vai salvar tanto a primeira variavel quanto o Segundo isso porque ele esta rastreável por isso nesse sentido eu uso AsNoTracking para não fazer o rastreamento dos relacionamentos dela.

#### Explique a diferença entre arquitetura monolítica e arquitetura de microsserviços. 
**Monolito:** Praticamente toda aplicação esta em um unico lugar até mesmo o frontend.

**Microsserviços:** Praticamente é dividade entre serviços e cada um com sua responsabilidade.


### O PROJETO

Para rodar o projeto, basta abrir o CMD e digitar:  
``sh
dotnet run``

endereço do swagger:
http://localhost:5019/swagger/index.html
or
http://localhost:{port}/swagger/index.html

O Projeto segue arquitetura de 3 camadas;

Camada de Apresentação (Presentation), Camada de Aplicação/Serviço (Application/Service) e Camada de Acesso a Dados (Data/Repository)
