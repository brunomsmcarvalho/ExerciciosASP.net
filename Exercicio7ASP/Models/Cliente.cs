using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Exercicio7ASP.Models
{
    public class Cliente
    {
        //Não esquecer de adicionar using System.ComponentModel.DataAnnotations; para usar os atributos de validação
        //Não é necessário colocar [Table("Clientes")] porque o nome da classe é igual ao nome da tabela na BD
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório", AllowEmptyStrings = false)]  //sao considerados metadados
        [Display(Name = "Nome do Utilizador")] // altera o label na view
        public string Nome { get; set; }

        public string? Apelido { get; set; }// o ? indica que o campo é opcional (aceita null)

        [StringLength(10, MinimumLength = 4)] // limita o tamanho do campo max 10 min 4
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email obrigatório", AllowEmptyStrings = false)] //sao considerados metadados
        [StringLength(100, ErrorMessage = "Permitido máximo de 100 catacteres")] // limita o tamanho do campo
        [DataType(DataType.EmailAddress, ErrorMessage = "Email errado!")] // se o email é valido sintaticamente. existem APIs para validar emails que existam de verdade
        //[EmailAddress(ErrorMessage = "Email errado!")] // valida o formato do email
        public string Email { get; set; }

        public string? Mensagem { get; set; }
    }
}

// mudámos todo o modelo do cliente para poder criar um formulário automatico atraves do scaffolding no form3.cshtml
// que vai permitir criar, editar, listar e apagar clientes na base de dados.
// Para isso, precisamos de um contexto de dados que represente a base de dados e permita interagir com ela usando Entity Framework Core.
// Esse contexto de dados é geralmente uma classe que herda de DbContext e contém DbSet<T> para cada entidade que queremos mapear para uma tabela na base de dados.
// Depois de criar o contexto de dados, podemos usar o scaffolding para gerar automaticamente as views e controllers necessários para realizar operações CRUD (Create, Read, Update, Delete) no modelo Cliente.


