using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class ConsultationRequest
    {
        [Required(ErrorMessage = "Поле Ім'я прізвище обов'язкове")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле Email обов'язкове")]
        [EmailAddress(ErrorMessage = "Введіть коректний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Бажана дата консультації обов'язкове")]
        [FutureDate(ErrorMessage = "Виберіть дату в майбутньому")]
        [NotOnWeekend(ErrorMessage = "Консультація не може проходити вихідними")]
        [NotOnMonday("Основи", ErrorMessage = "Консультація не може проходити в понеділок для продукту 'Основи'")]
        public DateTime DesiredDate { get; set; }

        [Required(ErrorMessage = "Поле Продукт обов'язкове")]
        public string SelectedProduct { get; set; }
    }

    // Custom validation attributes
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date > DateTime.Now;
        }
    }

    public class NotOnWeekendAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NotOnMondayAttribute : ValidationAttribute
    {
        public string RestrictedProductType { get; }

        public NotOnMondayAttribute(string restrictedProductType)
        {
            RestrictedProductType = restrictedProductType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            var productTypeProperty = validationContext.ObjectType.GetProperty("SelectedProduct");

            if (productTypeProperty == null)
            {
                return new ValidationResult("Property 'SelectedProduct' not found");
            }

            var productTypeValue = productTypeProperty.GetValue(validationContext.ObjectInstance, null);

            if (productTypeValue != null && productTypeValue.ToString().Equals(RestrictedProductType, StringComparison.OrdinalIgnoreCase))
            {
                // Якщо це консультація для обмеженого продукту, перевірте, чи не понеділок
                if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            // Інакше дозвольте консультацію в будь-який день
            return ValidationResult.Success;
        }
    }
}
