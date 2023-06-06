using CleanArchMVC.Domain.Entites;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        // Test to validate the creation of the class domain category
        // Teste para validar a criação da class de dominio category

        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Test");
            action.Should().NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        // Test to validate if id is negativo
        // Teste para validar se id é negativo

        [Fact]
        public void CreateCategory_NegativeId_DomainExecptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Test");
            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The id not can be 0");
        }

        // Test to validate if field category is empty
        // Teste para validar se o campo categoria está vazio

        [Fact]
        public void CreateCategory_WithFieldEmpty_DomainExecptionInvalidId()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The Name field is required");
        }

        // Test to validate if Name of category is smaller that three
        // Teste para validar se o nome da categoria é menor que três

        [Fact]
        public void CreateCategory_NameCategorySmallerThatThree_DomainExecptionInvalidId()
        {
            Action action = () => new Category(1, "Te");
            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The name field must be greater than 3 characters");
        }

    }
}