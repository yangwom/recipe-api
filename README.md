
## 1 - Implemente as funções ReadAll, ReadOne e seus testes
`Em src/recipes-api/RecipesController.cs`

<details>
  <summary>Implemente a Action para ler todas as receitas</summary><br />

A action deve ser do tipo `HttpGet`;

A action deve retornar uma `IActionResult` do tipo `Ok` com um array com todas as receitas.
  
</details>

<details>
  <summary>Implemente a Action para ler uma receita</summary><br />

A action deve ser do tipo `HttpGet` e deve receber um parâmetro `name`;

A action deve retornar uma `IActionResult` do tipo `Ok` com o objeto do tipo `Recipe` que corresponde à busca.

Se não for encontrada uma receita com o nome passado por parâmetro, a Action deve retornar uma `IActionResult` do tipo `NotFound`.
  
</details>

> Os testes desse requisito já estão implementados para serem usados como **base**

> Os testes devem verificar se, quando chamada a action, ela retorna respectivamente uma receita específica, buscada por nome e todas as receitas.


## 2 - Implemente a função Create e seus testes

`Em src/recipes-api/RecipesController.cs`

<details>
  <summary>Implemente a Action para criar uma nova receita</summary><br />

A action deve ser do tipo `HttpPost`;
A action deve receber uma `Recipe` pelo corpo da requisição;

Se a receita passada por parâmetro for nula, deve ser retornado um `IActionResult` do tipo `BadRequest`;

A action deve adicionar a receita criada por parâmetro ao service e retornar um `IActionResult` do tipo `CreatedAtRoute` com a receita;
  
</details>

<details>
  <summary>Implemente os testes para a função de Create</summary><br />

Crie sua lógica em `src/recipes-api.Test/TestRecipesControllerCreate.cs`
  
Seu teste deve verificar se, quando chamada a action, ela adiciona corretamente a Recipe para o service.

</details>

## 3 - Implemente a função Update e seus testes
`Em src/recipes-api/RecipesController.cs`

<details>
  <summary>Implemente a Action para criar uma nova receita</summary><br />

A action deve ser do tipo `HttpPut`;
A action deve receber uma string de nome por parâmetro e uma `Recipe` pelo corpo da requisição;

Se a receita passada por parâmetro for nula ou o nome passado por parâmetro for diferente do nome da receita, deve ser retornado um `IActionResult` do tipo `BadRequest`;

A action deve atualizar a receita no service corretamente e retornar um `IActionResult` do tipo `NoContent` com a receita;
  
</details>

<details>
  <summary>Implemente os testes para a função de Update</summary><br />

Crie sua lógica em `src/recipes-api.Test/TestRecipesControllerUpdate.cs`
  
Seu teste deve verificar se, quando chamada a action, ela altera corretamente a Recipe no service.

</details>




## 4 - Implemente a função Delete e seus testes
`Em src/recipes-api/RecipesController.cs`

<details>
  <summary>Implemente a Action para deletar uma nova receita</summary><br />

A action deve ser do tipo `HttpDelete`;
A action deve receber uma string de nome por parâmetro;

Se a receita a ser deletada não existir no service, deve ser retornado um `IActionResult` do tipo `NotFound`;

A action deve deletar a receita no service corretamente e retornar um `IActionResult` do tipo `NoContent` com a receita;
  
</details>

<details>
  <summary>Implemente os testes para a função de Delete</summary><br />

Crie sua lógica em `src/recipes-api.Test/TestRecipesControllerDelete.cs`
  
Seu teste deve verificar se, quando chamada a action, ela deleta corretamente a Recipe no service.

</details>
