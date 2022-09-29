using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using recipes_api.Models;
using recipes_api.Services;
using recipes_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace recipes_api.Test;

public class TestRecipesControllerCreate
{
    public static IEnumerable<object[]> RecipeServiceTestData()
    {
        yield return new object[]
        {
            new Recipe {
                        Name = "Cocada",
                        RecipeType = RecipesType.sweet,
                        PreparationTime = 1.3,
                        Ingredients = new List<string> {"2 xícaras de coco fresco ralado grosso", "1 xícara de açúcar refinado ou cristal", " meia xícara de água (120 mililitros)"},
                        Directions = "Separe os 3 ingredientes da sua cocada de antigamente: água, coco ralado fresco ralado grosso e açúcar. Em uma panela misture o açúcar e a água.",
                        Rating = 4
                        },
            new List<Recipe>
            {
                new Recipe { Name = "Bolo de cenoura",
                            RecipeType = RecipesType.sweet,
                            PreparationTime = 0.4,
                            Ingredients = new List<string> {"1/2 xícara (chá) de óleo", "3 cenouras médias raladas", "4 ovos", "2 xícaras (chá) de açúcar", "2 e 1/2 xícaras (chá) de farinha de trigo", "1 colher (sopa) de fermento em pó"},
                            Directions = "Em um liquidificador, adicione a cenoura, os ovos e o óleo, depois misture. Acrescente o açúcar e bata novamente por 5 minutos. Em uma tigela ou na batedeira, adicione a farinha de trigo e depois misture novamente. Acrescente o fermento e misture lentamente com uma colher. Asse em um forno preaquecido a 180° C por aproximadamente 40 minutos.",
                            Rating = 10},
                new Recipe { Name = "Coxinha",
                            RecipeType = RecipesType.salty,
                            PreparationTime = 0.4,
                            Ingredients = new List<string> {"4 xícaras de trigo", "4 xícaras de leite", "1 caldo de galinha", "1/2 colher de margarina"},
                            Directions = "Leve ao fogo o leite, a margarina e o caldo. Deixe ferver. Despeje de uma só vez o trigo e mexa bem. Depois retire da panela e coloque sobre a mesa. Sove um pouco e comece a modelar as coxinhas. Coloque para fritar em óleo quente, espere dourar, retire e sirva.",
                            Rating = 7},
                new Recipe { Name = "Pudim de Leite",
                            RecipeType = RecipesType.sweet,
                            PreparationTime = 1.1,
                            Ingredients = new List<string> {"1 xícara (chá) de açúcar", "1 lata de leite condensado", "2 latas de leite (medida da lata de leite condensado)", "3 ovos"},
                            Directions = "Bata todos os ingredientes do pudim no liquidificador e despeje na forma reservada. Asse em banho-maria, em forno médio (180º C), por cerca de 1 hora e 30 minutos. Depois de frio, leve para gelar por cerca de 6 horas. Desenforme e sirva a seguir.",
                            Rating = 9},
                new Recipe {
                        Name = "Cocada",
                        RecipeType = RecipesType.sweet,
                        PreparationTime = 1.3,
                        Ingredients = new List<string> {"2 xícaras de coco fresco ralado grosso", "1 xícara de açúcar refinado ou cristal", " meia xícara de água (120 mililitros)"},
                        Directions = "Separe os 3 ingredientes da sua cocada de antigamente: água, coco ralado fresco ralado grosso e açúcar. Em uma panela misture o açúcar e a água.",
                        Rating = 4
                        }
            }
        };

    }

    [Theory]
    [MemberData(nameof(RecipeServiceTestData))]
    public void TestCreate(Recipe entryRecipe, List<Recipe> expected)
    {
        RecipesController instance = new RecipesController(new RecipeService());
        var actionResult = instance.Create(entryRecipe);
        var okResult = actionResult as CreatedAtActionResult;
        var actualList = okResult.Value;
        actualList.Should().BeEquivalentTo(entryRecipe);
        instance._service.GetRecipes().Should().BeEquivalentTo(expected);
    }
}