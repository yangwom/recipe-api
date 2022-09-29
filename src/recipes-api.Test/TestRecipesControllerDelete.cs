using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using recipes_api.Models;
using recipes_api.Services;
using recipes_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace recipes_api.Test;

public class TestRecipesControllerDelete
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
            Name = "bolo de laranja",
            Ingredients = new List<string> { "fermento", "ovo", "laranja" },
            Directions = "misture tudo e bate na batedeira",
            Rating = 1
         }
        }
    };
    }

    [Theory]
    [MemberData(nameof(RecipeServiceTestData))]
    public void TestDelete(string entryName, List<Recipe> expected)
    {
        RecipesController instance = new RecipesController(new RecipeService());        
        var actionResult = instance.Delete(entryName);
        var okResult = actionResult as NoContentResult;
        okResult.Should().BeAssignableTo<NoContentResult>();
        instance._service.GetRecipes().Should().BeEquivalentTo(expected);
    }
}