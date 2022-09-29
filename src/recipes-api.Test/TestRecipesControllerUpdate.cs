using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using recipes_api.Models;
using recipes_api.Services;
using recipes_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace recipes_api.Test;

public class TestRecipesControllerUpdate
{
    public static IEnumerable<object[]> RecipeServiceTestData()
    {
        yield return new object[]
      {
            "Coxinha queimada",
            new Recipe { Name = "Coxinha queimada",
                            RecipeType = RecipesType.salty,
                            PreparationTime = 0.4,
                            Ingredients = new List<string> {"4 xícaras de trigo", "4 xícaras de leite", "1 caldo de galinha", "1/2 colher de margarina"},
                            Directions = "Leve ao fogo o leite, a margarina e o caldo. Deixe ferver. Despeje de uma só vez o trigo e mexa bem. Depois retire da panela e coloque sobre a mesa. Sove um pouco e comece a modelar as coxinhas. Coloque para fritar em óleo quente, espere dourar, retire e sirva.",
                            Rating = 7}
      };
    }

    [Theory]
    [MemberData(nameof(RecipeServiceTestData))]
    public void TestUpdate(string entryName, Recipe entryRecipe, List<Recipe> expected)
    {
        RecipesController instance = new RecipesController(new RecipeService());
        var actionResult = instance.Update(entryName, entryRecipe);
        var okResult = actionResult as NoContentResult;
        okResult.Should().BeAssignableTo<NoContentResult>();
        instance._service.GetRecipes().Should().BeEquivalentTo(expected);
    }
}
