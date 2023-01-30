using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Product
    {
        /* Data Annotation Attributes:
         * - Required
         * - MaxLength, MinLenght
         * - Range
         * - Phone
         * - CreditCard
         * - EmailAddres
         * - Url
         * - Compare
         * - RegularExpression
         */

        public int Id { get; set; }

        //[Required, MinLength(2)]
        public string Name { get; set; }

        //[Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0")]
        public decimal Price { get; set; }

        //[Url]
        public string? ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
