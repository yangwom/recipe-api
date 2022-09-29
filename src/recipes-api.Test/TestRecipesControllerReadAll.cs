using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using recipes_api.Models;
using recipes_api.Services;
using recipes_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace recipes_api.Test;

public class TestRecipesControllerReadAll
{
    public static IEnumerable<object[]> RecipeServiceTestData()
    {
        yield return new object[] {
        new List<Recipe> {
         new Recipe {
            Name = "bolo",
            Ingredients = new List<string> { "fermento", "ovo", "nescal" },
            Directions = "misture tudo e bate na batedeira",
            Rating = 1
         },

          new Recipe {
            Name = "coxinha",
            Ingredients = new List<string> { "fermento", "ovo", "mandioca" },
            Directions = "misture tudo e bate na batedeira, ponhe no forno deixe passar do até ficar preta",
            Rating = 1
         }
        }
    };
    }

    [Theory]
    [MemberData(nameof(RecipeServiceTestData))]
    public void TestReadAll(List<Recipe> expected)
    {
        var instance = new RecipesController(new RecipeService());
        var actionResult = instance.Get();
        var okResult = actionResult as OkObjectResult;
        var actualList = okResult.Value;
        actualList.Should().BeEquivalentTo(expected);
        instance._service.GetRecipes().Should().BeEquivalentTo(expected);
    }
}