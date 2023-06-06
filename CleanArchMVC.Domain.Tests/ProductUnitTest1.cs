using CleanArchMVC.Domain.Entites;
using FluentAssertions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        // Test to validate the creation of the class domain product
        // Teste para validar a criação da class de dominio produto

        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Test", "teste", 12, 12);
            action.Should().NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }


        // Test to validate the name field is null or empty
        // Tste para validar se o campo nome é nulo ou vazio

        [Fact]
        public void CreateProduct_ValadationFieldNameisEmptyOrNull_ResultObjectValidState()
        {
            Action action = () => new Product(1, "", "teste", 12, 12);
            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The Name field is required");
        }

        // Test to validate that the name field is less than three
        // Teste para validar se o campo nome é menor que três

        [Fact]
        public void CreateProduct_ValadationNameFieldIsLessThanThree_ResultObjectValidState()
        {
            Action action = () => new Product(1, "12", "teste", 12, 12);
            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The name field must be greater than 3 characters");
        }



        // Test to validate that the description field is less than five
        // Teste para validar se o campo descrição é menor que cinco

        [Fact]
        public void CreateProduct_ValadationDescriptionFieldIsLessThanFive_ResultObjectValidState()
        {
            Action action = () => new Product(1, "teste", "tes", 12, 12);
            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The description field must be greater than 5 characters");
        }


        // Test to validate if price field is negative
        // Teste para validar se o campo preço é negativo

        [Fact]
        public void CreateProduct_ValadationIfPriceIsNegative_ResultObjectValidState()
        {
            Action action = () => new Product(1, "teste", "teste", -1, 12);
            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The value of the product cannot be less than 0");
        }


    }
}